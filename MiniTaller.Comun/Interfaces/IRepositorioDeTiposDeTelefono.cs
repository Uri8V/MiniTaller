using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Comun.Interfaces
{
    public interface IRepositorioDeTiposDeTelefono
    {
        void Agregar(TiposDeTelefono tipo);
        void Borrar(int TipoDePagoId);
        void Editar(TiposDeTelefono tipo);
        bool Existe(TiposDeTelefono tipo);
        int GetCantidad();
        List<TiposDeTelefono> GetTiposDeTelefono();
        bool EstaRelacionado(TiposDeTelefono tipo);
        TiposDeTelefono GetTipoDeTelefonoPorId(int tipoId);
    }
}
