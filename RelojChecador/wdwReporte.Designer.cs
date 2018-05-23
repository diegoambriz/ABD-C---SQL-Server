namespace RelojChecador
{
    partial class wdwReporte
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbciclos = new System.Windows.Forms.ComboBox();
            this.btnReporte = new System.Windows.Forms.Button();
            this.gridMaterias = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaterias)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cbciclos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnReporte, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridMaterias, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(733, 378);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbciclos
            // 
            this.cbciclos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbciclos.FormattingEnabled = true;
            this.cbciclos.Location = new System.Drawing.Point(119, 27);
            this.cbciclos.Name = "cbciclos";
            this.cbciclos.Size = new System.Drawing.Size(244, 21);
            this.cbciclos.TabIndex = 0;
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReporte.Location = new System.Drawing.Point(488, 26);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(123, 23);
            this.btnReporte.TabIndex = 1;
            this.btnReporte.Text = "Materias";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // gridMaterias
            // 
            this.gridMaterias.AllowUserToAddRows = false;
            this.gridMaterias.AllowUserToDeleteRows = false;
            this.gridMaterias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gridMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.gridMaterias, 2);
            this.gridMaterias.Location = new System.Drawing.Point(123, 103);
            this.gridMaterias.Name = "gridMaterias";
            this.gridMaterias.ReadOnly = true;
            this.gridMaterias.Size = new System.Drawing.Size(487, 247);
            this.gridMaterias.TabIndex = 2;
            // 
            // wdwReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 378);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "wdwReporte";
            this.Text = "wdwReporte";
            this.Load += new System.EventHandler(this.wdwReporte_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaterias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbciclos;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.DataGridView gridMaterias;
    }
}