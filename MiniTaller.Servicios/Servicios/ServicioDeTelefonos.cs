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
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool Existe(Telefonos telefono)
        {
            try
            {
                return _repo.Existe(telefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Existe", ex);
            }
        }

        public int GetCantidad(int? IdCliente, int? IdTipoDeTelefono)
        {
            try
            {
                return _repo.GetCantidad(IdCliente, IdTipoDeTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetCantidad", ex);
            }
        }

        public Telefonos GetTelefonoPorId(int IdTelefono)
        {
            try
            {
                return _repo.GetTelefonoPorId(IdTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetTelefonoPorId", ex);
            }
        }

        public List<TelefonosDto> GetTelefonosPorPagina(int registrosPorPagina, int paginaActual, int? IdCliente, int? IdTipoDeTelefono)
        {
            try
            {
                return _repo.GetTelefonosPorPagina(registrosPorPagina, paginaActual, IdCliente, IdTipoDeTelefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetTelefonosPorPagina", ex);
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
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }
    }
}
