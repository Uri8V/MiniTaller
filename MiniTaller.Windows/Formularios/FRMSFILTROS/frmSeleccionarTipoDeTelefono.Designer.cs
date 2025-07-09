namespace MiniTaller.Windows.Formularios.FRMSFILTROS
{
    partial class frmSeleccionarTipoDeTelefono
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
            this.btnAgregarTipoDeTelefono = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTipoDeTelefono = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarTipoDeTelefono
            // 
            this.btnAgregarTipoDeTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(140)))), ((int)(((byte)(71)))));
            this.btnAgregarTipoDeTelefono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTipoDeTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAgregarTipoDeTelefono.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarTipoDeTelefono.Location = new System.Drawing.Point(662, 12);
            this.btnAgregarTipoDeTelefono.Name = "btnAgregarTipoDeTelefono";
            this.btnAgregarTipoDeTelefono.Size = new System.Drawing.Size(62, 51);
            this.btnAgregarTipoDeTelefono.TabIndex = 1;
            this.btnAgregarTipoDeTelefono.Tag = "Agregar Tipo de Telefono";
            this.btnAgregarTipoDeTelefono.UseVisualStyleBackColor = false;
            this.btnAgregarTipoDeTelefono.Click += new System.EventHandler(this.btnAgregarTipoDeTelefono_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Seleccionar el Tipo de Telefono:";
            // 
            // comboBoxTipoDeTelefono
            // 
            this.comboBoxTipoDeTelefono.AllowDrop = true;
            this.comboBoxTipoDeTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.comboBoxTipoDeTelefono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoDeTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboBoxTipoDeTelefono.FormattingEnabled = true;
            this.comboBoxTipoDeTelefono.IntegralHeight = false;
            this.comboBoxTipoDeTelefono.Location = new System.Drawing.Point(300, 22);
            this.comboBoxTipoDeTelefono.MaxDropDownItems = 20;
            this.comboBoxTipoDeTelefono.Name = "comboBoxTipoDeTelefono";
            this.comboBoxTipoDeTelefono.Size = new System.Drawing.Size(356, 32);
            this.comboBoxTipoDeTelefono.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.AllowDrop = true;
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnConfirmar.Location = new System.Drawing.Point(213, 93);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(148, 42);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AllowDrop = true;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnCancelar.Location = new System.Drawing.Point(433, 93);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 42);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSeleccionarTipoDeTelefono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(736, 147);
            this.ControlBox = false;
            this.Controls.Add(this.btnAgregarTipoDeTelefono);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTipoDeTelefono);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(670, 147);
            this.Name = "frmSeleccionarTipoDeTelefono";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSeleccionarTipoDeTelefono";
            this.Load += new System.EventHandler(this.frmSeleccionarTipoDeTelefono_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarTipoDeTelefono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTipoDeTelefono;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}