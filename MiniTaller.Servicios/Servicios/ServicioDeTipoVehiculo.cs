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
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool EstaRelacionado(TiposDeVehiculos tipo)
        {
            try
            {
                return _repo.EstaRelacionado(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método EstaRelacionado", ex);
            }
        }

        public bool Existe(TiposDeVehiculos tipo)
        {
            try
            {
                return _repo.Existe(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Existe", ex);
            }
        }

        public int GetCantidad()
        {
            try
            {
                return _repo.GetCantidad();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetCantidad", ex);
            }
        }

        public TiposDeVehiculos GetTipoDeVehiculoPorId(int tipoId)
        {
            try
            {
                return _repo.GetTipoDeVehiculoPorId(tipoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetTiposDeVehiculoPorId", ex);
            }
        }

        public List<TiposDeVehiculos> GetTiposDeVehiculo()
        {
            try
            {
                return _repo.GetTiposDeVehiculos();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetTiposDeVehiculo", ex);
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
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }
    }
}
