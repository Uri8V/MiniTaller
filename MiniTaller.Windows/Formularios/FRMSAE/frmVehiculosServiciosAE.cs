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
    public partial class frmVehiculosServiciosAE : Form
    {
        public frmVehiculosServiciosAE()
        {
            InitializeComponent();
            _servicio = new ServiciosDeServicios();
            _servicioCliente = new ServicioDeClientes();
            _servicioVehiculo = new ServicioDeVehiculos();
        }
        private IServicioDeServicios _servicio;
        private IServicioDeClientes _servicioCliente;
        private IServicioDeVehiculos _servicioVehiculo;
        private VehiculosServicios servicios;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ComboHelper.CargarComboClientesEmpresas(ref comboEmpresa);
            ComboHelper.CargarComboClientesPersonas(ref comboCliente);
            ComboHelper.CargarComboVehiculos(ref comboVehiculo);
            ComboHelper.CargarComboServicios(ref comboServicio);
            if (servicios != null)
            {
                if (_servicioCliente.GetClientePorId(servicios.IdCliente).CUIT != "")
                {
                    checkBoxEmpresa.Checked = true;
                    comboEmpresa.Enabled = true;
                    comboCliente.Enabled = false;
                    comboCliente.SelectedIndex = 0;
                    comboEmpresa.SelectedValue = servicios.IdCliente;
                }
                else
                {
                    checkBoxEmpresa.Checked = false;
                    comboEmpresa.Enabled = false;
                    comboCliente.Enabled = true;
                    comboEmpresa.SelectedIndex = 0;
                    comboCliente.SelectedValue = servicios.IdCliente;
                }
                comboServicio.SelectedValue = servicios.IdServicio;
                txtDebe.Text = _servicio.GetServiciosPorId(servicios.IdServicio).Debe.ToString();
                comboVehiculo.SelectedValue = servicios.IdVehiculo;
                txtDescripcion.Text = servicios.Descripcion;
                txtHaber.Text = servicios.Haber.ToString();
                dateTimePickerFecha.Value = servicios.Fecha.Date;
            }
        }
        internal VehiculosServicios GetServicio()
        {
            return servicios;
        }

        internal void SetServicio(VehiculosServicios servicios)
        {
            this.servicios = servicios;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVehiculosServiciosAE_Load(object sender, EventArgs e)
        {
            if (checkBoxEmpresa.Checked == false)
            {
                comboEmpresa.Enabled = false;
                comboCliente.Enabled = true;
            }
            dateTimePickerFecha.Value= DateTime.Now.Date;
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
                if (servicios == null)
                {
                    servicios = new VehiculosServicios();
                }

                if (checkBoxEmpresa.Checked)
                {
                    servicios.Cliente = (Clientes)comboEmpresa.SelectedValue;
                    servicios.IdCliente = (int)comboEmpresa.SelectedValue;
                }
                else
                {
                    servicios.Cliente = _servicioCliente.GetClientePorId((int)comboCliente.SelectedValue);
                    servicios.IdCliente = (int)comboCliente.SelectedValue;
                }
                servicios.Servicio = _servicio.GetServiciosPorId((int)comboServicio.SelectedValue);
                servicios.IdServicio = (int)comboServicio.SelectedValue;

                servicios.Vehiculo = _servicioVehiculo.GetVehiculosPorId((int)comboVehiculo.SelectedValue);
                servicios.IdVehiculo = (int)comboVehiculo.SelectedValue;

                servicios.Debe = Decimal.Parse(txtDebe.Text);
                servicios.Haber = Decimal.Parse(txtHaber.Text);
                servicios.Descripcion = txtDescripcion.Text;

                servicios.Fecha = dateTimePickerFecha.Value;

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
            if (comboServicio.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboServicio, "Debe seleccionar un Movimiento");
            }
            if (comboVehiculo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboVehiculo, "Debe selccionar un Vehiculo");
            }
            //if(!int.TryParse(txtDebe.Text, out int Debe))
            //{
            //    valido = false;
            //    errorProvider1.SetError(txtDebe, "Debe poner cuanto debe");
            //}
            //else if (Debe < 0)
            //{
            //    valido = false;
            //    errorProvider1.SetError(txtDebe, "Lo que debe ser positivo");
            //}
            if (!int.TryParse(txtHaber.Text, out int Haber))
            {
                valido = false;
                errorProvider1.SetError(txtHaber, "Debe poner el Haber");
            }
            else if (Haber < 0)
            {
                valido = false;
                errorProvider1.SetError(txtHaber, "El haber debe ser positivo");
            }
            else if (Haber>int.Parse(txtDebe.Text))
            {
                valido = false;
                errorProvider1.SetError(txtHaber, "El haber no puede ser mayor al debe");
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "Debe ingresar una Descripción");
            }
            if (dateTimePickerFecha.Value.Date < new DateTime(2023, 1, 1))
            {
                valido = false;
                errorProvider1.SetError(dateTimePickerFecha, "Debe ingresar una fecha mayor a 2023/01/01");
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

        private void btnAgregarMovimiento_Click(object sender, EventArgs e)
        {
            frmServicios frm = new frmServicios();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboServicios(ref comboServicio);
                return;
            }
        }

        private void comboMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboServicio.SelectedIndex != 0)
            {
                txtDebe.Text = (_servicio.GetServiciosPorId((int)comboServicio.SelectedValue).Debe).ToString();
            }
        }


    }
}
