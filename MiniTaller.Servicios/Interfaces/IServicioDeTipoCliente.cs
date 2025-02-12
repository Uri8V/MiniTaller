using MiniTaller.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicio.Interfaces
{
    public interface IServicioDeTipoCliente
    {
        void Guardar(TiposClientes tipo);
        void Borrar(int TipoDeClienteId);
        bool Existe(TiposClientes tipo);
        int GetCantidad();
        List<TiposClientes> GetTiposDeClientes();
        bool EstaRelacionado(TiposClientes tipo);
        TiposClientes GetTipoClientePorId(int tipoId);
    }
}
