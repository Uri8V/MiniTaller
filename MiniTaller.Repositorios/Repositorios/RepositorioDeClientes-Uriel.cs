using Dapper;
using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Repositorios.Repositorios
{
    public class RepositorioDeClientes:IRepositorioDeClientes
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeClientes()
        {
            cadenaDeConexion= ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Clientes cliente)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"INSERT INTO Clientes (Nombre, Apellido, Documento, Domicilio, CUIT, IdTipoCliente) 
                                    Values (@Nombre, @Apellido, @Documento, @Domicilio, @CUIT, @IdTipoCliente); SELECT SCOPE_IDENTITY();";
                int id = conn.ExecuteScalar<int>(selectQuery, cliente);
                cliente.IdCliente = id;
            }
        }

        public void Borrar(int IdCliente)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string deleteQuery = "DELETE FROM Clientes WHERE IdCliente=@IdCliente";
                conn.Execute(deleteQuery, new { IdCliente = IdCliente });
            }
        }

        public void Editar(Clientes cliente)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string updateQuery = @"UPDATE Clientes SET Nombre=@Nombre, Apellido=@Apellido, Documento=@Documento, Domicilio=@Domicilio, CUIT=@CUIT,
                    IdTipoCliente=@IdTipoCliente WHERE IdCliente=@IdCliente";
                conn.Execute(updateQuery, cliente);
            }
        }

        public bool EstaRelacionada(Clientes cliente)
        {
            int cantidadTelefonoss = 0;
            int cantidadVehiculosServicios = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM Telefonos WHERE IdCliente=@IdCliente
                                       SELECT COUNT(*) FROM VehiculosServicios WHERE IdCliente = @IdCliente";
                using (var resultado = conn.QueryMultiple(selectQuery, new { IdCliente = cliente.IdCliente }))
                {
                    cantidadTelefonoss = resultado.Read<int>().First();
                    cantidadVehiculosServicios = resultado.Read<int>().First();
                }
            }
            return cantidadTelefonoss + cantidadVehiculosServicios > 0;

        }

        public bool Existe(Clientes cliente)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (cliente.IdCliente == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Clientes 
                            WHERE Documento=@Documento AND CUIT=@CUIT";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Documento = cliente.Documento, CUIT = cliente.CUIT });
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Clientes 
                WHERE Documento=@Documento AND CUIT=@CUIT AND IdCliente!=@IdCliente";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Documento = cliente.Documento, CUIT = cliente.CUIT, IdCliente = cliente.IdCliente });
                }
            }
            return cantidad > 0;
        }

        public int GetCantidad(int? IdTipocliente)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if ( IdTipocliente== null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Clientes";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Clientes 
                        WHERE IdTipoCliente=@IdTipoCliente";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdTipoCliente = IdTipocliente });
                }
            }
            return cantidad;
        }

        public Clientes GetClientePorId(int IdCliente)
        {
            Clientes cliente = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT IdCliente, Nombre, Apellido, Documento, Domicilio, CUIT, IdTipoCliente 
                    FROM Clientes WHERE IdCliente=@IdCliente";
                cliente = conn.QuerySingleOrDefault<Clientes>(selectQuery,
                    new { IdCliente = IdCliente });
            }
            return cliente;
        }

        public List<ClientesComboDto> GetClientesCombos()
        {
            List<ClientesComboDto> lista = new List<ClientesComboDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT c.IdCliente, CONCAT(UPPER(c.Apellido),'  ',c.Nombre,' (',c.Documento,')')AS Info FROM Clientes c WHERE c.CUIT=''; ";
                lista = conn.Query<ClientesComboDto>(selectQuery).ToList();
            }
            return lista;
        }

        public List<ClientesComboDto> GetClientesCombosEmpresa()
        {
            List<ClientesComboDto> lista = new List<ClientesComboDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT c.IdCliente, CONCAT(UPPER(c.Apellido),'  ',c.Nombre,' (',c.CUIT,')')AS Info FROM Clientes c WHERE c.Documento=''; ";
                lista = conn.Query<ClientesComboDto>(selectQuery).ToList();
            }
            return lista;
        }

        public List<ClientesDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual, int? IdTipoCliente)
        {
            List<ClientesDto> lista = new List<ClientesDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT c.IdCLiente,c.Nombre,c.Apellido,c.Documento,c.Domicilio, c.CUIT, t.Tipo");
                selectQuery.AppendLine("FROM Clientes c");
                selectQuery.AppendLine("INNEr JOIN TiposDeClientes t ON c.IdTipoCliente = t.IdTipoCliente");

                if (IdTipoCliente != null)
                {
                    selectQuery.AppendLine("WHERE t.IdTipoCliente = @IdTipoCliente ");
                }
                selectQuery.AppendLine("ORDER BY t.Tipo, c.Nombre, c.Apellido");
                selectQuery.AppendLine("OFFSET @cantidadRegistros ROWS FETCH NEXT @CantidadPorPagina ROWS ONLY");

                var parametros = new
                {
                    IdTipoCliente,
                    cantidadRegistros = registrosPorPagina * (paginaActual - 1),
                    cantidadPorPagina = registrosPorPagina
                };
                lista = conn.Query<ClientesDto>(selectQuery.ToString(), parametros).ToList();
            }
            return lista;
        }
    }
}
