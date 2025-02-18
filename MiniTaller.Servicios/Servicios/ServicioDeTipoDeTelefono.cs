using MiniTaller.Comun.Interfaces;
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
    public class ServicioDeTipoDeTelefono:IServicioDeTipoDeTelefono
    {
        private readonly IRepositorioDeTiposDeTelefono _repo;

        public ServicioDeTipoDeTelefono()
        {
            _repo = new RepositorioDeTipoDeTelefono();
        }

        public void Borrar(int IdTipoDeTelefono)
        {
            try
            {
                _repo.Borrar(IdTipoDeTelefono);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(TiposDeTelefono tipo)
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

        public bool Existe(TiposDeTelefono tipo)
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

        public TiposDeTelefono GetTipoDeTelefonoPorId(int tipoId)
        {
            try
            {
                return _repo.GetTipoDeTelefonoPorId(tipoId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TiposDeTelefono> GetTiposDeTelefono()
        {
            try
            {
                return _repo.GetTiposDeTelefono();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(TiposDeTelefono tipo)
        {
            try
            {
                if (tipo.IdTipoDeTelefono==0)
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
