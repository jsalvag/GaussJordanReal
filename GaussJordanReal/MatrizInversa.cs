using System;
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

        private Boolean construMInv() {
            int i, j;
            try {
                mInv = new double[fc, cc];
                for(i = 0; i < this.fc; i++)
                    for(j = 0; j < this.cc; j++) {
                        this.mInv[i, j] = 0;
                        if(i == j)
                            this.mInv[i, j] = 1;
                    }
                return true;
            } catch {
                return false;
            }
        }

        private Boolean dt_mtz() {
            int i, j;
            try {
                mtz = new double[fc, cc];
                i = 0;
                foreach(DataRow dr in dt.Rows) {
                    j = 0;
                    foreach(var d in dr.ItemArray)
                        mtz[i, j++] = Convert.ToDouble(d);
                    i++;
                }
                return true;
            } catch {
                return false;
            }
        }

        private Boolean unirMtz() {
            try {
                construMInv();
                dt_mtz();
                int i, j;
                mUni = new double[fc, cc * 2];
                for(i = 0; i < fc; i++) {
                    for(j = 0; j < cc; j++) {
                        mUni[i, j] = mtz[i, j];
                        mUni[i, j + fc] = mInv[i, j];
                    }
                }
                return true;
            } catch {
                return false;
            }
        }

        public double[,] mtzUnida() {
            if(fc != cc)
                return null;
            unirMtz();
            calcular();
            return mUni;
        }

        void calcular() {
            int i, //columna piloto
                j, 
                k, 
                l,
                n = mUni.GetLength(1);
            
            double[]
                fpiv = new double[n],
                fcer = new double[n];
            for(i = 0; i < fc; i++) {//Recorremos la matriz columna por columna
                for(j = i; j < fc; j++) {//Recorremos la matriz fila por fila
                    for(k = 0; k < n; k++) {//Recorremos cada columna de la fila
                        fpiv[k] = mUni[j, k];//Llenamos un arreglo con la fila de la matriz
                    }
                    if(i == j) {//si i = j es una posicion de la diagonal y sebe ser 1
                        uno(ref fpiv, i);//hacemos 1 la posicion piloto de la fila pivote
                        for(k = 0; k < fc; k++) {//recorremos nuevamente la matriz[filas]
                            for(l = 0; l < n; l++) {//[columnas]
                                fcer[l] = mUni[k, l];//tomamos la fila
                            }
                            if(fpiv != fcer)//verificamos que no se la fila pivote
                                cero(ref fcer, fpiv, i);//si no es, hacemos 0 la posicion piloto
                            for(l = 0; l < n; l++) {//cargamos la fila en la matriz
                                mUni[k, l] = fcer[l];
                            }
                        }
                    }
                    for(k = 0; k < n; k++) {
                        mUni[j, k] = fpiv[k];
                    }
                }
            }
        }

        private void uno(ref double[] fila, int ind) {
            double pil = 1 / fila[ind];
            int i, n = fila.Length;
            for(i = 0; i < n; i++) {
                fila[i] *= pil;
            }
        }

        void cero(ref double[] fila, double[] piv, int ind) {
            double pil = fila[ind] * -1;
            int i, n = fila.Length;
            for(i = 0; i < n; i++) {
                fila[i] = (pil * piv[i]) + fila[i];
            }
        }

    }
}
