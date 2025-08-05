using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Comun.Interfaces
{
    public interface IRepositorioDeDetallesVehiculosServicios
    {
        void Agregar(DetallesVehiculosServicios detallesVehiculosServicios);
        void Borrar(int Id);
        void BorrarTodosLosDetallesPorIdVehiculoFechaYIdCliente(int IdVehiculo, DateTime Fecha, int IdCliente);
        void Editar(DetallesVehiculosServicios detallesVehiculosServicios);
        bool Existe(DetallesVehiculosServicios detallesVehiculosServicios);
        bool ExistenDetallesParaVehiculoServicio(int idVehiculo, DateTime fecha, int idCliente);
        List<DetallesVehiculosServicios> GetDetallesVehiculosServiciosPorIdVehiculoNombreServicioFechaYIdCliente(int IdVehiculo, DateTime Fecha, int IdCliente, string Servicio=null);
        List<decimal> GetPreciosPorIdVehiculoNombreServicioFechaYIdCliente(int idVehiculo, DateTime fecha, int idCliente, string servicio=null);
        List<ServicioTipoDePago> GetServiciosTipoDePagoPorIdVehiculoNombreServicioFechaYIdCliente(int idVehiculo, DateTime fecha, int idCliente, string servicio = null);
    }
}
