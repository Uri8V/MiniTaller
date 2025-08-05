using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicios.Interfaces
{
    public interface IServicioDeDetallesVehiculosServicios
    {
        void Guardar(DetallesVehiculosServicios detallesVehiculosServicios);
        void Borrar(int Id);
        void Existe(DetallesVehiculosServicios detallesVehiculosServicios);
        List<DetallesVehiculosServicios> GetDetallesVehiculosServiciosPorIdVehiculoNombreServicioFechaYIdCliente(int IdVehiculo, DateTime Fecha, int IdCliente, string Servicio=null);
        void BorrarTodosLosDetallesPorIdVehiculoFechaYIdCliente(int IdVehiculo, DateTime Fecha, int IdCliente);
        bool ExistenDetallesParaVehiculoServicio(int idVehiculo, DateTime fecha, int idCliente);
        List<decimal> GetPreciosPorIdVehiculoNombreServicioFechaYIdCliente(int idVehiculo, DateTime fecha, int idCliente, string servicio=null);
        List<ServicioTipoDePago> GetServiciosTipoDePagoPorIdVehiculoNombreServicioFechaYIdCliente(int idVehiculo, DateTime fecha, int idCliente, string servicio=null);
    }
}
