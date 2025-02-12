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
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Repositorios.Repositorios
{
    public class RepositorioDeTelefonos : IRepositorioDeTelefonos
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeTelefonos()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Telefonos telefono)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"INSERT INTO Telefonos (IdCliente, Telefono, TipoTelefono) 
                                    Values (@IdCliente, @Telefono, @TipoTelefono); SELECT SCOPE_IDENTITY();";
                int id = conn.ExecuteScalar<int>(selectQuery, telefono);
                telefono.IdTelefono = id;
            }
        }

        public void Borrar(int IdTelefono)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string deleteQuery = "DELETE FROM Telefonos WHERE IdTelefono=@IdTelefono";
                conn.Execute(deleteQuery, new { IdTelefono = IdTelefono });
            }
        }

        public void Editar(Telefonos telefono)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string updateQuery = @"UPDATE Telefonos SET IdCliente=@IdCliente, Telefono=@Telefono, TipoTelefono=@TipoTelefono 
                WHERE IdTelefono=@IdTelefono";
                conn.Execute(updateQuery, telefono);
            }
        }

        public bool Existe(Telefonos telefono)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (telefono.IdTelefono == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Telefonos 
                            WHERE Telefono=@Telefono AND TipoTelefono=@TipoTelefono AND IdCliente=@IdCliente";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Telefono = telefono.Telefono, TipoTelefono = telefono.TipoTelefono, IdCliente = telefono.IdCliente });

                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Telefonos 
                            WHERE Telefono=@Telefono AND TipoTelefono=@TipoTelefono AND IdCliente=@IdCliente AND IdTelefono!=@IdTelefono";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Telefono = telefono.Telefono, TipoTelefono = telefono.TipoTelefono, IdCliente = telefono.IdCliente, IdTelefono = telefono.IdTelefono });
                }
            }
            return cantidad > 0;
        }

        public int GetCantidad(int? IdCliente, string texto = null)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (IdCliente == null && texto == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Telefonos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else if  (texto == null && IdCliente!=null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Telefonos 
                        WHERE IdCliente=@IdCliente";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdCliente = IdCliente });
                }
                else if(IdCliente==null&& texto!=null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Telefonos WHERE TipoTelefono LIKE @texto ";
                    texto = $"%{texto}%";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { texto });
                }
            }
            return cantidad;

        }

        public Telefonos GetTelefonoPorId(int IdTelefono)
        {
            Telefonos telefonos = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT IdTelefono, IdCliente, Telefono, TipoTelefono 
                    FROM Telefonos WHERE IdTelefono=@IdTelefono";
                telefonos = conn.QuerySingleOrDefault<Telefonos>(selectQuery,
                    new { IdTelefono = IdTelefono });
            }
            return telefonos;
        }

        public List<TelefonosDto> GetTelefonosPorPagina(int registrosPorPagina, int paginaActual, int? IdCliente, string texto = null)
        {
            List<TelefonosDto> lista = new List<TelefonosDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT t.IdTelefono, c.CUIT, c.Documento, c.Nombre, c.Apellido, t.Telefono, t.TipoTelefono");
                selectQuery.AppendLine("FROM Telefonos t");
                selectQuery.AppendLine("INNER JOIN Clientes c ON c.IdCliente = t.IdCliente");

                if (IdCliente != null  || texto != null)
                {
                    selectQuery.AppendLine("WHERE c.IdCLiente = @clienteid OR t.TipoTelefono LIKE @texto ");
                }
                selectQuery.AppendLine("ORDER BY c.Apellido");
                selectQuery.AppendLine("OFFSET @cantidadRegistros ROWS FETCH NEXT @CantidadPorPagina ROWS ONLY");

                texto = $"%{texto}%";
                var parametros = new
                {
                    texto,
                    IdCliente,
                    cantidadRegistros = registrosPorPagina * (paginaActual - 1),
                    cantidadPorPagina = registrosPorPagina
                };

                lista = conn.Query<TelefonosDto>(selectQuery.ToString(), parametros).ToList();
            }
            return lista;
        }
    }
}
