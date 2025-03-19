using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Servicios.Interfaces;
using MiniTaller.Servicios.Servicios;
using MiniTaller.Windows.Formularios.FRMSAE;
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

namespace MiniTaller.Windows.Formularios.FRMS
{
    public partial class frmImagenes : Form
    {
        public frmImagenes(Observaciones observaciones = null, VehiculosServicios vehiculosServicios = null)
        {
            InitializeComponent();
            _servicio = new ServicioDeImagenes();
            _servicioDeObservaciones = new ServicioDeObservaciones();
            _servicioDeVehiculosServicios = new ServicioDeVehiculosServicios();
            _servicioDeClientes = new ServicioDeClientes();
            _servicioDeVehiculos = new ServicioDeVehiculos();
            this.observaciones = observaciones;
            this.vehiculosServicios = vehiculosServicios;
        }
        private List<ImagenesDto> lista;
        private readonly IServicioDeImagenes _servicio;
        private readonly IServicioDeObservaciones _servicioDeObservaciones;
        private readonly IServicioDeVehiculosServicios _servicioDeVehiculosServicios;
        private readonly IServicioDeClientes _servicioDeClientes;
        private readonly IServicioDeVehiculos _servicioDeVehiculos;
        private  Observaciones observaciones;
        private  VehiculosServicios vehiculosServicios;
        int? IdObservacion = null;
        int? IdVehiculoServicio = null;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 2;
        int paginaActual = 1;

        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmImagenes_Load(object sender, EventArgs e)
        {
            if (observaciones != null)
            {
                IdObservacion = observaciones.IdObservacion;
            }
            if (vehiculosServicios != null)
            {
                IdVehiculoServicio = vehiculosServicios.IdVehiculoServicio;
            }
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            registros = _servicio.GetCantidad(IdObservacion, IdVehiculoServicio);
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarPaginado();
        }

        private void MostrarPaginado()
        {
            lista = _servicio.GetImagenesPorPagina(registrosPorPagina, paginaActual, IdObservacion, IdVehiculoServicio);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelpers.LimpiarGrilla(dataGridView1);
            GridHelpers.ConstruirColumnaImage(dataGridView1);
            foreach (var item in lista)
            {
                DataGridViewRow row = GridHelpers.ContruirFIlas(dataGridView1);
                GridHelpers.ByteArrayToIMage(item, row);
            }
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();
            lblRegistros.Text = registros.ToString();

            if (observaciones != null)
            {
                txtCliente.Text = _servicioDeClientes.GetInfo(observaciones.IdCliente);
                txtVehiculo.Text = _servicioDeVehiculos.GetVehiculosPorId(observaciones.IdVehiculo).Patente;
            }
            if (vehiculosServicios != null)
            {
                txtCliente.Text = _servicioDeClientes.GetInfo(vehiculosServicios.IdCliente);
                txtVehiculo.Text = _servicioDeVehiculos.GetVehiculosPorId(vehiculosServicios.IdVehiculo).Patente;
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual == paginas)
            {
                return;
            }
            paginaActual++;
            MostrarPaginado();

        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual == 1)
            {
                return;
            }
            paginaActual--;
            MostrarPaginado();
        }
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            paginaActual = paginas;
            MostrarPaginado();
        }
        private void btnPrimero_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();
        }

        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            frmImagenesAE frm = new frmImagenesAE(observaciones, vehiculosServicios);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var imagen = frm.GetImagen();
            //preguntar si existe
            if (!_servicio.Existe(imagen))
            {
                _servicio.Guardar(imagen);
                MessageBox.Show("Imagen agregada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
                registros = _servicio.GetCantidad(null, null);
                paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
                RecargarGrilla();
            }
            else
            {
                MessageBox.Show("La Imagen ya existe!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            ImagenesDto imagenABorrar = (ImagenesDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea eliminar la Imagen del Cliente {imagenABorrar.Info} con el vehiculo {imagenABorrar.Patente}?", "Confirmar Selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            //Falta metodo de objeto relacionado
            GridHelpers.QuitarFila(dataGridView1, r);
            _servicio.Borrar(imagenABorrar.IdImage);
            RecargarGrilla();
        }
        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            ImagenesDto ImagenDto = (ImagenesDto)r.Tag;
            ImagenesDto CopiaImagen = (ImagenesDto)ImagenDto.Clone();

            Imagenes imagenes = _servicio.GetImagenPorId(ImagenDto.IdImage);
            try
            {
                if (imagenes.IdObservacion!=0 && imagenes.IdObservacion!=null)
                {
                    observaciones =_servicioDeObservaciones.GetVehiculoObservacionPorId((int)imagenes.IdObservacion);
                }
                if (imagenes.IdVehiculoServicio!=0 && imagenes.IdVehiculoServicio!=null)
                {
                    vehiculosServicios = _servicioDeVehiculosServicios.GetVehiculoServicioPorId((int)imagenes.IdVehiculoServicio);
                }
                frmImagenesAE frm = new frmImagenesAE(observaciones,vehiculosServicios) { Text = "Editar imagen" };
                frm.SetImagen(imagenes);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelpers.SetearFila(r, CopiaImagen);

                    return;
                }
                imagenes = frm.GetImagen();
                if (!_servicio.Existe(imagenes))
                {
                    if (imagenes != null)
                    {
                        //Crear el dto
                        ImagenDto.IdImage = imagenes.IdImage;
                        ImagenDto.imageURL = imagenes.imageURL;
                        ImagenDto.Patente = observaciones!=null?_servicioDeVehiculos.GetVehiculosPorId(observaciones.IdVehiculo).Patente:_servicioDeVehiculos.GetVehiculosPorId(vehiculosServicios.IdVehiculo).Patente;
                        ImagenDto.Info = observaciones!=null?_servicioDeClientes.GetInfo(observaciones.IdCliente):_servicioDeClientes.GetInfo(vehiculosServicios.IdCliente);
                        GridHelpers.SetearFila(r, ImagenDto);
                        _servicio.Guardar(imagenes);
                        RecargarGrilla();
                    }
                    else
                    {
                        //Recupero la copia del dto
                        GridHelpers.SetearFila(r, CopiaImagen);
                    }
                }
                else
                {
                    MessageBox.Show("La imagen ya existe!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                GridHelpers.SetearFila(r, CopiaImagen);
                throw;
            }
        }
    }
}
