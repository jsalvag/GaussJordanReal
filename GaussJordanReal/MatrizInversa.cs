using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GaussJordanReal {
    class MatrizInversa {
        private DataTable dt;
        private Double[,] mInv, mtz, mUni;
        int fc, cc;

        public MatrizInversa(DataTable dt) {
            this.dt = dt;
            this.fc = dt.Rows.Count;
            this.cc = dt.Columns.Count;
        }

        private void construMInv() {
            int i, j;
            mInv = new double[fc, cc];
            for(i = 0; i < this.fc; i++)
                for(j = 0; j < this.cc; j++) {
                    this.mInv[i, j] = 0;
                    if(i == j)
                        this.mInv[i, j] = 1;
                }
        }

        private void dt_mtz() {
            int i, j;
            mtz = new double[fc, cc];
            i = 0;
            foreach(DataRow dr in dt.Rows) {
                j = 0;
                foreach(var d in dr.ItemArray)
                    mtz[i, j++] = Convert.ToDouble(d);
                i++;
            }
        }

        private void unirMtz() {
            construMInv();
            dt_mtz();
            int l = fc * 2, i, j;
            mUni = new double[l, cc];
            for(i = 0; i < fc; i++) {
                for(j = 0; j < cc; j++) {
                    mUni[i, j] = mtz[i, j];
                    mUni[i + fc, j] = mInv[i, j];
                }
            }
        }

        public 
    }
}
