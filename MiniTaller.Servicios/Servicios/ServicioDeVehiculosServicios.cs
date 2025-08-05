using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Repositorios.Repositorios;
using MiniTaller.Servicios.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTaller.Servicios.Servicios
{
    public class ServicioDeVehiculosServicios : IServicioDeVehiculosServicios
    {
        private readonly IRepositorioDeVehiculosServicios _repo;
        private IServicioDeServicios _servicioDeServicios;
        private IServicioDeVehiculos _servicioDeVehiculos;
        private IServicioDeDetallesVehiculosServicios detallesVehiculosServicios;
        public ServicioDeVehiculosServicios()
        {
            _repo = new RepositorioDeVehiculosServicios();
            _servicioDeServicios= new ServiciosDeServicios();
            _servicioDeVehiculos = new ServicioDeVehiculos();
            detallesVehiculosServicios = new ServicioDeDetallesVehiculosServicios();
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
                return _repo.GetCantidad(IdVehiculo, IdServicio, IdCliente, FechaServicios, Yapago);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetCantidad", ex);
            }
        }

        public VehiculoServicioComboDto GetServiciosCombo(int IdVehiculoServicio)
        {
            try
            {
                return _repo.GetServiciosCombo(IdVehiculoServicio);
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
                throw new Exception("Oh no algo no salio bien en el método GetVehiculoServicioPorCliente", ex);
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

        public void Guardar(VehiculosServicios vehiculosServicios, List<ServicioTipoDePago> listaDeServicios, List<decimal> listaDePrecios, DateTime? dateTime)
        {
            List<DetallesVehiculosServicios> detalles= new List<DetallesVehiculosServicios>();
            try
            {
                var haber = vehiculosServicios.Haber;
                if (vehiculosServicios.IdVehiculoServicio==0)
                {
                    if (!Existe(vehiculosServicios))
                    {
                        _repo.Agregar(vehiculosServicios);
                        MessageBox.Show($"Se ha agregado satisfactoriamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (var i = 0; i < listaDeServicios.Count(); i++)
                        {
                            var detalle = new DetallesVehiculosServicios
                            {
                                IdVehiculoServicio = vehiculosServicios.IdVehiculoServicio,
                                IdServicioTipoDePago = listaDeServicios[i].IdServicioTipoDePago,
                                Debe = listaDePrecios[i],
                                Pago = 0,
                                FechaPago = vehiculosServicios.Fecha
                            };
                            haber = ControlDePago(detalle, listaDePrecios, haber, i);
                            detallesVehiculosServicios.Guardar(detalle);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Ya se realizó este registro", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    for (var i = 0; i < listaDeServicios.Count(); i++)
                    {
                        detalles = detallesVehiculosServicios.GetDetallesVehiculosServiciosPorIdVehiculoNombreServicioFechaYIdCliente(vehiculosServicios.IdVehiculo, vehiculosServicios.Fecha, vehiculosServicios.IdCliente, _servicioDeServicios.GetServiciosPorId(listaDeServicios[i].IdServicio).Servicio);
                        detalles[0].Debe = listaDePrecios[i];
                        detalles[0].IdVehiculoServicio = vehiculosServicios.IdVehiculoServicio;
                        detalles[0].IdServicioTipoDePago = listaDeServicios[i].IdServicioTipoDePago;
                        detalles[0].FechaPago = dateTime.Value.Date;
                        haber = ControlDePago(detalles[0], listaDePrecios, haber, i);
                        detallesVehiculosServicios.Guardar(detalles[0]);
                    }
                    if (!_repo.Existe(vehiculosServicios))
                    {
                        _repo.Editar(vehiculosServicios);
                        _repo.ActualizarHaberTotal(vehiculosServicios.IdVehiculoServicio);
                        MessageBox.Show($"Se ha edito satisfactoriamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Ya se realizó este registro", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }

        private static decimal ControlDePago(DetallesVehiculosServicios detalle, List<decimal> listaDePrecios, decimal haber, int i)
        {
            if (haber != 0)
            {
                if (detalle.Debe < haber)
                {
                    haber -= listaDePrecios[i];
                    detalle.Pago = detalle.Debe;
                }
                else
                {
                    detalle.Pago = haber;
                    haber = 0;
                }
            }
            else
            {
                detalle.Pago = 0;
            }
            return haber;
        }

        public List<VehiculosServicios> GetVehiculosServiciosPorIdClienteIdVehiculoYFecha(int IdVehiculo, int IdCliente, DateTime Fecha)
        {
            try
            {
                return _repo.GetVehiculosServiciosPorIdClienteIdVehiculoYFecha(IdVehiculo, IdCliente, Fecha);
            }
            catch (Exception ex)
            {
              throw new Exception("Oh no algo no salio bien en el método GetVehiculosServiciosPorIdClienteIdVehiculoYFecha", ex);
            }
        }

        public bool ExistenImagenesParaVehiculoServicio(int idVehiculoServicio)
        {
            try
            {
                return _repo.ExistenImagenesParaVehiculoServicio(idVehiculoServicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método ExistenImagenesParaVehiculoServicio", ex);
            }
        }

        public void ActualizarHaberTotal(int idVehiculoServicio)
        {
            try
            {
                _repo.ActualizarHaberTotal(idVehiculoServicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método ActualizarHaberTotal", ex);
            }
        }
    }
}
