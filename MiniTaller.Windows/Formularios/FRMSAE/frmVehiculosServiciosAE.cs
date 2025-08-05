using iTextSharp.tool.xml.html;
using MiniTaller.Entidades.Dtos;
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
            _servicioDeVehiculosServicios = new ServicioDeVehiculosServicios();
            _servicioTipoPago = new ServicioDeTipoPago();
            _servicioDetallesVehiculosServicios=new ServicioDeDetallesVehiculosServicios();
            rtxtDescripcion.KeyDown += rtxtDescripcion_KeyDown;
            this.WindowState = FormWindowState.Maximized;
        }
        private List<ServicioTipoDePagoDto> lista;
        private List<ServicioTipoDePago> _listaParaAgregarLosServicios;
        private List<ServicioTipoDePagoDto> _listaParaMostrarServiciosAgregados= new List<ServicioTipoDePagoDto>();
        private DateTime fechaPago;
        private void MostrarDatosEnGrilla()
        {
            lista = _servicioServicioTipoGato.GetServiciosTiposDePagoPorPagina();
            GridHelpers.LimpiarGrilla(dgvDatos);
            foreach (var item in lista)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgvDatos);
                GridHelpers.SetearFila(r, item);
                r.Cells[2].Value = "Agregar";
                GridHelpers.AgregarFila(dgvDatos, r);
                if (_listaParaMostrarServiciosAgregados.Any(x=>x.servicio==item.servicio))
                {
                    GridHelpers.QuitarFila(dgvDatos, r);
                }
            }
        }
        private IServicioDeDetallesVehiculosServicios _servicioDetallesVehiculosServicios;
        private IServicioDeVehiculosServicios _servicioDeVehiculosServicios;
        private IServicioDeServicios _servicioDeServicios;
        private IServicioDeClientes _servicioCliente;
        private IServicioDeVehiculos _servicioVehiculo;
        private IServicioDeServiciosTiposDePago _servicioServicioTipoGato;
        private IServicioDeTipoPago _servicioTipoPago;
        private VehiculosServicios vehiculoServicio = new VehiculosServicios();
        private bool modoListaActiva = false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ComboHelper.CargarComboClientesEmpresas(ref comboEmpresa);
            ComboHelper.CargarComboClientesPersonas(ref comboCliente);
            ComboHelper.CargarComboVehiculos(ref comboVehiculo);

            if (vehiculoServicio!=null && vehiculoServicio.IdVehiculoServicio!=0)
            {
                if (_servicioCliente.GetClientePorId(vehiculoServicio.IdCliente).CUIT != "")
                {
                    checkBoxEmpresa.Checked = true;
                    comboEmpresa.Enabled = true;
                    comboCliente.Enabled = false;
                    comboCliente.SelectedIndex = 0;
                    comboEmpresa.SelectedValue = vehiculoServicio.IdCliente;
                }
                else
                {
                    checkBoxEmpresa.Checked = false;
                    comboEmpresa.Enabled = false;
                    comboCliente.Enabled = true;
                    comboEmpresa.SelectedIndex = 0;
                    comboCliente.SelectedValue = vehiculoServicio.IdCliente;
                }
                dgvDatosServiciosSeleccionados.Visible = false;
                DialogResult dr = MessageBox.Show("¿Quiere editar el pago de los servicios realizados?", "Seleccione su decisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var detalles = _servicioDetallesVehiculosServicios.GetDetallesVehiculosServiciosPorIdVehiculoNombreServicioFechaYIdCliente(vehiculoServicio.IdVehiculo, vehiculoServicio.Fecha, vehiculoServicio.IdCliente).Where(d=>d.Debe!=d.Pago);
                    decimal pago = 0;
                    foreach (var item in detalles)
                    {
                        var servicioTipoDePago = _servicioServicioTipoGato.GetServicioTipoDePagoPorId(item.IdServicioTipoDePago);
                        if (!_listaParaAgregarLosServicios.Any(id=>id.IdServicioTipoDePago==servicioTipoDePago.IdServicioTipoDePago))
                        {
                            _listaParaAgregarLosServicios.Add(servicioTipoDePago);
                            listaDePrecios.Add((int)item.Debe);
                        }
                        var servicioTipoDePagoDto = new ServicioTipoDePagoDto
                        {
                            IdServicioTipoDePago = item.IdServicioTipoDePago,
                            servicio = _servicioDeServicios.GetServiciosPorId(_servicioServicioTipoGato.GetServicioTipoDePagoPorId(item.IdServicioTipoDePago).IdServicio).Servicio,
                            Tipo = _servicioTipoPago.GetTipoDePagoPorId(_servicioServicioTipoGato.GetServicioTipoDePagoPorId(item.IdServicioTipoDePago).IdTipoPago).Tipo
                        };
                        _listaParaMostrarServiciosAgregados.Add(servicioTipoDePagoDto);
                        total += item.Debe;
                        pago += item.Pago;
                    }
                    txtHaber.Text = pago.ToString();
                    MostrarServiciosSeleccionados();
                    dgvDatosServiciosSeleccionados.Columns.Remove(dgvDatosServiciosSeleccionados.Columns[3]);
                    dgvDatosServiciosSeleccionados.Visible = true;
                    lblServicio.Visible = false;
                    btnAgregarServicio.Visible = false;
                    comboServicio.Visible = false;
                    toolStrip1.Enabled = false;
                    rtxtDescripcion.ReadOnly = true;
                    comboCliente.Enabled = false;
                    comboEmpresa.Enabled = false;
                    comboVehiculo.Enabled = false;
                    checkBoxEmpresa.Enabled = false;
                    dateTimePickerFecha.Enabled = false;
                    txtKilometraje.Enabled = false;
                    btnAgregarCliente.Enabled = false;
                    btnAgregarVehiculo.Enabled = false;
                    txtDebe.Text = total.ToString();
                }
                else
                {
                    var servicio = _servicioDeServicios.GetServiciosPorId(_listaParaAgregarLosServicios[0].IdServicio);
                    var detalle = _servicioDetallesVehiculosServicios.GetDetallesVehiculosServiciosPorIdVehiculoNombreServicioFechaYIdCliente(vehiculoServicio.IdVehiculo, vehiculoServicio.Fecha, vehiculoServicio.IdCliente, servicio.Servicio);
                    txtHaber.Text = detalle[0].Pago.ToString();
                    lblServicio.Visible = true;
                    comboServicio.Visible = true;
                    btnAgregarServicio.Visible = true;
                    txtDebe.Text = listaDePrecios[0].ToString();
                    txtDebe.Enabled = true;
                    ComboHelper.CargarComboServiciosTipoDePago(ref comboServicio);
                    comboServicio.SelectedValue = _listaParaAgregarLosServicios[0].IdServicioTipoDePago;
                }
                splitContainer1.Visible = false;
                rtxtDescripcion.Size = new Size(1145, 156);
                label4.Visible = false;
                comboVehiculo.SelectedValue = vehiculoServicio.IdVehiculo;
                rtxtDescripcion.Rtf = vehiculoServicio.Descripcion;
                dateTimePickerFecha.Value = vehiculoServicio.Fecha.Date;
                txtKilometraje.Text = vehiculoServicio.Kilometros;
                labelFechaPago.Visible = true;
                dateTimePickerFechaPago.Visible = true;
                dateTimePickerFechaPago.Value = fechaPago.Date;
            }
            else
            {
                MostrarDatosEnGrilla();
                splitContainer1.Visible = true;
                lblServicio.Visible = false;
                comboServicio.Visible = false;
                btnAgregarServicio.Visible = false;
                label4.Visible = true;
                dgvDatosServiciosSeleccionados.Visible = true;
                rtxtDescripcion.Size = new Size(657, 156);
                dateTimePickerFecha.Value = DateTime.Now.Date;
                dateTimePickerFechaPago.Visible = false;
                labelFechaPago.Visible = false;
            }
        }
        internal VehiculosServicios GetServicio()
        {
            return vehiculoServicio;
        }

        internal void SetServicio(VehiculosServicios servicio)
        {
            vehiculoServicio = servicio;
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
                if (vehiculoServicio==null || vehiculoServicio.IdVehiculoServicio==0)
                {
                    var vehiculosServicios = new VehiculosServicios();
                }

                if (checkBoxEmpresa.Checked)
                {
                    vehiculoServicio.Cliente = (Clientes)comboEmpresa.SelectedValue;
                    vehiculoServicio.IdCliente = (int)comboEmpresa.SelectedValue;
                }
                else
                {
                    vehiculoServicio.Cliente = _servicioCliente.GetClientePorId((int)comboCliente.SelectedValue);
                    vehiculoServicio.IdCliente = (int)comboCliente.SelectedValue;
                }

                if (dgvDatosServiciosSeleccionados.Visible==false)
                {
                    _listaParaAgregarLosServicios.RemoveAt(0);
                    listaDePrecios.RemoveAt(0);
                    _listaParaAgregarLosServicios.Add(_servicioServicioTipoGato.GetServicioTipoDePagoPorId((int)comboServicio.SelectedValue));
                    listaDePrecios.Add(Decimal.Parse(txtDebe.Text));
                }
                if (dateTimePickerFechaPago.Visible==true)
                {
                    fechaPago = dateTimePickerFechaPago.Value.Date;
                }
                vehiculoServicio.Vehiculo = _servicioVehiculo.GetVehiculosPorId((int)comboVehiculo.SelectedValue);
                vehiculoServicio.IdVehiculo = (int)comboVehiculo.SelectedValue;
                vehiculoServicio.Haber = Decimal.Parse(txtHaber.Text);
                vehiculoServicio.Descripcion = rtxtDescripcion.Rtf;
                vehiculoServicio.Kilometros = txtKilometraje.Text;
                vehiculoServicio.Fecha = dateTimePickerFecha.Value;

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
            if (string.IsNullOrEmpty(txtKilometraje.Text))
            {
                valido = false;
                errorProvider1.SetError(txtKilometraje, "Debe ingresar un Kilometraje");
            }
            else if (!int.TryParse(txtKilometraje.Text, out int kilometraje))
            {
                valido = false;
                errorProvider1.SetError(txtKilometraje, "El Kilometraje debe ser un número entero");
            }
            else if (kilometraje < 0)
            {
                valido = false;
                errorProvider1.SetError(txtKilometraje, "El Kilometraje no puede ser negativo");
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
            if (dgvDatosServiciosSeleccionados.Visible==false)
            {
                if (!decimal.TryParse(txtDebe.Text, out decimal Debe))
                {
                    valido = false;
                    errorProvider1.SetError(txtDebe, "Debe poner el Debe");
                }
                else if (Debe <= 0)
                {
                    valido = false;
                    errorProvider1.SetError(txtDebe, "El debe debe ser positivo");
                } 
            }
            if (!decimal.TryParse(txtHaber.Text, out decimal Haber))
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
            if (dateTimePickerFechaPago.Visible==true)
            {
                if (dateTimePickerFechaPago.Value.Date<dateTimePickerFecha.Value.Date)
                {
                    valido = false;
                    errorProvider1.SetError(dateTimePickerFechaPago, "La fecha de pago no puede ser menor a la fecha del servicio");
                }
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
                if (obj is ServicioTipoDePagoDto ser)
                {
                    r.Cells[2].Value = "Agregar";

                    GridHelpers.AgregarFila(dgv, r);
                    if (_listaParaMostrarServiciosAgregados.Any(s => s.servicio == ser.servicio))
                    {
                        GridHelpers.QuitarFila(dgvDatos, r);
                    }
                }
            }
        }

        private decimal total = 0;
        List<decimal> listaDePrecios= new List<decimal>();
        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var r = dgvDatos.SelectedRows[0];
                ServicioTipoDePagoDto ServicioSeleccionado = (ServicioTipoDePagoDto)r.Tag;
                DialogResult dr=MessageBox.Show($"Esta seguro que quiere agregar el servicio {ServicioSeleccionado.servicio}, del tipo {ServicioSeleccionado.Tipo}?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr==DialogResult.Yes)
                {
                    frmAgregarPrecio frm = new frmAgregarPrecio();
                    DialogResult drt = frm.ShowDialog(this);
                    if (drt == DialogResult.Cancel)
                    {
                        return;
                    }
                    var precio = frm.GetPrecio();
                    ServicioTipoDePago servicioTipoDePago = _servicioServicioTipoGato?.GetServicioTipoDePagoPorId(ServicioSeleccionado.IdServicioTipoDePago);
                    servicioTipoDePago.servicio= _servicioDeServicios.GetServiciosPorId(servicioTipoDePago.IdServicio);
                    _listaParaAgregarLosServicios?.Add(servicioTipoDePago);
                    _listaParaMostrarServiciosAgregados.Add(ServicioSeleccionado);
                    MostrarDatosEnGrilla();
                    total+=precio;
                    txtDebe.Text =total.ToString();
                    listaDePrecios.Add(precio);
                    MostrarServiciosSeleccionados();
                }
                return;
            }
        }

        private void MostrarServiciosSeleccionados()
        {
            GridHelpers.LimpiarGrilla(dgvDatosServiciosSeleccionados);
            for (int i=0; i<_listaParaMostrarServiciosAgregados.Count();i++)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgvDatosServiciosSeleccionados);
                GridHelpers.SetearFila(r, _listaParaMostrarServiciosAgregados[i]);
                r.Cells[2].Value = listaDePrecios[i].ToString(); 
                r.Cells[3].Value = "Borrar";
                GridHelpers.AgregarFila(dgvDatosServiciosSeleccionados, r);
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

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dgvDatosServiciosSeleccionados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var r = dgvDatosServiciosSeleccionados.SelectedRows[0];
                ServicioTipoDePagoDto ServicioSeleccionado = (ServicioTipoDePagoDto)r.Tag;
                var precio=int.Parse(r.Cells[2].Value.ToString());
                DialogResult dr = MessageBox.Show($"Esta seguro que quiere Borrar el servicio {ServicioSeleccionado.servicio}, del tipo {ServicioSeleccionado.Tipo} con el precio ${precio}?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    ServicioTipoDePago servicioTipoDePago = _servicioServicioTipoGato?.GetServicioTipoDePagoPorId(ServicioSeleccionado.IdServicioTipoDePago);
                    servicioTipoDePago.servicio = _servicioDeServicios.GetServiciosPorId(servicioTipoDePago.IdServicio);
                    if (_listaParaAgregarLosServicios.Exists(x => x.IdServicioTipoDePago == servicioTipoDePago.IdServicioTipoDePago))
                        _listaParaAgregarLosServicios.RemoveAll(x => x.IdServicioTipoDePago == servicioTipoDePago.IdServicioTipoDePago);
                    _listaParaMostrarServiciosAgregados.Remove(ServicioSeleccionado);
                    dgvDatosServiciosSeleccionados.Rows.Remove(r);
                    total -= precio;
                    txtDebe.Text = total.ToString();
                    MostrarDatosEnGrilla();

                }
                return;
            }
        }

        internal List<decimal> GetListaDePrecios()
        {
            return listaDePrecios;
        }

        internal void SetServicios(List<ServicioTipoDePago> listaDeServicios)
        {
               _listaParaAgregarLosServicios = listaDeServicios;
        }

        internal void SetPrecios(List<decimal> listaDePrecios)
        {
            this.listaDePrecios = listaDePrecios;
        }

        internal DateTime GetFechaPago()
        {
           return fechaPago;
        }

        internal void SetFechaPago(DateTime fechaPago)
        {
           this.fechaPago = fechaPago;
        }
    }
}
