namespace RelojChecador
{
    partial class wdwAdmin
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHorarios = new System.Windows.Forms.Button();
            this.btnHorasClase = new System.Windows.Forms.Button();
            this.btnGrupos = new System.Windows.Forms.Button();
            this.btnMaterias = new System.Windows.Forms.Button();
            this.btnProfesores = new System.Windows.Forms.Button();
            this.gbTituloDatos = new System.Windows.Forms.GroupBox();
            this.gridViewDatos = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnEdicion = new System.Windows.Forms.Button();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.btnAlta = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbTituloDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDatos)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnHorarios, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnHorasClase, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGrupos, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMaterias, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnProfesores, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbTituloDatos, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.92308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1144, 496);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnHorarios
            // 
            this.btnHorarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHorarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHorarios.Image = global::RelojChecador.Properties.Resources.Scheduler;
            this.btnHorarios.Location = new System.Drawing.Point(959, 24);
            this.btnHorarios.Name = "btnHorarios";
            this.btnHorarios.Size = new System.Drawing.Size(137, 65);
            this.btnHorarios.TabIndex = 4;
            this.btnHorarios.Text = "Horarios";
            this.btnHorarios.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnHorarios.UseVisualStyleBackColor = true;
            this.btnHorarios.Click += new System.EventHandler(this.btnHorarios_Click);
            // 
            // btnHorasClase
            // 
            this.btnHorasClase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHorasClase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHorasClase.Image = global::RelojChecador.Properties.Resources.Hour;
            this.btnHorasClase.Location = new System.Drawing.Point(729, 24);
            this.btnHorasClase.Name = "btnHorasClase";
            this.btnHorasClase.Size = new System.Drawing.Size(137, 65);
            this.btnHorasClase.TabIndex = 3;
            this.btnHorasClase.Text = "Horas-Clase";
            this.btnHorasClase.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnHorasClase.UseVisualStyleBackColor = true;
            this.btnHorasClase.Click += new System.EventHandler(this.btnHorasClase_Click);
            // 
            // btnGrupos
            // 
            this.btnGrupos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrupos.Image = global::RelojChecador.Properties.Resources.Groups;
            this.btnGrupos.Location = new System.Drawing.Point(501, 24);
            this.btnGrupos.Name = "btnGrupos";
            this.btnGrupos.Size = new System.Drawing.Size(137, 65);
            this.btnGrupos.TabIndex = 2;
            this.btnGrupos.Text = "Grupos";
            this.btnGrupos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGrupos.UseVisualStyleBackColor = true;
            this.btnGrupos.Click += new System.EventHandler(this.btnGrupos_Click);
            // 
            // btnMaterias
            // 
            this.btnMaterias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMaterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterias.Image = global::RelojChecador.Properties.Resources.Courses;
            this.btnMaterias.Location = new System.Drawing.Point(273, 24);
            this.btnMaterias.Name = "btnMaterias";
            this.btnMaterias.Size = new System.Drawing.Size(137, 65);
            this.btnMaterias.TabIndex = 1;
            this.btnMaterias.Text = "Materias";
            this.btnMaterias.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMaterias.UseVisualStyleBackColor = true;
            this.btnMaterias.Click += new System.EventHandler(this.btnMaterias_Click);
            // 
            // btnProfesores
            // 
            this.btnProfesores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProfesores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfesores.Image = global::RelojChecador.Properties.Resources.Teachers;
            this.btnProfesores.Location = new System.Drawing.Point(45, 24);
            this.btnProfesores.Name = "btnProfesores";
            this.btnProfesores.Size = new System.Drawing.Size(137, 65);
            this.btnProfesores.TabIndex = 0;
            this.btnProfesores.Text = "Profesores";
            this.btnProfesores.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnProfesores.UseVisualStyleBackColor = true;
            this.btnProfesores.Click += new System.EventHandler(this.btnProfesores_Click);
            // 
            // gbTituloDatos
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbTituloDatos, 3);
            this.gbTituloDatos.Controls.Add(this.gridViewDatos);
            this.gbTituloDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTituloDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTituloDatos.Location = new System.Drawing.Point(459, 117);
            this.gbTituloDatos.Name = "gbTituloDatos";
            this.gbTituloDatos.Size = new System.Drawing.Size(682, 376);
            this.gbTituloDatos.TabIndex = 5;
            this.gbTituloDatos.TabStop = false;
            this.gbTituloDatos.Text = "groupBox1";
            this.gbTituloDatos.Visible = false;
            // 
            // gridViewDatos
            // 
            this.gridViewDatos.AllowUserToAddRows = false;
            this.gridViewDatos.AllowUserToDeleteRows = false;
            this.gridViewDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewDatos.Location = new System.Drawing.Point(3, 25);
            this.gridViewDatos.MultiSelect = false;
            this.gridViewDatos.Name = "gridViewDatos";
            this.gridViewDatos.ReadOnly = true;
            this.gridViewDatos.RowHeadersVisible = false;
            this.gridViewDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewDatos.Size = new System.Drawing.Size(676, 348);
            this.gridViewDatos.TabIndex = 0;
            this.gridViewDatos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridViewDatos_CellMouseClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.btnBaja, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnEdicion, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.pnlContenedor, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAlta, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 117);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(450, 376);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btnBaja
            // 
            this.btnBaja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaja.Image = global::RelojChecador.Properties.Resources.Delete;
            this.btnBaja.Location = new System.Drawing.Point(321, 319);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(106, 51);
            this.btnBaja.TabIndex = 3;
            this.btnBaja.Text = "Baja";
            this.btnBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Visible = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnEdicion
            // 
            this.btnEdicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdicion.Image = global::RelojChecador.Properties.Resources.Edit;
            this.btnEdicion.Location = new System.Drawing.Point(171, 319);
            this.btnEdicion.Name = "btnEdicion";
            this.btnEdicion.Size = new System.Drawing.Size(106, 51);
            this.btnEdicion.TabIndex = 2;
            this.btnEdicion.Text = "Edición";
            this.btnEdicion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdicion.UseVisualStyleBackColor = true;
            this.btnEdicion.Visible = false;
            this.btnEdicion.Click += new System.EventHandler(this.btnEdicion_Click);
            // 
            // pnlContenedor
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.pnlContenedor, 3);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(3, 3);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(444, 307);
            this.pnlContenedor.TabIndex = 0;
            this.pnlContenedor.Visible = false;
            // 
            // btnAlta
            // 
            this.btnAlta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.Image = global::RelojChecador.Properties.Resources.Add;
            this.btnAlta.Location = new System.Drawing.Point(21, 319);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(106, 51);
            this.btnAlta.TabIndex = 1;
            this.btnAlta.Text = "Alta";
            this.btnAlta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Visible = false;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // wdwAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 496);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "wdwAdmin";
            this.Text = "Reloj Checador: Administración";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbTituloDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDatos)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnHorarios;
        private System.Windows.Forms.Button btnHorasClase;
        private System.Windows.Forms.Button btnGrupos;
        private System.Windows.Forms.Button btnMaterias;
        private System.Windows.Forms.Button btnProfesores;
        private System.Windows.Forms.GroupBox gbTituloDatos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnEdicion;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.DataGridView gridViewDatos;
    }
}