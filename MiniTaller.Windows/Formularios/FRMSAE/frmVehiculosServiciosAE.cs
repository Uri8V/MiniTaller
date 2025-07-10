using iTextSharp.tool.xml.html;
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
    public partial class frmVehiculosServiciosAE : Form
    {
        public frmVehiculosServiciosAE()
        {
            InitializeComponent();
            _servicioDeServicios = new ServiciosDeServicios();
            _servicioCliente = new ServicioDeClientes();
            _servicioVehiculo = new ServicioDeVehiculos();
            _servicioServicioTipoGato= new ServicioDeServiciosTiposDePago();
            _listaParaAgregarLosServicios = new List<ServicioTipoDePago>();
            MostrarDatosEnGrilla();
            rtxtDescripcion.KeyDown += rtxtDescripcion_KeyDown;
            this.WindowState = FormWindowState.Maximized;
        }
        private List<ServicioTipoDePagoDto> lista;
        private List<ServicioTipoDePago> _listaParaAgregarLosServicios;

        private void MostrarDatosEnGrilla()
        {
            lista = _servicioServicioTipoGato.GetServiciosTiposDePagoPorPagina();
            GridHelpers.LimpiarGrilla(dgvDatos);
            foreach (var item in lista)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgvDatos);
                GridHelpers.SetearFila(r, item);
                r.Cells[3].Value = "Agregar";
                GridHelpers.AgregarFila(dgvDatos, r);
                if (_listaParaAgregarLosServicios.Any(s=>s.IdServicioTipoDePago==item.IdServicioTipoDePago))
                {
                    GridHelpers.QuitarFila(dgvDatos, r);
                }
            }
        }
        private IServicioDeServicios _servicioDeServicios;
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
            splitContainer1.Visible = true;
            lblServicio.Visible = false;
            comboServicio.Visible = false;
            btnAgregarServicio.Visible = false;
            rtxtDescripcion.Size = new Size(657, 156);
            if (servicios != null)
            {
                ComboHelper.CargarComboServiciosTipoDePago(ref comboServicio);
                splitContainer1.Visible = false;
                lblServicio.Visible = true;
                comboServicio.Visible = true;
                btnAgregarServicio.Visible = true;
                rtxtDescripcion.Size = new Size(1145, 156);
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

                if (splitContainer1.Visible==false)
                {
                    servicios.Servicio = _servicioServicioTipoGato.GetServicioTipoDePagoPorId((int)comboServicio.SelectedValue);
                    servicios.IdServicioTipoDePago = (int)comboServicio.SelectedValue;
                    
                    _listaParaAgregarLosServicios.Add(servicios.Servicio); 
                }

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
            if (splitContainer1.Visible == true)
            {
                if (_listaParaAgregarLosServicios.Count == 0)
                {
                    valido = false;
                    errorProvider1.SetError(splitContainer1, "Debe agregar al menos un Servicio");
                }
            }
            else
            {
                if (comboServicio.SelectedIndex==0)
                {
                    valido = false;
                    errorProvider1.SetError(comboServicio, "Debe seleccionar un Servicio");
                }
            }
         
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmServiciosTiposDePago frm = new frmServiciosTiposDePago();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                MostrarDatosEnGrilla();
                return;
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.SelectAll();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            var texto = toolStripTextBox1.Text;
            BuscarServicio(lista, texto);
        }

        private void BuscarServicio(List<ServicioTipoDePagoDto> lista, string texto)
        {
            var listaFiltrada = lista;
            if (texto.Length != 0)
            {
                Func<ServicioTipoDePagoDto, bool> condicion = c => c.servicio.Contains(texto);
                listaFiltrada = lista.Where(condicion).ToList();
            }
            MostrarDatosEnGrilla<ServicioTipoDePagoDto>(dgvDatos, listaFiltrada);

        }

        private void MostrarDatosEnGrilla<T>(DataGridView dgv, List<ServicioTipoDePagoDto> lista)
        {
            GridHelpers.LimpiarGrilla(dgv);
            foreach (var obj in lista)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgv);
                GridHelpers.SetearFila(r, obj);
                if (dgv.Columns.Count == 4)
                {
                    r.Cells[3].Value = "Agregar";
                }
                GridHelpers.AgregarFila(dgv, r);
                if (_listaParaAgregarLosServicios.Any(s => s.IdServicioTipoDePago == obj.IdServicioTipoDePago))
                {
                    GridHelpers.QuitarFila(dgvDatos, r);
                }
            }
        }

        private decimal total = 0;

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var r = dgvDatos.SelectedRows[0];
                ServicioTipoDePagoDto ServicioSeleccionado = (ServicioTipoDePagoDto)r.Tag;
                DialogResult dr=MessageBox.Show($"Esta seguro que quiere agregar el servicio {ServicioSeleccionado.servicio}, del tipo {ServicioSeleccionado.Tipo} con el precio ${ServicioSeleccionado.Precio}?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr==DialogResult.Yes)
                {  
                    ServicioTipoDePago servicioTipoDePago = _servicioServicioTipoGato?.GetServicioTipoDePagoPorId(ServicioSeleccionado.IdServicioTipoDePago);
                    servicioTipoDePago.servicio= _servicioDeServicios.GetServiciosPorId(servicioTipoDePago.IdServicio);
                    _listaParaAgregarLosServicios?.Add(servicioTipoDePago);
                    dgvDatos.Rows.Remove(r);
                    total+=servicioTipoDePago.Precio;
                    txtDebe.Text =total.ToString();
                }
                return;
            }
        }

        internal List<ServicioTipoDePago> GetListaDeServicios()
        {
            return _listaParaAgregarLosServicios;
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            frmServiciosTiposDePago frm = new frmServiciosTiposDePago();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboServiciosTipoDePago(ref comboServicio);
                return;
            }
        }

        private void comboServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboServicio.SelectedIndex != 0)
            {
                txtDebe.Text = _servicioServicioTipoGato.GetServicioTipoDePagoPorId((int)comboServicio.SelectedValue).Precio.ToString();
            }
            else
            {
                txtDebe.Text = "0";
            }
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
