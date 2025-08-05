using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Dtos
{
    public class ServicioTipoDePagoDto: ICloneable
    {
        public int IdServicioTipoDePago { get; set; }
        public string servicio { get; set; }
        public string Tipo { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
