using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicios.Interfaces
{
    public interface IServicioDeVehiculos
    {
        void Guardar(Vehiculos vehiculos);
        void Borrar(int IdVehiculo);
        bool Existe(Vehiculos vehiculos);
        bool EstaRelacionada(Vehiculos vehiculos);
        int GetCantidad(int? IdModleo, int? IdTipoVehiculo);
        List<VehiculosDto> GetVehiculosPorPagina(int registrosPorPagina, int paginaActual, int? IdModelo, int? IdTipoVehiculo);
        Vehiculos GetVehiculosPorId(int IdVehiculo);
        List<VehiculosComboDto> GetVehiculosCombos();
    }
}
