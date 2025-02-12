using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper;

namespace MiniTaller.Repositorios.Repositorios
{
    public class RepositorioDeMarcas:IRepositorioDeMarcas
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeMarcas()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Marcas tipo)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string insertQuery = "INSERT INTO Marcas (Marca) VALUES(@Marca); SELECT SCOPE_IDENTITY()";
                conn.Open();
                using (var comando = new SqlCommand(insertQuery, conn))
                {
                    comando.Parameters.Add("@Marca", SqlDbType.NVarChar);
                    comando.Parameters["@Marca"].Value = tipo.Marca;

                    int MarcaId = Convert.ToInt32(comando.ExecuteScalar());
                    tipo.IdMarca = MarcaId;
                }
            }

        }

        public void Borrar(int MarcaId)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Marcas WHERE IdMarca=@IdMarca";
                    using (var comando = new SqlCommand(deleteQuery, conn))
                    {
                        comando.Parameters.Add("@IdMarca", SqlDbType.Int);
                        comando.Parameters["@IdMarca"].Value = MarcaId;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Editar(Marcas marca)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Marcas SET Marca=@Marca WHERE IdMarca=@IdMarca";
                    using (var comando = new SqlCommand(updateQuery, conn))
                    {
                        comando.Parameters.Add("@Marca", SqlDbType.NVarChar);
                        comando.Parameters["@Marca"].Value = marca.Marca;

                        comando.Parameters.Add("@IdMarca", SqlDbType.Int);
                        comando.Parameters["@IdMarca"].Value = marca.IdMarca;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool EstaRelacionado(Marcas marca)
        {
            int cantidad = 0;
            using (IDbConnection conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Modelos WHERE IdMarca=@IdMarca";
                cantidad = conn.QuerySingle<int>(selectQuery, new { IdMarca = marca.IdMarca });
            }
            return cantidad > 0;
        }

        public bool Existe(Marcas marca)
        {
            try
            {
                int cantidad;
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string selectQuery;
                    if (marca.IdMarca == 0)
                    {
                        selectQuery = "SELECT COUNT(*) FROM Marcas WHERE Marca=@Marca";
                    }
                    else
                    {
                        selectQuery = "SELECT COUNT(*) FROM Marcas WHERE Marca=@Marca AND IdMarca!=@IdMarca";
                    }
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.Add("@Marca", SqlDbType.NVarChar);
                        comando.Parameters["@Marca"].Value = marca.Marca;

                        if (marca.IdMarca != 0)
                        {
                            comando.Parameters.Add("@IdMarca", SqlDbType.Int);
                            comando.Parameters["@IdMarca"].Value = marca.IdMarca;
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
                string selectQuery;
                    selectQuery = "SELECT COUNT(*) FROM Marcas";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                
            }
            return cantidad;
        }

        public Marcas GetMarcaPorId(int IdMarca)
        {
            Marcas marca = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                conn.Open();
                string selectQuery = @"SELECT IdMarca, Marca 
                    FROM Marcas WHERE IdMarca=@IdMarca";

                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@IdMarca", SqlDbType.Int);
                    cmd.Parameters["@IdMarca"].Value = IdMarca;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            marca = ConstruirMarca(reader);
                        }
                    }
                }
            }
            return marca;

        }

        public List<Marcas> GetMarcas()
        {
            List<Marcas> lista = new List<Marcas>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT IdMarca, Marca FROM Marcas
                         ORDER BY Marca";
                conn.Open();
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var marca = ConstruirMarca(reader);

                            lista.Add(marca);
                        }
                    }
                }
            }
            return lista;

        }

        private Marcas ConstruirMarca(SqlDataReader reader)
        {
            Marcas marcas = new Marcas()
            {
                IdMarca = reader.GetInt32(0),
                Marca = reader.GetString(1)
            };
            return marcas;
        }
    }
}
