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
    public interface IServicioDeClientes
    {
        void Guardar(Clientes cliente);
        void Borrar(int IdCliente);
        bool Existe(Clientes cliente);
        bool EstaRelacionada(Clientes cliente);
        int GetCantidad(int? IdCliente);
        List<ClientesDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual, int? IdTipoCliente);
        Clientes GetClientePorId(int IdCliente);
        List<ClientesComboDto> GetClientesCombos();
        List<ClientesComboDto> GetClientesCombosEmpresa();
    }
}
