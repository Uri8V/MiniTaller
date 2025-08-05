using MiniTaller.Comun.Interfaces;
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
    public class ServicioDeDetallesVehiculosServicios : IServicioDeDetallesVehiculosServicios
    {
        private readonly IRepositorioDeDetallesVehiculosServicios _repositorio;
        public ServicioDeDetallesVehiculosServicios()
        {
            _repositorio=new RepositorioDeDetallesVehiculosServicios();
        }
        public void Borrar(int Id)
        {
            try
            {
                _repositorio.Borrar(Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public void BorrarTodosLosDetallesPorIdVehiculoFechaYIdCliente(int IdVehiculo, DateTime Fecha, int IdCliente)
        {
            try
            {
                _repositorio.BorrarTodosLosDetallesPorIdVehiculoFechaYIdCliente(IdVehiculo,Fecha,IdCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método BoarrarTodosLosDetallesPorIdVehiculo", ex);
            }
        }

        public void Existe(DetallesVehiculosServicios detallesVehiculosServicios)
        {
            try
            {
                _repositorio.Existe(detallesVehiculosServicios);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Existe", ex);
            }
        }

        public bool ExistenDetallesParaVehiculoServicio(int idVehiculo, DateTime fecha, int idCliente)
        {
            try
            {
              return _repositorio.ExistenDetallesParaVehiculoServicio(idVehiculo, fecha, idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método ExistenDetallesParaVehiculoServicio", ex);
            }
        }

        public List<DetallesVehiculosServicios> GetDetallesVehiculosServiciosPorIdVehiculoNombreServicioFechaYIdCliente(int IdVehiculo, DateTime Fecha, int IdCliente, string Servicio = null)
        {
            try
            {
                return _repositorio.GetDetallesVehiculosServiciosPorIdVehiculoNombreServicioFechaYIdCliente(IdVehiculo, Fecha, IdCliente,Servicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetDetallesVehiculosServiciosPorIdVehiculoNombreServicioFechaYIdCliente", ex);
            }
        }

        public List<decimal> GetPreciosPorIdVehiculoNombreServicioFechaYIdCliente(int idVehiculo, DateTime fecha, int idCliente, string servicio = null)
        {
            try
            {
                return _repositorio.GetPreciosPorIdVehiculoNombreServicioFechaYIdCliente(idVehiculo, fecha, idCliente, servicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetPreciosPorIdVehiculoNombreServicioFechaYIdCliente", ex);
            }
        }

        public List<ServicioTipoDePago> GetServiciosTipoDePagoPorIdVehiculoNombreServicioFechaYIdCliente(int idVehiculo, DateTime fecha, int idCliente, string servicio = null)
        {
            try
            {
                return _repositorio.GetServiciosTipoDePagoPorIdVehiculoNombreServicioFechaYIdCliente(idVehiculo, fecha, idCliente, servicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetServiciosTipoDePagoPorIdVehiculoNombreServicioFechaYIdCliente", ex);
            }
        }

        public void Guardar(DetallesVehiculosServicios detallesVehiculosServicios)
        {
            try
            {
                if (detallesVehiculosServicios.Id==0)
                {
                    _repositorio.Agregar(detallesVehiculosServicios);
                }
                else
                {
                    _repositorio.Editar(detallesVehiculosServicios);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }
    }
}
