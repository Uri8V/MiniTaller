using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class VehiculosServicios
    {
        public int IdVehiculoServicio { get; set; }
        public int IdVehiculo { get; set; }
        public Vehiculos Vehiculo { get; set; }
        public int IdServicioTipoDePago { get; set; }
        public ServicioTipoDePago Servicio { get; set; }
        public int IdCliente { get; set; }
        public Clientes Cliente { get; set; }
        public string Descripcion { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public DateTime Fecha { get; set; }
    }
}
