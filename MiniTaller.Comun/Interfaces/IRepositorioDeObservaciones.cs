using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Comun.Interfaces
{
    public interface IRepositorioDeObservaciones
    {
        void Agregar(Observaciones Observacion);
        void Borrar(int IdObservacion);
        void Editar(Observaciones Observacion);
        bool Existe(Observaciones Observacion);
        int GetCantidad(int? IdVehiculo, int? IdCliente, DateTime? Fecha);
        List<ObservacionDto> GetVehiculoObservacionPorPagina(int registrosPorPagina, int paginaActual, int? IdVehiculo, int? IdCliente, DateTime? Fecha);
        Observaciones GetVehiculoObservacionPorId(int IdObservacion);
        List<ObservacionDto> GetVehiculoObservacionPorClienteYVehiculo(int idCLiente, int idVehiculo);
    }
}
