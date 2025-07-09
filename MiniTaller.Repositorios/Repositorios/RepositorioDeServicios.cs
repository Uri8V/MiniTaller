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
    public class RepositorioDeServicios:IRepositorioDeServicios
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeServicios()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Servicioss servicios)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"INSERT INTO Servicios (Servicio) 
                                    Values (@Servicio); SELECT SCOPE_IDENTITY();";
                int id = conn.ExecuteScalar<int>(selectQuery, servicios);
                servicios.IdServicio = id;
            }
        }

        public void Borrar(int IdServicio)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string deleteQuery = "DELETE FROM Servicios WHERE IdServicio=@IdServicio";
                conn.Execute(deleteQuery, new { IdServicio = IdServicio });
            }
        }

        public void Editar(Servicioss servicios)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string updateQuery = @"UPDATE Servicios SET Servicio=@Servicio
                WHERE IdServicio=@IdServicio";
                conn.Execute(updateQuery, servicios);
            }
        }

        public bool EstaRelacionada(Servicioss servicios)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {

                string selectQuery = @"SELECT COUNT(*) FROM ServiciosTiposDePago WHERE IdServicio=@IdServicio";
                cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdServicio = servicios.IdServicio });
            }
            return cantidad > 0;
        }

        public bool Existe(Servicioss servicios)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (servicios.IdServicio == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Servicios 
                            WHERE Servicio=@Servicio";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Servicio = servicios.Servicio});
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Servicios 
                WHERE Servicio=@Servicio AND IdServicio!=@IdServicio";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Servicio = servicios.Servicio, IdServicio = servicios.IdServicio });
                }
            }
            return cantidad > 0;
        }

        public int GetCantidad()
        {

            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Servicios";
                cantidad = conn.ExecuteScalar<int>(selectQuery);
            }
            return cantidad;
        }

        public List<Servicioss> GetServiciosCombos()
        {
            List<Servicioss> lista;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT s.IdServicio,s.Servicio
                                       FROM Servicios s
                                       ORDER BY s.Servicio";
                lista = conn.Query<Servicioss>(selectQuery).ToList();
            }
            return lista;
        }

        public Servicioss GetServiciosPorId(int IdServicio)
        {
            Servicioss servicios = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT s.IdServicio,s.Servicio
                    FROM Servicios s WHERE s.IdServicio=@IdServicio";
                servicios = conn.QuerySingleOrDefault<Servicioss>(selectQuery,
                    new { IdServicio = IdServicio });
            }
            return servicios;
        }

        public List<Servicioss> GetServiciosPorPagina(int registrosPorPagina, int paginaActual)
        {
            List<Servicioss> lista = new List<Servicioss>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT s.IdServicio,s.Servicio");
                selectQuery.AppendLine("FROM Servicios s");
                selectQuery.AppendLine("ORDER BY s.Servicio");
                selectQuery.AppendLine("OFFSET @registrosSaltados ROWS FETCH NEXT @registrosPorPagina ROWS ONLY");

                var parametros = new {registrosSaltados = registrosPorPagina * (paginaActual - 1), registrosPorPagina };

                lista = conn.Query<Servicioss>(selectQuery.ToString(), parametros).ToList();
                return lista;
            }

        }
    }
}
