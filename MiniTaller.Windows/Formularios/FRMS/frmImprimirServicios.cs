using MiniTaller.Entidades.Dtos;
using MiniTaller.Servicios.Interfaces;
using MiniTaller.Servicios.Servicios;
using MiniTaller.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTaller.Windows.Formularios.FRMS
{
    public partial class frmImprimirServicios : Form
    {
        public frmImprimirServicios(VehiculosServiciosDto vehiculosServiciosDto = null, ObservacionDto observacionDto = null)
        {
            InitializeComponent();
            _servicios = new ServicioDeVehiculosServicios();
            _servicioObservacion = new ServicioDeObservaciones();
            vehiculosServiciosDTO = vehiculosServiciosDto;
            observacionDTO = observacionDto;
            this.WindowState = FormWindowState.Maximized;
        }
        private ObservacionDto observacionDTO;
        private VehiculosServiciosDto vehiculosServiciosDTO;
        private IServicioDeObservaciones _servicioObservacion;
        private List<VehiculosServiciosDto> lista;
        private IServicioDeVehiculosServicios _servicios;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmImprimirServicios_Load(object sender, EventArgs e)
        {
            RecarGrilla();
        }

        private void RecarGrilla()
        {
            if (vehiculosServiciosDTO == null)
            {
                EliminarColumnas();
                txtCliente.Text = $"{observacionDTO.Cliente.ToUpper()}";
                GridHelpers.LimpiarGrilla(dgvDatos);
                ConstruirColumnas();
                ConstruirFila();
                SetearFila(observacionDTO);
                txtDocCUIT.Visible = false;
                label2.Visible = false;
                txtTotal.Visible = false;
                label4.Visible = false;
                txtCliente.Size = new Size(500, txtCliente.Height);
            }
            else
            {
                if (vehiculosServiciosDTO.CUIT != "")
                {
                    lista = _servicios.GetVehiculoServicioPorCliente(vehiculosServiciosDTO.CUIT).Where(p => p.Patente == vehiculosServiciosDTO.Patente && p.Debe != p.Haber).ToList();

                }
                else
                {
                    lista = _servicios.GetVehiculoServicioPorCliente(vehiculosServiciosDTO.Documento).Where(p => p.Patente == vehiculosServiciosDTO.Patente && p.Debe != p.Haber).ToList();
                }
                MostraDatosEnGrilla();
            }
        }

        private void SetearFila(ObservacionDto observacionDTO)
        {
           DataGridViewRow r = ConstruirFila();
            r.Cells[0].Value = observacionDTO.Vehiculo;
            r.Cells[1].Value = GridHelpers.ATextoPlano(observacionDTO.Observacion);
            r.Cells[2].Value = observacionDTO.Fecha.ToShortDateString();
            r.Cells[3].Value = observacionDTO.Kilometros;
            AgregarFila(r);
        }

        private void ConstruirColumnas()
        {
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colVehiculo",
                HeaderText = "Vehiculo",
                Width = 100,
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colObservacion",
                HeaderText = "Observacion",
                Width = 100,
                ReadOnly = true,
                AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colFecha",
                HeaderText = "Fecha",
                Width = 100,
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colKilometros",
                HeaderText = "Kilometros",
                Width = 100,
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void EliminarColumnas()
        {
            dgvDatos.Columns.Remove(dgvDatos.Columns[5]);
            dgvDatos.Columns.Remove(dgvDatos.Columns[4]);
            dgvDatos.Columns.Remove(dgvDatos.Columns[3]);
            dgvDatos.Columns.Remove(dgvDatos.Columns[2]);
            dgvDatos.Columns.Remove(dgvDatos.Columns[1]);
            dgvDatos.Columns.Remove(dgvDatos.Columns[0]);
        }

        private void MostraDatosEnGrilla()
        {
            decimal total = 0;
            decimal haber = 0;
            dgvDatos.Rows.Clear();
            foreach (var item in lista)
            {
                if (lista.IndexOf(item) == 0)
                {
                    txtCliente.Text = $"{item.Apellido.ToUpper()}, {item.Nombre}";
                    txtDocCUIT.Text = $"{item.Documento}{item.CUIT}";
                }
                DataGridViewRow r = ConstruirFila();
                CrearFila(r, item);
                AgregarFila(r);
                haber += item.Haber;
                total += item.Debe;
            }
            txtTotal.Text = (total - haber).ToString();
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void CrearFila(DataGridViewRow r, VehiculosServiciosDto item)
        {
            r.Cells[0].Value = item.Fecha.ToShortDateString();
            r.Cells[1].Value = item.Patente;
            r.Cells[2].Value = item.Servicio;
            r.Cells[3].Value = GridHelpers.ATextoPlano(item.Descripcion);
            r.Cells[4].Value = item.Haber.ToString();
            r.Cells[5].Value = (item.Debe - item.Haber).ToString();
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (observacionDTO == null)
            {
              ImprimirHelper.ImprimirFactura(lista);
            }
            else
            {
              ImprimirHelper.ImprimirObservacion(observacionDTO);
            }
        }

    }
}
