using MiniTaller.Entidades.Entidades;
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
    public partial class frmMarcasAE : Form
    {
        public frmMarcasAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (marca != null)
            {
                txtMarca.Text = marca.Marca;
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        Marcas marca;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (marca == null)
                {
                    marca = new Marcas();
                }
                marca.Marca = txtMarca.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                errorProvider1.SetError(txtMarca, "Debe ingresar una Marca");
                valido = false;
            }
            return valido;
        }

        public Marcas GetMarca()
        {
            return marca;
        }

        internal void SetMarca(Marcas marca)
        {
            this.marca = marca;
        }

     
    }
}
