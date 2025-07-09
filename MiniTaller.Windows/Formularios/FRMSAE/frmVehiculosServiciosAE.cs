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
            _servicioServicioTipoGato= new ServicioDeServiciosTiposDePago();
            rtxtDescripcion.KeyDown += rtxtDescripcion_KeyDown;
            this.WindowState = FormWindowState.Maximized;
        }
        private IServicioDeServicios _servicio;
        private IServicioDeClientes _servicioCliente;
        private IServicioDeVehiculos _servicioVehiculo;
        private IServicioDeServiciosTiposDePago _servicioServicioTipoGato;
        private VehiculosServicios servicios;
        private bool modoListaActiva = false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dateTimePickerFecha.Value = DateTime.Now.Date;
            ComboHelper.CargarComboClientesEmpresas(ref comboEmpresa);
            ComboHelper.CargarComboClientesPersonas(ref comboCliente);
            ComboHelper.CargarComboVehiculos(ref comboVehiculo);
            ComboHelper.CargarComboServiciosTipoDePago(ref comboServicio);
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
                comboServicio.SelectedValue = servicios.IdServicioTipoDePago;
                txtDebe.Text = _servicioServicioTipoGato.GetServicioTipoDePagoPorId(servicios.IdServicioTipoDePago).Precio.ToString();
                comboVehiculo.SelectedValue = servicios.IdVehiculo;
                rtxtDescripcion.Rtf = servicios.Descripcion;
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
                servicios.Servicio = _servicioServicioTipoGato.GetServicioTipoDePagoPorId((int)comboServicio.SelectedValue);
                servicios.IdServicioTipoDePago = (int)comboServicio.SelectedValue;

                servicios.Vehiculo = _servicioVehiculo.GetVehiculosPorId((int)comboVehiculo.SelectedValue);
                servicios.IdVehiculo = (int)comboVehiculo.SelectedValue;

                servicios.Debe = Decimal.Parse(txtDebe.Text);
                servicios.Haber = Decimal.Parse(txtHaber.Text);
                servicios.Descripcion = rtxtDescripcion.Rtf;

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
            else if (Haber>Decimal.Parse(txtDebe.Text))
            {
                valido = false;
                errorProvider1.SetError(txtHaber, "El haber no puede ser mayor al debe");
            }
            if (string.IsNullOrEmpty(rtxtDescripcion.Text))
            {
                valido = false;
                errorProvider1.SetError(rtxtDescripcion, "Debe ingresar una Descripción");
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
                txtDebe.Text = (_servicioServicioTipoGato.GetServicioTipoDePagoPorId((int)comboServicio.SelectedValue).Precio).ToString();
            }
        }
        private void toolStripButtonNegrita_Click(object sender, EventArgs e)
        {
            var currentFont = rtxtDescripcion.SelectionFont ?? rtxtDescripcion.Font;
            var newStyle = currentFont.Style ^ FontStyle.Bold;
            rtxtDescripcion.SelectionFont = new Font(currentFont, newStyle);
        }

        private void toolStripButtonCursiva_Click(object sender, EventArgs e)
        {
            var currentFont = rtxtDescripcion.SelectionFont ?? rtxtDescripcion.Font;
            var newStyle = currentFont.Style ^ FontStyle.Italic;
            rtxtDescripcion.SelectionFont = new Font(currentFont, newStyle);
        }

        private void toolStripButtonSubrayar_Click(object sender, EventArgs e)
        {
            var currentFont = rtxtDescripcion.SelectionFont ?? rtxtDescripcion.Font;
            var newStyle = currentFont.Style ^ FontStyle.Underline;
            rtxtDescripcion.SelectionFont = new Font(currentFont, newStyle);
        }

        private void toolStripButtonTamaño_Click(object sender, EventArgs e)
        {
            using (var fontDialog = new FontDialog())
            {
                fontDialog.Font = rtxtDescripcion.SelectionFont ?? rtxtDescripcion.Font;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    rtxtDescripcion.SelectionFont = fontDialog.Font;
                }
            }
        }

        private void toolStripButtonColores_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    rtxtDescripcion.SelectionColor = colorDialog.Color;
                }
            }
        }

        private void toolStripButtonItems_Click(object sender, EventArgs e)
        {
            modoListaActiva = true;
            rtxtDescripcion.SelectionBullet = true;
            rtxtDescripcion.SelectedText = "";
        }

        private void rtxtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (!modoListaActiva) return; // solo responde si la lista fue activada

            // Solo intervenimos si Enter fue presionado y el cursor está en una línea con bullet
            if (e.KeyCode == Keys.Enter && rtxtDescripcion.SelectionBullet)
            {
                var lineIndex = rtxtDescripcion.GetLineFromCharIndex(rtxtDescripcion.SelectionStart);
                var currentLine = rtxtDescripcion.Lines.ElementAtOrDefault(lineIndex)?.Trim();

                // Si está en una línea vacía, desactivamos viñetas
                if (string.IsNullOrWhiteSpace(currentLine))
                {
                    // Si el usuario presionó Enter sobre una línea vacía, salimos del modo lista
                    rtxtDescripcion.SelectionBullet = false;
                    modoListaActiva = false;

                }
                else
                {
                    // Si aún está escribiendo ítems, nos aseguramos de mantener el modo activo
                    rtxtDescripcion.SelectionBullet = true;
                }
            }


        }
    }
}
