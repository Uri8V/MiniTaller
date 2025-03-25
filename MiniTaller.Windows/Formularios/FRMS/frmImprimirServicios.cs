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
        public frmImprimirServicios(VehiculosServiciosDto vehiculosServiciosDto)
        {
            InitializeComponent();
            _servicios = new ServicioDeVehiculosServicios();
            vehiculosServiciosDTO = vehiculosServiciosDto;
        }
        private VehiculosServiciosDto vehiculosServiciosDTO;
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
            if (vehiculosServiciosDTO.CUIT != "")
            {
                lista = _servicios.GetVehiculoServicioPorCliente(vehiculosServiciosDTO.CUIT).Where(p=>p.Patente==vehiculosServiciosDTO.Patente && p.Debe!=p.Haber).ToList();

            }
            else
            {
                lista = _servicios.GetVehiculoServicioPorCliente(vehiculosServiciosDTO.Documento).Where(p => p.Patente == vehiculosServiciosDTO.Patente && p.Debe != p.Haber).ToList();
            }
            MostraDatosEnGrilla();
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
                total += item.DebeServicio;
            }
            txtTotal.Text = (total - haber).ToString();
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void CrearFila(DataGridViewRow r, VehiculosServiciosDto item)
        {
            if (item.Fecha == new DateTime(2023, 01, 01))
            {
                r.Cells[0].Value = "Aún no se realizo el servicio";
            }
            else
            {
                r.Cells[0].Value = item.Fecha.ToShortDateString();
            }
            r.Cells[1].Value = item.Patente;
            r.Cells[2].Value = item.Servicio;
            r.Cells[3].Value = item.Descripcion;
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
            ImprimirHelper.ImprimirFactura(lista);
        }

    }
}
