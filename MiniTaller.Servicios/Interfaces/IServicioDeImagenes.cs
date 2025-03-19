using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicios.Interfaces
{
    public interface IServicioDeImagenes
    {
        void Borrar(int IdImage);
        void Guardar(Imagenes img);
        bool Existe(Imagenes img);
        List<ImagenesDto> GetImagenesPorPagina(int registrosPorPagina, int paginaActual, int? IdObservacion, int? IdVehiculoServicio);
        Imagenes GetImagenPorId(int marcaId);
        int GetCantidad(int? IdObservacion, int? IdVehiculoServico);
    }
}
