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
    public class ServicioDeClientes:IServicioDeClientes
    {
        private readonly IRepositorioDeClientes _repo;
        public ServicioDeClientes()
        {
            _repo = new RepositorioDeClientes();
        }

        public void Borrar(int IdCliente)
        {
            try
            {
                _repo.Borrar(IdCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Borrar", ex);
            }
        }

        public bool EstaRelacionada(Clientes cliente)
        {
            try
            {
                return _repo.EstaRelacionada(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método EstaRelacionada", ex);
            }
        }

        public bool Existe(Clientes cliente)
        {
            try
            {
                return _repo.Existe(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Existe", ex);
            }
        }

        public int GetCantidad(int? IdCliente)
        {
            try
            {
                return _repo.GetCantidad(IdCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetCantidad", ex);
            }
        }

        public Clientes GetClientePorId(int IdCliente)
        {
            try
            {
                return _repo.GetClientePorId(IdCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetClientePorId",ex);
            }
        }

        public List<ClientesComboDto> GetClientesCombos()
        {
            try
            {
                return _repo.GetClientesCombos();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetClientesCombos", ex);
            }
        }

        public List<ClientesComboDto> GetClientesCombosEmpresa()
        {
            try
            {
                return _repo.GetClientesCombosEmpresa();
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetClientsCombosEmpresas", ex);
            }
        }

        public List<ClientesDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual, int? IdTipoCliente)
        {
            try
            {
                return _repo.GetClientesPorPagina(registrosPorPagina, paginaActual, IdTipoCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetClientesPorPagina", ex);
            }
        }

        public string GetInfo(int IdCliente)
        {
            try
            {
                return _repo.GetInfo(IdCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método GetInfo", ex);
            }
        }

        public void Guardar(Clientes cliente)
        {
            try
            {
                if (cliente.IdCliente==0)
                {
                    _repo.Agregar(cliente);
                }
                else
                {
                    _repo.Editar(cliente);  
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Oh no algo no salio bien en el método Guardar", ex);
            }
        }
    }
}
