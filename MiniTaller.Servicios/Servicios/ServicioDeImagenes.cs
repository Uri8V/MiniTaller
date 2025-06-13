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
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool Existe(Imagenes img)
        {
            try
            {
                return _repo.Existe(img);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Existe", ex);
            }
        }

        public int GetCantidad(int? IdObservacion, int? IdVehiculoServico)
        {
            try
            { 
                return _repo.GetCantidad(IdObservacion, IdVehiculoServico);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetCantidad", ex);
            }
        }

        public List<ImagenesDto> GetImagenesPorPagina(int registrosPorPagina, int paginaActual, int? IdObservacion, int? IdVehiculoServicio)
        {
            try
            {
                return _repo.GetImagenesPorPagina(registrosPorPagina, paginaActual, IdObservacion, IdVehiculoServicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetImaginesPorPagina", ex);
            }
        }

        public Imagenes GetImagenPorId(int marcaId)
        {
            try
            {
                return _repo.GetImagenPorId(marcaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetImagenPorId", ex);
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
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }
    }
}
