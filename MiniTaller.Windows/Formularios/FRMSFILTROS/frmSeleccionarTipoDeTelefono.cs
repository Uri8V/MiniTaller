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
    public partial class frmSeleccionarTipoDeTelefono: Form
    {
        public frmSeleccionarTipoDeTelefono()
        {
            InitializeComponent();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private TiposDeTelefono tipo;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                tipo = (TiposDeTelefono)comboBoxTipoDeTelefono.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidaDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (comboBoxTipoDeTelefono.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboBoxTipoDeTelefono, "Debe seleccionar un Tipo de Telefono");
                valido = false;
            }
            return valido;
        }

        private void frmSeleccionarTipoDeTelefono_Load(object sender, EventArgs e)
        {
            ComboHelper.CargarComboTipoDeTelefono(ref comboBoxTipoDeTelefono);
        }

        private void btnAgregarTipoDeTelefono_Click(object sender, EventArgs e)
        {
            frmTipoDePago frm = new frmTipoDePago();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboTipoCliente(ref comboBoxTipoDeTelefono);
                return;
            }
        }
        internal TiposDeTelefono GetTipo()
        {
            return tipo;
        }
    }
}
