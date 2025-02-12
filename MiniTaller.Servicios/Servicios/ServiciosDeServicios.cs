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
    public class ServiciosDeServicios:IServicioDeServicios
    {
        private readonly IRepositorioDeServicios _repo;
        public ServiciosDeServicios()
        {
            _repo = new RepositorioDeServicios();
        }

        public void Borrar(int IdServicios)
        {
            try
            {
                _repo.Borrar(IdServicios);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Servicioss servicios)
        {
            try
            {
                return _repo.EstaRelacionada(servicios);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Servicioss servicios)
        {
            try
            {
                return _repo.Existe(servicios);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(int? IdTipoPago)
        {
            try
            {
               return _repo.GetCantidad(IdTipoPago);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ServiciosComboDto> GetServiciosCombos()
        {
            try
            {
                return _repo.GetServiciosCombos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Servicioss GetServiciosPorId(int IdServicio)
        {
            try
            {
                return _repo.GetServiciosPorId(IdServicio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ServiciosDto> GetServiciosPorPagina(int registrosPorPagina, int paginaActual, int? IdTipoDePago)
        {
            try
            {
               return _repo.GetServiciosPorPagina(registrosPorPagina, paginaActual, IdTipoDePago);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Servicioss servicios)
        {
            try
            {
                if (servicios.IdServicio==0)
                {
                    _repo.Agregar(servicios);
                }
                else
                {
                    _repo.Editar(servicios);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
