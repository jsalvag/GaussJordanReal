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

        private Boolean ConstruMInv() {//construimos una matriz identidad con las dimesiones de la matriz original
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

        private Boolean Dt_mtz() {
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

        private Boolean UnirMtz() {//unimos la matriz original a la matriz identidad
            try {
                ConstruMInv();
                Dt_mtz();
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

        public double[,] MtzUnida() {
            if(fc != cc)
                return null;
            UnirMtz();
            Calcular();
            return mUni;
        }

        void Calcular() {
            int i, //columna piloto
                j, //fila pivote
                k, //colimpa pivote
                l, //elemento piloto
                n = mUni.GetLength(1);//cantidad de columnas de la matriz
            
            double[]
                fpiv = new double[n],//fila pivote
                fcer = new double[n];//fila a modificar
            for(i = 0; i < fc; i++) {//Recorremos la matriz columna por columna
                for(j = i; j < fc; j++) {//Recorremos la matriz fila por fila
                    for(k = 0; k < n; k++) {//Recorremos cada columna de la fila
                        fpiv[k] = mUni[j, k];//Llenamos un arreglo con la fila de la matriz
                    }
                    if(i == j) {//si i = j es una posicion de la diagonal y sebe ser 1
                        Uno(ref fpiv, i);//hacemos 1 la posicion piloto de la fila pivote
                        for(k = 0; k < fc; k++) {//recorremos nuevamente la matriz[filas]
                            for(l = 0; l < n; l++) {//[columnas]
                                fcer[l] = mUni[k, l];//tomamos la fila
                            }
                            if(fpiv != fcer)//verificamos que no se la fila pivote
                                Cero(ref fcer, fpiv, i);//si no es, hacemos 0 la posicion piloto
                            for(l = 0; l < n; l++) {//cargamos la fila en la matriz
                                mUni[k, l] = fcer[l];
                            }
                        }//Pasamos a la siguiente fila a hacer 0 el elemto piloto
                    }
                    for(k = 0; k < n; k++) {//cargamos la fila en la matriz
                        mUni[j, k] = fpiv[k];
                    }
                }//pasamos a la siguiente fila
            }//evaluamos la siguiente columna
        }

        private void Uno(ref double[] fila, int ind) {
            double pil = 1 / fila[ind];//calcular inverso de elemento
            int i, n = fila.Length;
            for(i = 0; i < n; i++) {
                fila[i] *= pil;//multiplicamos cada elemto por el inverso del elemento piloto
            }
        }

        private void Cero(ref double[] fila, double[] piv, int ind) {
            double pil = fila[ind] * -1;//calculamos el simetrico del elemento piloto
            int i, n = fila.Length;
            for(i = 0; i < n; i++) {
                fila[i] = (pil * piv[i]) + fila[i];//multiplicamos cada elemento por el inverso del elemento piloto
            }
        }

    }
}
