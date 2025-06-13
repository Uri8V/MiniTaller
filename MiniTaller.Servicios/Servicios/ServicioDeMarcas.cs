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
    public class ServicioDeMarcas:IServicioDeMarcas
    {
        private readonly IRepositorioDeMarcas _repo;
        public ServicioDeMarcas()
        {
            _repo = new RepositorioDeMarcas();
        }

        public void Borrar(int MarcaId)
        {
            try
            {
                _repo.Borrar(MarcaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool EstaRelacionado(Marcas marca)
        {
            try
            {
                return _repo.EstaRelacionado(marca);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método EstaRelacionado", ex);
            }
        }

        public bool Existe(Marcas marca)
        {
            try
            {
                return _repo.Existe(marca);
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

        public Marcas GetMarcaPorId(int marcaId)
        {
            try
            {
                return _repo.GetMarcaPorId(marcaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetMarcaPorId", ex);
            }
        }

        public List<Marcas> GetMarcas()
        {
            try
            {
                return _repo.GetMarcas();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetMarcas", ex);
            }
        }

        public void Guardar(Marcas marca)
        {
            try
            {
                if (marca.IdMarca==0)
                {
                    _repo.Agregar(marca);
                }
                else
                {
                    _repo.Editar(marca);    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }
    }
}
