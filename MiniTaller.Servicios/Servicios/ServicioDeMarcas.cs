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
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Marcas marca)
        {
            try
            {
                return _repo.EstaRelacionado(marca);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Marcas marca)
        {
            try
            {
                return _repo.Existe(marca);
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

        public Marcas GetMarcaPorId(int marcaId)
        {
            try
            {
                return _repo.GetMarcaPorId(marcaId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Marcas> GetMarcas()
        {
            try
            {
                return _repo.GetMarcas();
            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
