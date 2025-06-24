namespace MiniTaller.Windows.Formularios.FRMSAE
{
    partial class frmVehiculosServiciosAE
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHaber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDebe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btnAgregarMovimiento = new System.Windows.Forms.Button();
            this.btnAgregarVehiculo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboServicio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboEmpresa = new System.Windows.Forms.ComboBox();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.checkBoxEmpresa = new System.Windows.Forms.CheckBox();
            this.comboVehiculo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFecha.Location = new System.Drawing.Point(96, 231);
            this.dateTimePickerFecha.MinDate = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(87, 20);
            this.dateTimePickerFecha.TabIndex = 65;
            this.dateTimePickerFecha.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Fecha:";
            // 
            // txtHaber
            // 
            this.txtHaber.Location = new System.Drawing.Point(551, 239);
            this.txtHaber.Name = "txtHaber";
            this.txtHaber.Size = new System.Drawing.Size(153, 20);
            this.txtHaber.TabIndex = 63;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Haber:";
            // 
            // txtDebe
            // 
            this.txtDebe.Enabled = false;
            this.txtDebe.Location = new System.Drawing.Point(551, 190);
            this.txtDebe.Name = "txtDebe";
            this.txtDebe.Size = new System.Drawing.Size(153, 20);
            this.txtDebe.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(576, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "DESCRIPCIÓN:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(533, 99);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(171, 62);
            this.txtDescripcion.TabIndex = 58;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(506, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Debe:";
            // 
            // btnAgregarMovimiento
            // 
            this.btnAgregarMovimiento.Image = global::MiniTaller.Windows.Properties.Resources.add_32px;
            this.btnAgregarMovimiento.Location = new System.Drawing.Point(429, 171);
            this.btnAgregarMovimiento.Name = "btnAgregarMovimiento";
            this.btnAgregarMovimiento.Size = new System.Drawing.Size(46, 37);
            this.btnAgregarMovimiento.TabIndex = 57;
            this.btnAgregarMovimiento.UseVisualStyleBackColor = true;
            this.btnAgregarMovimiento.Click += new System.EventHandler(this.btnAgregarMovimiento_Click);
            // 
            // btnAgregarVehiculo
            // 
            this.btnAgregarVehiculo.Image = global::MiniTaller.Windows.Properties.Resources.add_32px;
            this.btnAgregarVehiculo.Location = new System.Drawing.Point(462, 108);
            this.btnAgregarVehiculo.Name = "btnAgregarVehiculo";
            this.btnAgregarVehiculo.Size = new System.Drawing.Size(48, 40);
            this.btnAgregarVehiculo.TabIndex = 56;
            this.btnAgregarVehiculo.UseVisualStyleBackColor = true;
            this.btnAgregarVehiculo.Click += new System.EventHandler(this.btnAgregarVehiculo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Seleccionar Servicio:";
            // 
            // comboServicio
            // 
            this.comboServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServicio.FormattingEnabled = true;
            this.comboServicio.Location = new System.Drawing.Point(123, 185);
            this.comboServicio.Name = "comboServicio";
            this.comboServicio.Size = new System.Drawing.Size(266, 21);
            this.comboServicio.TabIndex = 54;
            this.comboServicio.SelectedIndexChanged += new System.EventHandler(this.comboMovimiento_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Seleccionar Vehiculo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Seleccionar Empresa:";
            // 
            // comboEmpresa
            // 
            this.comboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmpresa.FormattingEnabled = true;
            this.comboEmpresa.Location = new System.Drawing.Point(123, 59);
            this.comboEmpresa.Name = "comboEmpresa";
            this.comboEmpresa.Size = new System.Drawing.Size(253, 21);
            this.comboEmpresa.TabIndex = 49;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Image = global::MiniTaller.Windows.Properties.Resources.add_32px;
            this.btnAgregarCliente.Location = new System.Drawing.Point(399, 13);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(76, 58);
            this.btnAgregarCliente.TabIndex = 48;
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Seleccionar Cliente:";
            // 
            // comboCliente
            // 
            this.comboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Location = new System.Drawing.Point(123, 10);
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(253, 21);
            this.comboCliente.TabIndex = 46;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(21, 291);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(112, 50);
            this.btnConfirmar.TabIndex = 44;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(210, 291);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 50);
            this.btnCancelar.TabIndex = 45;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // checkBoxEmpresa
            // 
            this.checkBoxEmpresa.AutoSize = true;
            this.checkBoxEmpresa.Location = new System.Drawing.Point(10, 9);
            this.checkBoxEmpresa.Name = "checkBoxEmpresa";
            this.checkBoxEmpresa.Size = new System.Drawing.Size(67, 17);
            this.checkBoxEmpresa.TabIndex = 0;
            this.checkBoxEmpresa.Text = "Empresa";
            this.checkBoxEmpresa.UseVisualStyleBackColor = true;
            this.checkBoxEmpresa.CheckedChanged += new System.EventHandler(this.checkBoxEmpresa_CheckedChanged);
            // 
            // comboVehiculo
            // 
            this.comboVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVehiculo.DropDownWidth = 200;
            this.comboVehiculo.FormattingEnabled = true;
            this.comboVehiculo.IntegralHeight = false;
            this.comboVehiculo.Location = new System.Drawing.Point(114, 119);
            this.comboVehiculo.Name = "comboVehiculo";
            this.comboVehiculo.Size = new System.Drawing.Size(322, 21);
            this.comboVehiculo.TabIndex = 52;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxEmpresa);
            this.panel1.Location = new System.Drawing.Point(493, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(83, 34);
            this.panel1.TabIndex = 51;
            // 
            // frmVehiculosServiciosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 352);
            this.ControlBox = false;
            this.Controls.Add(this.dateTimePickerFecha);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtHaber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDebe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAgregarMovimiento);
            this.Controls.Add(this.btnAgregarVehiculo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboServicio);
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
            this.Name = "frmVehiculosServiciosAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVehiculosServiciosAE";
            this.Load += new System.EventHandler(this.frmVehiculosServiciosAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHaber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDebe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAgregarMovimiento;
        private System.Windows.Forms.Button btnAgregarVehiculo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboServicio;
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
        private System.Windows.Forms.CheckBox checkBoxEmpresa;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}