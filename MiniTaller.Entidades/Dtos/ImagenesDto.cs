using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Dtos
{
    public class ImagenesDto
    {
        public int IdImage { get; set; }
        public byte[] imageURL { get; set; }
        public string Info { get; set; }
        public string Patente { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
