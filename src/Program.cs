using DarkPad.Views;
using System;
using System.Windows.Forms;

namespace DarkPad {
    static class Program {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form_main(args));
            //Application.Run(args.Length==0 ? new form_main(String.Empty) : new form_main(args[0]));
        }
    }
}
