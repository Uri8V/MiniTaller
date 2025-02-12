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
    public class ServicioDeTelefonos:IServicioDeTelefonos
    {
        private readonly IRepositorioDeTelefonos _repo;
        public ServicioDeTelefonos()
        {
            _repo = new RepositorioDeTelefonos();
        }

        public void Borrar(int telefonoId)
        {
            try
            {
                _repo.Borrar(telefonoId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Telefonos telefono)
        {
            try
            {
                return _repo.Existe(telefono);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(int? IdCliente)
        {
            try
            {
                return _repo.GetCantidad(IdCliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Telefonos GetTelefonoPorId(int IdTelefono)
        {
            try
            {
                return _repo.GetTelefonoPorId(IdTelefono);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TelefonosDto> GetTelefonosPorPagina(int registrosPorPagina, int paginaActual, int? IdCliente)
        {
            try
            {
                return _repo.GetTelefonosPorPagina(registrosPorPagina, paginaActual, IdCliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Telefonos telefono)
        {
            try
            {
                if (telefono.IdTelefono==0)
                {
                    _repo.Agregar(telefono);
                }
                else
                {
                    _repo.Editar(telefono);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
