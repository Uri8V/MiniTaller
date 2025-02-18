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
    public partial class frmTipoDeTelefonoAE : Form
    {
        public frmTipoDeTelefonoAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipo != null)
            {
                txtTipoDeTelefono.Text = tipo.Tipo;
            }
        }
        private TiposDeTelefono tipo;
        internal TiposDeTelefono GetTipoDePago()
        {
            return tipo;
        }

        internal void SetTipoTelefono(TiposDeTelefono tipo)
        {
            this.tipo = tipo;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validardatos())
            {
                if (tipo == null)
                {
                    tipo = new TiposDeTelefono();
                }
                tipo.Tipo = txtTipoDeTelefono.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool Validardatos()
        {
            errorProvider1.Clear();
            bool validar = true;
            if (string.IsNullOrEmpty(txtTipoDeTelefono.Text))
            {
                errorProvider1.SetError(txtTipoDeTelefono, "Debe ingresar un Tipo de Telefono");
                validar = false;
            }
            return validar;
        }
    }
}
