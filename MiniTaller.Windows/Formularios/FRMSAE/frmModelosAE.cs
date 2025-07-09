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

namespace MiniTaller.Windows.Formularios.FRMSAE
{
    public partial class frmModelosAE : Form
    {
        public frmModelosAE()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ComboHelper.CargarComboMarcas(ref comboMarca);
            if (modelos != null)
            {
                txtModelo.Text = modelos.Modelo;
                comboMarca.SelectedValue = modelos.IdMarca;
            }
        }
        Modelos modelos;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (modelos == null)
                {
                    modelos = new Modelos();
                }
                modelos.Modelo = txtModelo.Text;
                modelos.Marca = (Marcas)comboMarca.SelectedItem;
                modelos.IdMarca = (int)comboMarca.SelectedValue;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                errorProvider1.SetError(txtModelo, "Debe ingresar un Modelo");
                valido = false;
            }
            if (comboMarca.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboMarca, "Debe seleccionar una Marca");
                valido = false;
            }
            return valido;
        }

        internal Modelos GetModelo()
        {
            return modelos;
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            frmMarcas frm = new frmMarcas();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboMarcas(ref comboMarca);
                return;
            }
        }

        internal void SetModelos(Modelos modelos)
        {
            this.modelos = modelos;
        }

    }
}
