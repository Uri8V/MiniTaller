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
    public class ServicioDeVehiculos:IServicioDeVehiculos
    {
        private readonly IRepositorioDeVehiculos _repo;
        public ServicioDeVehiculos()
        {
            _repo = new RepositorioDeVehiculos();
        }

        public void Borrar(int IdVehiculo)
        {
            try
            {
                _repo.Borrar(IdVehiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Vehiculos vehiculos)
        {
            try
            {
                return _repo.EstaRelacionada(vehiculos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Vehiculos vehiculos)
        {
            try
            {
                return _repo.Existe(vehiculos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(int? IdModleo, int? IdTipoVehiculo)
        {
            try
            {
                return _repo.GetCantidad(IdModleo, IdTipoVehiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VehiculosComboDto> GetVehiculosCombos()
        {
            try
            {
                return _repo.GetVehiculosCombos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Vehiculos GetVehiculosPorId(int IdVehiculo)
        {
            try
            {
                return _repo.GetVehiculosPorId(IdVehiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VehiculosDto> GetVehiculosPorPagina(int registrosPorPagina, int paginaActual, int? IdModelo, int? IdTipoVehiculo)
        {
            try
            {
                return _repo.GetVehiculosPorPagina(registrosPorPagina, paginaActual, IdModelo, IdTipoVehiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Vehiculos vehiculos)
        {
            try
            {
                if (vehiculos.IdVehiculo==0)
                {
                    _repo.Agregar(vehiculos);
                }
                else
                {
                    _repo.Editar(vehiculos);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
