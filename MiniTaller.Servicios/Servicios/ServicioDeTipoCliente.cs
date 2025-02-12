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
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(TiposClientes tipo)
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

        public bool Existe(TiposClientes tipo)
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

        public TiposClientes GetTipoClientePorId(int tipoId)
        {
            return _repo.GetTipoClientePorId(tipoId);
        }

        public List<TiposClientes> GetTiposDeClientes()
        {
           return _repo.GetTiposDeClientes();   
        }

        public void Guardar(TiposClientes tipo)
        {
            try
            {
                if (tipo.IdTipoCliente==0)
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
