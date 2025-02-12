using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class Servicioss
    {
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public decimal Debe { get; set; }
        public int IdTipoPago { get; set; }
        public TiposDePagos TipoDePago { get; set; }

    }
}
