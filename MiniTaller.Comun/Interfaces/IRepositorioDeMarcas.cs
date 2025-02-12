using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Comun.Interfaces
{
    public interface IRepositorioDeMarcas
    {
        void Agregar(Marcas marca);
        void Borrar(int MarcaId);
        void Editar(Marcas marca);
        bool Existe(Marcas marca);
        int GetCantidad();
        List<Marcas> GetMarcas();
        bool EstaRelacionado(Marcas marca);
        Marcas GetMarcaPorId(int marcaId);
    }
}
