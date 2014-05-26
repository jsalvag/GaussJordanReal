namespace GaussJordanReal {
    partial class Form1 {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgv_1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.num = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cBox_metodo = new System.Windows.Forms.ComboBox();
            this.btn_calcular = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.r = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.sMin = new System.Windows.Forms.RadioButton();
            this.sMax = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.r)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_1
            // 
            this.dgv_1.AllowUserToAddRows = false;
            this.dgv_1.AllowUserToDeleteRows = false;
            this.dgv_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_1.Location = new System.Drawing.Point(0, 80);
            this.dgv_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv_1.Name = "dgv_1";
            this.dgv_1.RowHeadersVisible = false;
            this.dgv_1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_1.Size = new System.Drawing.Size(876, 322);
            this.dgv_1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 41);
            this.panel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_calcular);
            this.panel1.Controls.Add(this.cBox_metodo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.num);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 39);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad de variables:";
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(177, 6);
            this.num.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(41, 26);
            this.num.TabIndex = 1;
            this.num.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num.ValueChanged += new System.EventHandler(this.n_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Método:";
            // 
            // cBox_metodo
            // 
            this.cBox_metodo.FormattingEnabled = true;
            this.cBox_metodo.Items.AddRange(new object[] {
            "Gauss Jorda",
            "Matriz Inversa",
            "Simplex"});
            this.cBox_metodo.Location = new System.Drawing.Point(317, 5);
            this.cBox_metodo.Name = "cBox_metodo";
            this.cBox_metodo.Size = new System.Drawing.Size(121, 28);
            this.cBox_metodo.TabIndex = 0;
            this.cBox_metodo.SelectedIndexChanged += new System.EventHandler(this.cBox_metodo_SelectedIndexChanged);
            // 
            // btn_calcular
            // 
            this.btn_calcular.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_calcular.Location = new System.Drawing.Point(771, 0);
            this.btn_calcular.Name = "btn_calcular";
            this.btn_calcular.Size = new System.Drawing.Size(105, 39);
            this.btn_calcular.TabIndex = 2;
            this.btn_calcular.Text = "Calcular";
            this.btn_calcular.UseVisualStyleBackColor = true;
            this.btn_calcular.Click += new System.EventHandler(this.btn_calcular_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.sMin);
            this.panel3.Controls.Add(this.sMax);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.r);
            this.panel3.Location = new System.Drawing.Point(3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(432, 36);
            this.panel3.TabIndex = 3;
            this.panel3.Visible = false;
            // 
            // r
            // 
            this.r.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.r.Location = new System.Drawing.Point(202, 5);
            this.r.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.r.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(41, 26);
            this.r.TabIndex = 2;
            this.r.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.r.ValueChanged += new System.EventHandler(this.n_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad de restricciones:";
            // 
            // sMin
            // 
            this.sMin.AutoSize = true;
            this.sMin.Location = new System.Drawing.Point(376, 5);
            this.sMin.Name = "sMin";
            this.sMin.Size = new System.Drawing.Size(52, 24);
            this.sMin.TabIndex = 7;
            this.sMin.Text = "Min";
            this.sMin.UseVisualStyleBackColor = true;
            // 
            // sMax
            // 
            this.sMax.AutoSize = true;
            this.sMax.Checked = true;
            this.sMax.Location = new System.Drawing.Point(314, 5);
            this.sMax.Name = "sMax";
            this.sMax.Size = new System.Drawing.Size(56, 24);
            this.sMax.TabIndex = 6;
            this.sMax.TabStop = true;
            this.sMax.Text = "Max";
            this.sMax.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 402);
            this.Controls.Add(this.dgv_1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.r)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num;
        private System.Windows.Forms.Button btn_calcular;
        private System.Windows.Forms.ComboBox cBox_metodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton sMin;
        private System.Windows.Forms.RadioButton sMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown r;
    }
}

