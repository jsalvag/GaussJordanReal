﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GaussJordanReal {
    class Simplex {
        private DataTable dt;
        double[] Cj, Zj, Cj_Zj, solOrg, aux;
        double[,] mtzOri, mtzFin, mtzInv, mtzUni, mtzRest;
        int vari, rest;

        public Simplex(DataTable dt, int vari, int rest) {
            this.dt = dt;
            this.Cj = new double[vari + rest];//contenedor de la funcion objetivo mas las holguras
            this.Zj = new double[vari + rest];//contenedor de la funcion Z calculada
            this.Cj_Zj = new double[vari + rest];//contenedor del resultado de Cj - Zj
            this.vari = vari;
            this.rest = rest;
            dt_mtz(ref mtzOri);
            separar(mtzOri);
            construMInv(mtzRest.GetLength(0));
            unirMtz(mtzRest, mtzInv);
        }

        private Boolean dt_mtz(ref double[,] mtz1) {
            int i, j;
            try {
                mtz1 = new double[dt.Rows.Count, dt.Columns.Count];
                i = 0;
                foreach(DataRow dr in dt.Rows) {
                    j = 0;
                    foreach(var d in dr.ItemArray)
                        mtz1[i, j++] = Convert.ToDouble(d);
                    i++;
                }
                return true;
            } catch {
                return false;
            }
        }

        private void separar(double[,] mtz1) {
            int n = mtz1.GetLength(0) - 1, i, j, k, l;
            int m = mtz1.GetLength(1) - 1;
            Cj = new double[m];
            mtzRest = new double[n, m];
            solOrg = new double[n + 1];

            for(k = 0; k < m; k++)
                Cj[k] = mtz1[0, k];

            for(i = 0; i < n; i++)
                for(j = 0; j < m; j++)
                    mtzRest[i, j] = mtz1[i + 1, j];

            for(l = 0; l < n; l++)
                solOrg[l] = mtz1[l + 1, m];
            solOrg[l] = 0;
        }

        private Boolean construMInv(int d) {//construimos una matriz identidad con las dimesiones de la matriz original
            int i, j;

            try {
                mtzInv = new double[d, d];
                for(i = 0; i < d; i++)
                    for(j = 0; j < d; j++) {
                        this.mtzInv[i, j] = 0;
                        if(i == j)
                            this.mtzInv[i, j] = 1;
                    }
                return true;
            } catch {
                return false;
            }
        }

        private Boolean unirMtz(double[,] m1, double[,] m2) {
            try {
                int x, y, i, j, k, m, n;
                x = m1.GetLength(0);
                y = m1.GetLength(1) + m2.GetLength(1);
                n = m1.GetLength(1);
                m = m2.GetLength(1);
                mtzUni = new double[x, y];
                for(i = 0; i < x; i++) {//tomamos la fila [i]
                    for(j = 0; j < n; j++)//insertamos la fila [i] de la primera matriz
                        mtzUni[i, j] = m1[i, j];
                    for(k = 0; k < m; k++)//insertamos la fila [i] de la segunda matriz
                        mtzUni[i, k + j] = m2[i, k];
                }
                return true;
            } catch {
                return false;
            }
        }

        private Boolean mtz_dt(double[,] mtz1) {
            try {
                int x = mtz1.GetLength(0);
                int y = mtz1.GetLength(1);
                dt = new DataTable();
                DataRow dr;

                for(int k = 0; k < y; k++)
                    dt.Columns.Add(k.ToString(), Type.GetType("System.Double"));
                for(int i = 0; i < x; i++) {
                    dr = dt.NewRow();
                    for(int j = 0; j < y; j++) {
                        dr[j] = mtz1[i, j];
                    }
                    dt.Rows.Add(dr);
                }

                return true;
            } catch {
                return false;
            }
        }

        public DataTable getDT() {
            mtz_dt(mtzUni);
            return this.dt;
        }

        //private void dibujarSimplex() {
        //    dgv_1.Rows.Clear();
        //    dgv_1.Columns.Clear();
        //    int n = Convert.ToInt32(this.r.Value),
        //        vr = Convert.ToInt32(num.Value),
        //        y = 1;
        //    char x = 'x';
        //    dgv_1.ColumnCount = vr + n + 2;
        //    dgv_1.RowCount = n + 1;
        //    int a = 0, b, m = 0;
        //    dgv_1.Columns[a].Name = "Z";
        //    dgv_1.Columns[a].HeaderText = "Z";
        //    for(a = 1; a < vr + 1; a++) {
        //        dgv_1.Columns[a].Name = x.ToString() + y.ToString();
        //        dgv_1.Columns[a].HeaderText = x.ToString() + y.ToString();
        //        y++;
        //    }
        //    y = 1;
        //    m = a + n;
        //    for(b = a; b < m; b++) {
        //        dgv_1.Columns[b].Name = "h" + y.ToString();
        //        dgv_1.Columns[b].HeaderText = "h" + y.ToString();
        //        y++;
        //        dgv_1.Columns[b + 1].Name = "sol";
        //        dgv_1.Columns[b + 1].HeaderText = "Solucion";
        //    }
        //    dgv_1.RowHeadersVisible = true;

        //    y = 1;
        //    for(a = 0; a < n; a++) {
        //        dgv_1.Rows[a].HeaderCell.Value = "h" + y++.ToString();
        //        dgv_1.Rows[a + 1].HeaderCell.Value = "Z";
        //    }
        //    dgv_1.RowHeadersWidth = 60;
        //}
    }
}
