using MiniTaller.Entidades.Entidades;
using MiniTaller.Servicio.Interfaces;
using MiniTaller.Servicio.Servicios;
using MiniTaller.Servicios.Interfaces;
using MiniTaller.Servicios.Servicios;
using MiniTaller.Windows.Formularios.FRMS;
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

namespace MiniTaller.Windows.Formularios.FRMSAE
{
    public partial class frmServiciosTiposDePagoAE : Form
    {
        public frmServiciosTiposDePagoAE()
        {
            InitializeComponent();
            _servicio = new ServicioDeServiciosTiposDePago();
            _servicioDeServicio = new ServiciosDeServicios();
            _servicioDeTipoPago= new ServicioDeTipoPago();
            this.WindowState = FormWindowState.Maximized;
        }
        private ServicioTipoDePago servicio;
        private IServicioDeServiciosTiposDePago _servicio;
        private IServicioDeServicios _servicioDeServicio;
        private IServicioDeTipoPago _servicioDeTipoPago;
        internal ServicioTipoDePago GetServicio()
        {
            return servicio;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmServiciosTiposDeGastosAE_Load(object sender, EventArgs e)
        {
            ComboHelper.CargarComboServicios(ref comboServicio);
            ComboHelper.CargarComboTipoDePago(ref comboTipoDePago);
            if (servicio != null)
            {
                txtPrecio.Text = servicio.Precio.ToString();
                comboServicio.SelectedValue = servicio.IdServicio;
                comboTipoDePago.SelectedValue = servicio.IdTipoPago;
            }
        }

        private void btnAgregarTipoDePago_Click(object sender, EventArgs e)
        {
            frmTipoDePago frm = new frmTipoDePago();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboTipoDePago(ref comboTipoDePago);
                return;
            }
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            frmServicios frm= new frmServicios();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboServicios(ref comboServicio);
                return;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (servicio==null)
                {
                    servicio = new ServicioTipoDePago();
                }
                servicio.Precio = Decimal.Parse(txtPrecio.Text);
                servicio.servicio = _servicioDeServicio.GetServiciosPorId((int)comboServicio.SelectedValue);
                servicio.IdServicio = (int)comboServicio.SelectedValue;

                servicio.Tipo = _servicioDeTipoPago.GetTipoDePagoPorId((int)comboTipoDePago.SelectedValue);
                servicio.IdTipoPago = (int)comboTipoDePago.SelectedValue;
               
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valid = true;
            if (comboServicio.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboServicio, "Debe seleccionar un Servicio");
                valid = false;
            }
            if (comboTipoDePago.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboTipoDePago, "Debe seleccionar un tipo de Pago");
                valid = false;
            }
            if (!Decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                errorProvider1.SetError(txtPrecio, "Debe ingresar un Precio válido");
                valid = false;
            }
            else if (precio <= 0)
            {
                errorProvider1.SetError(txtPrecio, "El Precio debe ser mayor a cero");
                valid = false;
            }
            return valid;
        }

        internal void SetServicio(ServicioTipoDePago servicios)
        {
            servicio = servicios;
        }
    }
}
