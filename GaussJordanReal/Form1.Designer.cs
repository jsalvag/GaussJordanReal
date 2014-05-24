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
            this.btn_gauss = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.n = new System.Windows.Forms.NumericUpDown();
            this.btn_mInv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n)).BeginInit();
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
            this.dgv_1.Size = new System.Drawing.Size(876, 322);
            this.dgv_1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 41);
            this.panel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_mInv);
            this.panel1.Controls.Add(this.btn_gauss);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.n);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 39);
            this.panel1.TabIndex = 5;
            // 
            // btn_gauss
            // 
            this.btn_gauss.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_gauss.Location = new System.Drawing.Point(749, 0);
            this.btn_gauss.Name = "btn_gauss";
            this.btn_gauss.Size = new System.Drawing.Size(127, 39);
            this.btn_gauss.TabIndex = 2;
            this.btn_gauss.Text = "Gauss Jordan";
            this.btn_gauss.UseVisualStyleBackColor = true;
            this.btn_gauss.Click += new System.EventHandler(this.btn_gauss_Click);
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
            // n
            // 
            this.n.Location = new System.Drawing.Point(177, 7);
            this.n.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.n.Name = "n";
            this.n.Size = new System.Drawing.Size(41, 26);
            this.n.TabIndex = 1;
            this.n.ValueChanged += new System.EventHandler(this.n_ValueChanged);
            // 
            // btn_mInv
            // 
            this.btn_mInv.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_mInv.Location = new System.Drawing.Point(629, 0);
            this.btn_mInv.Name = "btn_mInv";
            this.btn_mInv.Size = new System.Drawing.Size(120, 39);
            this.btn_mInv.TabIndex = 3;
            this.btn_mInv.Text = "Matriz Inversa";
            this.btn_mInv.UseVisualStyleBackColor = true;
            this.btn_mInv.Click += new System.EventHandler(this.btn_mInv_Click);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown n;
        private System.Windows.Forms.Button btn_gauss;
        private System.Windows.Forms.Button btn_mInv;
    }
}

