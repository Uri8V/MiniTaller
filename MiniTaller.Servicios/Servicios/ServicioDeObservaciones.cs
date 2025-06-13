using MiniTaller.Comun.Interfaces;
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
    public class ServicioDeObservaciones:IServicioDeObservaciones
    {
        private readonly IRepositorioDeObservaciones _repositorioDeObservaciones;
        public ServicioDeObservaciones()
        {
            _repositorioDeObservaciones = new RepositorioDeObservaciones();
        }

        public void Borrar(int IdObservacion)
        {
            try
            {
                _repositorioDeObservaciones.Borrar(IdObservacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool EstaRelacionado(Observaciones Observacion)
        {
            try
            {
                return _repositorioDeObservaciones.EstaRelacionado(Observacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método EstaRelacionada", ex);
            }
        }

        public bool Existe(Observaciones Observacion)
        {
            try
            {
                return _repositorioDeObservaciones.Existe(Observacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Existe", ex);
            }
        }

        public int GetCantidad(int? IdVehiculo, int? IdCliente, DateTime? Fecha)
        {
            try
            {
               return _repositorioDeObservaciones.GetCantidad(IdVehiculo,IdCliente,Fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetCantidad", ex);
            }
        }

        public List<ObservacionesComboDto> GetObservacionesCombos()
        {
            try
            {
                return _repositorioDeObservaciones.GetObservacionesCombo();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetObservacionesCombos", ex);
            }
        }

        public List<ObservacionDto> GetVehiculoObservacionPorClienteYVehiculo(int idCLiente, int idVehiculo)
        {
            try
            {
                return _repositorioDeObservaciones.GetVehiculoObservacionPorClienteYVehiculo(idCLiente,idVehiculo);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetVehiculoObservacionPorClienteYVehiculo", ex);
            }
        }

        public Observaciones GetVehiculoObservacionPorId(int IdObservacion)
        {
            try
            {
                return _repositorioDeObservaciones.GetVehiculoObservacionPorId(IdObservacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetVehivuloObservacionPorId", ex);
            }
        }

        public List<ObservacionDto> GetVehiculoObservacionPorPagina(int registrosPorPagina, int paginaActual, int? IdVehiculo, int? IdCliente, DateTime? Fecha)
        {
            try
            {
                return _repositorioDeObservaciones.GetVehiculoObservacionPorPagina(registrosPorPagina, paginaActual, IdVehiculo, IdCliente, Fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetVehiculoObservacionPorPagina", ex);
            }
        }

        public void Guardar(Observaciones Observacion)
        {
            try
            {
                if (Observacion.IdObservacion==0)
                {
                    _repositorioDeObservaciones.Agregar(Observacion);
                }
                else
                {
                    _repositorioDeObservaciones.Editar(Observacion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }
    }
}
