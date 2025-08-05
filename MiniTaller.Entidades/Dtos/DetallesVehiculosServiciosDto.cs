using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Dtos
{
    public class DetallesVehiculosServiciosDto
    {
        public int Id { get; set; }
        public decimal Debe { get; set; }
        public decimal Pago { get; set; }
        public string VehiculoServicio { get; set; }
        public string ServicioTipoDePago { get; set; }
    }
}
