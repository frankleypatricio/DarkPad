using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using DarkPad.Util;
using DarkPad.Components;

namespace DarkPad.Views {
    public partial class form_main : Form {
        private const string github = "https://github.com/frankleypatricio/DarkPad";
        private const int minWidth = 564;
        private const int minHeight = 380;

        private string[] args; //Argumentos de entrada
        private string altVerif; //Guarda texto original para verificar se houve alterações no arquivo
        private bool hasSave; //Guarda se precisa salvar o arquivo ou não
        private string openedFileDirectory; //Guarda o diretório do atual arquivo aberto
        private form_locate localizar; //Para abrir o Form do localizar
        private int theme; //Guarda o ID do tema atual em uso
        //static private RichTextBox staticRichText; //Serve para referenciar a myText para o método Localize(), por ele ser static, precisa de membros static
        static public int initialLocate; //Local inicial para a pesquisa na hora de buscar próxima ocorrência
        //static private form_main staticFormMain;
        private readonly List<ToolStripMenuItem> toolStripThemes; //Guarda o ToolStripMenuItem de todos os temas
        private readonly ToolStripItemCollection allToolStrip; //Guarda todos os ToolStripMenuItem

        static private readonly MyTextBox myText = new MyTextBox();

        public form_main(string[] args) {
            InitializeComponent();
            this.args=args;

            //Definindo MyTextBox
            myText.Multiline=true;
            myText.BackColor=Color.FromArgb(45, 45, 48);
            myText.ForeColor=Color.FromArgb(255,255,255);
            myText.Font=new Font("Arial Rounded MT Bold", 12);
            myText.BorderStyle=BorderStyle.None;
            Console.WriteLine(myText.MaxLength); //MÁXIMO DE CARACTERES QUE PODEM SER DIGITADOS (PADRÃO: 32767)
            myText.HideSelection=false; //Isso faz com que a seleção não seja ocultada ao perder o foco do form
            myText.ScrollBars=ScrollBars.Vertical; 
            myText.Dock=DockStyle.Fill;
            //Eventos
            myText.KeyUp+=new KeyEventHandler(Hotkeys_KeyUp);
            myText.SelectionChanged+=new EventHandler(SelectionChanged);
            myText.MouseUp+=new MouseEventHandler(myText.SelectionHasChanged); //Serve pra acionar o SelectionChanged quando o usuário seleciona manualmente
            myText.TextChanged+=new EventHandler(MyText_TextChanged);
            //Adivionando ao form
            this.Controls.Add(myText);
            myText.BringToFront();

            //Carregando configurações de Tema
            Temas.LoadConfig();
            theme=Temas.Theme;
            this.Size=(Temas.FormSize[0]>=minWidth&&Temas.FormSize[1]>=minHeight) ? new Size(Temas.FormSize[0], Temas.FormSize[1]) : new Size(minWidth, minHeight);
            myText.Font=new Font(Temas.FontFamily, Temas.FontSize, FontStyle.Regular);

            //Inicializando variáveis
            altVerif="";
            hasSave=false;
            openedFileDirectory ="";
            //staticRichText=myText;
            //staticFormMain=this;
            menu_main.Renderer=new MyRenderer(theme); //Adicionando o nosso Renderer personalizado ao menu_main

            //Preenchendo listas de ToolStripMenuItem
            toolStripThemes=new List<ToolStripMenuItem>();
            foreach(ToolStripMenuItem v in tool_tema.DropDownItems) {
                toolStripThemes.Add(v);
            }
            toolStripThemes[theme].Checked=true; //Checa o ToolStripMenuItem do tema atual

            allToolStrip=menu_main.Items;

            //Chamando funções iniciais
            UpdateTitle("");
            ChangeTheme(theme, false);
            UpdateInitialDirectory(Directory.Exists(Temas.InitialDirectory) ? Temas.InitialDirectory : Directory.GetCurrentDirectory());
        }

        private void Main_Load(object sender, EventArgs e) { //form_main Load (Esse método é para o abrir com...)
            //string[] args = Environment.GetCommandLineArgs(); //Obento argumentos da linha de comando
            if(args.Length >0) { //Se passou algum argumento
                string[] extensions = new string[] { ".txt", ".html", ".htm", ".css", ".php", ".dkp" };
                foreach(string arg in args) {
                    foreach(string v in extensions) {
                        if(arg.EndsWith(v)) { //Caso tenha passado algum argumento terminado com uma das extenções da lista
                            OpenFile(arg); //Carregando arquivo
                            myText.Select(0, 0); //Isso para parar de selecionar tudo ao abrir arquivo como
                            altVerif=myText.Text;
                            hasSave=false;
                            UpdateTitle(arg);
                            break;
                        }
                    }
                }
            }
        }

