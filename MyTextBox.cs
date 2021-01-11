using System;
using System.Windows.Forms;

namespace DarkPad {
    class MyTextBox:TextBox {
        public event EventHandler SelectionChanged;

        //Métodos
        public int Find(string str, int start, bool before, bool caseSensitive) {
            int pos;
            try {
                pos = Text.IndexOf(str, start,/* count,*/ caseSensitive==false ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                if(pos!=-1) {
                    if(before==true & pos>=SelectionStart) return -1; //Localizar Anterior: Isso é para não selecionar caso a posição encontrada seja a mesma
                    Select(pos, str.Length);
                    SelectionChanged?.Invoke(this, new EventArgs());
                } else if(pos>=SelectionStart) pos=-1; //Altera o valor de pos pra -1 pra não passar a posição repetida, o que rodaria o if lá do métoso Locate()
            } catch(Exception ex) {
                MessageBox.Show("Não foi possível realizar a busca do texto\n"+ex.Message);
                return -1;
            }
            return pos;
        }
        public int Find(string str, bool caseSensitive) {
            int pos;
            try {
                pos=Text.IndexOf(str, caseSensitive==false ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                if(pos!=-1) {
                    Select(pos, str.Length);
                    SelectionChanged?.Invoke(this, new EventArgs());
                }
            } catch(Exception ex) {
                MessageBox.Show("Não foi possível realizar a busca do texto\n"+ex.Message);
                return -1;
            }
            return pos;
        }
        //Evento acionando quando libera o botão do mouse (no fim de uma selção), aí verifica se foi selecionado algo
        public void SelectionHasChanged(object sender, MouseEventArgs e) {
            if(SelectedText != "") SelectionChanged?.Invoke(this, new EventArgs());
        }

    }
}
