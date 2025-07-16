using iTextSharp.tool.xml.html;
using MiniTaller.Entidades;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTaller.Windows.Helpers
{
    //💡 Importante: EnableHeadersVisualStyles = false es clave, porque si está en true, Windows ignora tus estilos y usa los predeterminados del sistema operativo.
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
                case TiposDeTelefono tipos:
                    r.Cells[0].Value = tipos.Tipo;
                    break;
                case Servicioss servicio:
                    r.Cells[0].Value = servicio.Servicio;
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
                    r.Cells[3].Value = vehiculo.Kilometros;
                    r.Cells[4].Value = vehiculo.ECU==""?"ECU aùn no encontrada":vehiculo.ECU;
                    r.Cells[5].Value = vehiculo.VIN;
                    r.Cells[6].Value = vehiculo.PINCode==""?"PIN CODE aùn no encontrada": vehiculo.PINCode;
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
                    r.Cells[2].Value = telefono.Tipo;

                    break;
                case ServicioTipoDePagoDto service:
                    r.Cells[0].Value = service.servicio;
                    r.Cells[1].Value = service.Tipo;
                    r.Cells[2].Value = service.Precio;
                    break;
                case VehiculosServiciosDto servicios:
                    r.Cells[0].Value = servicios.Patente;
                    r.Cells[1].Value = $"{servicios.Apellido.ToUpper()}, {servicios.Nombre} ({servicios.Documento} {servicios.CUIT})";
                    r.Cells[2].Value = $"{servicios.Servicio}, Precio:{servicios.DebeServicio}";
                    r.Cells[3].Value = (servicios.Debe - servicios.Haber).ToString();
                    if (servicios.Debe - servicios.Haber <= 0)
                    {
                        r.Cells[3].Style.BackColor = Color.Purple;
                    }
                    else
                    {
                        r.Cells[3].Style.BackColor = Color.Black;
                    }
                    r.Cells[4].Value = servicios.Haber;
                    r.Cells[5].Value = ReduccionDeTexto(ATextoPlano(servicios.Descripcion));//Esto es para que el richtextbox no se vea en la grilla, solo se usa para convertir el RTF a texto plano
                    r.Cells[6].Value = servicios.Fecha.ToShortDateString();
                    r.Cells[7].Value = servicios.Kilometros;
                    break;
                case ObservacionDto observacionDto:
                    r.Cells[0].Value = observacionDto.Vehiculo;
                    r.Cells[1].Value = observacionDto.Cliente;
                    r.Cells[2].Value = ReduccionDeTexto(ATextoPlano(observacionDto.Observacion));//Esto es para que el richtextbox no se vea en la grilla, solo se usa para convertir el RTF a texto plano
                    r.Cells[3].Value = observacionDto.Fecha.ToShortDateString();
                    break;
            }
            r.Tag = obj;

        }
        public static string ATextoPlano(string rtf)
        {
            using (var rtb = new RichTextBox())
            {
                rtb.Rtf = rtf;
                return rtb.Text;
            }
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
                if (dgv.Columns.Count==5)
                {
                    r.Cells[4].Value = "Ver Imagenes";
                }
                if (dgv.Columns.Count==9)
                {
                    r.Cells[8].Value = "Ver Imagenes";
                }
                GridHelpers.AgregarFila(dgv, r);
            }
        }
        public static void ConstruirColumnaImage(DataGridView dataGridView1)
        {
            if (dataGridView1.Columns.Count==0) //Debe crear este if para asegurarme que la grilla solo tenga un columna
                                                //que es donde voy a mostrar las imagenes
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                {
                    Name = "Imagen",
                    HeaderText = "Imagen",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    
                };
                dataGridView1.Columns.Add(imgColumn); 
            }
        }

        public static DataGridViewRow ContruirFIlas(DataGridView dataGridView1)
        {
            int rowIndex = dataGridView1.Rows.Add();
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            return row;
        }
        public static void ByteArrayToIMage(ImagenesDto item, DataGridViewRow row)
        {
            // Convertir bytes a imagen
            using (MemoryStream ms = new MemoryStream(item.imageURL))
            {
                row.Cells["Imagen"].Value = System.Drawing.Image.FromStream(ms);
            }
            row.Tag = item;
        }
        public static string ReduccionDeTexto(string descripcion)
        {
            return descripcion.Length >= 120 ? $"{descripcion.Substring(0, 116)}..." : descripcion;
        }
    }
}