        private void UpdateInitialDirectory(string dir) { //Altera o diretório inicial do save/open dialog para o último local acessado
            Temas.InitialDirectory= open_file.InitialDirectory= save_file.InitialDirectory= dir;
        }

        private void ChangeTheme(int theme, bool alterTheme) { //Alterar tema do programa
            myText.ForeColor=Temas.GetFontColor(theme);
            myText.BackColor=Temas.GetPrimaryColor(theme);
            menu_main.ForeColor=Temas.GetFontColor(theme);
            menu_main.BackColor=Temas.GetSecondaryColor(theme);
            sep_topBorder.BackColor=Temas.GetTopBorderColor(theme);
            menu_main.Renderer=new MyRenderer(theme); //Adicionando novo renderer

            int[] formSize = new int[2] { this.Width, this.Height };
            toolStripThemes[this.theme].Checked=false; //Remove Checked do tema anterior
            this.theme=theme;

            foreach(ToolStripMenuItem v in allToolStrip) {
                //Console.WriteLine(v.BackColor);
                v.ForeColor=Temas.GetFontColor(theme);
                for(int i = 0; i<v.DropDownItems.Count; i++) {
                    v.DropDownItems[i].BackColor=Temas.GetSecondaryColor(theme);
                    v.DropDownItems[i].ForeColor=Temas.GetFontColor(theme);
                }
                //Console.WriteLine(v.BackColor);
            }
            for(int i = 0; i<toolStripThemes.Count; i++) {
                toolStripThemes[i].BackColor=Temas.GetSecondaryColor(theme);
                toolStripThemes[i].ForeColor=Temas.GetFontColor(theme);
            }
            toolStripThemes[theme].Checked=true;

            if(alterTheme==true) Temas.SaveConfig(theme, myText.Font.FontFamily.Name, myText.Font.Size, formSize, Temas.InitialDirectory);
        }

