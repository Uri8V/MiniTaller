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

namespace MiniTaller.Windows.Formularios.FRMSFILTROS
{
    public partial class frmSeleccionarVehiculo : Form
    {
        public frmSeleccionarVehiculo()
        {
            InitializeComponent();
            _servicioVehiculo = new ServicioDeVehiculos();
        }
        private IServicioDeVehiculos _servicioVehiculo;
        private void frmSeleccionarVehiculo_Load(object sender, EventArgs e)
        {
            ComboHelper.CargarComboVehiculos(ref comboVehiculo);
        }
        private Vehiculos vehiculos;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                vehiculos = _servicioVehiculo.GetVehiculosPorId((int)comboVehiculo.SelectedValue);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidaDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (comboVehiculo.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboVehiculo, "Debe seleccionar un Vehiculo");
                valido = false;
            }
            return valido;
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            frmVehiculos frm = new frmVehiculos();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboVehiculos(ref comboVehiculo);
                return;
            }
        }

        internal Vehiculos GetVehiculos()
        {
            return vehiculos;
        }

    }
}
