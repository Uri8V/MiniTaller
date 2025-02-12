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
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Modelos modelos)
        {
            try
            {
                return _repo.EstaRelacionada(modelos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Modelos modelos)
        {
            try
            {
                return _repo.Existe(modelos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(int? IdMarca)
        {
            try
            {
                return _repo.GetCantidad(IdMarca);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ModelosComboDto> GetModelosCombos()
        {
            try
            {
               return _repo.GetModelosCombos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Modelos GetModelosPorId(int IdModelo)
        {
            try
            {
                return _repo.GetModelosPorId(IdModelo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ModelosDto> GetModelosPorPagina(int registrosPorPagina, int paginaActual, int? marca)
        {
            try
            {
                return _repo.GetModelosPorPagina(registrosPorPagina, paginaActual, marca);
            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
