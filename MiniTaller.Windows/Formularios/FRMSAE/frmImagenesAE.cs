using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTaller.Windows.Formularios.FRMSAE
{
    public partial class frmImagenesAE: Form
    {
        public frmImagenesAE(Observaciones observaciones=null, VehiculosServicios vehiculosServicios=null)
        {
            InitializeComponent();
            obser = observaciones;
            VehiculoSer = vehiculosServicios;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ComboHelper.CargarComboServiciosVehiculos(ref comboBoxVehiculoServicio);
            ComboHelper.CargarComboObservaciones(ref comboBoxObservacion);
            if (obser !=null)
            {
                checkBox1.Checked = true;
                comboBoxVehiculoServicio.Enabled = false;
                comboBoxObservacion.SelectedValue = obser.IdObservacion;
            }
            if (VehiculoSer !=null)
            {
                checkBox1.Checked = false;
                comboBoxVehiculoServicio.Enabled = true;
                comboBoxObservacion.Enabled = false;
                comboBoxVehiculoServicio.SelectedValue = VehiculoSer.IdVehiculoServicio;
            }
            if (imagen!=null)
            {
                pictureBox1.Image = ByteArrayToIMage(imagen);
            }
        }
        private static Image ByteArrayToIMage(Imagenes item)
        {
            // Convertir bytes a imagen
            using (MemoryStream ms = new MemoryStream(item.imageURL))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }
        VehiculosServicios VehiculoSer;
        Observaciones obser;
        Imagenes imagen;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (imagen==null)
                {
                    imagen = new Imagenes();
                }
                if ((int)comboBoxObservacion.SelectedIndex!=0)
                {
                    imagen.IdObservacion = (int)comboBoxObservacion.SelectedValue;
                }
                else
                {
                    imagen.IdVehiculoServicio = (int)comboBoxVehiculoServicio.SelectedValue;
                }
                imagen.imageURL = ConvertirImagen();
                DialogResult = DialogResult.OK;
            }
        }

        private byte[] ConvertirImagen()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.GetBuffer();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (checkBox1.Checked)
            {
                if (comboBoxObservacion.SelectedIndex == 0)
                {
                    valido = false;
                    errorProvider1.SetError(comboBoxObservacion, "Debe seleccionar una Observación");
                } 
            }
            else
            {
                if (comboBoxVehiculoServicio.SelectedIndex==0)
                {
                    valido = false;
                    errorProvider1.SetError(comboBoxVehiculoServicio, "Debe seleccionar un Servicio");
                }
            }
            if (pictureBox1.Image==null)
            {
                valido = false;
                errorProvider1.SetError(pictureBox1, "Debe seleccionar una Imagen");
            }
            return valido;

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            DialogResult dr = of.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(of.FileName);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBoxVehiculoServicio.Enabled = false;
                comboBoxVehiculoServicio.SelectedIndex = 0;
                comboBoxObservacion.Enabled = true;
            }
            else
            {
                comboBoxObservacion.Enabled = false;
                comboBoxObservacion.SelectedIndex = 0;
                comboBoxVehiculoServicio.Enabled = true;
            }
        }

        internal Imagenes GetImagen()
        {
            return imagen;
        }

        internal void SetImagen(Imagenes imagenes)
        {
            imagen = imagenes;
        }
    }
}
