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
    public interface IServicioDeServicios
    {
        void Guardar(Servicioss servicios);
        void Borrar(int IdMovimiento);
        bool Existe(Servicioss servicios);
        bool EstaRelacionada(Servicioss servicios);
        int GetCantidad();
        List<Servicioss> GetServiciosPorPagina(int registrosPorPagina, int paginaActual);
        Servicioss GetServiciosPorId(int IdServicio);
        List<Servicioss> GetServiciosCombos();
    }
}
