using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Dtos
{
    public class ClientesDto:ICloneable
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Domicilio { get; set; }
        public string CUIT { get; set; }
        public string Tipo { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
