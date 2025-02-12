using MiniTaller.Entidades.Entidades;
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
    public partial class frmServiciosAE : Form
    {
        public frmServiciosAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ComboHelper.CargarComboTipoDePago(ref comboBox1);
            if (Servicios != null)
            {
                txtServicio.Text = Servicios.Servicio;
                txtDebe.Text = Servicios.Debe.ToString();
                comboBox1.SelectedValue = Servicios.IdTipoPago;
            }
        }
        private Servicioss Servicios;
        internal Servicioss GetServicios()
        {
            return Servicios;
        }

        internal void SetServicio(Servicioss Servicios)
        {
            this.Servicios = Servicios;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (Servicios == null)
                {
                    Servicios = new Servicioss();
                }
                Servicios.Servicio = txtServicio.Text;
                Servicios.Debe = decimal.Parse(txtDebe.Text);
                Servicios.IdTipoPago = (int)comboBox1.SelectedValue;
                Servicios.TipoDePago = (TiposDePagos)comboBox1.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtServicio.Text))
            {
                valido = false;
                errorProvider1.SetError(txtServicio, "Debe ingresar un Servicio");
            }
            if (!decimal.TryParse(txtDebe.Text, out decimal Debe))
            {
                valido = false;
                errorProvider1.SetError(txtDebe, "Se necesita ingresar el total a deber ");
            }
            else if (Debe <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtDebe, "El monto debe ser positivo");
            }
            if (comboBox1.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboBox1, "Debe seleccionar una forma de Pago");
            }
            return valido;
        }
    }
}
