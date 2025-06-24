using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Servicios.Interfaces;
using MiniTaller.Servicios.Servicios;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniTaller.Windows.Formularios.FRMSFILTROS
{
    public partial class frmSeleccionarVehiculo : Form
    {
        public frmSeleccionarVehiculo()
        {
            InitializeComponent();
            _servicioVehiculo = new ServicioDeVehiculos();
          /*comboVehiculo.DrawMode = DrawMode.OwnerDrawVariable;
            comboVehiculo.MeasureItem += comboVehiculo_MeasureItem;Porque no estás llamando a los métodos directamente, estás diciendo:
                                                                    *“ComboBox, cuando se dispare este evento… usá este método para manejarlo”.
                                                                    *Entonces, en lugar de esto: comboVehiculo_MeasureItem(sender, e); // llamada directa, con parámetros
                                                                    *Lo que hacés es decirle: comboVehiculo.MeasureItem += comboVehiculo_MeasureItem;
                                                                    *Con eso le estás registrando tu método como un “manejador del evento”.
                                                                    *El sistema lo va a llamar automáticamente cada vez que lo necesite, 
                                                                    *y en ese momento le va a pasar los parámetros correctos (sender y MeasureItemEventArgs e).

➕ ¿Por qué usamos += en lugar de =?
            Porque un evento puede tener varios métodos suscritos al mismo tiempo.
            El += agrega tu método a una “lista de métodos” interna.
            Si usaras =, estarías reemplazando cualquier otro método que ya estuviera suscrito 
            (lo cual, en algunos casos, puede ser problemático).
            
            En resumen: no pasás parámetros porque el sistema se encarga de eso automáticamente, 
            y usás += porque podés tener múltiples reacciones al mismo evento.
            comboVehiculo.DrawItem += comboVehiculo_DrawItem;*/
           
        }
        private IServicioDeVehiculos _servicioVehiculo;
        private void frmSeleccionarVehiculo_Load(object sender, EventArgs e)
        {
            ComboHelper.CargarComboVehiculos(ref comboVehiculo);
        }
        private Vehiculos vehiculos;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                vehiculos = _servicioVehiculo.GetVehiculosPorId((int)comboVehiculo.SelectedValue);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidaDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (comboVehiculo.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboVehiculo, "Debe seleccionar un Vehiculo");
                valido = false;
            }
            return valido;
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            frmVehiculos frm = new frmVehiculos();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboVehiculos(ref comboVehiculo);
                return;
            }
        }

        internal Vehiculos GetVehiculos()
        {
            return vehiculos;
        }

        //private void comboVehiculo_MeasureItem(object sender /*Es el comboVehiculo*/, MeasureItemEventArgs e)
        ///*
        // * Es un evento que el ComboBox dispara antes de mostrar cada ítem, cuando estás en modo OwnerDrawVariable.
        // * Por eso vos no lo llamás directamente, lo llama automáticamente el ComboBox internamente cuando necesita calcular alturas. 
        // * Tu trabajo es responderle eso a través del parámetro MeasureItemEventArgs.
        // */
        //{
        //    if (e.Index < 0) return;/*Es una protección común. 
        //                             * El índice -1 puede ocurrir si el ComboBox llama al evento sin tener un ítem válido seleccionado.
        //                             * No es para chequear si hay texto, sino para evitar romper el código cuando e.Index apunta a la nada.*/

        //    var item = comboVehiculo.Items[e.Index] as VehiculosComboDto;
        //    string texto = item != null ? item.Info : comboVehiculo.Items[e.Index].ToString();

        //    Font font = comboVehiculo.Font;/*No obligatoria, pero muy recomendable.
        //                                    * El ComboBox puede tener fuente distinta a la del formulario,
        //                                    * y si querés calcular bien el tamaño del texto, tenés que usar la que efectivamente se va a dibujar.*/
        //    int width = comboVehiculo.DropDownWidth;

        //    Size textSize = TextRenderer.MeasureText(texto, font, new Size(width, 0), TextFormatFlags.WordBreak);
        //    /*Significa: "Medime el espacio que ocupa este texto, con esta fuente, en este ancho máximo (DropDownWidth), y permitiendo saltos de línea."
        //     * TextFormatFlags.WordBreak le dice: “si el texto no entra en una sola línea, cortalo y seguí en otra”.
        //     * Sin eso, te daría siempre la altura de una línea, y no verías el beneficio del ajuste automático de altura.*/
        //    e.ItemHeight = textSize.Height;
        //}

        //private void comboVehiculo_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    if (e.Index < 0) return;

        //    e.DrawBackground();/*Sirve para dibujar el fondo del ítem antes de pintar el texto.
        //                        * ¿Por qué? Porque si no lo hacés vos, puede quedar basura gráfica: colores viejos, manchas, o texto sobre fondos no actualizados.
        //                        * Además, este método ya toma en cuenta si el ítem está seleccionado, y pinta el fondo con el color correspondiente (por ejemplo, azul).*/

        //    var item = comboVehiculo.Items[e.Index] as VehiculosComboDto; 

        //    string texto = item != null ? item.Info : comboVehiculo.Items[e.Index].ToString();

        //    Color color = (e.State & DrawItemState.Selected) == DrawItemState.Selected
        //                  ? SystemColors.HighlightText
        //                  : SystemColors.ControlText;/*Porque cuando el usuario selecciona un ítem, el fondo cambia a azul (por ejemplo), 
        //                                              * y si no cambiamos el color del texto a blanco (HighlightText), se hace ilegible.
        //                                              * Y si el ítem no está seleccionado, usamos el color normal de texto (ControlText).
        //                                              * Si no hacés esto, ¡corres el riesgo de que el texto no se vea bien en ningún modo de selección o tema del sistema!*/

        //    TextRenderer.DrawText(e.Graphics, texto, comboVehiculo.Font, e.Bounds, color, TextFormatFlags.WordBreak);
        //    /*TextRenderer es una clase de System.Windows.Forms, no de System.IO, 
        //     * y está pensada para dibujar texto en controles usando el motor GDI del sistema operativo de Windows.
        //     * Por eso es muy eficiente para UI clásica*/

        //    e.DrawFocusRectangle();/*Esto lo usamos para que, si el ítem tiene el foco (por ejemplo, lo seleccionaste con las flechitas del teclado),
        //                            * se dibuje ese marco discontínuo típico alrededor, marcando visualmente que tiene el foco.
        //                            * Es una mejora de usabilidad.*/
        //}
    }
}
