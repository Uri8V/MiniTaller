﻿using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Repositorios.Repositorios;
using MiniTaller.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicios.Servicios
{
    public class ServicioDeVehiculosServicios:IServicioDeVehiculosServicios
    {
        private readonly IRepositorioDeVehiculosServicios _repo;
        public ServicioDeVehiculosServicios()
        {
            _repo = new RepositorioDeVehiculosServicios();
        }

        public void Borrar(int IdVehiculoServicio)
        {
            try
            {
                _repo.Borrar(IdVehiculoServicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool EstaRelacionado(VehiculosServicios vehiculosServicios)
        {
            try
            {
                return _repo.EstaRelacionado(vehiculosServicios);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método EstaRelacionado", ex);
            }
        }

        public bool Existe(VehiculosServicios vehiculosServicios)
        {
            try
            {
                return _repo.Existe(vehiculosServicios);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Existe", ex);
            }
        }

        public int GetCantidad(int? IdVehiculo, int? IdServicio, int? IdCliente, DateTime? FechaServicios, bool? Yapago)
        {
            try
            {
                return _repo.GetCantidad(IdVehiculo, IdServicio, IdCliente, FechaServicios,Yapago);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetCantidad", ex);
            }
        }

        public List<VehiculoServicioComboDto> GetServiciosCombo()
        {
            try
            {
                return _repo.GetServiciosCombo();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetServiciosCombo", ex);
            }
        }

        public List<VehiculosServiciosDto> GetVehiculoServicioPorCliente(string CUITDocumento)
        {
            try
            {
                return _repo.GetVehiculoServicioPorCliente(CUITDocumento);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetehiculoServicioPorCliente", ex);
            }
        }

        public VehiculosServicios GetVehiculoServicioPorId(int IdVehiculoServicio)
        {
            try
            {
                return _repo.GetVehiculoServicioPorId(IdVehiculoServicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetVehiculoServicioPorId", ex);
            }
        }

        public List<VehiculosServiciosDto> GetVehiculoServicioPorPagina(int registrosPorPagina, int paginaActual, int? IdVehiculo, int? IdServicio, int? IdCliente, DateTime? FechaServicios, bool? Yapago)
        {
            try
            {
                return _repo.GetVehiculoServicioPorPagina(registrosPorPagina, paginaActual, IdVehiculo, IdServicio, IdCliente, FechaServicios, Yapago);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetVehiculoServicioPorPagina", ex);
            }
        }

        public void Guardar(VehiculosServicios vehiculosServicios)
        {
            try
            {
                if (vehiculosServicios.IdVehiculoServicio==0)
                {
                    _repo.Agregar(vehiculosServicios);
                }
                else
                {
                    _repo.Editar(vehiculosServicios);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }
    }
}
