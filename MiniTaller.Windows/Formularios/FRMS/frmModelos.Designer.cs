namespace MiniTaller.Windows.Formularios.FRMS
{
    partial class frmModelos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.colModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.lblPaginas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPaginaActual = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCerrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFiltrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 82);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel2.Controls.Add(this.btnUltimo);
            this.splitContainer1.Panel2.Controls.Add(this.btnSiguiente);
            this.splitContainer1.Panel2.Controls.Add(this.btnAnterior);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrimero);
            this.splitContainer1.Panel2.Controls.Add(this.lblPaginas);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.lblPaginaActual);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.lblRegistros);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Size = new System.Drawing.Size(755, 372);
            this.splitContainer1.SplitterDistance = 271;
            this.splitContainer1.TabIndex = 8;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModelo,
            this.colMarca});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(755, 271);
            this.dgvDatos.TabIndex = 1;
            // 
            // colModelo
            // 
            this.colModelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModelo.HeaderText = "Modelo";
            this.colModelo.Name = "colModelo";
            this.colModelo.ReadOnly = true;
            // 
            // colMarca
            // 
            this.colMarca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMarca.HeaderText = "Marca";
            this.colMarca.Name = "colMarca";
            this.colMarca.ReadOnly = true;
            // 
            // btnUltimo
            // 
            this.btnUltimo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnUltimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltimo.Image = global::MiniTaller.Windows.Properties.Resources.Fast_Forward_50px;
            this.btnUltimo.Location = new System.Drawing.Point(656, 14);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(96, 62);
            this.btnUltimo.TabIndex = 79;
            this.btnUltimo.UseVisualStyleBackColor = false;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Image = global::MiniTaller.Windows.Properties.Resources.sort_right_50px;
            this.btnSiguiente.Location = new System.Drawing.Point(537, 14);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(96, 62);
            this.btnSiguiente.TabIndex = 80;
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Image = global::MiniTaller.Windows.Properties.Resources.sort_left_50px;
            this.btnAnterior.Location = new System.Drawing.Point(420, 14);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(96, 62);
            this.btnAnterior.TabIndex = 81;
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnPrimero
            // 
            this.btnPrimero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnPrimero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimero.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimero.Image = global::MiniTaller.Windows.Properties.Resources.rewind_50px;
            this.btnPrimero.Location = new System.Drawing.Point(301, 14);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(96, 62);
            this.btnPrimero.TabIndex = 82;
            this.btnPrimero.UseVisualStyleBackColor = false;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // lblPaginas
            // 
            this.lblPaginas.AutoSize = true;
            this.lblPaginas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblPaginas.ForeColor = System.Drawing.Color.White;
            this.lblPaginas.Location = new System.Drawing.Point(104, 58);
            this.lblPaginas.Name = "lblPaginas";
            this.lblPaginas.Size = new System.Drawing.Size(24, 26);
            this.lblPaginas.TabIndex = 76;
            this.lblPaginas.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(134, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 26);
            this.label4.TabIndex = 73;
            this.label4.Text = "de";
            // 
            // lblPaginaActual
            // 
            this.lblPaginaActual.AutoSize = true;
            this.lblPaginaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblPaginaActual.ForeColor = System.Drawing.Color.White;
            this.lblPaginaActual.Location = new System.Drawing.Point(176, 58);
            this.lblPaginaActual.Name = "lblPaginaActual";
            this.lblPaginaActual.Size = new System.Drawing.Size(24, 26);
            this.lblPaginaActual.TabIndex = 77;
            this.lblPaginaActual.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 26);
            this.label2.TabIndex = 74;
            this.label2.Text = "Página:";
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(251, 14);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(24, 26);
            this.lblRegistros.TabIndex = 78;
            this.lblRegistros.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 26);
            this.label3.TabIndex = 75;
            this.label3.Text = "Cantidad de Registros:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Black;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCerrar,
            this.toolStripButtonAgregar,
            this.toolStripButtonBorrar,
            this.toolStripButtonEditar,
            this.toolStripSeparator1,
            this.toolStripButtonFiltrar,
            this.toolStripButtonActualizar,
            this.toolStripSeparator2,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(755, 82);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButtonCerrar
            // 
            this.toolStripButtonCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripButtonCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonCerrar.Image = global::MiniTaller.Windows.Properties.Resources.Close_50px;
            this.toolStripButtonCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCerrar.Name = "toolStripButtonCerrar";
            this.toolStripButtonCerrar.Size = new System.Drawing.Size(76, 79);
            this.toolStripButtonCerrar.Text = "Cerrar";
            this.toolStripButtonCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonCerrar.Click += new System.EventHandler(this.toolStripButtonCerrar_Click);
            // 
            // toolStripButtonAgregar
            // 
            this.toolStripButtonAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripButtonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonAgregar.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.toolStripButtonAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAgregar.Name = "toolStripButtonAgregar";
            this.toolStripButtonAgregar.Size = new System.Drawing.Size(92, 79);
            this.toolStripButtonAgregar.Text = "Agregar";
            this.toolStripButtonAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonAgregar.Click += new System.EventHandler(this.toolStripButtonAgregar_Click);
            // 
            // toolStripButtonBorrar
            // 
            this.toolStripButtonBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripButtonBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonBorrar.Image = global::MiniTaller.Windows.Properties.Resources.Remove_50px;
            this.toolStripButtonBorrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBorrar.Name = "toolStripButtonBorrar";
            this.toolStripButtonBorrar.Size = new System.Drawing.Size(75, 79);
            this.toolStripButtonBorrar.Text = "Borrar";
            this.toolStripButtonBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonBorrar.Click += new System.EventHandler(this.toolStripButtonBorrar_Click);
            // 
            // toolStripButtonEditar
            // 
            this.toolStripButtonEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripButtonEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonEditar.Image = global::MiniTaller.Windows.Properties.Resources.pencil_50px;
            this.toolStripButtonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditar.Name = "toolStripButtonEditar";
            this.toolStripButtonEditar.Size = new System.Drawing.Size(72, 79);
            this.toolStripButtonEditar.Text = "Editar";
            this.toolStripButtonEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEditar.Click += new System.EventHandler(this.toolStripButtonEditar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 82);
            // 
            // toolStripButtonFiltrar
            // 
            this.toolStripButtonFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripButtonFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonFiltrar.Image = global::MiniTaller.Windows.Properties.Resources.filter_50px;
            this.toolStripButtonFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFiltrar.Name = "toolStripButtonFiltrar";
            this.toolStripButtonFiltrar.Size = new System.Drawing.Size(71, 79);
            this.toolStripButtonFiltrar.Text = "Filtrar";
            this.toolStripButtonFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonFiltrar.Click += new System.EventHandler(this.toolStripButtonFiltrar_Click);
            // 
            // toolStripButtonActualizar
            // 
            this.toolStripButtonActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripButtonActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonActualizar.Image = global::MiniTaller.Windows.Properties.Resources.reset_50px;
            this.toolStripButtonActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonActualizar.Name = "toolStripButtonActualizar";
            this.toolStripButtonActualizar.Size = new System.Drawing.Size(111, 79);
            this.toolStripButtonActualizar.Text = "Actualizar";
            this.toolStripButtonActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonActualizar.Click += new System.EventHandler(this.toolStripButtonActualizar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 82);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(220, 82);
            this.toolStripTextBox1.Text = "Buscador de Modelos";
            this.toolStripTextBox1.ToolTipText = "Buscador de Modelos";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // frmModelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 454);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(755, 454);
            this.Name = "frmModelos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmModelos";
            this.Load += new System.EventHandler(this.frmModelos_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarca;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Label lblPaginas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPaginaActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCerrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonAgregar;
        private System.Windows.Forms.ToolStripButton toolStripButtonBorrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonFiltrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}