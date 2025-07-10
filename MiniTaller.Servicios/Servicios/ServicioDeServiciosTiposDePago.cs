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
    public class ServicioDeServiciosTiposDePago : IServicioDeServiciosTiposDePago
    {
        private readonly IRepositorioDeServiciosTiposDePago _repo;
        public ServicioDeServiciosTiposDePago()
        {
            _repo = new RepositorioDeServiciosTiposDePago();
        }
        public void Borrar(int IdServicioTipoDePago)
        {
            try
            {
                _repo.Borrar(IdServicioTipoDePago);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool EstaRelacionado(ServicioTipoDePago servicioTipoDePago)
        {
            try
            {
                return _repo.EstaRelacionado(servicioTipoDePago);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método EstaRelacionado", ex);
            }
        }

        public bool Existe(ServicioTipoDePago servicioTipoDePago)
        {
            try
            {
                return _repo.Existe(servicioTipoDePago);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Existe", ex);
            }
        }

        public int GetCantidad(int? IdTipoPago, int? IdServicio)
        {
            try
            {
                return _repo.GetCantidad(IdTipoPago, IdServicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetCantidad", ex);
            }
        }

        public List<ServicioTipoDePagoComboDto> GetServiciosTiposDePagoCombo()
        {
            try
            {
                return _repo.GetServiciosTiposDePagoCombo();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetServiciosCombo", ex);
            }
        }

        public ServicioTipoDePago GetServicioTipoDePagoPorId(int IdServicioTipoDePago)
        {
            try
            {
                return _repo.GetServicioTipoDePagoPorId(IdServicioTipoDePago);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetVehiculoServicioPorId", ex);
            }
        }

        public List<ServicioTipoDePagoDto> GetServiciosTiposDePagoPorPagina(int registrosPorPagina, int paginaActual, int? IdTipoPago, int? IdServicio)
        {
            try
            {
                return _repo.GetServiciosTiposDePagoPorPagina(registrosPorPagina, paginaActual, IdTipoPago, IdServicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetServiciosTiposDePagoPorPagina", ex);
            }
        }

        public void Guardar(ServicioTipoDePago servicioTipoDePago)
        {
            try
            {
                if (servicioTipoDePago.IdServicioTipoDePago == 0)
                {
                    _repo.Agregar(servicioTipoDePago);
                }
                else
                {
                    _repo.Editar(servicioTipoDePago);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }

        public List<ServicioTipoDePagoDto> GetServiciosTiposDePagoPorPagina()
        {
            try
            {
                return _repo.GetServiciosTiposDePagoPorPagina();
            }
            catch (Exception ex)
            {

                throw new Exception("Oh no algo no salio bien en el método GetServiciosTiposDePagoPorPagina()", ex);
            }
        }
    }
}
