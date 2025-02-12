using MiniTaller.Entidades;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Comun.Interfaces
{
    public interface IRepositorioDeTiposDePagos
    {
        void Agregar(TiposDePagos tipo);
        void Borrar(int TipoDePagoId);
        void Editar(TiposDePagos tipo);
        bool Existe(TiposDePagos tipo);
        int GetCantidad();
        List<TiposDePagos> GetTiposDePagos();
        bool EstaRelacionado(TiposDePagos tipo);
       TiposDePagos GetTipoDePagoPorId(int tipoId);
    }
}
