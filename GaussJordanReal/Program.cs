﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GaussJordanReal {
    static class Program {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Console.WriteLine("HOLA");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
