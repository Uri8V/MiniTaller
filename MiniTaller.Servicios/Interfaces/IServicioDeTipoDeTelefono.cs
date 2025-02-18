using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicios.Interfaces
{
    public interface IServicioDeTipoDeTelefono
    {
        void Guardar(TiposDeTelefono tipo);
        void Borrar(int TipoDePagoId);
        bool Existe(TiposDeTelefono tipo);
        int GetCantidad();
        List<TiposDeTelefono> GetTiposDeTelefono();
        bool EstaRelacionado(TiposDeTelefono tipo);
        TiposDeTelefono GetTipoDeTelefonoPorId(int tipoId);
    }
}
