using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Dtos
{
    public class ServiciosDto: ICloneable
    {
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public decimal Debe { get; set; }
        public string Tipo { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
