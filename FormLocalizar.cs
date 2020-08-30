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
        public form_locate(int theme, int type) {
            InitializeComponent();
            if(type==1) tab_editar.SelectedTab=tab_substituir;
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
