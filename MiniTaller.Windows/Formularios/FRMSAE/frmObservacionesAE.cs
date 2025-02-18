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
    public partial class frmObservacionesAE: Form
    {
        public frmObservacionesAE()
        {
            InitializeComponent();
            _servicio = new ServicioDeObservaciones();
            _servicioCliente = new ServicioDeClientes();
            _servicioVehiculo = new ServicioDeVehiculos();
        }
        private IServicioDeObservaciones _servicio;
        private IServicioDeClientes _servicioCliente;
        private IServicioDeVehiculos _servicioVehiculo;
        private Observaciones observaciones;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ComboHelper.CargarComboClientesEmpresas(ref comboEmpresa);
            ComboHelper.CargarComboClientesPersonas(ref comboCliente);
            ComboHelper.CargarComboVehiculos(ref comboVehiculo);
            if (observaciones != null)
            {
                if (_servicioCliente.GetClientePorId(observaciones.IdCliente).CUIT != "")
                {
                    checkBoxEmpresa.Checked = true;
                    comboEmpresa.Enabled = true;
                    comboCliente.Enabled = false;
                    comboCliente.SelectedIndex = 0;
                    comboEmpresa.SelectedValue = observaciones.IdCliente;
                }
                else
                {
                    checkBoxEmpresa.Checked = false;
                    comboEmpresa.Enabled = false;
                    comboCliente.Enabled = true;
                    comboEmpresa.SelectedIndex = 0;
                    comboCliente.SelectedValue = observaciones.IdCliente;
                }
                comboVehiculo.SelectedValue = observaciones.IdVehiculo;
                txtObservacion.Text = observaciones.Observacion;
                dateTimePickerFecha.Value = observaciones.Fecha.Date;
            }
        }
        internal Observaciones GetServicio()
        {
            return observaciones;
        }

        internal void SetServicio(Observaciones observaciones)
        {
            this.observaciones = observaciones;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmObservacionesAE_Load(object sender, EventArgs e)
        {
            if (checkBoxEmpresa.Checked == false)
            {
                comboEmpresa.Enabled = false;
                comboCliente.Enabled = true;
            }
            dateTimePickerFecha.Value = DateTime.Now.Date;
        }

        private void checkBoxEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEmpresa.Checked)
            {
                comboCliente.Enabled = false;
                comboEmpresa.Enabled = true;
            }
            else
            {
                comboCliente.Enabled = true;
                comboEmpresa.Enabled = false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (observaciones == null)
                {
                    observaciones = new Observaciones();
                }

                if (checkBoxEmpresa.Checked)
                {
                    observaciones.Cliente = (Clientes)comboEmpresa.SelectedValue;
                    observaciones.IdCliente = (int)comboEmpresa.SelectedValue;
                }
                else
                {
                    observaciones.Cliente = _servicioCliente.GetClientePorId((int)comboCliente.SelectedValue);
                    observaciones.IdCliente = (int)comboCliente.SelectedValue;
                }

                observaciones.Vehiculo = _servicioVehiculo.GetVehiculosPorId((int)comboVehiculo.SelectedValue);
                observaciones.IdVehiculo = (int)comboVehiculo.SelectedValue;

                observaciones.Observacion = txtObservacion.Text;

                observaciones.Fecha = dateTimePickerFecha.Value;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (!checkBoxEmpresa.Checked)
            {
                if (comboCliente.SelectedIndex == 0)
                {
                    valido = false;
                    errorProvider1.SetError(comboCliente, "Debe seleccionar un Cliente");
                }
            }
            else
            {
                if (comboEmpresa.SelectedIndex == 0)
                {
                    valido = false;
                    errorProvider1.SetError(comboEmpresa, "Debe seleccionar una Empresa");
                }
            }
            if (comboVehiculo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboVehiculo, "Debe selccionar un Vehiculo");
            }
            if (dateTimePickerFecha.Value.Date > DateTime.Now.Date)
            {
                valido = false;
                errorProvider1.SetError(dateTimePickerFecha, "No puede ingresar una fecha que aún no ha pasado");
            }
            else if (dateTimePickerFecha.Value.Date < new DateTime(2023,01,01))
            {
                valido = false;
                errorProvider1.SetError(dateTimePickerFecha, "Debe ingresar una fecha superior a 01-01-2023");

            }
            return valido;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboClientesPersonas(ref comboCliente);
                ComboHelper.CargarComboClientesEmpresas(ref comboEmpresa);
                return;
            }
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            frmVehiculos frm = new frmVehiculos();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboVehiculos(ref comboVehiculo);
                return;
            }
        }
    }
}
