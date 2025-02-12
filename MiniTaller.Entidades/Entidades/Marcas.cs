using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class Marcas
    {
        public int IdMarca { get; set; }
        public string Marca { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
