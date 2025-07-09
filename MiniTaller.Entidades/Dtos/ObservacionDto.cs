using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Dtos
{
    public class ObservacionDto:ICloneable
    {
        public int IdObservacion { get; set; }
        public string Observacion { get; set; }
        public string Cliente { get; set; }
        public string Vehiculo { get; set; }
        public DateTime Fecha { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
