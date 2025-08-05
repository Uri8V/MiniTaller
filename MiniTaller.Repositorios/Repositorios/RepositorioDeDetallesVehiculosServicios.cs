using Dapper;
using MiniTaller.Comun.Interfaces;
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
    public class RepositorioDeDetallesVehiculosServicios : IRepositorioDeDetallesVehiculosServicios
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeDetallesVehiculosServicios()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(DetallesVehiculosServicios detallesVehiculosServicios)
        {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    string selectQuery = @"INSERT INTO DetallesVehiculosServicios (IdVehiculoServicio,IdServicioTipoDePago, Pago, Debe, FechaPago) 
                                    Values (@IdVehiculoServicio,@IdServicioTipoDePago, @Pago, @Debe, @FechaPago); SELECT SCOPE_IDENTITY();";
                    int id = conn.ExecuteScalar<int>(selectQuery, detallesVehiculosServicios);
                    detallesVehiculosServicios.Id = id;
                }
        }

        public void Borrar(int Id)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string deleteQuery = "DELETE FROM DetallesVehiculosServicios WHERE Id=@Id";
                conn.Execute(deleteQuery, new { Id = Id });
            }
        }

        public void BorrarTodosLosDetallesPorIdVehiculoFechaYIdCliente(int IdVehiculo, DateTime Fecha, int IdCliente)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            { //De esta forma puedo meter un INNER JOIN dentro de un DELETE, si no podría hacer una subconsulta, pero me parece que esta es más rápida de comprender
                string deleteQuery = @"DELETE d FROM DetallesVehiculosServicios d
                                       INNER JOIN VehiculosServicios vs ON d.IdVehiculoServicio = vs.IdVehiculoServicio
                                       WHERE vs.IdVehiculo=@IdVehiculo AND vs.Fecha=CONVERT(DATE,@Fecha) AND vs.IdCliente=@IdCliente";
                conn.Execute(deleteQuery, new { IdVehiculo = IdVehiculo, Fecha=Fecha, IdCliente=IdCliente});
            }
        }

        public void Editar(DetallesVehiculosServicios detallesVehiculosServicios)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string updateQuery = @"UPDATE DetallesVehiculosServicios SET IdVehiculoServicio=@IdVehiculoServicio,IdServicioTipoDePago=@IdServicioTipoDePago,Pago=@Pago,Debe=@Debe, FechaPago=@FechaPago
                WHERE Id=@Id";
                conn.Execute(updateQuery, detallesVehiculosServicios);
            }
        }

        public bool Existe(DetallesVehiculosServicios detallesVehiculosServicios)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (detallesVehiculosServicios.Id == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM DetallesVehiculosServicios 
                            WHERE IdVehiculoServicio=@IdVehiculoServicio AND IdServicioTipoDePago=@IdServicioTipoDePago AND Debe=@Debe AND Pago=@Pago AND FechaPago=@FechaPago";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdVehiculoServicio=detallesVehiculosServicios.IdVehiculoServicio, IdServicioTipoDePago=detallesVehiculosServicios.IdServicioTipoDePago,Debe=detallesVehiculosServicios.Debe,Pago=detallesVehiculosServicios.Pago });
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM DetallesVehiculosServicios 
                            WHERE IdVehiculoServicio=@IdVehiculoServicio AND IdServicioTipoDePago=@IdServicioTipoDePago AND Debe=@Debe AND Pago=@Pago AND FechaPago=@FechaPago AND Id!=@Id";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdVehiculoServicio = detallesVehiculosServicios.IdVehiculoServicio, IdServicioTipoDePago = detallesVehiculosServicios.IdServicioTipoDePago, Debe = detallesVehiculosServicios.Debe, Pago = detallesVehiculosServicios.Pago, Id=detallesVehiculosServicios.Id});
                }
            }
            return cantidad > 0;
        }

        public bool ExistenDetallesParaVehiculoServicio(int IdVehiculo, DateTime Fecha, int IdCliente)
        {
           var cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM DetallesVehiculosServicios d
                                       INNER JOIN VehiculosServicios vs ON d.IdVehiculoServicio = vs.IdVehiculoServicio
                                       WHERE vs.IdVehiculo=@IdVehiculo AND vs.Fecha=CONVERT(DATE,@Fecha) AND vs.IdCliente=@IdCliente";
                cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdVehiculo = IdVehiculo, Fecha=Fecha, IdCliente=IdCliente });
            }
            return cantidad > 1;
        }

        public List<DetallesVehiculosServicios> GetDetallesVehiculosServiciosPorIdVehiculoNombreServicioFechaYIdCliente(int IdVehiculo, DateTime Fecha, int IdCliente, string Servicio=null)
        {
            List<DetallesVehiculosServicios> detallesVehiculosServicios = new List<DetallesVehiculosServicios>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(@"SELECT d.Id,d.IdVehiculoServicio,d.IdServicioTipoDePago,d.Debe, d.Pago, d.FechaPago
                    FROM DetallesVehiculosServicios d
                    INNER JOIN VehiculosServicios vs ON d.IdVehiculoServicio = vs.IdVehiculoServicio
                    INNER JOIN ServiciosTiposDePago stp ON d.IdServicioTipoDePago = stp.IdServicioTipoDePago
                    INNER JOIN Servicios s ON stp.IdServicio = s.IdServicio  
                    WHERE vs.IdVehiculo=@IdVehiculo AND vs.Fecha=CONVERT(DATE,@Fecha) AND vs.IdCliente=@IdCliente");
                if (Servicio!=null)
                {
                    stringBuilder.AppendLine("AND s.Servicio=@Servicio ");
                }
                detallesVehiculosServicios = conn.Query<DetallesVehiculosServicios>(stringBuilder.ToString(),
                    new { IdVehiculo=IdVehiculo, Servicio=Servicio, Fecha=Fecha, IdCliente=IdCliente}).ToList();
            }
            return detallesVehiculosServicios;
        }

        public List<decimal> GetPreciosPorIdVehiculoNombreServicioFechaYIdCliente(int IdVehiculo, DateTime Fecha, int IdCliente, string servicio=null)
        {
            List<decimal> precios = new List<decimal>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder stringBuilder=new StringBuilder();
                stringBuilder.AppendLine(@"SELECT d.Debe FROM DetallesVehiculosServicios d
                                           INNER JOIN VehiculosServicios vs ON d.IdVehiculoServicio = vs.IdVehiculoServicio
                                           INNER JOIN ServiciosTiposDePago stp ON d.IdServicioTipoDePago = stp.IdServicioTipoDePago
                                           INNER JOIN Servicios s ON stp.IdServicio = s.IdServicio     
                                           WHERE vs.IdVehiculo=@IdVehiculo AND vs.Fecha=CONVERT(DATE,@Fecha) AND vs.IdCliente=@IdCliente");
                if (servicio != null)
                {
                    stringBuilder.AppendLine("AND s.Servicio = @servicio");
                }
                precios = conn.Query<decimal>(stringBuilder.ToString(), new { IdVehiculo = IdVehiculo, Fecha = Fecha, IdCliente = IdCliente, Servicio=servicio }).ToList();
            }
            return precios;
        }

        public List<ServicioTipoDePago> GetServiciosTipoDePagoPorIdVehiculoNombreServicioFechaYIdCliente(int IdVehiculo, DateTime Fecha, int IdCliente, string servicio = null)
        {
            List<ServicioTipoDePago> serviciosTipoDePago = new List<ServicioTipoDePago>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(@"SELECT stp.IdServicioTipoDePago, stp.IdServicio, stp.IdTipoPago
                                       FROM DetallesVehiculosServicios d
                                       INNER JOIN VehiculosServicios vs ON d.IdVehiculoServicio = vs.IdVehiculoServicio
                                       INNER JOIN ServiciosTiposDePago stp ON d.IdServicioTipoDePago = stp.IdServicioTipoDePago
                                       INNER JOIN Servicios s ON stp.IdServicio = s.IdServicio     
                                       WHERE vs.IdVehiculo=@IdVehiculo AND vs.Fecha=CONVERT(DATE,@Fecha) AND vs.IdCliente=@IdCliente");
                if (servicio != null)
                {
                    stringBuilder.AppendLine("AND s.Servicio = @servicio");
                }
                serviciosTipoDePago = conn.Query<ServicioTipoDePago>(stringBuilder.ToString(), new { IdVehiculo = IdVehiculo, Fecha = Fecha, IdCliente = IdCliente, servicio=servicio }).ToList();
            }
            return serviciosTipoDePago;
        }

        public DetallesVehiculosServicios GetVehiculoServicioPorId(int Id)
        {
            DetallesVehiculosServicios detallesVehiculosServicios = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT d.Id,d.IdVehiculoServicio,d.IdServicioTipoDePago,d.Debe, d.Pago, d.FechaPago
                    FROM DetallesVehiculosServicios d
                    WHERE d.Id=@Id";
                detallesVehiculosServicios = conn.QuerySingleOrDefault<DetallesVehiculosServicios>(selectQuery,
                    new { Id = Id });
            }
            return detallesVehiculosServicios;
        }
    }
}
