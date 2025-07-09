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
using Syncfusion.Windows.Forms.Tools;

namespace MiniTaller.Windows.Formularios.FRMSAE
{
    public partial class frmObservacionesAE : Form
    {
        public frmObservacionesAE()
        {
            InitializeComponent();
            _servicio = new ServicioDeObservaciones();
            _servicioCliente = new ServicioDeClientes();
            _servicioVehiculo = new ServicioDeVehiculos();
            rtxtObservaciones.KeyDown += rtxtObservaciones_KeyDown;
            this.WindowState = FormWindowState.Maximized;
        }
        private IServicioDeObservaciones _servicio;
        private IServicioDeClientes _servicioCliente;
        private IServicioDeVehiculos _servicioVehiculo;
        private Observaciones observaciones;
        private bool modoListaActiva = false;
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
                rtxtObservaciones.Rtf = observaciones.Observacion;
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

                observaciones.Observacion = rtxtObservaciones.Rtf;

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
            else if (dateTimePickerFecha.Value.Date < new DateTime(2023, 01, 01))
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

        private void toolStripButtonNegrita_Click(object sender, EventArgs e)
        {
            var currentFont = rtxtObservaciones.SelectionFont ?? rtxtObservaciones.Font;
            var newStyle = currentFont.Style ^ FontStyle.Bold;
            rtxtObservaciones.SelectionFont = new Font(currentFont, newStyle);
        }

        private void toolStripButtonCursiva_Click(object sender, EventArgs e)
        {
            var currentFont = rtxtObservaciones.SelectionFont ?? rtxtObservaciones.Font;
            var newStyle = currentFont.Style ^ FontStyle.Italic;
            rtxtObservaciones.SelectionFont = new Font(currentFont, newStyle);
        }

        private void toolStripButtonSubrayar_Click(object sender, EventArgs e)
        {
            var currentFont = rtxtObservaciones.SelectionFont ?? rtxtObservaciones.Font;
            var newStyle = currentFont.Style ^ FontStyle.Underline;
            rtxtObservaciones.SelectionFont = new Font(currentFont, newStyle);
        }

        private void toolStripButtonTamaño_Click(object sender, EventArgs e)
        {
            using (var fontDialog = new FontDialog())
            {
                fontDialog.Font = rtxtObservaciones.SelectionFont ?? rtxtObservaciones.Font;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    rtxtObservaciones.SelectionFont = fontDialog.Font;
                }
            }
        }

        private void toolStripButtonColores_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    rtxtObservaciones.SelectionColor = colorDialog.Color;
                }
            }
        }

        private void toolStripButtonItems_Click(object sender, EventArgs e)
        {
            modoListaActiva = true;
            rtxtObservaciones.SelectionBullet = true;
            rtxtObservaciones.SelectedText = "";
        }

        private void rtxtObservaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (!modoListaActiva) return; // solo responde si la lista fue activada

            // Solo intervenimos si Enter fue presionado y el cursor está en una línea con bullet
            if (e.KeyCode == Keys.Enter && rtxtObservaciones.SelectionBullet)
            {
                var lineIndex = rtxtObservaciones.GetLineFromCharIndex(rtxtObservaciones.SelectionStart);
                var currentLine = rtxtObservaciones.Lines.ElementAtOrDefault(lineIndex)?.Trim();
              
                // Si está en una línea vacía, desactivamos viñetas
                if (string.IsNullOrWhiteSpace(currentLine))
                {
                    // Si el usuario presionó Enter sobre una línea vacía, salimos del modo lista
                    rtxtObservaciones.SelectionBullet = false;
                    modoListaActiva = false;

                }
                else
                {
                    // Si aún está escribiendo ítems, nos aseguramos de mantener el modo activo
                    rtxtObservaciones.SelectionBullet = true;
                }
            }


        }
    }
}
