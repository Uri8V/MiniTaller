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
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(TiposDePagos tipo)
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

        public bool Existe(TiposDePagos tipo)
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

        public TiposDePagos GetTipoDePagoPorId(int tipoId)
        {
            try
            {
                return _repo.GetTipoDePagoPorId(tipoId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TiposDePagos> GetTiposDePagos()
        {
            try
            {
                return _repo.GetTiposDePagos();
            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
