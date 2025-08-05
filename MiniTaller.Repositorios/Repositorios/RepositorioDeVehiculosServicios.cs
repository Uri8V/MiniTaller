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
    public class RepositorioDeVehiculosServicios : IRepositorioDeVehiculosServicios
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeVehiculosServicios()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(VehiculosServicios vehiculosServicios)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"INSERT INTO VehiculosServicios (IdVehiculo, IdCliente, Descripcion, Haber, Fecha, Kilometros) 
                                    Values (@IdVehiculo, @IdCliente, @Descripcion, @Haber, @Fecha,@Kilometros); SELECT SCOPE_IDENTITY();";
                int id = conn.ExecuteScalar<int>(selectQuery, vehiculosServicios);
                vehiculosServicios.IdVehiculoServicio = id;
            }
        }
        public void Borrar(int IdVehiculoServicio)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string deleteQuery = "DELETE FROM VehiculosServicios WHERE IdVehiculoServicio=@IdVehiculoServicio";
                conn.Execute(deleteQuery, new { IdVehiculoServicio = IdVehiculoServicio });
            }
        }
        public void Editar(VehiculosServicios vehiculosServicios)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string updateQuery = @"UPDATE VehiculosServicios SET IdVehiculo=@IdVehiculo, IdCliente=@IdCliente, Descripcion=@Descripcion,Haber=@Haber, Fecha=@Fecha, Kilometros=@Kilometros
                WHERE IdVehiculoServicio=@IdVehiculoServicio";
                conn.Execute(updateQuery, vehiculosServicios);
            }
        }
        public bool EstaRelacionado(VehiculosServicios vehiculosServicios)
        {
            int cantidadImagenes = 0;
            int cantidadDetalles = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM Imagenes WHERE IdVehiculoServicio=@IdVehiculoServicio
                                       SELECT COUNT(*) FROM DetallesVehiculosSErvicios WHERE IdVehiculoServicio=@IdVehiculoServicio";
                using (var resultado = conn.QueryMultiple(selectQuery, new { IdVehiculoServicio =vehiculosServicios.IdVehiculoServicio }))
                {
                    cantidadImagenes = resultado.Read<int>().First();
                    cantidadDetalles = resultado.Read<int>().First();
                }
            }
            return cantidadImagenes+cantidadDetalles > 0;
        }
        public bool Existe(VehiculosServicios vehiculosServicios)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (vehiculosServicios.IdVehiculoServicio == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios 
                            WHERE IdVehiculo=@IdVehiculo AND IdCliente=@IdCliente AND Fecha=@Fecha";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdVehiculo = vehiculosServicios.IdVehiculo,  IdCliente = vehiculosServicios.IdCliente, Fecha = vehiculosServicios.Fecha });
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios 
                WHERE IdVehiculo=@IdVehiculo AND IdCliente=@IdCliente AND Fecha=@Fecha AND   Haber=@Haber AND IdVehiculoServicio!=@IdVehiculoServicio";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdVehiculo = vehiculosServicios.IdVehiculo, IdCliente = vehiculosServicios.IdCliente, Fecha = vehiculosServicios.Fecha, Haber = vehiculosServicios.Haber, IdVehiculoServicio = vehiculosServicios.IdVehiculoServicio });
                }
            }
            return cantidad > 0;
        }
        public int GetCantidad(int? IdVehiculo, int? IdServicioTipoDePago, int? IdCliente, DateTime? FechaServicios, bool? Yapago)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (IdVehiculo == null && IdServicioTipoDePago == null && IdCliente == null && FechaServicios == null && Yapago == null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios vs
                                    INNER JOIN DetallesVehiculosServicios d ON d.IdVehiculoServicio=vs.IdVehiculoServicio
                                    WHERE d.Debe!=d.Pago";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else if (IdVehiculo != null && IdServicioTipoDePago == null && IdCliente == null && FechaServicios == null && Yapago == null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios vs
                        INNER JOIN DetallesVehiculosServicios d ON d.IdVehiculoServicio=vs.IdVehiculoServicio
                        WHERE (IdVehiculo=@IdVehiculo)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdVehiculo = IdVehiculo });
                }
                else if (IdVehiculo == null && IdServicioTipoDePago != null && IdCliente == null && FechaServicios == null && Yapago == null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios vs
                        INNER JOIN DetallesVehiculosServicios d ON d.IdVehiculoServicio=vs.IdVehiculoServicio
                        WHERE (d.IdServicioTipoDePago=@IdServicioTipoDePago)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdServicioTipoDePago = IdServicioTipoDePago });
                }
                else if (IdVehiculo == null && IdServicioTipoDePago == null && IdCliente != null && FechaServicios == null && Yapago == null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios vs
                        INNER JOIN DetallesVehiculosServicios d ON d.IdVehiculoServicio=vs.IdVehiculoServicio
                        WHERE (IdCliente=@IdCliente)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdCliente = IdCliente });
                }
                else if (IdVehiculo == null && IdServicioTipoDePago == null && IdCliente == null && FechaServicios != null && Yapago == null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios vs
                        INNER JOIN DetallesVehiculosServicios d ON d.IdVehiculoServicio=vs.IdVehiculoServicio
                        WHERE (Fecha=CONVERT(DATE,@FechaServicios))";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { FechaServicios = FechaServicios });
                }
                else if (IdVehiculo == null && IdServicioTipoDePago == null && IdCliente == null && FechaServicios == null && Yapago != null)
                {
                    selectQuery =  @"SELECT COUNT(*) FROM VehiculosServicios vs
                                    INNER JOIN DetallesVehiculosServicios d ON d.IdVehiculoServicio=vs.IdVehiculoServicio
                                    WHERE d.Debe=d.Pago"; 
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
            }
            return cantidad;

        }
        public VehiculoServicioComboDto GetServiciosCombo(int IdVehiculoServicio)
        {
            VehiculoServicioComboDto vehiculoServicio = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                var selectQuery = @"SELECT vs.IdVehiculoServicio,
                CONCAT(vs.Fecha,' | ',v.Patente,' | ',UPPER(c.Apellido),', ', UPPER(c.Nombre), ' (', c.Documento, c.CUIT, ')') AS Info
                FROM VehiculosServicios vs
                INNER JOIN Vehiculos v ON vs.IdVehiculo = v.IdVehiculo
                INNER JOIN Clientes c ON c.IdCliente = vs.IdCliente
                WHERE vs.IdVehiculoServicio=@IdVehiculoServicio";
                vehiculoServicio = conn.QuerySingleOrDefault<VehiculoServicioComboDto>(selectQuery,
                    new { IdVehiculoServicio = IdVehiculoServicio });
            }
            return vehiculoServicio;
        }
        public List<VehiculosServiciosDto> GetVehiculoServicioPorCliente(string CUITDocumento)
        {
            List<VehiculosServiciosDto> lista = new List<VehiculosServiciosDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT vs.IdVehiculoServicio, v.Patente, s.Servicio, c.Apellido, c.Nombre,c.Documento,c.CUIT,vs.Descripcion,d.Debe,d.Pago as Haber,vs.Fecha, vs.Kilometros,d.FechaPago
                FROM VehiculosServicios vs
                INNER JOIN DetallesVehiculosServicios d ON d.IdVehiculoServicio=vs.IdVehiculoServicio
                INNER JOIN Vehiculos v ON v.IdVehiculo=vs.IdVehiculo 
                INNER JOIN ServiciosTiposDePago st ON d.IdServicioTipoDePago=st.IdServicioTipoDePago
                INNER JOIN Servicios s ON s.IdServicio=st.IdServicio
                INNER JOIN Clientes c ON vs.IdCliente=c.IdCliente
                WHERE c.Documento=@CUITDocumento OR c.CUIT=@CUITDocumento";
                var parametros = new { CUITDocumento };
                lista = conn.Query<VehiculosServiciosDto>(selectQuery, parametros).ToList();
            }
            return lista;
        }
        public VehiculosServicios GetVehiculoServicioPorId(int IdVehiculoServicio)
        {
            VehiculosServicios vehiculosServicios = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT vs.IdVehiculoServicio,vs.IdVehiculo,vs.IdCliente,vs.Descripcion, vs.Haber, vs.Fecha, vs.Kilometros
                    FROM VehiculosServicios vs
                    WHERE vs.IdVehiculoServicio=@IdVehiculoServicios";
                vehiculosServicios = conn.QuerySingleOrDefault<VehiculosServicios>(selectQuery,
                    new { IdVehiculoServicios = IdVehiculoServicio });
            }
            return vehiculosServicios;
        }
        public List<VehiculosServicios> GetVehiculosServiciosPorIdClienteIdVehiculoYFecha(int IdVehiculo,int IdCliente, DateTime Fecha)
        {
            List<VehiculosServicios> lista = new List<VehiculosServicios>();
            using (var conn= new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT vs.IdVehiculoServicio,vs.IdVehiculo,vs.IdServicioTipoDePago,vs.IdCliente,vs.Descripcion, vs.Debe, vs.Haber, vs.Fecha, vs.Kilometros
                    FROM VehiculosServicios vs WHERE vs.IdVehiculo = @IdVehiculo AND vs.Fecha=CONVERT(DATE,@Fecha) AND vs.IdCliente=@IdCliente and vs.Haber!=vs.Debe";
                var parametros = new { IdVehiculo = IdVehiculo, IdCliente = IdCliente, Fecha = Fecha };
                lista = conn.Query<VehiculosServicios>(selectQuery.ToString(),parametros).ToList();
            }
            return lista;
        }
        public List<VehiculosServiciosDto> GetVehiculoServicioPorPagina(int registrosPorPagina, int paginaActual, int? IdVehiculo, int? IdServicioTipoDePago, int? IdCliente, DateTime? FechaServicios, bool? Yapago)
        {

            List<VehiculosServiciosDto> lista = new List<VehiculosServiciosDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT vs.IdVehiculoServicio, v.Patente, vs.Kilometros, s.Servicio, c.Apellido, c.Nombre,c.Documento,c.CUIT,vs.Descripcion,d.Debe,d.Pago as Haber,vs.Fecha, d.FechaPago");
                selectQuery.AppendLine("FROM VehiculosServicios vs");
                selectQuery.AppendLine("INNER JOIN DetallesVehiculosServicios d ON d.IdVehiculoServicio=vs.IdVehiculoServicio");
                selectQuery.AppendLine("INNER JOIN Vehiculos v ON v.IdVehiculo=vs.IdVehiculo");
                selectQuery.AppendLine("INNER JOIN ServiciosTiposDePago st ON st.IdServicioTipoDePago=d.IdServicioTipoDePago");
                selectQuery.AppendLine("INNER JOIN Clientes c ON c.IdCliente=vs.IdCliente");
                selectQuery.AppendLine("INNER JOIN Servicios s ON st.IdServicio=s.IdServicio");

                if (IdVehiculo != null || IdServicioTipoDePago != null || IdCliente != null || FechaServicios != null)
                {
                    selectQuery.AppendLine("WHERE vs.IdVehiculo = @IdVehiculo OR d.IdServicioTipoDePago=@IdServicioTipoDePago OR vs.Fecha=CONVERT(DATE,@FechaServicios) OR vs.IdCliente=@IdCliente");
                }
                else if (Yapago != null)
                {
                    selectQuery.AppendLine("WHERE d.Debe=d.Pago");
                }
                else
                {
                    selectQuery.AppendLine("WHERE d.Debe!=d.Pago");
                }

                selectQuery.AppendLine("ORDER BY vs.Fecha,s.Servicio");
                selectQuery.AppendLine("OFFSET @registrosSaltados ROWS FETCH NEXT @registrosPorPagina ROWS ONLY");

                var parametros = new { IdVehiculo, IdServicioTipoDePago, IdCliente, FechaServicios, registrosSaltados = registrosPorPagina * (paginaActual - 1), registrosPorPagina };

                lista = conn.Query<VehiculosServiciosDto>(selectQuery.ToString(), parametros).ToList();

            }
            return lista;
        }
        public bool ExistenImagenesParaVehiculoServicio(int IdVehiculoServicio)
        {
            int cantidadImagenes = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM Imagenes WHERE IdVehiculoServicio=@IdVehiculoServicio";
                cantidadImagenes = conn.ExecuteScalar<int>(selectQuery, new { IdVehiculoServicio = IdVehiculoServicio });
            }
            return cantidadImagenes > 0;
        }
        public void ActualizarHaberTotal(int idVehiculoServicio)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string query = @"SELECT SUM(Pago) FROM DetallesVehiculosServicios WHERE IdVehiculoServicio = @IdVehiculoServicio";
                decimal nuevoHaber = conn.ExecuteScalar<decimal>(query, new { IdVehiculoServicio = idVehiculoServicio });

                string update = @"UPDATE VehiculosServicios SET Haber = @Haber WHERE IdVehiculoServicio = @IdVehiculoServicio";
                conn.Execute(update, new { Haber = nuevoHaber, IdVehiculoServicio = idVehiculoServicio });
            }
        }
    }
}
