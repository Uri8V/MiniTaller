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
    public partial class frmTelefonosAE : Form
    {
        public frmTelefonosAE()
        {
            InitializeComponent();
            _serviciosClientes = new ServicioDeClientes();
            _servicioDeTipoDeTelefono= new ServicioDeTipoDeTelefono();
        }
        private IServicioDeClientes _serviciosClientes;
        private IServicioDeTipoDeTelefono _servicioDeTipoDeTelefono;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ComboHelper.CargarComboClientesPersonas(ref comboClientes);
            ComboHelper.CargarComboClientesEmpresas(ref comboEmpresa);
            ComboHelper.CargarComboTipoDeTelefono(ref comboBoxTipoDeTelefono);
            if (telefonos != null)
            {
                txtTelefono.Text = telefonos.Telefono;
                comboBoxTipoDeTelefono.SelectedValue = telefonos.IdTipoDeTelefono;

                if (telefonos.IdCliente != 0)
                {
                    if (_serviciosClientes.GetClientePorId(telefonos.IdCliente).CUIT != "")
                    {
                        comboEmpresa.SelectedValue = telefonos.IdCliente;
                        comboClientes.SelectedIndex = 0;
                        checkBoxEmpresa.Checked = true;
                    }
                    else
                    {
                        comboClientes.SelectedValue = telefonos.IdCliente;
                        comboEmpresa.SelectedIndex = 0;
                        checkBoxEmpresa.Checked = false;
                    }
                }
                else
                {
                    comboClientes.SelectedIndex = 0;
                    comboEmpresa.SelectedIndex = 0;
                }
            }
        }
        private Telefonos telefonos;
        internal Telefonos GetTelefono()
        {
            return telefonos;
        }

        internal void SetTelefono(Telefonos telefono)
        {
            this.telefonos = telefono;
        }

        private void frmTelefonosAE_Load(object sender, EventArgs e)
        {
            if (checkBoxEmpresa.Checked==false)
            {
                comboClientes.Enabled = true;
                btnAgregarCliente.Enabled = true;
                comboEmpresa.Enabled = false;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTelefono, "Debe ingresar un Telefono");
            }
            if (comboBoxTipoDeTelefono.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxTipoDeTelefono, "Debe seleccionar un Tipo De Telefono");
            }
            if (checkBoxEmpresa.Checked == true)
            {
                if (comboEmpresa.SelectedIndex==0)
                {
                    valido = false;
                    errorProvider1.SetError(comboEmpresa, "Debe seleccionar una Empresa"); 
                }
            }
            else
            {
                if (comboClientes.SelectedIndex==0)
                {
                    valido = false;
                    errorProvider1.SetError(comboClientes, "Debe seleccionar un Cliente"); 
                }
            }
            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboClientesPersonas(ref comboClientes);
                ComboHelper.CargarComboClientesEmpresas(ref comboEmpresa);
                return;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (telefonos == null)
                {
                    telefonos = new Telefonos();
                }
                telefonos.Telefono = txtTelefono.Text;
                telefonos.TipoDeTelefono = (TiposDeTelefono)comboBoxTipoDeTelefono.SelectedItem;
                telefonos.IdTipoDeTelefono=(int)comboBoxTipoDeTelefono.SelectedValue;
                if (checkBoxEmpresa.Checked == false)
                {
                    telefonos.Cliente = _serviciosClientes.GetClientePorId(comboClientes.SelectedIndex);
                    telefonos.IdCliente = (int)comboClientes.SelectedValue;
                }
                else
                {
                    telefonos.Cliente = _serviciosClientes.GetClientePorId(comboEmpresa.SelectedIndex);
                    telefonos.IdCliente = (int)comboEmpresa.SelectedValue;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void checkBoxEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxEmpresa.Checked)
            {
                comboClientes.SelectedIndex = 0;
                comboClientes.Enabled = true;
                comboEmpresa.Enabled = false;
            }
            else
            {
                comboEmpresa.SelectedIndex = 0;
                comboEmpresa.Enabled = true;
                comboClientes.Enabled = false;
            }
        }

        private void btnAgregarTipoDeTelefono_Click(object sender, EventArgs e)
        {
            frmTipoDeTelefono frm = new frmTipoDeTelefono();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboTipoDeTelefono(ref comboBoxTipoDeTelefono);
                return;
            }
        }
    }
}
