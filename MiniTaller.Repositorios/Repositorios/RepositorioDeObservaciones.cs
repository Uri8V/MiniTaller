﻿using Dapper;
using MiniTaller.Comun.Interfaces;
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
    public class RepositorioDeObservaciones:IRepositorioDeObservaciones
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeObservaciones()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Observaciones Observacion)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"INSERT INTO Observaciones (Observacion,IdVehiculo, IdCliente, Fecha) 
                                    Values (@Observacion,@IdVehiculo, @IdCliente,@Fecha); SELECT SCOPE_IDENTITY();";
                int id = conn.ExecuteScalar<int>(selectQuery, Observacion);
                Observacion.IdObservacion = id;
            }
        }

        public void Borrar(int IdObservacion)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string deleteQuery = "DELETE FROM Observaciones WHERE IdObservacion=@IdObservacion";
                conn.Execute(deleteQuery, new { IdObservacion = IdObservacion });
            }
        }

        public void Editar(Observaciones Observacion)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string updateQuery = @"UPDATE Observaciones SET IdVehiculo=@IdVehiculo,Observacion=@Observacion, IdCliente=@IdCliente, Fecha=@Fecha
                WHERE IdObservacion=@IdObservacion";
                conn.Execute(updateQuery, Observacion);
            }
        }

        public bool Existe(Observaciones Observacion)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (Observacion.IdObservacion == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Observaciones 
                            WHERE IdVehiculo=@IdVehiculo AND IdCliente=@IdCliente AND Fecha=@Fecha";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdVehiculo = Observacion.IdVehiculo, IdCliente = Observacion.IdCliente, Fecha = Observacion.Fecha });
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Observaciones   
                WHERE IdVehiculo=@IdVehiculo AND IdCliente=@IdCliente AND Fecha=@Fecha AND IdObservacion!=@IdObservacion";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdVehiculo = Observacion.IdVehiculo, IdCliente = Observacion.IdCliente, Fecha = Observacion.Fecha, IdObservacion = Observacion.IdObservacion });
                }
            }
            return cantidad > 0;
        }

        public int GetCantidad(int? IdVehiculo, int? IdCliente, DateTime? Fecha)
        {

            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (IdVehiculo == null && IdCliente == null && Fecha == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Observaciones";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else if (IdVehiculo != null && IdCliente == null && Fecha == null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Observaciones 
                        WHERE (IdVehiculo=@IdVehiculo)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdVehiculo = IdVehiculo });
                }
                else if (IdVehiculo == null && IdCliente != null && Fecha == null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Observaciones 
                        WHERE (IdCliente=@IdCliente)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdCliente = IdCliente });
                }
                else if (IdVehiculo == null && IdCliente == null && Fecha != null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Observaciones 
                        WHERE (Fecha=CONVERT(DATE,@Fecha))";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { Fecha = Fecha });
                }
            }
            return cantidad;
        }

        public List<ObservacionDto> GetVehiculoObservacionPorClienteYVehiculo(int IdCliente, int IdVehiculo)
        {
            List<ObservacionDto> lista = new List<ObservacionDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT o.IdObservaciones, o.Observacion, CONCAT(v.Patente) AS Vehiculo, CONCAT(c.Apellido,', ', c.Nombre,' | 'c.Documento,c.CUIT) AS Cliente,o.Fecha
                    FROM Observaciones o
                    INNER JOIN Vehiculos v ON v.IdVehiculo=o.IdVehiculo
                    INNER JOIN Clientes c ON o.IdCliente=c.IdCliente
                    WHERE c.IdCliente=@IdCliente OR v.IdVehiculo=@IdVehiculo";
                var parametros = new { IdCliente, IdVehiculo };
                lista = conn.Query<ObservacionDto>(selectQuery, parametros).ToList();
            }
            return lista;
        }

        public Observaciones GetVehiculoObservacionPorId(int IdObservacion)
        {
            Observaciones Observaciones = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT O.IdObservacion,o.IdVehiculo, o.Observacion,o.IdCliente,o.Fecha
                    FROM Observaciones o WHERE o.IdObservacion=@IdObservacion";
                Observaciones = conn.QuerySingleOrDefault<Observaciones>(selectQuery,
                    new { IdObservacion = IdObservacion });
            }
            return Observaciones;
        }

        public List<ObservacionDto> GetVehiculoObservacionPorPagina(int registrosPorPagina, int paginaActual, int? IdVehiculo, int? IdCliente, DateTime? Fecha)
        {
            List<ObservacionDto> lista = new List<ObservacionDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT o.IdObservacion, o.Observacion,CONCAT(v.Patente,' | ',m.Modelo,' | ',tv.Tipo,' | ',v.Kilometros) AS Vehiculo, CONCAT(c.Apellido,', ', c.Nombre,' | ',c.Documento,c.CUIT) AS Cliente,o.Fecha");

                selectQuery.AppendLine("FROM Observaciones o");
                selectQuery.AppendLine("INNER JOIN Vehiculos v ON v.IdVehiculo=o.IdVehiculo");
                selectQuery.AppendLine("INNER JOIN Clientes c ON c.IdCliente=o.IdCliente");
                selectQuery.AppendLine("INNER JOIN Modelos m ON m.IdModelo=v.IdModelo");
                selectQuery.AppendLine("INNER JOIN TiposDeVehiculos tv ON tv.IdTipoVehiculo=v.IdTipoVehiculo ");

                if (IdVehiculo != null || IdCliente != null || Fecha != null)
                {
                    selectQuery.AppendLine("WHERE o.IdVehiculo = @IdVehiculo OR o.IdCliente=@IdCliente OR o.Fecha=CONVERT(DATE,@Fecha)");
                }

                selectQuery.AppendLine("ORDER BY o.Fecha");
                selectQuery.AppendLine("OFFSET @registrosSaltados ROWS FETCH NEXT @registrosPorPagina ROWS ONLY");

                var parametros = new { IdVehiculo, IdCliente, Fecha, registrosSaltados = registrosPorPagina * (paginaActual - 1), registrosPorPagina };

                lista = conn.Query<ObservacionDto>(selectQuery.ToString(), parametros).ToList();

            }
            return lista;

        }
    }
}
