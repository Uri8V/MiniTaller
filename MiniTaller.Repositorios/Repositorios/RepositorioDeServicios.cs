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
                string selectQuery = @"INSERT INTO Servicios (Servicio, Debe, IdTipoPago) 
                                    Values (@Servicio, @Debe, @IdTipoPago); SELECT SCOPE_IDENTITY();";
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
                string updateQuery = @"UPDATE Servicios SET Servicio=@Servicio, Debe=@Debe, IdTipoPago=@IdTipoPago
                WHERE IdServicio=@IdServicio";
                conn.Execute(updateQuery, servicios);
            }
        }

        public bool EstaRelacionada(Servicioss servicios)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {

                string selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios WHERE IdServicio=@IdServicio";
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
                            WHERE Servicio=@Servicio AND IdTipoPago=@IdTipoPago";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Servicio = servicios.Servicio, IdTipoPago = servicios.IdTipoPago });
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Servicios 
                WHERE Servicio=@Servicio AND IdTipoPago=@IdTipoPago AND IdServicio!=@IdServicio";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Servicio = servicios.Servicio, IdTipoPago = servicios.IdTipoPago, IdServicio = servicios.IdServicio });
                }
            }
            return cantidad > 0;
        }

        public int GetCantidad(int? IdTipoPago)
        {

            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (IdTipoPago == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Servicios";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Servicios 
                        WHERE (IdTipopago=@IdTipoPago)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdTipoPago = IdTipoPago });
                }
            }
            return cantidad;
        }

        public List<ServiciosComboDto> GetServiciosCombos()
        {
            List<ServiciosComboDto> lista;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT s.IdServicio, CONCAT(s.Servicio,' | ', s.Debe, '$',' | ', t.Tipo ) AS Info
                                       FROM Servicios s
                                       INNER JOIN TiposDePagos t ON s.IdTipoPago=t.IdTipoPago
                                       ORDER BY s.Servicio";
                lista = conn.Query<ServiciosComboDto>(selectQuery).ToList();
            }
            return lista;
        }

        public Servicioss GetServiciosPorId(int IdServicio)
        {
            Servicioss servicios = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT s.IdServicio,s.Servicio,s.Debe,s.IdTipoPago
                    FROM Servicios s WHERE s.IdServicio=@IdServicio";
                servicios = conn.QuerySingleOrDefault<Servicioss>(selectQuery,
                    new { IdServicio = IdServicio });
            }
            return servicios;
        }

        public List<ServiciosDto> GetServiciosPorPagina(int registrosPorPagina, int paginaActual, int? IdTipoPago)
        {
            List<ServiciosDto> lista = new List<ServiciosDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT s.IdServicio,s.Servicio,s.Debe, t.Tipo");

                selectQuery.AppendLine("FROM Servicios s");
                selectQuery.AppendLine("INNER JOIN TiposDePagos t ON t.IdTipoPago=s.IdTipoPago");

                if (IdTipoPago != null)
                {
                    selectQuery.AppendLine("WHERE t.IdTipoPago = @IdTipoPago");
                }

                selectQuery.AppendLine("ORDER BY s.Servicio,t.Tipo");
                selectQuery.AppendLine("OFFSET @registrosSaltados ROWS FETCH NEXT @registrosPorPagina ROWS ONLY");

                var parametros = new { IdTipoPago, registrosSaltados = registrosPorPagina * (paginaActual - 1), registrosPorPagina };

                lista = conn.Query<ServiciosDto>(selectQuery.ToString(), parametros).ToList();
                return lista;
            }

        }
    }
}
