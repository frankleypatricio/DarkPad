using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkPad {
    public partial class form_locate : Form {
        //Listas para os componentes do form
        private TabControl.TabPageCollection tabPages;
        private List<Button> buttons;
        private List<TextBox> textBoxes;
        private List<Label> labels;
        private List<CheckBox> checkBoxes;
        private List<Panel> separators;

        public form_locate(int theme, int type) {
            InitializeComponent();

            if(type==1) tab_editar.SelectedTab=tab_substituir;

            //Adicionando componentes às listas
            tabPages=tab_editar.TabPages;
            buttons =new List<Button>();
            buttons.Add(btn_ant); buttons.Add(btn_prox); buttons.Add(btn_substituir);
            textBoxes=new List<TextBox>();
            textBoxes.Add(txt_locate); textBoxes.Add(txt_original); textBoxes.Add(txt_substituir);
            labels =new List<Label>();
            labels.Add(lbl_locate); labels.Add(lbl_original); labels.Add(lbl_substituir);
            checkBoxes=new List<CheckBox>();
            checkBoxes.Add(cbx_caseLocali); checkBoxes.Add(cbx_caseLocali);
            separators=new List<Panel>();
            separators.Add(panel_sepLocate); separators.Add(panel_sepOriginal); separators.Add(panel_sepSubstituir);

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
            private void Localize(int type) {
            if(txt_locate.Text!="") form_main.initialLocate=form_main.Localize(txt_locate.Text, type, cbx_caseLocali.Checked, form_main.initialLocate);
            else MessageBox.Show("Digite um texto/palavra a ser localizada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void NextLocate_Click(object sender, EventArgs e) { //Botão Próximo
            Localize(0);
        }
        public void PreviousLocate_Click(object sender, EventArgs e) { //Botão Anterior
            Localize(1);
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
