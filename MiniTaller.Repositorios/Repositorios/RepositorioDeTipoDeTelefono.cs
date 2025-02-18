using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MiniTaller.Comun.Interfaces;

namespace MiniTaller.Repositorios.Repositorios
{
    public class RepositorioDeTipoDeTelefono : IRepositorioDeTiposDeTelefono
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeTipoDeTelefono()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(TiposDeTelefono tipo)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string insertQuery = "INSERT INTO TiposDeTelefono (Tipo) VALUES(@Tipo); SELECT SCOPE_IDENTITY()";
                conn.Open();
                using (var comando = new SqlCommand(insertQuery, conn))
                {
                    comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                    comando.Parameters["@Tipo"].Value = tipo.Tipo;

                    int tipoId = Convert.ToInt32(comando.ExecuteScalar());
                    tipo.IdTipoDeTelefono = tipoId;
                }
            }
        }

        public void Borrar(int IdTipoDeTelefono)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM TiposDeTelefono WHERE IdTipoDeTelefono=@IdTipoDeTelefono";
                    using (var comando = new SqlCommand(deleteQuery, conn))
                    {
                        comando.Parameters.Add("@IdTipoDeTelefono", SqlDbType.Int);
                        comando.Parameters["@IdTipoDeTelefono"].Value = IdTipoDeTelefono;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Editar(TiposDeTelefono tipo)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string updateQuery = "UPDATE TiposDeTelefono SET Tipo=@Tipo WHERE IdTipoDeTelefono=@IdTipoDeTelefono";
                    using (var comando = new SqlCommand(updateQuery, conn))
                    {
                        comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                        comando.Parameters["@Tipo"].Value = tipo.Tipo;

                        comando.Parameters.Add("@IdTipoDeTelefono", SqlDbType.Int);
                        comando.Parameters["@IdTipoDeTelefono"].Value = tipo.IdTipoDeTelefono;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(TiposDeTelefono tipo)
        {
            int cantidad = 0;
            using (IDbConnection conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Telefonos WHERE IdTipoDeTelefono=@IdTipoDeTelefono";
                cantidad = conn.QuerySingle<int>(selectQuery, new { IdTipoDeTelefono = tipo.IdTipoDeTelefono });
            }
            return cantidad > 0;
        }

        public bool Existe(TiposDeTelefono tipo)
        {
            try
            {
                int cantidad;
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string selectQuery;
                    if (tipo.IdTipoDeTelefono == 0)
                    {
                        selectQuery = "SELECT COUNT(*) FROM TiposDeTelefono WHERE Tipo=@Tipo";
                    }
                    else
                    {
                        selectQuery = "SELECT COUNT(*) FROM TiposDeTelefono WHERE Tipo=@Tipo AND IdTipoDeTelefono!=@IdTipoDeTelefono";
                    }
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                        comando.Parameters["@Tipo"].Value = tipo.Tipo;

                        if (tipo.IdTipoDeTelefono != 0)
                        {
                            comando.Parameters.Add("@IdTipoDeTelefono", SqlDbType.Int);
                            comando.Parameters["@IdTipoDeTelefono"].Value = tipo.IdTipoDeTelefono;
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
                string selectQuery = "SELECT COUNT(*) FROM TiposDeTelefono";
                cantidad = conn.ExecuteScalar<int>(selectQuery);

            }
            return cantidad;
        }

        public TiposDeTelefono GetTipoDeTelefonoPorId(int tipoId)
        {
            TiposDeTelefono tipo = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                conn.Open();
                string selectQuery = @"SELECT IdTipoDeTelefono,Tipo
                    FROM TiposDeTelefono WHERE IdTipoDeTelefono=@IdTipoDeTelefono";

                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@IdTipoDeTelefono", SqlDbType.Int);
                    cmd.Parameters["@IdTipoDeTelefono"].Value = tipoId;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            tipo = ConstruirTipoDeTelefono(reader);
                        }
                    }
                }
            }
            return tipo;
        }

        public List<TiposDeTelefono> GetTiposDeTelefono()
        {
            List<TiposDeTelefono> lista = new List<TiposDeTelefono>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT IdTipoDeTelefono, Tipo FROM TiposDeTelefono
                         ORDER BY Tipo";
                conn.Open();
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tipoDeTelefono = ConstruirTipoDeTelefono(reader);
                            lista.Add(tipoDeTelefono);
                        }
                    }
                }
            }
            return lista;
        }

        private TiposDeTelefono ConstruirTipoDeTelefono(SqlDataReader reader)
        {
            TiposDeTelefono tipo = new TiposDeTelefono()
            {
                IdTipoDeTelefono = reader.GetInt32(0),
                Tipo = reader.GetString(1)
            };
            return tipo;
        }
    }
}
