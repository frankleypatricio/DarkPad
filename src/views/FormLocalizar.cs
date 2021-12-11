using DarkPad.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DarkPad.Views {
    public partial class form_locate : Form {
        //Listas para os componentes do form
        private readonly TabControl.TabPageCollection tabPages;
        private readonly List<Button> buttons;
        private readonly List<TextBox> textBoxes;
        private readonly List<Label> labels;
        private readonly List<CheckBox> checkBoxes;
        private readonly List<Panel> separators;
        private readonly form_main control; //Serve para poder focar no form do texto ao localizar

        public form_locate(int theme, int type, string selectedText, form_main control) {
            InitializeComponent();
            this.control=control;

            if(selectedText!="") txt_original.Text=txt_locate.Text=selectedText;
            if(type==0) txt_locate.Focus();
            else txt_original.Focus();

            if(type==1) tab_editar.SelectedTab=tab_substituir;

            //Adicionando componentes às listas
            tabPages=tab_editar.TabPages;
            buttons=new List<Button> {
                btn_ant,
                btn_prox,
                btn_substituir
            };
            textBoxes=new List<TextBox> {
                txt_locate,
                txt_original,
                txt_substituir
            };
            labels=new List<Label> {
                lbl_locate,
                lbl_original,
                lbl_substituir
            };
            checkBoxes=new List<CheckBox> {
                cbx_caseLocali,
                cbx_caseLocali
            };
            separators=new List<Panel> {
                panel_sepLocate,
                panel_sepOriginal,
                panel_sepSubstituir
            };

            ChangeTheme(theme);
        }

        private void ChangeTheme(int theme) {
            this.BackColor=Temas.GetPrimaryColor(theme);
            foreach(Panel v in separators) v.BackColor=Temas.GetSecondaryColor(theme);
            foreach(TabPage v in tabPages) {
                v.BackColor=Temas.GetPrimaryColor(theme);
                v.ForeColor=Temas.GetFontColor(theme);
            }
            foreach(Button v in buttons) {
                v.BackColor=Temas.GetSecondaryColor(theme);
                v.ForeColor=Temas.GetFontColor(theme);
            }
            foreach(TextBox v in textBoxes) {
                v.BackColor=Temas.GetPrimaryColor(theme);
                v.ForeColor=Temas.GetFontColor(theme);
            }
            foreach(Label v in labels) {
                v.BackColor=Temas.GetPrimaryColor(theme);
                v.ForeColor=Temas.GetFontColor(theme);
            }
            foreach(CheckBox v in checkBoxes) {
                v.BackColor=Temas.GetPrimaryColor(theme);
                v.ForeColor=Temas.GetFontColor(theme);
            }

        }

            /* < Tab -> Localizar > */
        private void Locate(int type) {
            if(txt_locate.Text!="") form_main.initialLocate=form_main.Locate(txt_locate.Text, type, cbx_caseLocali.Checked, form_main.initialLocate);
            else MessageBox.Show("Digite um texto/palavra a ser localizada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void NextLocate_Click(object sender, EventArgs e) { //Botão Próximo
            Locate(0);
        }
        public void PreviousLocate_Click(object sender, EventArgs e) { //Botão Anterior
            Locate(1);
        }

        public void NewLocate_TextChanged(object sender, EventArgs e) { //Ao mudar texto de localização, resetando os valores essenciais
            form_main.initialLocate=0;
        }
        //Fim Tab -> Localizar >

        /* < Tab -> Substituiar > */
        public void Replace_Click(object sender, EventArgs e) { //Botão Substituir
            if(txt_original.Text != "" && txt_substituir.Text !="") form_main.Replace(txt_original.Text, txt_substituir.Text, cbx_caseSubst.Checked);
            else MessageBox.Show("Digite um texto/palavra a ser substituída", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
