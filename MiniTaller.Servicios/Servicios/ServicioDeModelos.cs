using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
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
    public class ServicioDeModelos:IServicioDeModelos
    {
        private readonly IRepositorioDeModelos _repo;
        public ServicioDeModelos()
        {
            _repo = new RepositorioDeModelos();
        }

        public void Borrar(int modeloId)
        {
            try
            {
                _repo.Borrar(modeloId);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool EstaRelacionada(Modelos modelos)
        {
            try
            {
                return _repo.EstaRelacionada(modelos);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método EstaRelacionado", ex);
            }
        }

        public bool Existe(Modelos modelos)
        {
            try
            {
                return _repo.Existe(modelos);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Existe", ex);
            }
        }

        public int GetCantidad(int? IdMarca)
        {
            try
            {
                return _repo.GetCantidad(IdMarca);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetCantidad", ex);
            }
        }

        public List<ModelosComboDto> GetModelosCombos()
        {
            try
            {
               return _repo.GetModelosCombos();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetModelosCombos", ex);
            }
        }

        public Modelos GetModelosPorId(int IdModelo)
        {
            try
            {
                return _repo.GetModelosPorId(IdModelo);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetModelosPorId", ex);
            }
        }

        public List<ModelosDto> GetModelosPorPagina(int registrosPorPagina, int paginaActual, int? marca)
        {
            try
            {
                return _repo.GetModelosPorPagina(registrosPorPagina, paginaActual, marca);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetModelosPorPagina", ex);
            }
        }

        public void Guardar(Modelos modelos)
        {
            try
            {
                if (modelos.IdModelo==0)
                {
                    _repo.Agregar(modelos);
                }
                else
                {
                    _repo.Editar(modelos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }
    }
}
