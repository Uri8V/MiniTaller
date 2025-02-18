using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class Observaciones
    {
        public int IdObservacion { get; set; }
        public string Observacion { get; set; }
        public int IdCliente { get; set; }
        public Clientes Cliente { get; set; }
        public int IdVehiculo { get; set; }
        public Vehiculos Vehiculo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
