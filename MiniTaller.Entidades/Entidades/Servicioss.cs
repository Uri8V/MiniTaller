using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class Servicioss
    {
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
