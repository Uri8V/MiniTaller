using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicio.Interfaces
{
    public interface IServicioDeTipoPago
    {
        void Guardar(TiposDePagos tipo);
        void Borrar(int TipoDePagoId);
        bool Existe(TiposDePagos tipo);
        int GetCantidad();
        List<TiposDePagos> GetTiposDePagos();
        bool EstaRelacionado(TiposDePagos tipo);
        TiposDePagos GetTipoDePagoPorId(int tipoId);
    }
}
