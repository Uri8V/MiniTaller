namespace MiniTaller.Windows.Formularios.FRMSAE
{
    partial class frmObservacionesAE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregarVehiculo = new System.Windows.Forms.Button();
            this.checkBoxEmpresa = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboEmpresa = new System.Windows.Forms.ComboBox();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.comboVehiculo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.rtxtObservaciones = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonNegrita = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCursiva = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSubrayar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonTamaño = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonColores = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonItems = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.dateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFecha.Location = new System.Drawing.Point(1192, 361);
            this.dateTimePickerFecha.MinDate = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(142, 35);
            this.dateTimePickerFecha.TabIndex = 8;
            this.dateTimePickerFecha.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1100, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 29);
            this.label8.TabIndex = 86;
            this.label8.Text = "Fecha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(14, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 29);
            this.label5.TabIndex = 81;
            this.label5.Text = "OBSERVACIÓN:";
            // 
            // btnAgregarVehiculo
            // 
            this.btnAgregarVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(191)))), ((int)(((byte)(96)))));
            this.btnAgregarVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnAgregarVehiculo.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarVehiculo.Location = new System.Drawing.Point(1011, 354);
            this.btnAgregarVehiculo.Name = "btnAgregarVehiculo";
            this.btnAgregarVehiculo.Size = new System.Drawing.Size(76, 54);
            this.btnAgregarVehiculo.TabIndex = 7;
            this.btnAgregarVehiculo.Tag = "Agregar Vehiculo";
            this.btnAgregarVehiculo.UseVisualStyleBackColor = false;
            this.btnAgregarVehiculo.Click += new System.EventHandler(this.btnAgregarVehiculo_Click);
            // 
            // checkBoxEmpresa
            // 
            this.checkBoxEmpresa.AutoSize = true;
            this.checkBoxEmpresa.ForeColor = System.Drawing.Color.White;
            this.checkBoxEmpresa.Location = new System.Drawing.Point(3, 9);
            this.checkBoxEmpresa.Name = "checkBoxEmpresa";
            this.checkBoxEmpresa.Size = new System.Drawing.Size(129, 33);
            this.checkBoxEmpresa.TabIndex = 0;
            this.checkBoxEmpresa.Text = "Empresa";
            this.checkBoxEmpresa.UseVisualStyleBackColor = true;
            this.checkBoxEmpresa.CheckedChanged += new System.EventHandler(this.checkBoxEmpresa_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 29);
            this.label3.TabIndex = 75;
            this.label3.Text = "Seleccionar Vehiculo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 29);
            this.label1.TabIndex = 72;
            this.label1.Text = "Seleccionar Empresa:";
            // 
            // comboEmpresa
            // 
            this.comboEmpresa.DropDownHeight = 300;
            this.comboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.comboEmpresa.FormattingEnabled = true;
            this.comboEmpresa.IntegralHeight = false;
            this.comboEmpresa.Location = new System.Drawing.Point(266, 281);
            this.comboEmpresa.MaxDropDownItems = 50;
            this.comboEmpresa.Name = "comboEmpresa";
            this.comboEmpresa.Size = new System.Drawing.Size(626, 37);
            this.comboEmpresa.TabIndex = 4;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(191)))), ((int)(((byte)(96)))));
            this.btnAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnAgregarCliente.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarCliente.Location = new System.Drawing.Point(1105, 255);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(76, 58);
            this.btnAgregarCliente.TabIndex = 5;
            this.btnAgregarCliente.Tag = "Agregar Cliente";
            this.btnAgregarCliente.UseVisualStyleBackColor = false;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 29);
            this.label2.TabIndex = 69;
            this.label2.Text = "Seleccionar Cliente:";
            // 
            // comboCliente
            // 
            this.comboCliente.DropDownHeight = 300;
            this.comboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.IntegralHeight = false;
            this.comboCliente.Location = new System.Drawing.Point(249, 232);
            this.comboCliente.MaxDropDownItems = 50;
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(643, 37);
            this.comboCliente.TabIndex = 2;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(166)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnConfirmar.Location = new System.Drawing.Point(356, 457);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(169, 64);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(59)))), ((int)(((byte)(57)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelar.Location = new System.Drawing.Point(680, 457);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(169, 64);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // comboVehiculo
            // 
            this.comboVehiculo.DropDownHeight = 500;
            this.comboVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVehiculo.DropDownWidth = 900;
            this.comboVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.comboVehiculo.FormattingEnabled = true;
            this.comboVehiculo.IntegralHeight = false;
            this.comboVehiculo.Location = new System.Drawing.Point(266, 364);
            this.comboVehiculo.MaxDropDownItems = 50;
            this.comboVehiculo.Name = "comboVehiculo";
            this.comboVehiculo.Size = new System.Drawing.Size(710, 37);
            this.comboVehiculo.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxEmpresa);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.panel1.Location = new System.Drawing.Point(951, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 45);
            this.panel1.TabIndex = 3;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // rtxtObservaciones
            // 
            this.rtxtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.rtxtObservaciones.Location = new System.Drawing.Point(213, 51);
            this.rtxtObservaciones.Name = "rtxtObservaciones";
            this.rtxtObservaciones.Size = new System.Drawing.Size(887, 156);
            this.rtxtObservaciones.TabIndex = 1;
            this.rtxtObservaciones.Text = "";
            this.rtxtObservaciones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtObservaciones_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(41)))), ((int)(((byte)(40)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonNegrita,
            this.toolStripSeparator1,
            this.toolStripButtonCursiva,
            this.toolStripSeparator2,
            this.toolStripButtonSubrayar,
            this.toolStripSeparator3,
            this.toolStripButtonTamaño,
            this.toolStripSeparator4,
            this.toolStripButtonColores,
            this.toolStripSeparator5,
            this.toolStripButtonItems});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1366, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(41)))), ((int)(((byte)(40)))));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(161, 36);
            this.toolStripLabel1.Text = "Herramientas:";
            // 
            // toolStripButtonNegrita
            // 
            this.toolStripButtonNegrita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(59)))));
            this.toolStripButtonNegrita.Image = global::MiniTaller.Windows.Properties.Resources.Negrita_32px;
            this.toolStripButtonNegrita.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonNegrita.ImageTransparentColor = System.Drawing.Color.LimeGreen;
            this.toolStripButtonNegrita.Name = "toolStripButtonNegrita";
            this.toolStripButtonNegrita.Size = new System.Drawing.Size(129, 36);
            this.toolStripButtonNegrita.Text = "Negrita";
            this.toolStripButtonNegrita.Click += new System.EventHandler(this.toolStripButtonNegrita_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonCursiva
            // 
            this.toolStripButtonCursiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(59)))));
            this.toolStripButtonCursiva.Image = global::MiniTaller.Windows.Properties.Resources.Cursiva_32px;
            this.toolStripButtonCursiva.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonCursiva.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCursiva.Name = "toolStripButtonCursiva";
            this.toolStripButtonCursiva.Size = new System.Drawing.Size(127, 36);
            this.toolStripButtonCursiva.Text = "Cursiva";
            this.toolStripButtonCursiva.Click += new System.EventHandler(this.toolStripButtonCursiva_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonSubrayar
            // 
            this.toolStripButtonSubrayar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(59)))));
            this.toolStripButtonSubrayar.Image = global::MiniTaller.Windows.Properties.Resources.Subrayar_32px;
            this.toolStripButtonSubrayar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSubrayar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSubrayar.Name = "toolStripButtonSubrayar";
            this.toolStripButtonSubrayar.Size = new System.Drawing.Size(143, 36);
            this.toolStripButtonSubrayar.Text = "Subrayar";
            this.toolStripButtonSubrayar.Click += new System.EventHandler(this.toolStripButtonSubrayar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonTamaño
            // 
            this.toolStripButtonTamaño.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(59)))));
            this.toolStripButtonTamaño.Image = global::MiniTaller.Windows.Properties.Resources.Tamaño_32px;
            this.toolStripButtonTamaño.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonTamaño.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTamaño.Name = "toolStripButtonTamaño";
            this.toolStripButtonTamaño.Size = new System.Drawing.Size(248, 36);
            this.toolStripButtonTamaño.Text = "Tamaño de Fuente";
            this.toolStripButtonTamaño.Click += new System.EventHandler(this.toolStripButtonTamaño_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonColores
            // 
            this.toolStripButtonColores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(59)))));
            this.toolStripButtonColores.Image = global::MiniTaller.Windows.Properties.Resources.Colores_32px;
            this.toolStripButtonColores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonColores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonColores.Name = "toolStripButtonColores";
            this.toolStripButtonColores.Size = new System.Drawing.Size(130, 36);
            this.toolStripButtonColores.Text = "Colores";
            this.toolStripButtonColores.Click += new System.EventHandler(this.toolStripButtonColores_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonItems
            // 
            this.toolStripButtonItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(59)))));
            this.toolStripButtonItems.Image = global::MiniTaller.Windows.Properties.Resources.bulleted_list_32px;
            this.toolStripButtonItems.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonItems.ImageTransparentColor = System.Drawing.Color.Linen;
            this.toolStripButtonItems.Name = "toolStripButtonItems";
            this.toolStripButtonItems.Size = new System.Drawing.Size(108, 36);
            this.toolStripButtonItems.Text = "Items";
            this.toolStripButtonItems.Click += new System.EventHandler(this.toolStripButtonItems_Click);
            // 
            // frmObservacionesAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(41)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1366, 543);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.rtxtObservaciones);
            this.Controls.Add(this.dateTimePickerFecha);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAgregarVehiculo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboEmpresa);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboCliente);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.comboVehiculo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(1112, 543);
            this.Name = "frmObservacionesAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmObservacionesAE";
            this.Load += new System.EventHandler(this.frmObservacionesAE_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarVehiculo;
        private System.Windows.Forms.CheckBox checkBoxEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboEmpresa;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox comboVehiculo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.RichTextBox rtxtObservaciones;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNegrita;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCursiva;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSubrayar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonTamaño;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonColores;
        private System.Windows.Forms.ToolStripButton toolStripButtonItems;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}