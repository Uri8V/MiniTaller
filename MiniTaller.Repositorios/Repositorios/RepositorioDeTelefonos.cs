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
                string selectQuery = @"INSERT INTO Telefonos (IdCliente, Telefono, IdTipoDeTelefono) 
                                    Values (@IdCliente, @Telefono, @IdTipoDeTelefono); SELECT SCOPE_IDENTITY();";
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
                string updateQuery = @"UPDATE Telefonos SET IdCliente=@IdCliente, Telefono=@Telefono, IdTipoDeTelefono=@IdTipoDeTelefono 
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
                            WHERE Telefono=@Telefono AND IdTipoDeTelefono=@IdTipoDeTelefono AND IdCliente=@IdCliente";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Telefono = telefono.Telefono, IdTipoDeTelefono = telefono.IdTipoDeTelefono, IdCliente = telefono.IdCliente });

                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Telefonos 
                            WHERE Telefono=@Telefono AND IdTipoDeTelefono=@IdTipoDeTelefono AND IdCliente=@IdCliente AND IdTelefono!=@IdTelefono";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Telefono = telefono.Telefono, IdTipoDeTelefono = telefono.IdTipoDeTelefono, IdCliente = telefono.IdCliente, IdTelefono = telefono.IdTelefono });
                }
            }
            return cantidad > 0;
        }

        public int GetCantidad(int? IdCliente, int? IdTipoDeTelefono)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (IdCliente == null && IdTipoDeTelefono == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Telefonos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else if  (IdTipoDeTelefono == null && IdCliente!=null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Telefonos 
                        WHERE IdCliente=@IdCliente";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdCliente = IdCliente });
                }
                else if(IdCliente==null && IdTipoDeTelefono != null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Telefonos WHERE IdTipoDeTelefono=@IdTipoDeTelefono ";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdTipoDeTelefono= IdTipoDeTelefono });
                }
            }
            return cantidad;

        }

        public Telefonos GetTelefonoPorId(int IdTelefono)
        {
            Telefonos telefonos = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT IdTelefono, IdCliente, Telefono, IdTipoDeTelefono 
                    FROM Telefonos WHERE IdTelefono=@IdTelefono";
                telefonos = conn.QuerySingleOrDefault<Telefonos>(selectQuery,
                    new { IdTelefono = IdTelefono });
            }
            return telefonos;
        }

        public List<TelefonosDto> GetTelefonosPorPagina(int registrosPorPagina, int paginaActual, int? IdCliente, int? IdTipoDeTelefono)
        {
            List<TelefonosDto> lista = new List<TelefonosDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT t.IdTelefono, c.CUIT, c.Documento, c.Nombre, c.Apellido, t.Telefono, tt.Tipo");
                selectQuery.AppendLine("FROM Telefonos t");
                selectQuery.AppendLine("INNER JOIN Clientes c ON c.IdCliente = t.IdCliente");
                selectQuery.AppendLine("INNER JOIN TiposDeTelefono tt ON t.IdTipoDeTelefono=tt.IdTipoDeTelefono");

                if (IdCliente != null  || IdTipoDeTelefono != null)
                {
                    selectQuery.AppendLine("WHERE c.IdCLiente = @IdCliente OR tt.IdTipoDeTelefono=@IdTipoDeTelefono ");
                }
                selectQuery.AppendLine("ORDER BY c.Apellido");
                selectQuery.AppendLine("OFFSET @cantidadRegistros ROWS FETCH NEXT @CantidadPorPagina ROWS ONLY");

                var parametros = new
                {
                    IdTipoDeTelefono,
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
