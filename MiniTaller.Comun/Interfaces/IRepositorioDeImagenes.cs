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
    public interface IRepositorioDeImagenes
    {
        void Agregar(Imagenes img);
        void Borrar(int IdImage);
        void Editar(Imagenes img);
        bool Existe(Imagenes img);
        List<ImagenesDto> GetImagenesPorPagina(int registrosPorPagina, int paginaActual, int? IdObservacion, int? IdVehiculoServicio);
        Imagenes GetImagenPorId(int marcaId);
        int GetCantidad(int? IdObservacion, int? IdVehiculoServico);
    }
}