        private void UpdateTitle(string fileDirectory) { //Atualiza título do Form e o atual diretório aberto
            string fileName = fileDirectory;
            int lastBar = 0;
            if(fileName.Length>0) {
                lastBar=1+fileName.LastIndexOf("\\"); //Encontrando posição da última ocorrência de um \ (1+ porque posição começa com 0 e aqui retorna tamanho normal)
                fileName=fileName.Remove(0, lastBar); //Removendo texto da posição 0 até o lastBar 
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
                        UpdateInitialDirectory(save_file.FileName.Remove(save_file.FileName.LastIndexOf(@"\")));
                    } else return DialogResult.Cancel;

                } else if(SaveFile(save_file.FileName)==false) return DialogResult.Cancel;
            }
            return result;
        }

        private bool SaveFile(string fileName) { //Salvar arquivo
            string text = myText.Text.Replace("\r\n", "\n");
            //string text = myText.Text.Replace("\r\n", ""); //Isso é para não ficar com quebra de linha dobrada ao salvar
            try {
                /* Obs:
                 * Não está salvando alterações em arquivos existente que tenham links, desde que essa alteração seja apenas
                 * apagando algum conteúdo. Caso adicione algo, ele salva normalmente.
                 * Deletando o arquivo e recriando resolve o problema...
                */
                if(File.Exists(fileName)) File.Delete(fileName); //Deletando o arquivo porque não estava salvando alguns arquivos...
                /*Console.WriteLine("\nFileName: {0}", fileName);
                Console.WriteLine("\nText: {0}", text);
                Console.WriteLine("\nAltVerif: {0}", altVerif);*/
                using(var arquivo= new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)) {
                    using(var gravador = new StreamWriter(arquivo)){
                        gravador.Flush();
                        gravador.BaseStream.Seek(0, SeekOrigin.Begin);
                        gravador.Write(text);
                        gravador.Flush();
                    }
                }
            } catch(Exception ex) {
                MessageBox.Show("Não foi possível salvar o arquivo\n"+ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            MyText_TextChanged(null, null); //Remover o * do título
            return true;
        }

        private void OpenFile(string fileName) { //Abrir arquivo
            string linha = null;
            string text = "";

            try {
                using(var arquivo = new FileStream(fileName, FileMode.Open, FileAccess.Read)) {
                    using(var leitor = new StreamReader(arquivo)) {
                        leitor.BaseStream.Seek(0, SeekOrigin.Begin);
                        myText.Clear();
                        linha=leitor.ReadLine();
                        while(linha!=null) {
                            //myText.Text+=linha+"\n"; - RichTextBox
                            text+=linha+"\n";
                            linha=leitor.ReadLine();
                        }
                        myText.Text=text.Replace("\n", "\r\n"); //Substituindo \n por \r\n, porque o TextBox não suporta o \n comum por algum motivo...
                    }
                }
            } catch(Exception ex) {
                MessageBox.Show("Não foi possível abrir o arquivo\n"+ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public static int Locate(string toLocate, int type, bool caseSense, int initialLocate) { //Serve pra localizar a próxima palavra ou anterior passada no form_localizar
            int next = 0, prev=-1, richLenght=0; //next: posição da próxima localização; prev: posição do inicio-tamanho da localização atual; richLenght: tamanho da localização atual; 
            int selectionStart = 0; //Guarda a posição inicial do texto selecionado
            bool found=false; //Se no botão anterior foi encontrado ou não a localização

            /*RichTextBoxFinds caseSensitive=new RichTextBoxFinds();
            if(caseSense==false) caseSensitive=RichTextBoxFinds.None; //Com Case Sensitive
            else caseSensitive=RichTextBoxFinds.MatchCase; //Sem Case Sensitive*/

            if(initialLocate!=0) next=initialLocate+myText.SelectionLength;
            if(myText.SelectedText != "") selectionStart=myText.SelectionStart;
            
            if(type==0) { //Próximo
                if(myText.Find(toLocate, next, false, caseSense)==-1) {
                    MessageBox.Show("Não foi possível localizar \""+toLocate+"\"", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return selectionStart;
                }
            } else { //Anterior
                richLenght=myText.SelectionLength;
                prev=initialLocate; //prev=next-richLenght;
                for(int i=prev-richLenght; i>0; i-=richLenght) { //i-=richLenght porque assim ele confere do 210-200 (por exemplo) e no próximo confere do 220-210, e por aí vai...
                    Console.WriteLine("i={0}, initialLocate={1}, richLenght={2}", i,initialLocate,richLenght);
                    if(myText.Find(toLocate, i, true, caseSense)!=-1) {
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
            return myText.SelectionStart;
        }

        public static void Replace(string text, string toReplace, bool caseSense) {
            /*RichTextBoxFinds caseSensitive = RichTextBoxFinds.None;
            if(caseSense == true) caseSensitive=RichTextBoxFinds.MatchCase;*/

            if(myText.Find(text, caseSense) ==-1) {
                MessageBox.Show("Não foi possível localizar \""+text+"\"", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            while(myText.Find(text, caseSense)!=-1) {
                myText.SelectedText=toReplace; //Percorre todo o RichText substituindo toda ocorrência do texto passado
            }
            MessageBox.Show("Ocorrências substituidas com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SelectionChanged(object sender, EventArgs e) { //Alterou seleção (isso é pro localizar/substituir)
            if(myText.SelectionLength>0) initialLocate=myText.SelectionStart;
            else initialLocate=0;
            //Console.WriteLine(initialLocate);
        }

        private void MyText_TextChanged(object sender, EventArgs e) { //Alterar texto da TextBox
            //Isso é pra mostrar um " * " antes do título pra indicar que o arquivo foi editado e não salvo
            if(myText.Text != altVerif & hasSave == false) {
                this.Text="*"+this.Text;
                hasSave=true;
            }else if(myText.Text == altVerif) {
                if(this.Text.Contains("*")) this.Text=this.Text.Remove(0, 1);
                hasSave=false;
            }
        }

            /* <Menu -> Arquivo> */
        private void NewFile_Click(object sender, EventArgs e) { //Botão Novo
            DialogResult result = DialogResult.None;

            Console.WriteLine("altVerif: "+altVerif);
            Console.WriteLine("RichTextBox: "+myText.Text);
            Console.WriteLine("openedFileDirectory: "+openedFileDirectory);

            if(myText.Text!="" && openedFileDirectory=="") result=SaveChanges(false); //Se tem conteúdo na rich_box não é de um arquivo aberto e não é vazio
            else if(openedFileDirectory!="" && altVerif!=myText.Text) result=SaveChanges(true); //Se tem conteúdo na rich_box é de um arquivo aberto e foi alterado

            if(result!=DialogResult.Cancel) {
                myText.Clear();
                altVerif="";
                hasSave=false;
                UpdateTitle("");
            }
        }

        private void NewWindow_Click(object sender, EventArgs e) { //Botão Nova janela
            //Não tá pegando porque está fazendo referência ao form_main já aberto...
            new form_main(null).Show();
        }

        private void OpenFile_Click(object sender, EventArgs e) { //Botão Abrir
            DialogResult result = DialogResult.None; //Para saber resultado do SaveChanges (se a pessoa não cancelou basicamente)

            if(myText.Text!=""&&openedFileDirectory=="") result=SaveChanges(false); //Se tem conteúdo na rich_box não é de um arquivo aberto e não é vazio
            else if(openedFileDirectory!=""&&altVerif!=myText.Text) result=SaveChanges(true); //Se tem conteúdo na rich_box é de um arquivo aberto e foi alterado

            if(result!=DialogResult.Cancel&&open_file.ShowDialog()==DialogResult.OK) {
                OpenFile(open_file.FileName);
                altVerif=myText.Text;
                hasSave=false;
                UpdateTitle(open_file.FileName);
                UpdateInitialDirectory(open_file.FileName.Remove(open_file.FileName.LastIndexOf(@"\")));
            }
        }

        private void Save_Click(object sender, EventArgs e) { //Botão Salvar
            if(openedFileDirectory!="") {
                if(SaveFile(openedFileDirectory)==true) altVerif=myText.Text;
            } else {
                if(save_file.ShowDialog()==DialogResult.OK) {
                    if(SaveFile(save_file.FileName)==false) return;
                    else {
                        altVerif=myText.Text;
                        hasSave=false;
                        UpdateTitle(save_file.FileName);
                    }
                } else return;
            }
            MyText_TextChanged(null, null);
        }

        private void SaveAs_Click(object sender, EventArgs e) { //Botão Salvar Como...
            if(save_file.ShowDialog()==DialogResult.OK) {
                if(SaveFile(save_file.FileName)==false) return;
                else {
                    altVerif=myText.Text;
                    hasSave=false;
                    UpdateTitle(save_file.FileName); //CONCERTAR ISSO, POIS ESTÁ PEGANDO O DIRETÓRIO DO ARQUIVO
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e) { //Botão Sair
            DialogResult result = DialogResult.None; //Para saber resultado do SaveChanges (se a pessoa não cancelou basicamente)

            if(myText.Text!=""&&openedFileDirectory=="") result=SaveChanges(false); //Se tem conteúdo na rich_box não é de um arquivo aberto e não é vazio
            else if(openedFileDirectory!=""&&altVerif!=myText.Text) result=SaveChanges(true); //Se tem conteúdo na rich_box é de um arquivo aberto e foi alterado

            if(result!=DialogResult.Cancel) this.Close();
        }
        //Fim -> Menu Arquivo

        /* < Menu -> Editar > */
        private void Cut_Click(object sender, EventArgs e) { //Botão Recortar
            if(myText.SelectionLength > 0) myText.Cut(); //Recortando seleção atual pra área de transferência
        }
        private void Copy_Click(object sender, EventArgs e) { //Botão Copiar
            if(myText.SelectionLength > 0) myText.Copy(); //Copiando seleção atual pra área de transferência
        }
        private void Paste_Click(object sender, EventArgs e) { //Botão Colar
            myText.Paste(); //Colando texto da área de transferência
        }
        private void Delete_Click(object sender, EventArgs e) { //Botão Deletar
            if(myText.SelectedText!="") myText.SelectedText="";
            else MessageBox.Show("Selecione um trexo para deletar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Locate_Click(object sender, EventArgs e) { //Botão Localizar
            localizar=new form_locate(theme,0,myText.SelectedText,this);
            localizar.Show();
        }
        private void LocateNext_Click(object sender, EventArgs e) { //Botão Localizar Próxima
            if(myText.SelectedText != "") Locate(myText.SelectedText, 0, false, initialLocate);
            else MessageBox.Show("Selecione um trexo para localizar outras ocorrências do mesmo ou use a opção \"Localizar (Crtl+F)\"", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LocatePrevious_Click(object sender, EventArgs e) { //Botão Localizar Anterior
            if(myText.SelectedText!="") Locate(myText.SelectedText, 1, false, initialLocate);
            else MessageBox.Show("Selecione um trexo para localizar outras ocorrências do mesmo ou use a opção \"Localizar (Crtl+F)\"", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Replace_Click(object sender, EventArgs e) { //Botão Substituir
            localizar=new form_locate(theme,1,myText.SelectedText, this);
            localizar.Show();
        }
        //Fim -> Menu Editar

        /* < Menu -> Formatar > */
        private void Font_Click(object sender, EventArgs e) { //Botão Fonte...
            font_custom.Font=myText.Font;

            if(font_custom.ShowDialog() == DialogResult.OK) {
                int[] formSize = new int[2] { this.Width, this.Height };
                myText.Font=font_custom.Font;
                Temas.SaveConfig(theme, myText.Font.FontFamily.Name, myText.Font.Size, formSize, Temas.InitialDirectory);
            }
        }

        private void Tema_Click(object sender, EventArgs e) { //Botão Tema Dark Grey-Blue...
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int id = int.Parse(item.Tag.ToString());
            if(!toolStripThemes[id].Checked) {
                ChangeTheme(id, true);
                toolStripThemes[id].Checked=true;
            }
        }
        //Fim -> Menu Formatar

        /* < Menu -> Ajuda > */
        private void Sobre_Click(object sender, EventArgs e) { //Botão Sobre
            MessageBox.Show("DarkPad Versão 2.0\n" +
                            "Desenvolvido por Frankley Patrício. Todos os Direitos Reservados © 2020\n" +
                            "Acesse o reposítório no GitHub para mais informações\n" +
                            github, "Sobre o Darkpad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Ajuda_Click(object sender, EventArgs e) { //Botão Exibir Ajuda
            Process.Start(github);
        }
        //Fim -> Menu Ajuda

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
            int[] formSize = (this.Width>=minWidth && this.Height>=minHeight) ? new int[] { this.Width, this.Height } : new int[] { minWidth, minHeight };

            if(myText.Text!="" && openedFileDirectory=="") result=SaveChanges(false); //Se tem conteúdo na text_box não é de um arquivo aberto e não é vazio
            else if(openedFileDirectory!=""&&altVerif!=myText.Text) result=SaveChanges(true); //Se tem conteúdo na text_box é de um arquivo aberto e foi alterado

            if(result==DialogResult.Cancel) return; //Se cancelou o fechamento

            /*if(this.Width != Temas.FormSize[0] || this.Height != Temas.FormSize[1]) { //Se alterou o size do form
                formSize=new int[] { this.Width, this.Height };
            }*/
            Temas.SaveConfig(theme, myText.Font.FontFamily.Name, myText.Font.Size, formSize, Temas.InitialDirectory);
        }
    }

    public class MyRenderer : ToolStripProfessionalRenderer { //Isso é para editar a cor de foco dos itens no menu
        public MyRenderer(int theme) : base(new MyColors(theme)) { }
    }
    public class MyColors : ProfessionalColorTable { //Aqui é onde editaremos as cores das funções herdades do ProfessionalColorTable
        private readonly int theme;

        public MyColors(int theme) {
            this.theme=theme;
        }
        public override Color MenuItemSelected { //Ao passar o mouse
            //get { return Color.FromArgb(9, 158, 182); }
            get { return Temas.GetMenuItemSelectedColor(theme); }
        }
        public override Color MenuItemSelectedGradientBegin { //Adiciona um Gradient (inicio) -> Ao passar o mouse
            get { return Temas.GetMenuItemSelectedColor(theme); }
        }
        public override Color MenuItemSelectedGradientEnd { //Adiciona um Gradient (fim) -> Ao passar o mouse (tem middle tb)
            get { return Temas.GetMenuItemSelectedColor(theme); }
        }
        public override Color MenuItemPressedGradientBegin { //Adiciona um Gradient (inicio) -> Ao clicar em um menu (abrindo seus sub menus)
            get { return Temas.GetMenuItemSelectedColor(theme); }
        }
        public override Color MenuItemPressedGradientEnd { //Adiciona um Gradient (inicio) -> Ao clicar em um menu (abrindo seus sub menus)
            get { return Temas.GetMenuItemSelectedColor(theme); }
        }
        public override Color MenuBorder { //Borda do tool menu
            get { return Temas.GetMenuBorderColor(theme); }
        }
    }
}
