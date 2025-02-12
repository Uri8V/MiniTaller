using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTaller.Windows.Helpers
{
    public class GridHelpers
    {
        public static void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }
        public static DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;

        }
        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case Marcas marca:
                    r.Cells[0].Value = marca.Marca;
                    break;
                case TiposDeVehiculos tipo:
                    r.Cells[0].Value = tipo.Tipo;
                    break;
                case TiposDePagos tipos:
                    r.Cells[0].Value = tipos.Tipo;
                    break;
                case TiposClientes tipos:
                    r.Cells[0].Value = tipos.Tipo;
                    break;
                case ServiciosDto servicio:
                    r.Cells[0].Value = servicio.Servicio;
                    r.Cells[1].Value = servicio.Debe;
                    r.Cells[2].Value = servicio.Tipo;
                    break;
                case ClientesDto clientes:
                    r.Cells[0].Value = clientes.Nombre;
                    r.Cells[1].Value = clientes.Apellido;
                    r.Cells[2].Value = clientes.Documento;
                    r.Cells[3].Value = clientes.Domicilio;
                    r.Cells[4].Value = clientes.CUIT;
                    r.Cells[5].Value = clientes.Tipo;
                    break;
                case ModelosDto modelo:
                    r.Cells[0].Value = modelo.Modelo;
                    r.Cells[1].Value = modelo.Marca;
                    break;
                case VehiculosDto vehiculo:
                    r.Cells[0].Value = vehiculo.Patente;
                    r.Cells[1].Value = vehiculo.Tipo;
                    r.Cells[2].Value = vehiculo.Modelo;
                    break;
                case TelefonosDto telefono:

                    if (!string.IsNullOrEmpty(telefono.Documento))
                    {
                        r.Cells[0].Value = $"{telefono.Apellido.ToUpper()}, {telefono.Nombre} ({telefono.Documento})";
                    }
                    else
                    {
                        r.Cells[0].Value = $"{telefono.Apellido.ToUpper()}, {telefono.Nombre} ({telefono.CUIT})";
                    }
                    r.Cells[1].Value = telefono.Telefono;
                    r.Cells[2].Value = telefono.TipoTelefono;

                    break;
                case VehiculosServiciosDto servicios:
                    r.Cells[0].Value = servicios.Patente;
                    r.Cells[1].Value = $"{servicios.Apellido.ToUpper()}, {servicios.Nombre} ({servicios.Documento} {servicios.CUIT})";
                    r.Cells[2].Value = $"{servicios.Servicio}, Debe:{servicios.DebeServicio}";
                    r.Cells[3].Value = (servicios.Debe - servicios.Haber).ToString();
                    if (servicios.Debe - servicios.Haber <= 0)
                    {
                        r.Cells[3].Style.BackColor = Color.Purple;
                    }
                    else
                    {
                        r.Cells[3].Style.BackColor = Color.White;
                    }
                    r.Cells[4].Value = servicios.Haber;
                    r.Cells[5].Value = servicios.Descripcion;
                    if (servicios.Fecha != new DateTime(2023, 01, 01))
                    {
                        r.Cells[6].Value = servicios.Fecha.ToShortDateString();
                    }
                    else
                    {
                        r.Cells[6].Value = "Aún no se realizó el Servicio";
                    }
                    break;
            }
            r.Tag = obj;

        }
        public static void AgregarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Add(r);
        }

        public static void QuitarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Remove(r);
        }

        internal static void MostrarDatosEnGrilla<T>(DataGridView dgv, List<T> lista)
        {
            GridHelpers.LimpiarGrilla(dgv);
            foreach (var obj in lista)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgv);
                GridHelpers.SetearFila(r, obj);
                GridHelpers.AgregarFila(dgv, r);
            }
        }
    }
}
