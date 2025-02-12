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
    public interface IRepositorioDeTelefonos
    {
        void Agregar(Telefonos telefono);
        void Borrar(int telefonoId);
        void Editar(Telefonos telefono);
        bool Existe(Telefonos telefono);
        int GetCantidad(int? IdCliente);
        List<TelefonosDto> GetTelefonosPorPagina(int registrosPorPagina, int paginaActual, int? IdCliente);
        Telefonos GetTelefonoPorId(int IdTelefono);
    }
}
