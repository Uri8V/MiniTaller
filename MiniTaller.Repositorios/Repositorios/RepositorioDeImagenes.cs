using Dapper;
using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MiniTaller.Repositorios.Repositorios
{
    public class RepositorioDeImagenes:IRepositorioDeImagenes
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeImagenes()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Imagenes imagenes)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"INSERT INTO Imagenes (IdObservacion, IdVehiculoServicio,imageURL) 
                                    Values (@IdObservacion, @IdVehiculoServicio, @imageURL); SELECT SCOPE_IDENTITY();";
                int id = conn.ExecuteScalar<int>(selectQuery, imagenes);
                imagenes.IdImage = id;
            }
        }

        public void Borrar(int IdImage)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string deleteQuery = "DELETE FROM Imagenes WHERE IdImage=@IdImage";
                conn.Execute(deleteQuery, new { IdImage = IdImage });
            }
        }

        public void Editar(Imagenes imagenes)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string updateQuery = @"UPDATE Imagenes SET IdObservacion=@IdObservacion, IdVehiculoServicio=@IdVehiculoServicio, imageURL=@imageURL
                WHERE IdImage=@IdImage";
                conn.Execute(updateQuery, imagenes);
            }
        }

        public bool Existe(Imagenes imagenes)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (imagenes.IdImage == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Imagenes 
                            WHERE (IdObservacion=@IdObservacion and imageURL=@imageURL) or (IdVehiculoServicio=@IdVehiculoServicio and imageURL=@imageURL)";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdObservacion = imagenes.IdObservacion, imageURL=imagenes.imageURL, IdVehiculoServicio=imagenes.IdVehiculoServicio });
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Imagenes 
                            WHERE (IdObservacion=@IdObservacion and imageURL=@imageURL and IdImage!=@IdImage) or (IdVehiculoServicio=@IdVehiculoServicio and imageURL=@imageURL and IdImage!=@IdImage)";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdImage=imagenes.IdImage, IdObservacion = imagenes.IdObservacion, imageURL = imagenes.imageURL, IdVehiculoServicio = imagenes.IdVehiculoServicio });
                }
            }
            return cantidad > 0;
        }

        public Imagenes GetImagenPorId(int IdImage)
        {
            Imagenes imagen = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT IdImage, IdObservacion, IdVehiculoServicio,imageURL 
                    FROM Imagenes WHERE IdImage=@IdImage";
                imagen = conn.QuerySingleOrDefault<Imagenes>(selectQuery,
                    new { IdImage = IdImage });
            }
            return imagen;
        }

        public List<ImagenesDto> GetImagenesPorPagina(int registrosPorPagina, int paginaActual, int? IdObservacion, int? IdVehiculoServicio)
        {
            List<ImagenesDto> lista = new List<ImagenesDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT");
                selectQuery.AppendLine("i.IdImage,");
                selectQuery.AppendLine("COALESCE(v.Patente, v2.Patente) AS Patente,");
                selectQuery.AppendLine("i.imageURL,");
                selectQuery.AppendLine("CONCAT(UPPER(COALESCE(c.Nombre, c2.Nombre)), ' ',");
                selectQuery.AppendLine("UPPER(COALESCE(c.Apellido, c2.Apellido)), ' (',");
                selectQuery.AppendLine("COALESCE(c.Documento, c2.Documento), ', ',");
                selectQuery.AppendLine("COALESCE(c.Documento, c2.Documento), ')') AS Info");
                selectQuery.AppendLine("FROM Imagenes i");
                selectQuery.AppendLine("LEFT JOIN Observaciones o ON o.IdObservacion = i.IdObservacion");
                selectQuery.AppendLine("LEFT JOIN VehiculosServicios vs ON vs.IdVehiculoServicio = i.IdVehiculoServicio");

                // Obtener vehículo desde Observaciones
                selectQuery.AppendLine("LEFT JOIN Vehiculos v ON v.IdVehiculo = o.IdVehiculo");
                // Obtener vehículo desde VehiculosServicios
                selectQuery.AppendLine("LEFT JOIN Vehiculos v2 ON v2.IdVehiculo = vs.IdVehiculo");

                //Obtener cliente desde Observaciones
                selectQuery.AppendLine("LEFT JOIN Clientes c ON c.IdCliente = o.IdCliente");
                // Obtener cliente desde VehiculosServicios
                selectQuery.AppendLine("LEFT JOIN Clientes c2 ON c2.IdCliente = vs.IdCliente");
                if (IdObservacion != null || IdVehiculoServicio != null)
                {
                    selectQuery.AppendLine("WHERE  o.IdObservacion= @IdObservacion OR vs.IdVehiculoServicio = @IdVehiculoServicio ");
                }
                selectQuery.AppendLine("ORDER BY v.Patente");
                selectQuery.AppendLine("OFFSET @cantidadRegistros ROWS FETCH NEXT @CantidadPorPagina ROWS ONLY");

                var parametros = new
                {
                    IdObservacion,
                    IdVehiculoServicio,
                    cantidadRegistros = registrosPorPagina * (paginaActual - 1),
                    cantidadPorPagina = registrosPorPagina
                };
                lista = conn.Query<ImagenesDto>(selectQuery.ToString(), parametros).ToList();
            }
            return lista;
        }

        public int GetCantidad(int? IdObservacion, int? IdVehiculoServico)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (IdObservacion == null && IdVehiculoServico == null )
                {
                    selectQuery = "SELECT COUNT(*) FROM Imagenes";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else if (IdObservacion != null && IdVehiculoServico == null) 
                {
                    selectQuery = @"SELECT COUNT(*) FROM Imagenes 
                        WHERE (IdObservacion=@IdObservacion)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdObservacion = IdObservacion });
                }
                else if (IdObservacion == null && IdVehiculoServico != null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Observaciones 
                        WHERE (IdVehiculoServicio=@IdVehiculoServicio)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdVehiculoServicio = IdVehiculoServico });
                }
            }
            return cantidad;
        }
    }
}
