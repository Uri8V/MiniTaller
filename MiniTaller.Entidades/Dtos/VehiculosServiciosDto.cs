﻿using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Dtos
{
    public class VehiculosServiciosDto:ICloneable
    {
        public int IdVehiculoServicio { get; set; }
        public string Patente { get; set; }
        public string Servicio { get; set; }
        public decimal DebeServicio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Descripcion { get; set; }
        public string CUIT { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public DateTime Fecha { get; set; }
        public string Kilometros { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
