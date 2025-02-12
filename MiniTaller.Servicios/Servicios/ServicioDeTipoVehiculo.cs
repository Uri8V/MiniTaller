using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Repositorios.Repositorios;
using MiniTaller.Servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicio.Servicios
{
    public class ServicioDeTipoVehiculo:IServicioDeTipoVehiculo
    {
        private readonly IRepositorioDeTipoDeVehiculos _repo;
        public ServicioDeTipoVehiculo()
        {
            _repo = new RepositorioDeTiposDeVehiculos();
        }

        public void Borrar(int TipoDeVehiculoId)
        {
            try
            {
                _repo.Borrar(TipoDeVehiculoId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(TiposDeVehiculos tipo)
        {
            try
            {
                return _repo.EstaRelacionado(tipo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(TiposDeVehiculos tipo)
        {
            try
            {
                return _repo.Existe(tipo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            try
            {
                return _repo.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TiposDeVehiculos GetTipoDeVehiculoPorId(int tipoId)
        {
            try
            {
                return _repo.GetTipoDeVehiculoPorId(tipoId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TiposDeVehiculos> GetTiposDeVehiculo()
        {
            try
            {
                return _repo.GetTiposDeVehiculos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(TiposDeVehiculos tipo)
        {
            try
            {
                if (tipo.IdTipoVehiculo==0)
                {
                    _repo.Agregar(tipo);
                }
                else
                {
                    _repo.Editar(tipo);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
