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
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Clientes cliente)
        {
            try
            {
                return _repo.EstaRelacionada(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Clientes cliente)
        {
            try
            {
                return _repo.Existe(cliente);
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

        public Clientes GetClientePorId(int IdCliente)
        {
            try
            {
                return _repo.GetClientePorId(IdCliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClientesComboDto> GetClientesCombos()
        {
            try
            {
                return _repo.GetClientesCombos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClientesComboDto> GetClientesCombosEmpresa()
        {
            try
            {
                return _repo.GetClientesCombosEmpresa();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClientesDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual, int? IdTipoCliente)
        {
            try
            {
                return _repo.GetClientesPorPagina(registrosPorPagina, paginaActual, IdTipoCliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetInfo(int IdCliente)
        {
            try
            {
                return _repo.GetInfo(IdCliente);
            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
