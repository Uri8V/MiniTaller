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
    public interface IRepositorioDeServiciosTiposDePago
    {
        void Agregar(ServicioTipoDePago servicioTipoDePago);
        void Borrar(int IdServicioTipoDePago);
        bool EstaRelacionado(ServicioTipoDePago servicioTipoDePago);
        void Editar(ServicioTipoDePago servicioTipoDePago);
        bool Existe(ServicioTipoDePago servicioTipoDePago);
        int GetCantidad(int? IdTipoPago, int? IdServicio);
        List<ServicioTipoDePagoDto> GetVehiculoServicioPorPagina(int registrosPorPagina, int paginaActual, int? IdTipoPago, int? IdServicio);
        ServicioTipoDePago GetServicioTipoDePagoPorId(int IdServicioTipoDePago);
        List<ServicioTipoDePagoComboDto> GetServiciosTiposDePagoCombo();

    }
}
