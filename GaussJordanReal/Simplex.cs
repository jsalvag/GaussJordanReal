using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GaussJordanReal {
    class Simplex {
        private DataTable dt;
        double[] Cj, Zj, solOrg;
        double[,] mtzOri, mtzInv, mtzUniTotal, mtzRest;
        int va, re, pivZj, filaPiv;
        string[] vb;

        public Simplex(DataTable dt, int vari, int rest) {
            this.dt = dt;
            this.Zj = new double[vari + rest];//contenedor de la funcion Z calculada
            this.va = vari;
            this.re = rest;
            vb = new string[rest + 1];
            Dt_mtz(ref mtzOri);
            Separar(mtzOri, ref mtzRest, ref Cj, ref solOrg);
            ConstruMInv(mtzRest.GetLength(0));

            UnirMtzTotal(mtzRest, mtzInv, Zj, solOrg, ref mtzUniTotal);

            iterar(ref mtzUniTotal, ref Zj, ref solOrg);
        }

        private void VB() {
            int i;
            for(i = 0; i < re; i++) {
                vb[i] = "h" + (i + 1).ToString();
            }
            vb[i] = "Z";
        }

        private void Separar(double[,] m1, ref double[,] m2, ref double[] z, ref double[] s) {
            int n = m1.GetLength(0) - 1, i, j, k, l;
            int m = m1.GetLength(1) - 1;
            z = new double[m + re];
            m2 = new double[n, m];
            s = new double[n + 1];

            for(k = 0; k < m; k++)
                z[k] = m1[0, k];

            for(i = 0; i < n; i++)
                for(j = 0; j < m; j++)
                    m2[i, j] = m1[i + 1, j];

            for(l = 0; l < n; l++)
                s[l] = m1[l + 1, m];
            s[l] = 0;

            CalcularZj(z, ref Zj);
        }

        private Boolean Dt_mtz(ref double[,] mtz1) {
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

        private Boolean ConstruMInv(int d) {//construimos una matriz identidad con las dimesiones de la matriz original
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

        private Boolean UnirMtzTotal(double[,] m1, double[,] m2, double[] Z, double[] sol, ref double[,] m3) {
            int x, y, i, j, k, m, n;
            x = m1.GetLength(0);
            y = m1.GetLength(1) + m2.GetLength(1);
            n = m1.GetLength(1);
            m = m2.GetLength(1);
            m3 = new double[x + 1, y + 1];
            for(i = 0; i < x; i++) {//tomamos la fila [i]
                for(j = 0; j < n; j++)//insertamos la fila [i] de la primera matriz
                    m3[i, j] = m1[i, j];
                for(k = 0; k < m; k++)//insertamos la fila [i] de la segunda matriz
                    m3[i, k + j] = m2[i, k];
            }
            for(j = 0; j < y; j++) {//se agrega l Fo negada
                m3[i, j] = Z[j];
            }
            for(j = 0; j < m; j++) {//se agregan las soluciones
                m3[j, y] = sol[j];
            }
            try {
                return true;
            } catch {
                return false;
            }
        }

        private Boolean CalcularZj(double[] a, ref double[] c) {
            int i, m;
            try {
                m = a.Length;
                for(i = 0; i < m; i++) {
                    c[i] = a[i] * -1;
                }
                return true;
            } catch {
                return false;
            }
        }

        private Boolean CalcPivotes(double[,] m1, int v, int r, ref int x, ref int y) {
            int i, j, m, n;
            double a, b, c;
            m = m1.GetLength(0);
            n = m1.GetLength(1);
            VB();
            x = 0;
            a = 100000000000000;
            b = 100000000000000;
            for(j = 0; j < v; j++)
                for(i = 0; i < v; i++) {
                    if(m1[m - 1, i] < a && m1[m - 1, i] != 0) {
                        a = m1[m - 1, i];
                        x = i;
                    }
                }
            for(j = 0; j < r; j++)
                for(i = 0; i < r; i++) {
                    c = m1[i, n - 1] / m1[i, x];
                    if(c > 0 && c < b) {
                        b = c;
                        y = i;
                    }
                }

            vb[y] = "X" + (x + 1).ToString();
            try {
                return true;
            } catch {
                return false;
            }
        }

        private Boolean FilaPivUno(ref double[,] m1, ref int x, ref int y) {
            CalcPivotes(m1, va, re, ref x, ref y);
            int i, m, n;
            m = m1.GetLength(1);
            n = m1.GetLength(0);
            double pil = 1/m1[y, x], a;
            for(i = 0; i < m; i++) {
                a = m1[y, i];
                m1[y, i] = a * pil;
            }
            FilaCero(ref m1, x, y);//hacemos 0 los demas elementos de la columna

            try {
                return true;
            } catch {
                return false;
            }
        }

        private Boolean FilaCero(ref double[,] m1, int x, int y) {
            int m, n, i, j;
            double fi, cp, fn;
            m = m1.GetLength(0);
            n = m1.GetLength(1);
            for(i = 0; i < m; i++) {
                if(i != y) {
                    cp = m1[i, x];
                    for(j = 0; j < n; j++) {
                        fi = m1[i, j];
                        fn = m1[y, j];
                        m1[i, j] = fi - (cp * fn);
                    }
                }
            }
            try {
                return true;
            } catch {
                return false;
            }
        }

        private Boolean compZj(double[,] m1) {
            int i, k;
            k = va;
            bool ev = true;
            try {
                for(i = 0; i < k; i++) {
                    if(m1[re, i] < 0)
                        ev = false;
                }
                return ev;
            } catch {
                return false;
            }
        }

        private Boolean iterar(ref double[,] m1, ref double[] Z, ref double[] sol) {
            bool v = false;
            int cont = 0;
            while(!v && (cont < 100)) {

                FilaPivUno(ref m1, ref pivZj, ref filaPiv);
                if(compZj(m1))
                    v = true;
                cont++;
            }
            try {
                return true;
            } catch {
                return false;
            }
        }

        private Boolean Mtz_dt(double[,] m1) {
            int k;
            int x = m1.GetLength(0);
            int y = m1.GetLength(1);
            dt = new DataTable();
            DataRow dr;

            for(k = 0; k < va; k++)
                dt.Columns.Add("X" + (k + 1).ToString(), Type.GetType("System.Double"));

            for(k = 0; k < re; k++)
                dt.Columns.Add("h" + (k + 1).ToString(), Type.GetType("System.Double"));

            dt.Columns.Add("Solucion", Type.GetType("System.Double"));

            for(int i = 0; i < x; i++) {
                dr = dt.NewRow();
                for(int j = 0; j < y; j++) {
                    dr[j] = m1[i, j];
                }
                dt.Rows.Add(dr);
            }
            try {
                return true;
            } catch {
                return false;
            }
        }

        public DataTable GetDT() {
            Mtz_dt(mtzUniTotal);
            return this.dt;
        }

        public string[] GetVarPos() {
            return vb;
        }
    }
}
