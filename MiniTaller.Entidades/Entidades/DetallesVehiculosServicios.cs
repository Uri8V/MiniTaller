using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class DetallesVehiculosServicios
    {
        public int Id { get; set; }
        public int IdVehiculoServicio { get; set; }
        public VehiculosServicios VehiculoServicio { get; set; }
        public int IdServicioTipoDePago { get; set; }
        public ServicioTipoDePago ServicioTipoDePago { get; set; }
        public decimal Debe { get; set; }
        public decimal Pago { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
