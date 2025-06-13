using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades;
using MiniTaller.Repositorios.Repositorios;
using MiniTaller.Servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicio.Servicios
{
    public class ServicioDeTipoCliente : IServicioDeTipoCliente
    {
        private IRepositorioDeTipoCliente _repo;
        public ServicioDeTipoCliente()
        {
            _repo = new RepositorioDeTipoDeCliente();
        }
        public void Borrar(int TipoDeClienteId)
        {
            try
            {
                _repo.Borrar(TipoDeClienteId);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool EstaRelacionado(TiposClientes tipo)
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

        public bool Existe(TiposClientes tipo)
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

        public TiposClientes GetTipoClientePorId(int tipoId)
        {
            try
            {
                return _repo.GetTipoClientePorId(tipoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetTipoClientePorId", ex);
            }
        }

        public List<TiposClientes> GetTiposDeClientes()
        {
            try
            {
                return _repo.GetTiposDeClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetTiposDeClientes", ex);
            }
        }

        public void Guardar(TiposClientes tipo)
        {
            try
            {
                if (tipo.IdTipoCliente == 0)
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
