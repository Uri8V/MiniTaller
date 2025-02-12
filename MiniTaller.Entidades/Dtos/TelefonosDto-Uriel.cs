using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Dtos
{
    public class TelefonosDto: ICloneable
    {
        public int IdTelefono { get; set; }
        public string Telefono { get; set; }
        public string TipoTelefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string CUIT { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
