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
        int metodo;

        public Form1() {
            InitializeComponent();
            cBox_metodo.SelectedIndex = 0;
        }

        public void dibujarDGV(int vr) {
            dgv_1.Rows.Clear();
            dgv_1.Columns.Clear();
            int y = 1, n = 1;
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
                    foreach(DataGridViewRow dr in dgv_1.Rows)
                        dr.HeaderCell.Value = "Fila " + (n++).ToString();
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
            dibujarDGV(Convert.ToInt32(n.Value));
        }

        private void cBox_metodo_SelectedIndexChanged(object sender, EventArgs e) {
            metodo = cBox_metodo.SelectedIndex;
            dibujarDGV(Convert.ToInt32(n.Value));
        }

        private void btn_calcular_Click(object sender, EventArgs e) {
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
                    break;
            }
        }
    }
}
