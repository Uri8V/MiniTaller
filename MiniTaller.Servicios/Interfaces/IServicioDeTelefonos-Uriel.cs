using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicios.Interfaces
{
    public interface IServicioDeTelefonos
    {
        void Guardar(Telefonos telefono);
        void Borrar(int telefonoId);
        bool Existe(Telefonos telefono);
        int GetCantidad(int? IdCliente);
        List<TelefonosDto> GetTelefonosPorPagina(int registrosPorPagina, int paginaActual, int? IdCliente);
        Telefonos GetTelefonoPorId(int IdTelefono);
    }
}
