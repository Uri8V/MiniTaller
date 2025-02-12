using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;

namespace MiniTaller.Repositorios.Repositorios
{
    public class RepositorioDeTipoDeCliente : IRepositorioDeTipoCliente
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeTipoDeCliente()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(TiposClientes tipo)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string insertQuery = "INSERT INTO TiposDeClientes (Tipo) VALUES(@Tipo); SELECT SCOPE_IDENTITY()";
                conn.Open();
                using (var comando = new SqlCommand(insertQuery, conn))
                {
                    comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                    comando.Parameters["@Tipo"].Value = tipo.Tipo;

                    int tipoId = Convert.ToInt32(comando.ExecuteScalar());
                    tipo.IdTipoCliente = tipoId;
                }
            }
        }

        public void Borrar(int TipoDeClienteId)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM TiposDeClientes WHERE IdTipoCliente=@IdTipoCliente";
                    using (var comando = new SqlCommand(deleteQuery, conn))
                    {
                        comando.Parameters.Add("@IdTipoCliente", SqlDbType.Int);
                        comando.Parameters["@IdTipoCliente"].Value = TipoDeClienteId;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Editar(TiposClientes tipo)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string updateQuery = "UPDATE TiposDeClientes SET Tipo=@Tipo WHERE IdTipoCliente=@IdTipoCliente";
                    using (var comando = new SqlCommand(updateQuery, conn))
                    {
                        comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                        comando.Parameters["@Tipo"].Value = tipo.Tipo;

                        comando.Parameters.Add("@IdTipoCliente", SqlDbType.Int);
                        comando.Parameters["@IdTipoCliente"].Value = tipo.IdTipoCliente;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool EstaRelacionado(TiposClientes tipo)
        {
            int cantidad = 0;
            using (IDbConnection conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Clientes WHERE IdTipoCliente=@IdTipoCliente";
                cantidad = conn.QuerySingle<int>(selectQuery, new { IdTipoCliente = tipo.IdTipoCliente });
            }
            return cantidad > 0;
        }

        public bool Existe(TiposClientes tipo)
        {
            try
            {
                int cantidad;
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string selectQuery;
                    if (tipo.IdTipoCliente == 0)
                    {
                        selectQuery = "SELECT COUNT(*) FROM TiposDeClientes WHERE Tipo=@Tipo";
                    }
                    else
                    {
                        selectQuery = "SELECT COUNT(*) FROM TiposDeClientes WHERE Tipo=@Tipo AND IdTipoCliente!=@IdTipoCliente";
                    }
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                        comando.Parameters["@Tipo"].Value = tipo.Tipo;

                        if (tipo.IdTipoCliente != 0)
                        {
                            comando.Parameters.Add("@IdTipoCliente", SqlDbType.Int);
                            comando.Parameters["@IdTipoCliente"].Value = tipo.IdTipoCliente;
                        }
                        cantidad = (int)comando.ExecuteScalar();
                    }
                }
                return cantidad > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM TiposDeClientes";
                cantidad = conn.ExecuteScalar<int>(selectQuery);
            }
            return cantidad;
        }

        public TiposClientes GetTipoClientePorId(int tipoId)
        {
            TiposClientes tipo = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                conn.Open();
                string selectQuery = @"SELECT IdTipoCliente, Tipo 
                    FROM TiposDeClientes WHERE IdTipoCliente=@tipoId";

                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@tipoId", SqlDbType.Int);
                    cmd.Parameters["@tipoId"].Value = tipoId;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            tipo = ConstruirTipoDeCliente(reader);
                        }
                    }
                }
            }
            return tipo;
        }

        private TiposClientes ConstruirTipoDeCliente(SqlDataReader reader)
        {
            TiposClientes tipo = new TiposClientes()
            {
                IdTipoCliente = reader.GetInt32(0),
                Tipo = reader.GetString(1)
            };
            return tipo;
        }

        public List<TiposClientes> GetTiposDeClientes()
        {
            List<TiposClientes> lista = new List<TiposClientes>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT IdTipoCliente, Tipo FROM TiposDeClientes
                         ORDER BY Tipo";
                conn.Open();
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tipoDeCliente = ConstruirTipoDeCliente(reader);

                            lista.Add(tipoDeCliente);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
