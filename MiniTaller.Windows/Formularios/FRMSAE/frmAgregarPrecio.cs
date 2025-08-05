using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniTaller.Windows.Formularios.FRMSAE
{
    public partial class frmAgregarPrecio : Form
    {
        public frmAgregarPrecio()
        {
            InitializeComponent();
        }

        private void frmAgregarPrecio_Load(object sender, EventArgs e)
        {

        }
        private int precio = 0;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                precio = int.Parse(textBox1.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valid = true;
            if (!int.TryParse(textBox1.Text, out int precio) || precio <= 0)
            {
                errorProvider1.SetError(textBox1, "Debe ingresar un Precio mayor a 0");
                valid = false;
            }
            return valid;
        }

        internal int GetPrecio()
        {
            return precio;
        }
    }
}
