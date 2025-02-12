using MiniTaller.Entidades.Entidades;
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
    public partial class frmSeleccionarTipoVehiculo : Form
    {
        public frmSeleccionarTipoVehiculo()
        {
            InitializeComponent();
        }

        internal TiposDeVehiculos GetTipoVehiculo()
        {
            return tipo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private TiposDeVehiculos tipo;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                tipo = (TiposDeVehiculos)comboBoxTipoDeVehiculo.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidaDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (comboBoxTipoDeVehiculo.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboBoxTipoDeVehiculo, "Debe seleccionar un Tipo de Vehiculo");
                valido = false;
            }
            return valido;
        }

        private void btnAgregarTipoDeVehiculo_Click(object sender, EventArgs e)
        {
            frmTipoDeVehiculo frm = new frmTipoDeVehiculo();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboTipoVehiculo(ref comboBoxTipoDeVehiculo);
                return;
            }
        }

        private void frmSeleccionarTipoVehiculo_Load(object sender, EventArgs e)
        {
            ComboHelper.CargarComboTipoVehiculo(ref comboBoxTipoDeVehiculo);
        }
    }
}
