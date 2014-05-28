using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GaussJordanReal {
    public partial class Form1 : Form {
        GaussJordan gauss;
        MatrizInversa inversa;
        Simplex simp;
        int metodo;

        public Form1() {
            InitializeComponent();
            cBox_metodo.SelectedIndex = 0;
        }

        public void dibujarDGV(int vr) {
            btn_calcular.Enabled = true;
            dgv_1.DataSource = null;
            if(dgv_1.Rows.Count != 0)
                dgv_1.Rows.Clear();
            dgv_1.RowHeadersVisible = false;
            if(dgv_1.Columns.Count != 0)
                dgv_1.Columns.Clear();
            dgv_1.ColumnHeadersVisible = true;
            int y = 1;
            char x = 'x';
            switch(metodo) {
                case 0:
                    dgv_1.ColumnCount = vr + 1;
                    dgv_1.RowCount = vr;
                    for(int i = 0; i < vr; i++) {
                        dgv_1.Columns[i].Name = x.ToString() + y.ToString();
                        dgv_1.Columns[i].HeaderText = x.ToString() + y.ToString();
                        x++;
                        if(x > 'z') {
                            y++;
                            x = 'x';
                        }
                        dgv_1.Columns[i + 1].HeaderText = "=";
                    }
                    break;
                case 1:
                    dgv_1.ColumnCount = vr;
                    dgv_1.RowCount = vr;
                    for(int i = 0; i < vr; i++) {
                        dgv_1.Columns[i].Name = x.ToString() + y.ToString();
                        dgv_1.Columns[i].HeaderText = x.ToString() + y.ToString();
                        x++;
                        if(x > 'z') {
                            y++;
                            x = 'x';
                        }
                    }
                    break;
                case 2:
                    int n = Convert.ToInt32(r.Value) + 1;
                    dgv_1.RowCount = n;
                    dgv_1.RowHeadersVisible = true;
                    dgv_1.Rows[0].HeaderCell.Value = "Función";
                    for(int i = 1; i < n; i++) {
                        dgv_1.Rows[i].HeaderCell.Value = "Restricción " + i.ToString(); ;
                    }
                    dgv_1.ColumnCount = vr + 1;
                    for(int i = 0; i < vr; i++) {
                        dgv_1.Columns[i].Name = x.ToString() + y.ToString();
                        dgv_1.Columns[i].HeaderText = x.ToString() + y.ToString();
                        x++;
                        if(x > 'z') {
                            y++;
                            x = 'x';
                        }
                        dgv_1.Columns[i + 1].HeaderText = "=";
                    }
                    dgv_1.Rows[0].Cells[vr].ReadOnly = true;
                    dgv_1.Rows[0].Cells[vr].Style.BackColor = System.Drawing.Color.Black;
                    break;
            }
        }



        private void addSolucion(double[] r) {
            if(dgv_1.RowCount == dgv_1.ColumnCount - 1) {
                dgv_1.ColumnCount += 1;
                int solc = dgv_1.ColumnCount - 1, i = 0;
                dgv_1.Columns[solc].Name = "Sol";
                dgv_1.Columns[solc].HeaderText = "Solución";
                dgv_1.Columns[solc].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                foreach(DataGridViewRow dr in dgv_1.Rows) {
                    dr.Cells[solc].Value = r[i];
                    i++;
                }
            } else {
                dgv_1.ColumnCount--;
                addSolucion(r);
            }
        }

        private DataTable dgv_dt(DataGridView dgv) {
            DataTable dt = new DataTable();
            int i;

            foreach(DataGridViewColumn dgc in dgv.Columns) {
                DataColumn dc = new DataColumn(dgc.Name);
                dt.Columns.Add(dc);
            }
            foreach(DataGridViewRow dgr in dgv.Rows) {
                DataRow dr = dt.NewRow();
                i = 0;
                foreach(DataGridViewTextBoxCell d in dgr.Cells) {
                    if(d.Value == "")
                        d.Value = "0";
                    dr[i] = Convert.ToDouble(d.Value);
                    i++;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void n_ValueChanged(object sender, EventArgs e) {
            dibujarDGV(Convert.ToInt32(num.Value));
        }

        private void cBox_metodo_SelectedIndexChanged(object sender, EventArgs e) {
            metodo = cBox_metodo.SelectedIndex;
            dibujarDGV(Convert.ToInt32(num.Value));
            if(metodo == 2)
                panel3.Show();
            else
                panel3.Hide();
        }

        private void btn_calcular_Click(object sender, EventArgs e) {
            btn_calcular.Enabled = false;
            switch(metodo) {
                case 0:
                    gauss = new GaussJordan(dgv_dt(dgv_1));
                    double[] res = new double[dgv_1.RowCount];
                    gauss.elimGauseana(res);
                    addSolucion(res);
                    break;
                case 1:
                    inversa = new MatrizInversa(dgv_dt(dgv_1));
                    double[,] re = inversa.mtzUnida();
                    if(re != null) {
                        int fil = re.GetLength(0), f;
                        int col = re.GetLength(1), c;
                        string[] r = new string[col];
                        dgv_1.Rows.Clear();
                        dgv_1.Columns.Clear();
                        dgv_1.ColumnCount = col;
                        dgv_1.ColumnHeadersVisible = false;
                        for(f = 0; f < fil; f++) {
                            for(c = 0; c < col; c++)
                                r[c] = re[f, c].ToString();
                            dgv_1.Rows.Add(r);
                        }
                    } else {
                        MessageBox.Show("la matriz debe ser cuadrada");
                    }
                    break;
                case 2:
                    dgv_1.DataSource = null;
                    simp = new Simplex(dgv_dt(dgv_1), Convert.ToInt32(this.num.Value), Convert.ToInt32(this.r.Value));
                    //dibujarSimplex();
                    DataTable a = simp.getDT();
                    dgv_1.Columns.Clear();
                    dgv_1.DataSource = a;
                    break;
            }
        }
    }
}
