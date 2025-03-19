using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class Imagenes
    {
        public int IdImage { get; set; }
        public int? IdObservacion { get; set; }
        public int? IdVehiculoServicio { get; set; }
        public byte[] imageURL { get; set; }
    }
}
