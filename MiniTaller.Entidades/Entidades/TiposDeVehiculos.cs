using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class TiposDeVehiculos
    {
        public int IdTipoVehiculo { get; set; }
        public string Tipo { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
