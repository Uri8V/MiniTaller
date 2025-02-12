using MiniTaller.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Comun.Interfaces
{
    public interface IRepositorioDeTipoCliente
    {
        void Agregar(TiposClientes tipo);
        void Borrar(int TipoDeClienteId);
        void Editar(TiposClientes tipo);
        bool Existe(TiposClientes tipo);
        int GetCantidad();
        List<TiposClientes> GetTiposDeClientes();
        bool EstaRelacionado(TiposClientes tipo);
        TiposClientes GetTipoClientePorId(int tipoId);
    }
}
