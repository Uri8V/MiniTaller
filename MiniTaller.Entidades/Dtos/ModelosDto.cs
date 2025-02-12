using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Dtos
{
    public  class ModelosDto: ICloneable
    {
        public int IdModelo { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
