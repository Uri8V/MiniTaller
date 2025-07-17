using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
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
    public partial class frmVehiculosAE : Form
    {
        public frmVehiculosAE()
        {
            InitializeComponent();
            _sericioDeModelos=new ServicioDeModelos();
            this.WindowState = FormWindowState.Maximized;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ComboHelper.CargarComboTipoVehiculo(ref comboTipoVehiculo);
            ComboHelper.CargarComboModelo(ref comboModelo);

            if (vehiculos != null)
            {
                txtPatente.Text = vehiculos.Patente;
                comboModelo.SelectedValue = vehiculos.IdModelo;
                comboTipoVehiculo.SelectedValue = vehiculos.IdTipoVehiculo;
                txtVIN.Text = vehiculos.VIN;
                txtPINCODE.Text=vehiculos.PINCode;
                txtECU.Text = vehiculos.ECU;
            }
        }
        private Vehiculos vehiculos;
        private IServicioDeModelos _sericioDeModelos;
        internal Vehiculos GetVehiculo()
        {
            return vehiculos;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal void SetVehiculo(Vehiculos vehiculos)
        {
            this.vehiculos = vehiculos;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (vehiculos == null)
                {
                    vehiculos = new Vehiculos();
                }
                vehiculos.Patente = txtPatente.Text;
                vehiculos.TipoDeVehiculo = (TiposDeVehiculos)comboTipoVehiculo.SelectedItem;
                vehiculos.IdTipoVehiculo = (int)comboTipoVehiculo.SelectedValue;
                ModelosComboDto modeloaSeleccionado = (ModelosComboDto)comboModelo.SelectedItem;
                vehiculos.Modelo = _sericioDeModelos.GetModelosPorId(modeloaSeleccionado.IdModelo);
                vehiculos.IdModelo = (int)comboModelo.SelectedValue;
                vehiculos.ECU = txtECU.Text;
                vehiculos.VIN=txtVIN.Text;
                vehiculos.PINCode=txtPINCODE.Text;
                DialogResult = DialogResult.OK;
            }
        }
        
        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valid = true;
            if (string.IsNullOrEmpty(txtPatente.Text))
            {
                errorProvider1.SetError(txtPatente, "Debe ingresar una patente");
                valid = false;
            }
            else if (ValidadorPatente.Validar(txtPatente.Text) == false)
            {
                valid = false;
                errorProvider1.SetError(txtPatente, "La patente agregada no es valida");
            }
            if (comboModelo.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboModelo, "Debe seleccionar un Modelo");
                valid = false;
            }
            if (comboTipoVehiculo.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboTipoVehiculo, "Debe seleccionar un tipo de Vehiculo");
                valid = false;
            }
            if (string.IsNullOrEmpty(txtVIN.Text))
            {
                valid = false;
                errorProvider1.SetError(txtVIN, "Debe ingresar el VIN");
            }
            return valid;
        }

        private void btnAgregarModelo_Click(object sender, EventArgs e)
        {
            frmModelos frm = new frmModelos();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboModelo(ref comboModelo);
                return;
            }
        }

        private void btnAgregarTipoVehiculo_Click(object sender, EventArgs e)
        {
            frmTipoDeVehiculo frm = new frmTipoDeVehiculo();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboTipoCliente(ref comboTipoVehiculo);
                return;
            }
        }

    }
}
