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
    public class RepositorioDeServiciosTiposDePago : IRepositorioDeServiciosTiposDePago
    {   
        private readonly string cadenaDeConexion;
        public RepositorioDeServiciosTiposDePago()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(ServicioTipoDePago servicioTipoDePago)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    string selectQuery = @"INSERT INTO ServiciosTiposDePago (IdTipoPago,IdServicio) 
                                    Values (@IdTipoPago,@IdServicio); SELECT SCOPE_IDENTITY();";
                    int id = conn.ExecuteScalar<int>(selectQuery, servicioTipoDePago);
                    servicioTipoDePago.IdServicioTipoDePago = id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("OH NO, debe haber un error en el mètodo Agregar del repositorio",ex);
            }
        }

        public void Borrar(int IdServicioTipoDePago)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    string deleteQuery = "DELETE FROM ServiciosTiposDePago WHERE IdServicioTipoDePago=@IdServicioTipoDePago";
                    conn.Execute(deleteQuery, new { IdServicioTipoDePago = IdServicioTipoDePago });
                }
            }
            catch (Exception ex )
            {
                throw new Exception("OH NO, debe haber un error en el mètodo Borrar del repositorio", ex);
            }
        }

        public void Editar(ServicioTipoDePago servicioTipoDePago)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    string updateQuery = @"UPDATE ServiciosTiposDePago SET IdTipoPago=@IdTipoPago,IdServicio=@IdServicio
                WHERE IdServicioTipoDePago=@IdServicioTipoDePago";
                    conn.Execute(updateQuery, servicioTipoDePago);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("OH NO, debe haber un error en el mètodo Editar del repositorio", ex);
            }

        }

        public bool EstaRelacionado(ServicioTipoDePago servicioTipoDePago)
        {
            try
            {
                int cantidad = 0;
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    string selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios WHERE IdServicioTipoDePago=@IdServicioTipoDePago";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdServicioTipoDePago = servicioTipoDePago.IdServicioTipoDePago });
                }
                return cantidad > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("OH NO, debe haber un error en el mètodo EstaRelacionado del repositorio", ex);
            }
        }

        public bool Existe(ServicioTipoDePago servicioTipoDePago)
        {
            try
            {
                var cantidad = 0;
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    string selectQuery;
                    if (servicioTipoDePago.IdServicioTipoDePago == 0)
                    {
                        selectQuery = @"SELECT COUNT(*) FROM ServiciosTiposDePago 
                            WHERE IdTipoPago=@IdTipoPago AND IdServicio=@IdServicio";
                        cantidad = conn.ExecuteScalar<int>(
                            selectQuery, new { IdTipoPago = servicioTipoDePago.IdTipoPago, IdServicio = servicioTipoDePago.IdServicio});
                    }
                    else
                    {
                        selectQuery = @"SELECT COUNT(*) FROM ServiciosTiposDePago 
                            WHERE IdTipoPago=@IdTipoPago AND IdServicio=@IdServicio AND IdServicioTipoDePago!=@IdServicioTipoDePago";
                        cantidad = conn.ExecuteScalar<int>(
                            selectQuery, new { IdTipoPago = servicioTipoDePago.IdTipoPago, IdServicio = servicioTipoDePago.IdServicio, IdServicioTipoDePago = servicioTipoDePago.IdServicioTipoDePago });
                    }
                }
                return cantidad > 0;

            }
            catch (Exception ex)
            {
                throw new Exception("OH NO, debe haber un error en el mètodo Existe del repositorio", ex);
            }
        }

        public int GetCantidad(int? IdTipoPago, int? IdServicio)
        {
            try
            {
                int cantidad = 0;
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    string selectQuery;
                    if (IdTipoPago == null && IdServicio == null)
                    {
                        selectQuery = "SELECT COUNT(*) FROM ServiciosTiposDePago";
                        cantidad = conn.ExecuteScalar<int>(selectQuery);
                    }
                    else if (IdTipoPago != null && IdServicio == null)
                    {
                        selectQuery = @"SELECT COUNT(*) FROM ServiciosTiposDePago 
                        WHERE (IdTipoPago=@IdTipoPago)";
                        cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdTipoPago = IdTipoPago });
                    }
                    else if (IdTipoPago == null && IdServicio != null)
                    {
                        selectQuery = @"SELECT COUNT(*) FROM ServiciosTiposDePago 
                        WHERE (IdServicio=@IdServicio)";
                        cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdServicio = IdServicio });
                    }
                }
                return cantidad;


            }
            catch (Exception ex)
            {
                throw new Exception("OH NO, debe haber un error en el mètodo GetCantidad del repositorio", ex);
            }
        }

        public List<ServicioTipoDePagoComboDto> GetServiciosTiposDePagoCombo()
        {
            try
            {
                List<ServicioTipoDePagoComboDto> lista= new List<ServicioTipoDePagoComboDto>();
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    string selectQuery = @"SELECT st.IdServicioTipoDePago,CONCAT('Servicio: ',s.Servicio,' | ', tp.Tipo) AS Info 
                                       FROM ServiciosTiposDePago st
                                       INNER JOIN TiposDePagos tp ON st.IdTipoPago=tp.IdTipoPago
                                       INNER JOIN Servicios s ON s.IdServicio=st.IdServicio
                                       ORDER BY s.Servicio";
                    lista = conn.Query<ServicioTipoDePagoComboDto>(selectQuery).ToList();

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("OH NO, debe haber un error en el mètodo GetServiciosTiposDePagoCombo del repositorio", ex);
            }
        }

        public ServicioTipoDePago GetServicioTipoDePagoPorId(int IdServicioTipoDePago)
        {
            try
            {
                ServicioTipoDePago servicioTipoDePago = null;
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    string selectQuery = @"SELECT st.IdServicioTipoDePago,st.IdServicio,st.IdTipoPago
                    FROM ServiciosTiposDePago st 
                    WHERE st.IdServicioTipoDePago=@IdServicioTipoDePago";
                    servicioTipoDePago = conn.QuerySingleOrDefault<ServicioTipoDePago>(selectQuery,
                        new { IdServicioTipoDePago = IdServicioTipoDePago });
                }
                return servicioTipoDePago;
            }
            catch (Exception ex)
            {
                throw new Exception("OH NO, debe haber un error en el mètodo GetServicioTipoDePagoPorId del repositorio", ex);
            }
        }

        public List<ServicioTipoDePagoDto> GetServiciosTiposDePagoPorPagina(int registrosPorPagina, int paginaActual, int? IdTipoPago, int? IdServicio)
        {
            try
            {
                List<ServicioTipoDePagoDto> lista = new List<ServicioTipoDePagoDto>();
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    StringBuilder selectQuery = new StringBuilder();
                    selectQuery.AppendLine("SELECT st.IdServicioTipoDePago,s.Servicio,tp.Tipo");
                    selectQuery.AppendLine("FROM ServiciosTiposDePago st");
                    selectQuery.AppendLine("INNER JOIN TiposDePagos tp ON tp.IdTipoPago=st.IdTipoPago");
                    selectQuery.AppendLine("INNER JOIN Servicios s ON s.IdServicio=st.IdServicio");

                    if (IdTipoPago != null || IdServicio != null)
                    {
                        selectQuery.AppendLine("WHERE st.IdTipoPago = @IdTipoPago OR st.IdServicio=@IdServicio");
                    }

                    selectQuery.AppendLine("ORDER BY s.Servicio");
                    selectQuery.AppendLine("OFFSET @registrosSaltados ROWS FETCH NEXT @registrosPorPagina ROWS ONLY");

                    var parametros = new { IdTipoPago, IdServicio, registrosSaltados = registrosPorPagina * (paginaActual - 1), registrosPorPagina };

                    lista = conn.Query<ServicioTipoDePagoDto>(selectQuery.ToString(), parametros).ToList();

                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("OH NO, debe haber un error en el mètodo GetServiciosTiposDePagoPorPagina del repositorio", ex);
            }
        }

        public List<ServicioTipoDePagoDto> GetServiciosTiposDePagoPorPagina()
        {
            List<ServicioTipoDePagoDto> lista = new List<ServicioTipoDePagoDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT st.IdServicioTipoDePago,s.Servicio,tp.Tipo");
                selectQuery.AppendLine("FROM ServiciosTiposDePago st");
                selectQuery.AppendLine("INNER JOIN TiposDePagos tp ON tp.IdTipoPago=st.IdTipoPago");
                selectQuery.AppendLine("INNER JOIN Servicios s ON s.IdServicio=st.IdServicio");
                selectQuery.AppendLine("ORDER BY s.Servicio");
                lista = conn.Query<ServicioTipoDePagoDto>(selectQuery.ToString()).ToList();
            }
            return lista;
        }
    }
}
