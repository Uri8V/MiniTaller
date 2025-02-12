using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicio.Interfaces
{
    public interface IServicioDeMarcas
    {
        void Guardar(Marcas marca);
        void Borrar(int MarcaId);
        bool Existe(Marcas marca);
        int GetCantidad();
        List<Marcas> GetMarcas();
        bool EstaRelacionado(Marcas marca);
        Marcas GetMarcaPorId(int marcaId);
    }
}
