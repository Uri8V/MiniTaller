using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class Modelos
    {
        public int IdModelo { get; set; }
        public string Modelo { get; set; }
        public int IdMarca { get; set; }
        public Marcas Marca { get; set; }
    }
}
