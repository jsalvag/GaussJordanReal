using System;
using System.Data;

namespace GaussJordanReal {
    class GaussJordan {
        DataTable dt;
        public GaussJordan(DataTable dt) {
            this.dt = dt;
        }

        public bool elimGauseana(double[] r) {
            double[,] a = new double[dt.Rows.Count, dt.Columns.Count];
            double t, s;
            int i, j, k, l, m, n;
            i = 0;
            foreach(DataRow dr in dt.Rows) {
                j = 0;
                foreach(var d in dr.ItemArray)
                    a[i, j++] = Convert.ToDouble(d);
                i++;
            }
            
            try {
                n = r.Length - 1;
                m = n + 1;
                for(l = 0; l <= n - 1; l++) {
                    j = l;
                    for(k = l + 1; k <= n; k++) {
                        if(!(Math.Abs(a[j, l]) >= Math.Abs(a[k, l]))) j = k;
                    }
                    if(!(j == l)) {
                        for(i = 0; i <= m; i++) {
                            t = a[l, i];
                            a[l, i] = a[j, i];
                            a[j, i] = t;
                        }
                    }
                    for(j = l + 1; j <= n; j++) {
                        t = (a[j, l] / a[l, l]);
                        for(i = 0; i <= m; i++) a[j, i] -= t * a[l, i];
                    }
                }
                r[n] = a[n, m] / a[n, n];
                for(i = 0; i <= n - 1; i++) {
                    j = n - i - 1;
                    s = 0;
                    for(l = 0; l <= i; l++) {
                        k = j + l + 1;
                        s += a[j, k] * r[k];
                    }
                    r[j] = ((a[j, m] - s) / a[j, j]);
                }
                return true;
            } catch {
                return false;
            } finally {
                //foreach(double res in r)
                //    MessageBox.Show(res.ToString());
            }
        }
    }
}
