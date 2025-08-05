using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class ServicioTipoDePago
    {
        public int IdServicioTipoDePago { get; set; }
        public int IdServicio { get; set; }
        public Servicioss servicio { get; set; }
        public int IdTipoPago { get; set; }
        public TiposDePagos Tipo { get; set; }
    }
}
