﻿using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Comun.Interfaces
{
    public interface IRepositorioDeServicios
    {
        void Agregar(Servicioss servicios);
        void Borrar(int IdMovimiento);
        void Editar(Servicioss servicios);
        bool Existe(Servicioss servicios);
        bool EstaRelacionada(Servicioss servicios);
        int GetCantidad();
        List<Servicioss> GetServiciosPorPagina(int registrosPorPagina, int paginaActual);
        Servicioss GetServiciosPorId(int IdServicio);
        List<Servicioss> GetServiciosCombos();

    }
}
