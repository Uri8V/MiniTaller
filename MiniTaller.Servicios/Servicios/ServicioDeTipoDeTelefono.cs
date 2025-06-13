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
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool EstaRelacionado(TiposDeTelefono tipo)
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

        public bool Existe(TiposDeTelefono tipo)
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

        public TiposDeTelefono GetTipoDeTelefonoPorId(int tipoId)
        {
            try
            {
                return _repo.GetTipoDeTelefonoPorId(tipoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetTipoDeTelefonoPorId", ex);
            }
        }

        public List<TiposDeTelefono> GetTiposDeTelefono()
        {
            try
            {
                return _repo.GetTiposDeTelefono();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetTiposDeTelefono", ex);
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
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }
    }
}
