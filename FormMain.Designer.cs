namespace DarkPad {
    partial class form_main {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing&&(components!=null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_main));
            this.rich_text = new System.Windows.Forms.RichTextBox();
            this.menu_main = new System.Windows.Forms.MenuStrip();
            this.tool_arquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_novo = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_nova_jan = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_abrir = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_salvar = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_savar_como = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_sair = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_editar = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_recortar = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_copiar = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_colar = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_deletar = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_localizar = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_localizar_prox = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_localizar_ante = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_substituir = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_formatar = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_fonte = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_tema = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_tema0 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_tema1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_tema2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_tema3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_tema4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_ajuda = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_exibirAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_sobre = new System.Windows.Forms.ToolStripMenuItem();
            this.sep_topBorder = new System.Windows.Forms.Panel();
            this.save_file = new System.Windows.Forms.SaveFileDialog();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.font_custom = new System.Windows.Forms.FontDialog();
            this.menu_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // rich_text
            // 
            this.rich_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.rich_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rich_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rich_text.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rich_text.ForeColor = System.Drawing.Color.White;
            this.rich_text.Location = new System.Drawing.Point(0, 25);
            this.rich_text.Name = "rich_text";
            this.rich_text.Size = new System.Drawing.Size(842, 416);
            this.rich_text.TabIndex = 0;
            this.rich_text.Text = "";
            this.rich_text.SelectionChanged += new System.EventHandler(this.SelectionChanged);
            this.rich_text.TextChanged += new System.EventHandler(this.RichText_TextChanged);
            this.rich_text.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Hotkeys_KeyUp);
            // 
            // menu_main
            // 
            this.menu_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.menu_main.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_arquivo,
            this.tool_editar,
            this.tool_formatar,
            this.tool_ajuda});
            this.menu_main.Location = new System.Drawing.Point(0, 0);
            this.menu_main.Name = "menu_main";
            this.menu_main.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu_main.Size = new System.Drawing.Size(842, 25);
            this.menu_main.TabIndex = 1;
            this.menu_main.Text = "menuStrip1";
            // 
            // tool_arquivo
            // 
            this.tool_arquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_novo,
            this.tool_nova_jan,
            this.tool_abrir,
            this.tool_salvar,
            this.tool_savar_como,
            this.tool_sair});
            this.tool_arquivo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tool_arquivo.ForeColor = System.Drawing.Color.White;
            this.tool_arquivo.Name = "tool_arquivo";
            this.tool_arquivo.Size = new System.Drawing.Size(69, 21);
            this.tool_arquivo.Text = "Arquivo";
            // 
            // tool_novo
            // 
            this.tool_novo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_novo.ForeColor = System.Drawing.Color.White;
            this.tool_novo.Name = "tool_novo";
            this.tool_novo.Size = new System.Drawing.Size(255, 22);
            this.tool_novo.Text = "Novo (Crtl+N)";
            this.tool_novo.Click += new System.EventHandler(this.NewFile_Click);
            // 
            // tool_nova_jan
            // 
            this.tool_nova_jan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_nova_jan.ForeColor = System.Drawing.Color.White;
            this.tool_nova_jan.Name = "tool_nova_jan";
            this.tool_nova_jan.Size = new System.Drawing.Size(255, 22);
            this.tool_nova_jan.Text = "Nova Janela (Crtl+Shift+N)";
            this.tool_nova_jan.Click += new System.EventHandler(this.NewWindow_Click);
            // 
            // tool_abrir
            // 
            this.tool_abrir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_abrir.ForeColor = System.Drawing.Color.White;
            this.tool_abrir.Name = "tool_abrir";
            this.tool_abrir.Size = new System.Drawing.Size(255, 22);
            this.tool_abrir.Text = "Abrir (Crtl+O)";
            this.tool_abrir.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // tool_salvar
            // 
            this.tool_salvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_salvar.ForeColor = System.Drawing.Color.White;
            this.tool_salvar.Name = "tool_salvar";
            this.tool_salvar.Size = new System.Drawing.Size(255, 22);
            this.tool_salvar.Text = "Salvar (Crtl+S)";
            this.tool_salvar.Click += new System.EventHandler(this.Save_Click);
            // 
            // tool_savar_como
            // 
            this.tool_savar_como.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_savar_como.ForeColor = System.Drawing.Color.White;
            this.tool_savar_como.Name = "tool_savar_como";
            this.tool_savar_como.Size = new System.Drawing.Size(255, 22);
            this.tool_savar_como.Text = "Salvar Como... (Crtl+Shift+S)";
            this.tool_savar_como.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // tool_sair
            // 
            this.tool_sair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_sair.ForeColor = System.Drawing.Color.White;
            this.tool_sair.Name = "tool_sair";
            this.tool_sair.Size = new System.Drawing.Size(255, 22);
            this.tool_sair.Text = "Sair";
            this.tool_sair.Click += new System.EventHandler(this.Exit_Click);
            // 
            // tool_editar
            // 
            this.tool_editar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_recortar,
            this.tool_copiar,
            this.tool_colar,
            this.tool_deletar,
            this.tool_localizar,
            this.tool_localizar_prox,
            this.tool_localizar_ante,
            this.tool_substituir});
            this.tool_editar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tool_editar.ForeColor = System.Drawing.Color.White;
            this.tool_editar.Name = "tool_editar";
            this.tool_editar.Size = new System.Drawing.Size(56, 21);
            this.tool_editar.Text = "Editar";
            // 
            // tool_recortar
            // 
            this.tool_recortar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_recortar.ForeColor = System.Drawing.Color.White;
            this.tool_recortar.Name = "tool_recortar";
            this.tool_recortar.Size = new System.Drawing.Size(213, 22);
            this.tool_recortar.Text = "Recortar (Ctrl + X)";
            // 
            // tool_copiar
            // 
            this.tool_copiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_copiar.ForeColor = System.Drawing.Color.White;
            this.tool_copiar.Name = "tool_copiar";
            this.tool_copiar.Size = new System.Drawing.Size(213, 22);
            this.tool_copiar.Text = "Copiar (Ctrl + C)";
            // 
            // tool_colar
            // 
            this.tool_colar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_colar.ForeColor = System.Drawing.Color.White;
            this.tool_colar.Name = "tool_colar";
            this.tool_colar.Size = new System.Drawing.Size(213, 22);
            this.tool_colar.Text = "Colar (Ctrl + V)";
            // 
            // tool_deletar
            // 
            this.tool_deletar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_deletar.ForeColor = System.Drawing.Color.White;
            this.tool_deletar.Name = "tool_deletar";
            this.tool_deletar.Size = new System.Drawing.Size(213, 22);
            this.tool_deletar.Text = "Deletar (Del)";
            this.tool_deletar.Click += new System.EventHandler(this.Delete_Click);
            // 
            // tool_localizar
            // 
            this.tool_localizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_localizar.ForeColor = System.Drawing.Color.White;
            this.tool_localizar.Name = "tool_localizar";
            this.tool_localizar.Size = new System.Drawing.Size(213, 22);
            this.tool_localizar.Text = "Localizar (Ctrl + F)";
            this.tool_localizar.Click += new System.EventHandler(this.Locate_Click);
            // 
            // tool_localizar_prox
            // 
            this.tool_localizar_prox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_localizar_prox.ForeColor = System.Drawing.Color.White;
            this.tool_localizar_prox.Name = "tool_localizar_prox";
            this.tool_localizar_prox.Size = new System.Drawing.Size(213, 22);
            this.tool_localizar_prox.Text = "Localizar Próxima (F3)";
            this.tool_localizar_prox.Click += new System.EventHandler(this.LocateNext_Click);
            // 
            // tool_localizar_ante
            // 
            this.tool_localizar_ante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_localizar_ante.ForeColor = System.Drawing.Color.White;
            this.tool_localizar_ante.Name = "tool_localizar_ante";
            this.tool_localizar_ante.Size = new System.Drawing.Size(213, 22);
            this.tool_localizar_ante.Text = "Localizar Anterior (F4)";
            this.tool_localizar_ante.Click += new System.EventHandler(this.LocatePrevious_Click);
            // 
            // tool_substituir
            // 
            this.tool_substituir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_substituir.ForeColor = System.Drawing.Color.White;
            this.tool_substituir.Name = "tool_substituir";
            this.tool_substituir.Size = new System.Drawing.Size(213, 22);
            this.tool_substituir.Text = "Substituir (Ctrl + H)";
            this.tool_substituir.Click += new System.EventHandler(this.Replace_Click);
            // 
            // tool_formatar
            // 
            this.tool_formatar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_fonte,
            this.tool_tema});
            this.tool_formatar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tool_formatar.ForeColor = System.Drawing.Color.White;
            this.tool_formatar.Name = "tool_formatar";
            this.tool_formatar.Size = new System.Drawing.Size(76, 21);
            this.tool_formatar.Text = "Formatar";
            // 
            // tool_fonte
            // 
            this.tool_fonte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_fonte.ForeColor = System.Drawing.Color.White;
            this.tool_fonte.Name = "tool_fonte";
            this.tool_fonte.Size = new System.Drawing.Size(123, 22);
            this.tool_fonte.Text = "Fonte...";
            this.tool_fonte.Click += new System.EventHandler(this.Font_Click);
            // 
            // tool_tema
            // 
            this.tool_tema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_tema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_tema0,
            this.tool_tema1,
            this.tool_tema2,
            this.tool_tema3,
            this.tool_tema4});
            this.tool_tema.ForeColor = System.Drawing.Color.White;
            this.tool_tema.Name = "tool_tema";
            this.tool_tema.Size = new System.Drawing.Size(123, 22);
            this.tool_tema.Text = "Tema";
            // 
            // tool_tema0
            // 
            this.tool_tema0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_tema0.ForeColor = System.Drawing.Color.White;
            this.tool_tema0.Name = "tool_tema0";
            this.tool_tema0.Size = new System.Drawing.Size(208, 22);
            this.tool_tema0.Text = "Dark Grey-Blue";
            this.tool_tema0.Click += new System.EventHandler(this.Tema0_Click);
            // 
            // tool_tema1
            // 
            this.tool_tema1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_tema1.ForeColor = System.Drawing.Color.White;
            this.tool_tema1.Name = "tool_tema1";
            this.tool_tema1.Size = new System.Drawing.Size(208, 22);
            this.tool_tema1.Text = "Dark Purple-Hot Pink";
            this.tool_tema1.Click += new System.EventHandler(this.Tema1_Click);
            // 
            // tool_tema2
            // 
            this.tool_tema2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_tema2.ForeColor = System.Drawing.Color.White;
            this.tool_tema2.Name = "tool_tema2";
            this.tool_tema2.Size = new System.Drawing.Size(208, 22);
            this.tool_tema2.Text = "Dark Blue-Green";
            this.tool_tema2.Click += new System.EventHandler(this.Tema2_Click);
            // 
            // tool_tema3
            // 
            this.tool_tema3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_tema3.ForeColor = System.Drawing.Color.White;
            this.tool_tema3.Name = "tool_tema3";
            this.tool_tema3.Size = new System.Drawing.Size(208, 22);
            this.tool_tema3.Text = "Dark Grey-Yellow";
            this.tool_tema3.Click += new System.EventHandler(this.Tema3_Click);
            // 
            // tool_tema4
            // 
            this.tool_tema4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_tema4.ForeColor = System.Drawing.Color.White;
            this.tool_tema4.Name = "tool_tema4";
            this.tool_tema4.Size = new System.Drawing.Size(208, 22);
            this.tool_tema4.Text = "White-Classic";
            this.tool_tema4.Click += new System.EventHandler(this.Tema4_Click);
            // 
            // tool_ajuda
            // 
            this.tool_ajuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_exibirAjuda,
            this.tool_sobre});
            this.tool_ajuda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tool_ajuda.ForeColor = System.Drawing.Color.White;
            this.tool_ajuda.Name = "tool_ajuda";
            this.tool_ajuda.Size = new System.Drawing.Size(56, 21);
            this.tool_ajuda.Text = "Ajuda";
            // 
            // tool_exibirAjuda
            // 
            this.tool_exibirAjuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_exibirAjuda.ForeColor = System.Drawing.Color.White;
            this.tool_exibirAjuda.Name = "tool_exibirAjuda";
            this.tool_exibirAjuda.Size = new System.Drawing.Size(151, 22);
            this.tool_exibirAjuda.Text = "Exibir Ajuda";
            // 
            // tool_sobre
            // 
            this.tool_sobre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tool_sobre.ForeColor = System.Drawing.Color.White;
            this.tool_sobre.Name = "tool_sobre";
            this.tool_sobre.Size = new System.Drawing.Size(151, 22);
            this.tool_sobre.Text = "Sobre";
            this.tool_sobre.Click += new System.EventHandler(this.Sobre_Click);
            // 
            // sep_topBorder
            // 
            this.sep_topBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.sep_topBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.sep_topBorder.Location = new System.Drawing.Point(0, 25);
            this.sep_topBorder.Name = "sep_topBorder";
            this.sep_topBorder.Size = new System.Drawing.Size(842, 3);
            this.sep_topBorder.TabIndex = 2;
            // 
            // save_file
            // 
            this.save_file.DefaultExt = "txt";
            this.save_file.FileName = "*.txt";
            this.save_file.Filter = "(*.txt)|*.txt|(*.html)|*.html|(*.css)|*.css|(*.php)|*.php";
            // 
            // open_file
            // 
            this.open_file.DefaultExt = "txt";
            this.open_file.FileName = "*.txt";
            this.open_file.Filter = "(*.txt)|*.txt|(*.html)|*.html|(*.css)|*.css|(*.php)|*.php";
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 441);
            this.Controls.Add(this.sep_topBorder);
            this.Controls.Add(this.rich_text);
            this.Controls.Add(this.menu_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_main;
            this.Name = "form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DarkPad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menu_main.ResumeLayout(false);
            this.menu_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rich_text;
        private System.Windows.Forms.MenuStrip menu_main;
        private System.Windows.Forms.ToolStripMenuItem tool_arquivo;
        private System.Windows.Forms.Panel sep_topBorder;
        private System.Windows.Forms.ToolStripMenuItem tool_novo;
        private System.Windows.Forms.ToolStripMenuItem tool_salvar;
        private System.Windows.Forms.ToolStripMenuItem tool_savar_como;
        private System.Windows.Forms.ToolStripMenuItem tool_abrir;
        private System.Windows.Forms.ToolStripMenuItem tool_nova_jan;
        private System.Windows.Forms.ToolStripMenuItem tool_sair;
        private System.Windows.Forms.ToolStripMenuItem tool_editar;
        private System.Windows.Forms.ToolStripMenuItem tool_recortar;
        private System.Windows.Forms.ToolStripMenuItem tool_copiar;
        private System.Windows.Forms.ToolStripMenuItem tool_colar;
        private System.Windows.Forms.ToolStripMenuItem tool_deletar;
        private System.Windows.Forms.ToolStripMenuItem tool_localizar;
        private System.Windows.Forms.ToolStripMenuItem tool_localizar_prox;
        private System.Windows.Forms.ToolStripMenuItem tool_localizar_ante;
        private System.Windows.Forms.ToolStripMenuItem tool_formatar;
        private System.Windows.Forms.ToolStripMenuItem tool_fonte;
        private System.Windows.Forms.ToolStripMenuItem tool_tema;
        private System.Windows.Forms.ToolStripMenuItem tool_tema0;
        private System.Windows.Forms.SaveFileDialog save_file;
        private System.Windows.Forms.OpenFileDialog open_file;
        private System.Windows.Forms.ToolStripMenuItem tool_ajuda;
        private System.Windows.Forms.ToolStripMenuItem tool_exibirAjuda;
        private System.Windows.Forms.ToolStripMenuItem tool_sobre;
        private System.Windows.Forms.FontDialog font_custom;
        private System.Windows.Forms.ToolStripMenuItem tool_substituir;
        private System.Windows.Forms.ToolStripMenuItem tool_tema1;
        private System.Windows.Forms.ToolStripMenuItem tool_tema2;
        private System.Windows.Forms.ToolStripMenuItem tool_tema3;
        private System.Windows.Forms.ToolStripMenuItem tool_tema4;
    }
}

