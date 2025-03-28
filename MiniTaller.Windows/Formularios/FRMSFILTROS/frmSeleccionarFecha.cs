﻿using System;
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
    public partial class frmSeleccionarFecha : Form
    {
        public frmSeleccionarFecha()
        {
            InitializeComponent();
        }

        private void frmSeleccionarFecha_Load(object sender, EventArgs e)
        {

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private DateTime fecha;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                fecha = (DateTime)dateTimePickerFiltro.Value;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool validar = true;
            errorProvider1.Clear();
            if (dateTimePickerFiltro.Value > DateTime.Now)
            {
                errorProvider1.SetError(dateTimePickerFiltro, "Debe ingresar una fecha actual");
                validar = false;
            }
            return validar;
        }

        internal DateTime GetFecha()
        {
            return fecha;
        }
    }
}
