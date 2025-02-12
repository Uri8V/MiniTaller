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
    public interface IRepositorioDeModelos
    {
        void Agregar(Modelos modelos);
        void Borrar(int modeloId);
        void Editar(Modelos modelos);
        bool Existe(Modelos modelos);
        bool EstaRelacionada(Modelos modelos);
        int GetCantidad(int? IdMarca);
        List<ModelosDto> GetModelosPorPagina(int registrosPorPagina, int paginaActual, int? marca);
        Modelos GetModelosPorId(int marcaId);
        List<ModelosComboDto> GetModelosCombos();
    }
}
