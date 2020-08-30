using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DarkPad {
    public static class Temas {
        private static int theme=0;
        private static string fontFamily= "Arial Rounded MT Bold";
        private static float fontSize = 12F;
        //Isso obtêm o diretório do executável. É necessário porque ao abrir .txt como DarkPad, ele busca o config lá no system32...
        private static string directory = AppDomain.CurrentDomain.BaseDirectory.ToString()+"\\config.dkp";

        public static int Theme{
            get{return theme;}
            set{theme=value;}
        }
        public static string FontFamily {
            get { return fontFamily; }
            set { fontFamily=value; }
        }
        public static float FontSize {
            get { return fontSize; }
            set { fontSize=value; }
        }
        public static string Directory {
            get { return directory; }
        }

        public static void LoadConfig() {
            string[] config = new string[3] { Theme.ToString(), FontFamily, FontSize.ToString() };
            string linha = "";
            
            int i = 0;

            try {
                FileStream arquivo = new FileStream(Directory, FileMode.Open, FileAccess.Read);
                StreamReader leitor = new StreamReader(arquivo);

                leitor.BaseStream.Seek(0, SeekOrigin.Begin);
                linha=leitor.ReadLine();
                while(linha!=null) {
                    config[i++]=linha;
                    linha=leitor.ReadLine();
                }
                Theme=int.Parse(config[0]);
                FontFamily=config[1];
                FontSize=float.Parse(config[2]);

                leitor.Close();
                arquivo.Close();
            } catch(Exception ex) {
                //Console.WriteLine(ex.Message);
                SaveConfig(Theme, FontFamily, FontSize);
                LoadConfig();
            }
        }
        /*public static int LoadTheme() {
            StreamWriter gravador
        }*/
        public static void SaveConfig(int theme, string fontFamily, float fontSize) {
            FileStream arquivo;
            StreamWriter gravador;

            try {
                arquivo=new FileStream(Directory, FileMode.OpenOrCreate, FileAccess.Write);
                gravador=new StreamWriter(arquivo);

                gravador.Flush();
                gravador.BaseStream.Seek(0,SeekOrigin.Begin);
                gravador.Write(theme+"\n");
                gravador.Write(fontFamily+"\n");
                gravador.Write(fontSize);
                gravador.Flush();

                Theme=theme;
                FontFamily=fontFamily;
                FontSize=fontSize;

                gravador.Close();
                arquivo.Close();

            } catch(Exception ex) {
                MessageBox.Show("Não foi possível salvar as configurações\n"+ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static Color GetPrimaryColor(int theme) {
            switch(theme) {
                case 0: return Color.FromArgb(45,45,48);
                case 1: return Color.FromArgb(19,20,31);
                default: return Color.FromArgb(0, 122, 204);
            }
        }

        public static Color GetSecondaryColor(int theme) {
            switch(theme) {
                case 0: return Color.FromArgb(0, 122, 204);
                case 1: return Color.FromArgb(230, 11, 76);
                default: return Color.FromArgb(0, 122, 204);
            }
        }

        public static Color GetTopBorderColor(int theme) {
            switch(theme) {
                case 0: return Color.FromArgb(28, 28, 28);
                case 1: return Color.FromArgb(64, 67, 103);
                default: return Color.FromArgb(28, 28, 28);
            }
        }

        public static Color GetFontColor(int theme) {
            switch(theme) {
                case 0: return Color.FromArgb(255,255,255);
                case 1: return Color.FromArgb(255, 255, 255);
                default: return Color.FromArgb(255, 255, 255);
            }
        }

        public static Color GetMenuItemSelectedColor(int theme) {
            switch(theme) {
                case 0: return Color.FromArgb(9, 158, 182);
                case 1: return Color.FromArgb(205, 95, 128);
                default: return Color.FromArgb(9, 158, 182);
            }
        }
    }
}
