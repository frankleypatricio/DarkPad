﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DarkPad {
    public static class Temas {
        private static readonly string[] configParams = new string[] { "theme", "font-family", "font-size", "form-width", "form-height", "initial-directory" }; // Parâmetros das configurações
        private static int theme=0;
        private static string fontFamily= "Arial Rounded MT Bold";
        private static float fontSize = 12F;
        private static int[] formSize = new int[2] { 858, 480 };
        //Isso obtêm o diretório do executável. É necessário porque ao abrir .txt como DarkPad, ele busca o config lá no system32...
        private static readonly string directory = AppDomain.CurrentDomain.BaseDirectory.ToString()+"\\config.dkp";
        private static string initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //Desktop do user atual

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
        public static int[] FormSize {
            get { return formSize; }
            set { formSize=value; }
        }
        public static string InitialDirectory {
            get { return initialDirectory; }
            set { initialDirectory=value; }
        }

        public static void LoadConfig() {
            string[] check = new string[2]; // Serve para checar a integridade dos dados do arquivo config
            int indexSep; // Index do separador (=)
            string[] config = new string[6] { Theme.ToString(), FontFamily, FontSize.ToString(), FormSize[0].ToString(), FormSize[1].ToString(), InitialDirectory };
            string linha;

            try {
                using(var arquivo = new FileStream(Directory, FileMode.Open, FileAccess.Read)) {
                    using(var leitor = new StreamReader(arquivo)) {
                        leitor.BaseStream.Seek(0, SeekOrigin.Begin);
                        linha=leitor.ReadLine();

                        for(int i = 0; i<config.Length; i++) {
                            if(linha==null) break;

                            indexSep=linha.IndexOf("=");
                            check[0]=linha.Remove(indexSep);
                            check[1]=linha.Remove(0, indexSep+1);

                            if(check[0] != configParams[i]) throw new Exception("O arquivo \"config.dkp\" está corrompido");

                            config[i]=check[1];
                            linha=leitor.ReadLine();
                        }

                        Theme=int.Parse(config[0]);
                        FontFamily=config[1];
                        FontSize=float.Parse(config[2]);
                        FormSize[0]=int.Parse(config[3]);
                        FormSize[1]=int.Parse(config[4]);
                        InitialDirectory=config[5];
                    }
                }
            } catch(Exception /*ex*/) {
                //Console.WriteLine(ex.Message);
                SaveConfig(Theme, FontFamily, FontSize, FormSize, InitialDirectory);
                LoadConfig();
            }
        }

        public static void SaveConfig(int theme, string fontFamily, float fontSize, int[] formSize, string initialDirectory) {
            try {
                using(var arquivo = new FileStream(Directory, FileMode.OpenOrCreate, FileAccess.Write)) {
                    using(var gravador = new StreamWriter(arquivo)) {
                        gravador.Flush();
                        gravador.BaseStream.Seek(0, SeekOrigin.Begin);
                        gravador.Write(configParams[0]+"="+theme+"\n");
                        gravador.Write(configParams[1]+"="+fontFamily+"\n");
                        gravador.Write(configParams[2]+"="+fontSize+"\n");
                        gravador.Write(configParams[3]+"="+formSize[0]+"\n");
                        gravador.Write(configParams[4]+"="+formSize[1]+"\n");
                        gravador.Write(configParams[5]+"="+initialDirectory);
                        gravador.Flush();

                        Theme=theme;
                        FontFamily=fontFamily;
                        FontSize=fontSize;
                    }
                }
            } catch(Exception ex) {
                MessageBox.Show("Não foi possível salvar as configurações\n"+ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static Color GetPrimaryColor(int theme) {
            switch(theme) {
                case 0: return Color.FromArgb(45,45,48);
                case 1: return Color.FromArgb(19,20,31);
                case 2: return Color.FromArgb(16, 29, 37);
                case 3: return Color.FromArgb(45, 45, 48);
                case 4: return Color.FromArgb(255, 255, 255);
                default: return Color.FromArgb(45, 45, 48);
            }
        }

        public static Color GetSecondaryColor(int theme) {
            switch(theme) {
                case 0: return Color.FromArgb(0, 122, 204);
                case 1: return Color.FromArgb(230, 11, 76);
                case 2: return Color.FromArgb(18, 167, 152);
                case 3: return Color.FromArgb(254, 184, 0);
                case 4: return Color.FromArgb(255, 255, 255);
                default: return Color.FromArgb(0, 122, 204);
            }
        }

        public static Color GetTopBorderColor(int theme) {
            switch(theme) {
                case 0: return Color.FromArgb(28, 28, 28);
                case 1: return Color.FromArgb(64, 67, 103);
                case 2: return Color.FromArgb(35, 45, 54);
                case 3: return Color.FromArgb(28, 28, 28);
                case 4: return Color.FromArgb(240, 240, 240);
                default: return Color.FromArgb(28, 28, 28);
            }
        }

        public static Color GetFontColor(int theme) {
            switch(theme) {
                case 0: return Color.FromArgb(255,255,255);
                case 1: return Color.FromArgb(255, 255, 255);
                case 2: return Color.FromArgb(255, 255, 255);
                case 3: return Color.FromArgb(255, 255, 255);
                case 4: return Color.FromArgb(0, 0, 0);
                default: return Color.FromArgb(255, 255, 255);
            }
        }

        public static Color GetMenuItemSelectedColor(int theme) {
            switch(theme) {
                case 0: return Color.FromArgb(9, 158, 182);
                case 1: return Color.FromArgb(205, 95, 128);
                case 2: return Color.FromArgb(13, 115, 105);
                case 3: return Color.FromArgb(214, 126, 10);
                case 4: return Color.FromArgb(229, 243, 255);
                default: return Color.FromArgb(9, 158, 182);
            }
        }

        public static Color GetMenuBorderColor(int theme) {
            switch(theme) {
                case 0: return Color.FromArgb(255, 255, 255);
                case 1: return Color.FromArgb(255, 255, 255);
                case 2: return Color.FromArgb(255, 255, 255);
                case 3: return Color.FromArgb(255, 255, 255);
                case 4: return Color.FromArgb(0, 0, 0);
                default: return Color.FromArgb(255, 255, 255);
            }
        }
    }
}
