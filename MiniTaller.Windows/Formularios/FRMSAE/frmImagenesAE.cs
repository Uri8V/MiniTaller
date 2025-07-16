using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
            if (obser !=null)
            {
                ComboHelper.CargarComboObservaciones(ref comboBoxObservacion, obser.IdObservacion);
                comboBoxVehiculoServicio.Visible = false;
                label2.Visible = true;
                label1.Visible = false;
                comboBoxObservacion.Visible = true;
                comboBoxObservacion.SelectedValue = obser.IdObservacion;
            }
            if (VehiculoSer !=null)
            {
                ComboHelper.CargarComboServiciosVehiculos(ref comboBoxVehiculoServicio, VehiculoSer.IdVehiculoServicio);
                comboBoxVehiculoServicio.Visible = true;
                label2.Visible = false;
                comboBoxObservacion.Visible = false;
                label1.Visible = true;
                comboBoxVehiculoServicio.SelectedValue = VehiculoSer.IdVehiculoServicio;
            }
            if (imagen!=null)
            {
                pictureBox1.Image = ByteArrayToIMage(imagen);
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
                if (obser!=null)
                {
                    imagen.IdObservacion = (int)comboBoxObservacion.SelectedValue;
                }
                else
                {
                    imagen.IdVehiculoServicio = (int)comboBoxVehiculoServicio.SelectedValue;
                }
                imagen.imageURL = ConvertirYReducirImagen(pictureBox1);
                DialogResult = DialogResult.OK;
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
        public static byte[] ConvertirYReducirImagen(PictureBox pb, int anchoDeseado = 800, int altoDeseado = 600)
        {
            using (var imgOriginal = pb.Image)
            {
                var imgReducida = new Bitmap(anchoDeseado, altoDeseado);
                using (var g = Graphics.FromImage(imgReducida))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(imgOriginal, 0, 0, anchoDeseado, altoDeseado);
                }

                using (var ms = new MemoryStream())
                {
                    imgReducida.Save(ms, ImageFormat.Jpeg); // usa JPG para menor peso
                    return ms.ToArray();
                }
            }
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            DialogResult dr = of.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                if (pictureBox1.Image != null)
                    pictureBox1.Image.Dispose();
                pictureBox1.Image = Image.FromFile(of.FileName);
            }
        }
        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (pictureBox1.Image==null)
            {
                valido = false;
                errorProvider1.SetError(pictureBox1, "Debe seleccionar una Imagen");
            }
            return valido;

        }

        internal Imagenes GetImagen()
        {
            return imagen;
        }

        internal void SetImagen(Imagenes imagenes)
        {
            imagen = imagenes;
        }

        private void frmImagenesAE_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
