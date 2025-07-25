﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Entidades
{
    public class Vehiculos
    {
        public int IdVehiculo { get; set; }
        public string Patente { get; set; }
        public int IdModelo { get; set; }
        public Modelos Modelo { get; set; }
        public int  IdTipoVehiculo { get; set; }
        public TiposDeVehiculos TipoDeVehiculo { get; set; }
        public string PINCode { get; set; }
        public string ECU {get; set; }
        public string VIN { get; set; }
    }
}
