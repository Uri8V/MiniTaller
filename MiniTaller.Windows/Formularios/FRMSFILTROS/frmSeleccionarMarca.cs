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
    public partial class frmSeleccionarMarca : Form
    {
        public frmSeleccionarMarca()
        {
            InitializeComponent();
        }
        private void frmSeleccionarMarca_Load(object sender, EventArgs e)
        {
            ComboHelper.CargarComboMarcas(ref comboBoxMarca);
        }
        private Marcas marca;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                marca = (Marcas)comboBoxMarca.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidaDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (comboBoxMarca.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboBoxMarca, "Debe seleccionar una Marca");
                valido = false;
            }
            return valido;
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            frmMarcas frm = new frmMarcas();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboMarcas(ref comboBoxMarca);
                return;
            }
        }

        internal Marcas GetMarca()
        {
            return marca;
        }
    }
}
