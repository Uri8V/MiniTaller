using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Dtos
{
    public class VehiculosDto : ICloneable
    {
        public int IdVehiculo { get; set; }
        public string Patente { get; set; }
        public string Kilometros { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string PINCode { get; set; }
        public string ECU { get; set; }
        public string VIN { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
