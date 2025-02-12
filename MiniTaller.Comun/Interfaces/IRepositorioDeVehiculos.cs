using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Comun.Interfaces
{
    public interface IRepositorioDeVehiculos
    {
        void Agregar(Vehiculos vehiculos);
        void Borrar(int IdVehiculo);
        void Editar(Vehiculos vehiculos);
        bool Existe(Vehiculos vehiculos);
        bool EstaRelacionada(Vehiculos vehiculos);
        int GetCantidad(int? IdModleo, int? IdTipoVehiculo);
        List<VehiculosDto> GetVehiculosPorPagina(int registrosPorPagina, int paginaActual, int? IdModelo, int? IdTipoVehiculo);
        Vehiculos GetVehiculosPorId(int IdVehiculo);
        List<VehiculosComboDto> GetVehiculosCombos();
    }
}
