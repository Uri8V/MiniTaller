using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Comun.Interfaces
{
    public interface IRepositorioDeVehiculosServicios
    {
        void Agregar(VehiculosServicios vehiculosServicios);
        void Borrar(int IdVehiculoServicio);
        void Editar(VehiculosServicios vehiculosServicios);
        bool Existe(VehiculosServicios vehiculosServicios);
        int GetCantidad(int? IdVehiculo, int? IdServicio, int? IdCliente, DateTime? FechaServicios);
        List<VehiculosServiciosDto> GetVehiculoServicioPorPagina(int registrosPorPagina, int paginaActual, int? IdVehiculo, int? IdMovimiento, int? IdCliente, DateTime? FechaServicios);
        VehiculosServicios GetVehiculoServicioPorId(int IdVehiculoServicio);
        List<VehiculosServiciosDto> GetVehiculoServicioPorCliente(string CUITDocumento);
    }
}
