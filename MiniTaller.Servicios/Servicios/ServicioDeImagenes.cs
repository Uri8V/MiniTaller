using MiniTaller.Comun.Interfaces;
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
    public class ServicioDeImagenes:IServicioDeImagenes
    {
        public IRepositorioDeImagenes _repo;
        public ServicioDeImagenes()
        {
            _repo = new RepositorioDeImagenes();
        }

        public void Borrar(int IdImage)
        {
            try
            {
                _repo.Borrar(IdImage);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Imagenes img)
        {
            try
            {
                return _repo.Existe(img);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(int? IdObservacion, int? IdVehiculoServico)
        {
            try
            { //Hay un error
                return _repo.GetCantidad(IdObservacion, IdVehiculoServico);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ImagenesDto> GetImagenesPorPagina(int registrosPorPagina, int paginaActual, int? IdObservacion, int? IdVehiculoServicio)
        {
            try
            {
                return _repo.GetImagenesPorPagina(registrosPorPagina, paginaActual, IdObservacion, IdVehiculoServicio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Imagenes GetImagenPorId(int marcaId)
        {
            try
            {
                return _repo.GetImagenPorId(marcaId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Imagenes img)
        {
            try
            {
                if (img.IdImage==0)
                {
                    _repo.Agregar(img);
                }
                else
                {
                    _repo.Editar(img);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
