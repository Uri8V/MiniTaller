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
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Observaciones Observacion)
        {
            try
            {
                return _repositorioDeObservaciones.EstaRelacionado(Observacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Observaciones Observacion)
        {
            try
            {
                return _repositorioDeObservaciones.Existe(Observacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(int? IdVehiculo, int? IdCliente, DateTime? Fecha)
        {
            try
            {
               return _repositorioDeObservaciones.GetCantidad(IdVehiculo,IdCliente,Fecha);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ObservacionesComboDto> GetObservacionesCombos()
        {
            try
            {
                return _repositorioDeObservaciones.GetObservacionesCombo();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ObservacionDto> GetVehiculoObservacionPorClienteYVehiculo(int idCLiente, int idVehiculo)
        {
            try
            {
                return _repositorioDeObservaciones.GetVehiculoObservacionPorClienteYVehiculo(idCLiente,idVehiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Observaciones GetVehiculoObservacionPorId(int IdObservacion)
        {
            try
            {
                return _repositorioDeObservaciones.GetVehiculoObservacionPorId(IdObservacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ObservacionDto> GetVehiculoObservacionPorPagina(int registrosPorPagina, int paginaActual, int? IdVehiculo, int? IdCliente, DateTime? Fecha)
        {
            try
            {
                return _repositorioDeObservaciones.GetVehiculoObservacionPorPagina(registrosPorPagina, paginaActual, IdVehiculo, IdCliente, Fecha);
            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
