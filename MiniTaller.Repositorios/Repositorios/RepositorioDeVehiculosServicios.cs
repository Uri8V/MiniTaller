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
                string selectQuery = @"INSERT INTO VehiculosServicios (IdVehiculo,IdServicioTipoDePago, IdCliente, Descripcion, Debe, Haber, Fecha) 
                                    Values (@IdVehiculo,@IdServicioTipoDePago, @IdCliente, @Descripcion, @Debe, @Haber, @Fecha); SELECT SCOPE_IDENTITY();";
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
                string updateQuery = @"UPDATE VehiculosServicios SET IdVehiculo=@IdVehiculo,IdServicioTipoDePago=@IdServicioTipoDePago, IdCliente=@IdCliente, Descripcion=@Descripcion, Debe=@Debe, Haber=@Haber, Fecha=@Fecha
                WHERE IdVehiculoServicio=@IdVehiculoServicio";
                conn.Execute(updateQuery, vehiculosServicios);
            }
        }

        public bool EstaRelacionado(VehiculosServicios vehiculosServicios)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM Imagenes WHERE IdVehiculoServicio=@IdVehiculoServicio";
                cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdVehiculoServicio = vehiculosServicios.IdVehiculoServicio });
            }
            return cantidad > 0;
        }

        public bool Existe(VehiculosServicios vehiculosServicios, List<ServicioTipoDePago> lista)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (lista.Count>1 || vehiculosServicios.IdVehiculoServicio == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios 
                            WHERE IdVehiculo=@IdVehiculo AND IdServicioTipoDePago=@IdServicioTipoDePago AND IdCliente=@IdCliente AND Fecha=@Fecha";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdVehiculo = vehiculosServicios.IdVehiculo, IdServicioTipoDePago = vehiculosServicios.IdServicioTipoDePago, IdCliente = vehiculosServicios.IdCliente, Fecha = vehiculosServicios.Fecha });
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios 
                WHERE IdVehiculo=@IdVehiculo AND IdServicioTipoDePago=@IdServicioTipoDePago AND IdCliente=@IdCliente AND Fecha=@Fecha AND   Haber=@Haber AND IdVehiculoServicio!=@IdVehiculoServicio";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdVehiculo = vehiculosServicios.IdVehiculo, IdServicioTipoDePago = vehiculosServicios.IdServicioTipoDePago, IdCliente = vehiculosServicios.IdCliente, Fecha = vehiculosServicios.Fecha, Haber = vehiculosServicios.Haber, IdVehiculoServicio = vehiculosServicios.IdVehiculoServicio });
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
                    selectQuery = "SELECT COUNT(*) FROM VehiculosServicios WHERE Debe!=Haber";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else if (IdVehiculo != null && IdServicioTipoDePago == null && IdCliente == null && FechaServicios == null && Yapago == null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios 
                        WHERE (IdVehiculo=@IdVehiculo)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdVehiculo = IdVehiculo });
                }
                else if (IdVehiculo == null && IdServicioTipoDePago != null && IdCliente == null && FechaServicios == null && Yapago == null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios 
                        WHERE (IdServicioTipoDePago=@IdServicioTipoDePago)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdServicioTipoDePago = IdServicioTipoDePago });
                }
                else if (IdVehiculo == null && IdServicioTipoDePago == null && IdCliente != null && FechaServicios == null && Yapago == null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios 
                        WHERE (IdCliente=@IdCliente)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdCliente = IdCliente });
                }
                else if (IdVehiculo == null && IdServicioTipoDePago == null && IdCliente == null && FechaServicios != null && Yapago == null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios 
                        WHERE (Fecha=CONVERT(DATE,@FechaServicios))";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { FechaServicios = FechaServicios });
                }
                else if (IdVehiculo == null && IdServicioTipoDePago == null && IdCliente == null && FechaServicios == null && Yapago != null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios 
                        WHERE Debe=Haber";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
            }
            return cantidad;

        }

        public List<VehiculoServicioComboDto> GetServiciosCombo()
        {
            List<VehiculoServicioComboDto> lista = new List<VehiculoServicioComboDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"  WITH cte AS (
    SELECT 
        vs.IdVehiculoServicio, 
        CONCAT(v.Patente, ' | ', UPPER(c.Apellido), ', ', UPPER(c.Nombre), ' (', c.Documento, c.CUIT, ')') AS Info,
        ROW_NUMBER() OVER (PARTITION BY v.Patente, c.Apellido, c.Nombre, c.Documento, c.CUIT ORDER BY vs.IdVehiculoServicio ASC) AS rn
    FROM [MiniTaller].[dbo].[VehiculosServicios] vs
    INNER JOIN Vehiculos v ON vs.IdVehiculo = v.IdVehiculo
    INNER JOIN Clientes c ON c.IdCliente = vs.IdCliente
)
SELECT IdVehiculoServicio, Info FROM cte WHERE rn = 1;
";
                lista = conn.Query<VehiculoServicioComboDto>(selectQuery).ToList();
            }
            return lista;
        }

        public List<VehiculosServiciosDto> GetVehiculoServicioPorCliente(string CUITDocumento)
        {
            List<VehiculosServiciosDto> lista = new List<VehiculosServiciosDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT vs.IdVehiculoServicio, v.Patente, s.Servicio, st.Precio as DebeServicio, c.Apellido, c.Nombre,c.Documento,c.CUIT,vs.Descripcion,vs.Debe,vs.Haber,vs.Fecha
                    FROM VehiculosServicios vs
                    INNER JOIN Vehiculos v ON v.IdVehiculo=vs.IdVehiculo
                    INNER JOIN ServiciosTiposDePago st ON vs.IdServicioTipoDePago=st.IdServicioTipoDePago
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
                string selectQuery = @"SELECT vs.IdVehiculoServicio,vs.IdVehiculo,vs.IdServicioTipoDePago,vs.IdCliente,vs.Descripcion, vs.Debe, vs.Haber, vs.Fecha
                    FROM VehiculosServicios vs WHERE vs.IdVehiculoServicio=@IdVehiculoServicios";
                vehiculosServicios = conn.QuerySingleOrDefault<VehiculosServicios>(selectQuery,
                    new { IdVehiculoServicios = IdVehiculoServicio });
            }
            return vehiculosServicios;
        }

        public List<VehiculosServiciosDto> GetVehiculoServicioPorPagina(int registrosPorPagina, int paginaActual, int? IdVehiculo, int? IdServicioTipoDePago, int? IdCliente, DateTime? FechaServicios, bool? Yapago)
        {

            List<VehiculosServiciosDto> lista = new List<VehiculosServiciosDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT vs.IdVehiculoServicio, v.Patente, v.Kilometros, s.Servicio, st.Precio as DebeServicio, c.Apellido, c.Nombre,c.Documento,c.CUIT,vs.Descripcion,vs.Debe,vs.Haber,vs.Fecha");
                selectQuery.AppendLine("FROM VehiculosServicios vs");
                selectQuery.AppendLine("INNER JOIN Vehiculos v ON v.IdVehiculo=vs.IdVehiculo");
                selectQuery.AppendLine("INNER JOIN ServiciosTiposDePago st ON st.IdServicioTipoDePago=vs.IdServicioTipoDePago");
                selectQuery.AppendLine("INNER JOIN Clientes c ON c.IdCliente=vs.IdCliente");
                selectQuery.AppendLine("INNER JOIN Servicios s ON st.IdServicio=s.IdServicio");

                if (IdVehiculo != null || IdServicioTipoDePago != null || IdCliente != null || FechaServicios != null)
                {
                    selectQuery.AppendLine("WHERE vs.IdVehiculo = @IdVehiculo OR vs.IdServicioTipoDePago=@IdServicioTipoDePago OR vs.Fecha=CONVERT(DATE,@FechaServicios) OR vs.IdCliente=@IdCliente");
                }
                else if (Yapago != null)
                {
                    selectQuery.AppendLine("WHERE vs.Debe=vs.Haber");
                }
                else
                {
                    selectQuery.AppendLine("WHERE vs.Debe!=vs.Haber");
                }

                selectQuery.AppendLine("ORDER BY vs.Fecha,s.Servicio");
                selectQuery.AppendLine("OFFSET @registrosSaltados ROWS FETCH NEXT @registrosPorPagina ROWS ONLY");

                var parametros = new { IdVehiculo, IdServicioTipoDePago, IdCliente, FechaServicios, registrosSaltados = registrosPorPagina * (paginaActual - 1), registrosPorPagina };

                lista = conn.Query<VehiculosServiciosDto>(selectQuery.ToString(), parametros).ToList();

            }
            return lista;
        }
    }
}
