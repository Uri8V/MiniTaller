using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class Telefonos
    {
        public int IdTelefono { get; set; }
        public string Telefono { get; set; }
        public int IdTipoDeTelefono { get; set; }
        public TiposDeTelefono TipoDeTelefono { get; set; }
        public int IdCliente { get; set; }
        public Clientes Cliente { get; set; }
    }
}
