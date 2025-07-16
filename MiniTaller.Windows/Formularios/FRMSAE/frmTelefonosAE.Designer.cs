namespace MiniTaller.Windows.Formularios.FRMSAE
{
    partial class frmTelefonosAE
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
            this.checkBoxEmpresa = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboEmpresa = new System.Windows.Forms.ComboBox();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.comboClientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBoxTipoDeTelefono = new System.Windows.Forms.ComboBox();
            this.btnAgregarTipoDeTelefono = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxEmpresa
            // 
            this.checkBoxEmpresa.AutoSize = true;
            this.checkBoxEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.checkBoxEmpresa.ForeColor = System.Drawing.Color.White;
            this.checkBoxEmpresa.Location = new System.Drawing.Point(895, 179);
            this.checkBoxEmpresa.Name = "checkBoxEmpresa";
            this.checkBoxEmpresa.Size = new System.Drawing.Size(175, 33);
            this.checkBoxEmpresa.TabIndex = 4;
            this.checkBoxEmpresa.Text = "Es Empresa?";
            this.checkBoxEmpresa.UseVisualStyleBackColor = true;
            this.checkBoxEmpresa.CheckedChanged += new System.EventHandler(this.checkBoxEmpresa_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 29);
            this.label5.TabIndex = 38;
            this.label5.Text = "Empresa:";
            // 
            // comboEmpresa
            // 
            this.comboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmpresa.DropDownWidth = 500;
            this.comboEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.comboEmpresa.FormattingEnabled = true;
            this.comboEmpresa.IntegralHeight = false;
            this.comboEmpresa.Location = new System.Drawing.Point(137, 197);
            this.comboEmpresa.MaxDropDownItems = 20;
            this.comboEmpresa.Name = "comboEmpresa";
            this.comboEmpresa.Size = new System.Drawing.Size(726, 37);
            this.comboEmpresa.TabIndex = 5;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(191)))), ((int)(((byte)(96)))));
            this.btnAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCliente.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarCliente.Location = new System.Drawing.Point(1076, 169);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(76, 58);
            this.btnAgregarCliente.TabIndex = 6;
            this.btnAgregarCliente.Tag = "Agregar Cliente";
            this.btnAgregarCliente.UseVisualStyleBackColor = false;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // comboClientes
            // 
            this.comboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClientes.DropDownWidth = 500;
            this.comboClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.comboClientes.FormattingEnabled = true;
            this.comboClientes.IntegralHeight = false;
            this.comboClientes.Location = new System.Drawing.Point(128, 141);
            this.comboClientes.MaxDropDownItems = 20;
            this.comboClientes.Name = "comboClientes";
            this.comboClientes.Size = new System.Drawing.Size(735, 37);
            this.comboClientes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 29);
            this.label2.TabIndex = 31;
            this.label2.Text = "Tipo de Telefono:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 29);
            this.label4.TabIndex = 29;
            this.label4.Text = "Clientes:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtTelefono.Location = new System.Drawing.Point(137, 12);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(278, 35);
            this.txtTelefono.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(59)))), ((int)(((byte)(57)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnCancelar.Location = new System.Drawing.Point(678, 270);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(169, 64);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(166)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnConfirmar.Location = new System.Drawing.Point(310, 270);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(169, 64);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // comboBoxTipoDeTelefono
            // 
            this.comboBoxTipoDeTelefono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoDeTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.comboBoxTipoDeTelefono.FormattingEnabled = true;
            this.comboBoxTipoDeTelefono.Location = new System.Drawing.Point(227, 77);
            this.comboBoxTipoDeTelefono.MaxDropDownItems = 50;
            this.comboBoxTipoDeTelefono.Name = "comboBoxTipoDeTelefono";
            this.comboBoxTipoDeTelefono.Size = new System.Drawing.Size(381, 37);
            this.comboBoxTipoDeTelefono.TabIndex = 1;
            // 
            // btnAgregarTipoDeTelefono
            // 
            this.btnAgregarTipoDeTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(191)))), ((int)(((byte)(96)))));
            this.btnAgregarTipoDeTelefono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTipoDeTelefono.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarTipoDeTelefono.Location = new System.Drawing.Point(634, 69);
            this.btnAgregarTipoDeTelefono.Name = "btnAgregarTipoDeTelefono";
            this.btnAgregarTipoDeTelefono.Size = new System.Drawing.Size(76, 58);
            this.btnAgregarTipoDeTelefono.TabIndex = 2;
            this.btnAgregarTipoDeTelefono.Tag = "Agregar Tipo de Telefono";
            this.btnAgregarTipoDeTelefono.UseVisualStyleBackColor = false;
            this.btnAgregarTipoDeTelefono.Click += new System.EventHandler(this.btnAgregarTipoDeTelefono_Click);
            // 
            // frmTelefonosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(41)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1169, 360);
            this.ControlBox = false;
            this.Controls.Add(this.btnAgregarTipoDeTelefono);
            this.Controls.Add(this.comboBoxTipoDeTelefono);
            this.Controls.Add(this.checkBoxEmpresa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboEmpresa);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.comboClientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(823, 360);
            this.Name = "frmTelefonosAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTelefonosAE";
            this.Load += new System.EventHandler(this.frmTelefonosAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxEmpresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboEmpresa;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.ComboBox comboClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox comboBoxTipoDeTelefono;
        private System.Windows.Forms.Button btnAgregarTipoDeTelefono;
    }
}