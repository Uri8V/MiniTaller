﻿using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicios.Interfaces
{
    public interface IServicioDeVehiculosServicios
    {
        void Guardar(VehiculosServicios vehiculosServicios);
        void Borrar(int IdVehiculoServicio);
        bool EstaRelacionado(VehiculosServicios vehiculosServicios);
        bool Existe(VehiculosServicios vehiculosServicios);
        int GetCantidad(int? IdVehiculo, int? IdServicio, int? IdCliente, DateTime? FechaServicios, bool? Yapago);
        List<VehiculosServiciosDto> GetVehiculoServicioPorPagina(int registrosPorPagina, int paginaActual, int? IdVehiculo, int? IdMovimiento, int? IdCliente, DateTime? FechaServicios, bool? Yapago);
        VehiculosServicios GetVehiculoServicioPorId(int IdVehiculoServicio);
        List<VehiculosServiciosDto> GetVehiculoServicioPorCliente(string CUITDocumento);
        List<VehiculoServicioComboDto> GetServiciosCombo();
    }
}
