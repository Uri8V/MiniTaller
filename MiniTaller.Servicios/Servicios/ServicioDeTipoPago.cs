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
    public class ServicioDeTipoPago:IServicioDeTipoPago
    {
        private readonly IRepositorioDeTiposDePagos _repo;
        public ServicioDeTipoPago()
        {
            _repo = new RepositorioDeTiposDePagos();
        }

        public void Borrar(int TipoDePagoId)
        {
            try
            {
                _repo.Borrar(TipoDePagoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool EstaRelacionado(TiposDePagos tipo)
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

        public bool Existe(TiposDePagos tipo)
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

        public TiposDePagos GetTipoDePagoPorId(int tipoId)
        {
            try
            {
                return _repo.GetTipoDePagoPorId(tipoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetTipoDePagoPorId", ex);
            }
        }

        public List<TiposDePagos> GetTiposDePagos()
        {
            try
            {
                return _repo.GetTiposDePagos();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetTiposDePagos", ex);
            }
        }

        public void Guardar(TiposDePagos tipo)
        {
            try
            {
                if (tipo.IdTipoPago==0)
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
