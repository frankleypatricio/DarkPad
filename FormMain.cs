using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkPad {
    public partial class form_main : Form {
        private string altVerif; //Guarda texto original para verificar se houve alterações no arquivo
        private string openedFileDirectory; //Guarda o diretório do atual arquivo aberto
        private form_locate localizar; //Para abrir o Form do localizar
        public int theme; //Guarda o ID do tema atual em uso
        static private RichTextBox staticRichText; //Serve para referenciar a rich_text para o método Localize(), por ele ser static, precisa de membros static
        static public int initialLocate; //Local inicial para a pesquisa na hora de buscar próxima ocorrência
        //static private form_main staticFormMain;
        private List<ToolStripMenuItem> toolStripThemes; //Guarda o ToolStripMenuItem de todos os temas

        public form_main() {
            InitializeComponent();
            Temas.LoadConfig();

            //Inicializando variáveis
            theme=Temas.Theme; //MODIFICAR PRA MÉTODO QUE IRÁ BUSCAR O VALOR
            rich_text.Font=new Font(Temas.FontFamily, Temas.FontSize, FontStyle.Regular);
            altVerif="";
            openedFileDirectory="";
            staticRichText=rich_text;
            //staticFormMain=this;
            menu_main.Renderer=new MyRenderer(theme); //Adicionando o nosso Renderer personalizado ao menu_main

            toolStripThemes=new List<ToolStripMenuItem>();
            toolStripThemes.Add(tool_tema0);
            toolStripThemes.Add(tool_tema1);
            toolStripThemes[theme].Checked=true; //Checa o ToolStripMenuItem do tema atual

            //Chamando funções iniciais
            UpdateTitle("");
            ChangeTheme(theme, false);
        }

        private void Main_Load(object sender, EventArgs e) { //form_main Load (Esse método é para o abrir como...)
            string[] args = Environment.GetCommandLineArgs(); //Obento argumentos da linha de comando
            string[] extensions = new string[] { ".txt",".html", ".htm", ".css", ".php", ".dkp" };
            foreach(string arg in args) {
                foreach(string v in extensions) {
                    if(arg.EndsWith(v)) { //Tenho tenha passado algum argumento terminado com ".txt"
                        OpenFile(arg); //Carregando arquivo
                        altVerif=rich_text.Text;
                        UpdateTitle(arg);
                        break;
                    }
                }
            }
        }

        private void ChangeTheme(int theme, bool alterTheme) { //Alterar tema do programa
            rich_text.BackColor=Temas.GetPrimaryColor(theme);
            menu_main.BackColor=Temas.GetSecondaryColor(theme);
            sep_topBorder.BackColor=Temas.GetTopBorderColor(theme);
            menu_main.Renderer=new MyRenderer(theme); //Adicionando novo renderer

            if(alterTheme==true) {
                toolStripThemes[this.theme].Checked=false; //Remove Checked do tema anterior
                this.theme=theme;
                Temas.SaveConfig(theme, rich_text.Font.FontFamily.Name, rich_text.Font.Size);
            }
        }

        private void UpdateTitle(string fileDirectory) { //Atualiza título do Form e o atual diretório aberto
            string fileName = fileDirectory;
            int lastBar = 0;
            if(fileName.Length>0) {
                lastBar=1+fileName.LastIndexOf("\\"); //Encontrando posição da última ocorrência de um \ (1+ porque posição começa com 0 e aqui retorna tamanho normal)
                fileName=fileName.Remove(0, lastBar); //Removendo texto da posição 0 até lastBar 
            }

            if(fileName!="") this.Text=fileName+" - Darkpad";
            else this.Text="Sem título - Darkpad";

            openedFileDirectory=fileDirectory;
        }

        private DialogResult SaveChanges(bool isFileExiste) { //Serve para verificar se o usuário quer salvar o arquivo/alterações ao criar novo, abrir ou fechar
            DialogResult result = MessageBox.Show("Salvar alterações no arquivo?", "Darkpad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if(result==DialogResult.Yes) {
                if(isFileExiste==false) { //Arquivo não existe

                    if(save_file.ShowDialog()==DialogResult.OK) {
                        if(SaveFile(save_file.FileName)==false) return DialogResult.Cancel;
                    } else return DialogResult.Cancel;

                } else if(SaveFile(save_file.FileName)==false) return DialogResult.Cancel;
            }
            return result;
        }

        private bool SaveFile(string fileName) { //Salvar arquivo
            StreamWriter gravador;
            FileStream arquivo;
            try {
                arquivo=new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                gravador=new StreamWriter(arquivo);

                gravador.Flush();
                gravador.BaseStream.Seek(0, SeekOrigin.Begin);
                gravador.Write(rich_text.Text);
                gravador.Flush();

                gravador.Close();
                arquivo.Close();
            } catch(Exception ex) {
                MessageBox.Show("Não foi possível salvar o arquivo\n"+ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void OpenFile(string fileName) { //Abrir arquivo
            string linha = null;
            FileStream arquivo = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader leitor = new StreamReader(arquivo);

            leitor.BaseStream.Seek(0, SeekOrigin.Begin);
            rich_text.Clear();
            linha=leitor.ReadLine();
            while(linha!=null) {
                rich_text.Text+=linha+"\n";
                linha=leitor.ReadLine();
            }

            leitor.Close();
            arquivo.Close();
        }
        
        public static int Localize(string toLocate, int type, bool caseSense, int initialLocate) { //Serve pra localizar a próxima palavra ou anterior passada no form_localizar
            int next = 0, prev=-1, richLenght=0; //next: posição da próxima localização; prev: posição do inicio-tamanho da localização atual; richLenght: tamanho da localização atual; 
            int selectionStart = 0; //Guarda a posição inicial do texto selecionado
            bool found=false; //Se no botão anterior foi encontrado ou não a localização

            RichTextBoxFinds caseSensitive=new RichTextBoxFinds(); //Com Case Sensitive
            if(caseSense==false) caseSensitive=RichTextBoxFinds.None; //Sem Case Sensitive
            else caseSensitive=RichTextBoxFinds.MatchCase;

            if(initialLocate!=0) next=initialLocate+staticRichText.SelectionLength;
            if(staticRichText.SelectedText != "") selectionStart=staticRichText.SelectionStart;

            if(type==0) { //Próximo
                if(staticRichText.Find(toLocate, next, caseSensitive)==-1) {
                    MessageBox.Show("Não foi possível localizar \""+toLocate+"\"", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return selectionStart;
                }
            } else { //Anterior
                richLenght=staticRichText.SelectionLength;
                prev=next-richLenght;
                for(int i=prev-richLenght; i>0; i-=richLenght) { //i-=richLenght porque assim ele confere do 210-200 (por exemplo) e no próximo confere do 220-210, e por aí vai...
                    if(staticRichText.Find(toLocate, i, prev, caseSensitive)!=-1) {
                        found=true;
                        break;
                    }
                    //Assim que ele encontrar a última instância antes de prev, ele para
                }
                if(found == false) {
                    MessageBox.Show("Não foi possível localizar \""+toLocate+"\"", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return selectionStart;
                }
            }
            return staticRichText.SelectionStart;
        }

        public static void Replace(string text, string toReplace, bool caseSense) {
            RichTextBoxFinds caseSensitive = RichTextBoxFinds.None;
            if(caseSense == true) caseSensitive=RichTextBoxFinds.MatchCase;

            if(staticRichText.Find(text, caseSensitive) ==-1) {
                MessageBox.Show("Não foi possível localizar \""+text+"\"", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            while(staticRichText.Find(text, caseSensitive)!=-1) {
                staticRichText.SelectedText=toReplace; //Percorre todo o RichText substituindo toda ocorrência do texto passado
            }
            MessageBox.Show("Ocorrências substituidas com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SelectionChanged(object sender, EventArgs e) {
            if(rich_text.SelectionLength>0) initialLocate=rich_text.SelectionStart;
            else initialLocate=0;
            Console.WriteLine(initialLocate);
        }

        /* <Menu -> Arquivo> */
        private void NewFile_Click(object sender, EventArgs e) { //Botão Novo
            DialogResult result = DialogResult.None;

            Console.WriteLine("altVerif: "+altVerif);
            Console.WriteLine("RichTextBox: "+rich_text.Text);
            Console.WriteLine("openedFileDirectory: "+openedFileDirectory);

            if(rich_text.Text!=""&&openedFileDirectory=="") result=SaveChanges(false); //Se tem conteúdo na rich_box não é de um arquivo aberto e não é vazio
            else if(openedFileDirectory!=""&&altVerif!=rich_text.Text) result=SaveChanges(true); //Se tem conteúdo na rich_box é de um arquivo aberto e foi alterado

            if(result!=DialogResult.Cancel) {
                rich_text.Clear();
                altVerif="";
                UpdateTitle("");
            }
        }

        private void NewWindow_Click(object sender, EventArgs e) { //Botão Nova janela
            //Não tá pegando porque está fazendo referência ao form_main já aberto...
            new form_main().Show();
        }

        private void OpenFile_Click(object sender, EventArgs e) { //Botão Abrir
            DialogResult result = DialogResult.None; //Para saber resultado do SaveChanges (se a pessoa não cancelou basicamente)

            if(rich_text.Text!=""&&openedFileDirectory=="") result=SaveChanges(false); //Se tem conteúdo na rich_box não é de um arquivo aberto e não é vazio
            else if(openedFileDirectory!=""&&altVerif!=rich_text.Text) result=SaveChanges(true); //Se tem conteúdo na rich_box é de um arquivo aberto e foi alterado

            if(result!=DialogResult.Cancel&&open_file.ShowDialog()==DialogResult.OK) {
                OpenFile(open_file.FileName);
                altVerif=rich_text.Text;
                UpdateTitle(open_file.FileName); //CONCERTAR ISSO, POIS ESTÁ PEGANDO O DIRETÓRIO DO ARQUIVO
            }
        }

        private void Save_Click(object sender, EventArgs e) { //Botão Salvar
            if(openedFileDirectory!="") {
                if(SaveFile(openedFileDirectory)==true) altVerif=rich_text.Text;
            } else {
                if(save_file.ShowDialog()==DialogResult.OK) {
                    if(SaveFile(save_file.FileName)==false) return;
                    else {
                        altVerif=rich_text.Text;
                        UpdateTitle(save_file.FileName);
                    }
                } else return;
            }
        }

        private void SaveAs_Click(object sender, EventArgs e) { //Botão Salvar Como...
            if(save_file.ShowDialog()==DialogResult.OK) {
                if(SaveFile(save_file.FileName)==false) return;
                else {
                    altVerif=rich_text.Text;
                    UpdateTitle(save_file.FileName); //CONCERTAR ISSO, POIS ESTÁ PEGANDO O DIRETÓRIO DO ARQUIVO
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e) { //Botão Sair
            DialogResult result = DialogResult.None; //Para saber resultado do SaveChanges (se a pessoa não cancelou basicamente)

            if(rich_text.Text!=""&&openedFileDirectory=="") result=SaveChanges(false); //Se tem conteúdo na rich_box não é de um arquivo aberto e não é vazio
            else if(openedFileDirectory!=""&&altVerif!=rich_text.Text) result=SaveChanges(true); //Se tem conteúdo na rich_box é de um arquivo aberto e foi alterado

            if(result!=DialogResult.Cancel) this.Close();
        }
        //Fim -> Menu Arquivo

        /* < Menu -> Editar > */
        private void Cut_Click(object sender, EventArgs e) { //Botão Recortar
            if(rich_text.SelectionLength > 0) rich_text.Cut(); //Recortando seleção atual pra área de transferência
        }
        private void Copy_Click(object sender, EventArgs e) { //Botão Copiar
            if(rich_text.SelectionLength > 0) rich_text.Copy(); //Copiando seleção atual pra área de transferência
        }
        private void Paste_Click(object sender, EventArgs e) { //Botão Colar
            rich_text.Paste(); //Colando texto da área de transferência
        }
        private void Delete_Click(object sender, EventArgs e) { //Botão Deletar
            if(rich_text.SelectedText!="") rich_text.SelectedText="";
            else MessageBox.Show("Selecione um trexo para deletar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Locate_Click(object sender, EventArgs e) { //Botão Localizar
            localizar=new form_locate(theme,0);
            localizar.Show();
        }
        private void LocateNext_Click(object sender, EventArgs e) { //Botão Localizar Próxima
            if(rich_text.SelectedText != "") Localize(rich_text.SelectedText, 0, false, initialLocate);
            else MessageBox.Show("Selecione um trexo para localizar outras ocorrências do mesmo ou use a opção \"Localizar (Crtl+F)\"", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LocatePrevious_Click(object sender, EventArgs e) { //Botão Localizar Anterior
            if(rich_text.SelectedText!="") Localize(rich_text.SelectedText, 1, false, initialLocate);
            else MessageBox.Show("Selecione um trexo para localizar outras ocorrências do mesmo ou use a opção \"Localizar (Crtl+F)\"", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Replace_Click(object sender, EventArgs e) { //Botão Substituir
            localizar=new form_locate(theme,1);
            localizar.Show();
        }
        //Fim -> Menu Editar

        /* < Menu -> Formatar > */
        private void Font_Click(object sender, EventArgs e) { //Botão Fonte...
            font_custom.Font=rich_text.Font;

            if(font_custom.ShowDialog() == DialogResult.OK) {
                rich_text.SelectionFont=font_custom.Font;
                Temas.SaveConfig(theme, rich_text.Font.FontFamily.Name, rich_text.Font.Size);
            }

        }

        private void Tema0_Click(object sender, EventArgs e) { //Botão Tema Dark Grey-Blue...
            if(!toolStripThemes[0].Checked) {
                ChangeTheme(0,true);
                toolStripThemes[0].Checked=true;
            }
        }

        private void Tema1_Click(object sender, EventArgs e) { //Botão Tema Dark Grey-Blue...
            if(!toolStripThemes[1].Checked) {
                ChangeTheme(1,true);
                toolStripThemes[1].Checked=true;
            }
        }
        //Fim -> Menu Formatar

        /* <Atalhos do Teclado> */
        private void Hotkeys_KeyUp(object sender, KeyEventArgs e) { //Atalhos do Teclado
            //Não sei se passar null e como parâmetro dá problema... Vendo pelo lado de que nem é utilizado dentro destas funções específicas (as chamadas após o if)... Então não (Usar o e do KeyEventArgs e também funciona)
            if(e.Control && e.KeyCode==Keys.S) Save_Click(null, null); //Se der problema só usar assim: Save_Click(tool_salvar, null);
            if(e.Control && e.Shift && e.KeyCode==Keys.S) SaveAs_Click(null, null);
            if(e.Control && e.KeyCode==Keys.N) NewFile_Click(null, null);
            if(e.Control && e.Shift&&e.KeyCode==Keys.N) NewWindow_Click(null, null);
            if(e.Control && e.KeyCode==Keys.O) OpenFile_Click(null, null);

            if(e.Control&&e.KeyCode==Keys.F) Locate_Click(null, null);
            if(e.KeyCode==Keys.F3) LocateNext_Click(null, null);
            if(e.KeyCode==Keys.F4) LocatePrevious_Click(null, null);
            if(e.Control&&e.KeyCode==Keys.H) Replace_Click(null, null);
        }

        //EDITAR ISSO AQUI, TALVEZ SOBREESCREVER A FUNÇÃO " ONCLOSING "
        private void form_main_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult result = DialogResult.None; //Para saber resultado do SaveChanges (se a pessoa não cancelou basicamente)

            if(rich_text.Text!="" && openedFileDirectory=="") result=SaveChanges(false); //Se tem conteúdo na rich_box não é de um arquivo aberto e não é vazio
            else if(openedFileDirectory!=""&&altVerif!=rich_text.Text) result=SaveChanges(true); //Se tem conteúdo na rich_box é de um arquivo aberto e foi alterado

            if(result==DialogResult.Cancel) return;
        }
    }

    public class MyRenderer : ToolStripProfessionalRenderer { //Isso é para editar a cor de foco dos itens no menu
        public MyRenderer(int theme) : base(new MyColors(theme)) { }
    }
    public class MyColors : ProfessionalColorTable { //Aqui é onde editaremos as cores das funções herdades do ProfessionalColorTable
        private int theme;

        public MyColors(int theme) {
            this.theme=theme;
        }
        public override Color MenuItemSelected { //Ao passar o mouse
            //get { return Color.FromArgb(9, 158, 182); }
            get { return Temas.GetMenuItemSelectedColor(theme); }
        }
        public override Color MenuItemSelectedGradientBegin { //Adiciona um Gradient (inicio) -> Ao passar o mouse
            get { return Color.FromArgb(9,158,182); }
        }
        public override Color MenuItemSelectedGradientEnd { //Adiciona um Gradient (fim) -> Ao passar o mouse (tem middle tb)
            get { return Color.FromArgb(9, 158, 182); }
        }
        public override Color MenuItemPressedGradientBegin { //Adiciona um Gradient (inicio) -> Ao clicar em um menu (abrindo seus sub menus)
            get { return Color.FromArgb(9, 158, 182); }
        }
        public override Color MenuItemPressedGradientEnd { //Adiciona um Gradient (inicio) -> Ao clicar em um menu (abrindo seus sub menus)
            get { return Color.FromArgb(9, 158, 182); }
        }
        public override Color MenuBorder { //Borda do tool menu
            get { return Color.White; }
        }
    }
}
