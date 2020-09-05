namespace DarkPad {
    partial class form_locate {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing&&(components!=null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txt_locate = new System.Windows.Forms.TextBox();
            this.lbl_locate = new System.Windows.Forms.Label();
            this.panel_sepLocate = new System.Windows.Forms.Panel();
            this.btn_prox = new System.Windows.Forms.Button();
            this.btn_ant = new System.Windows.Forms.Button();
            this.cbx_caseLocali = new System.Windows.Forms.CheckBox();
            this.tab_editar = new System.Windows.Forms.TabControl();
            this.tab_localizar = new System.Windows.Forms.TabPage();
            this.tab_substituir = new System.Windows.Forms.TabPage();
            this.lbl_substituir = new System.Windows.Forms.Label();
            this.panel_sepSubstituir = new System.Windows.Forms.Panel();
            this.txt_substituir = new System.Windows.Forms.TextBox();
            this.panel_sepOriginal = new System.Windows.Forms.Panel();
            this.btn_substituir = new System.Windows.Forms.Button();
            this.cbx_caseSubst = new System.Windows.Forms.CheckBox();
            this.lbl_original = new System.Windows.Forms.Label();
            this.txt_original = new System.Windows.Forms.TextBox();
            this.tab_editar.SuspendLayout();
            this.tab_localizar.SuspendLayout();
            this.tab_substituir.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_locate
            // 
            this.txt_locate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txt_locate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_locate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_locate.ForeColor = System.Drawing.Color.White;
            this.txt_locate.Location = new System.Drawing.Point(119, 21);
            this.txt_locate.Name = "txt_locate";
            this.txt_locate.Size = new System.Drawing.Size(362, 22);
            this.txt_locate.TabIndex = 0;
            // 
            // lbl_locate
            // 
            this.lbl_locate.AutoSize = true;
            this.lbl_locate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_locate.ForeColor = System.Drawing.Color.White;
            this.lbl_locate.Location = new System.Drawing.Point(9, 21);
            this.lbl_locate.Name = "lbl_locate";
            this.lbl_locate.Size = new System.Drawing.Size(104, 22);
            this.lbl_locate.TabIndex = 1;
            this.lbl_locate.Text = "Localizar: ";
            // 
            // panel_sepLocate
            // 
            this.panel_sepLocate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel_sepLocate.Location = new System.Drawing.Point(119, 45);
            this.panel_sepLocate.Name = "panel_sepLocate";
            this.panel_sepLocate.Size = new System.Drawing.Size(362, 3);
            this.panel_sepLocate.TabIndex = 2;
            // 
            // btn_prox
            // 
            this.btn_prox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_prox.FlatAppearance.BorderSize = 0;
            this.btn_prox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_prox.ForeColor = System.Drawing.Color.White;
            this.btn_prox.Location = new System.Drawing.Point(491, 14);
            this.btn_prox.Name = "btn_prox";
            this.btn_prox.Size = new System.Drawing.Size(91, 32);
            this.btn_prox.TabIndex = 3;
            this.btn_prox.Text = "Próxima";
            this.btn_prox.UseVisualStyleBackColor = false;
            this.btn_prox.TextChanged += new System.EventHandler(this.NewLocate_TextChanged);
            this.btn_prox.Click += new System.EventHandler(this.NextLocate_Click);
            // 
            // btn_ant
            // 
            this.btn_ant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_ant.FlatAppearance.BorderSize = 0;
            this.btn_ant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ant.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ant.ForeColor = System.Drawing.Color.White;
            this.btn_ant.Location = new System.Drawing.Point(491, 52);
            this.btn_ant.Name = "btn_ant";
            this.btn_ant.Size = new System.Drawing.Size(91, 32);
            this.btn_ant.TabIndex = 4;
            this.btn_ant.Text = "Anteriror";
            this.btn_ant.UseVisualStyleBackColor = false;
            this.btn_ant.Click += new System.EventHandler(this.PreviousLocate_Click);
            // 
            // cbx_caseLocali
            // 
            this.cbx_caseLocali.AutoSize = true;
            this.cbx_caseLocali.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_caseLocali.ForeColor = System.Drawing.Color.White;
            this.cbx_caseLocali.Location = new System.Drawing.Point(60, 56);
            this.cbx_caseLocali.Name = "cbx_caseLocali";
            this.cbx_caseLocali.Size = new System.Drawing.Size(372, 26);
            this.cbx_caseLocali.TabIndex = 5;
            this.cbx_caseLocali.Text = "Diferenciar maiúsculas de minúsculas";
            this.cbx_caseLocali.UseVisualStyleBackColor = true;
            // 
            // tab_editar
            // 
            this.tab_editar.Controls.Add(this.tab_localizar);
            this.tab_editar.Controls.Add(this.tab_substituir);
            this.tab_editar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_editar.Location = new System.Drawing.Point(-4, 6);
            this.tab_editar.Name = "tab_editar";
            this.tab_editar.SelectedIndex = 0;
            this.tab_editar.Size = new System.Drawing.Size(602, 130);
            this.tab_editar.TabIndex = 6;
            // 
            // tab_localizar
            // 
            this.tab_localizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tab_localizar.Controls.Add(this.btn_prox);
            this.tab_localizar.Controls.Add(this.cbx_caseLocali);
            this.tab_localizar.Controls.Add(this.lbl_locate);
            this.tab_localizar.Controls.Add(this.btn_ant);
            this.tab_localizar.Controls.Add(this.panel_sepLocate);
            this.tab_localizar.Controls.Add(this.txt_locate);
            this.tab_localizar.ForeColor = System.Drawing.Color.White;
            this.tab_localizar.Location = new System.Drawing.Point(4, 27);
            this.tab_localizar.Name = "tab_localizar";
            this.tab_localizar.Padding = new System.Windows.Forms.Padding(3);
            this.tab_localizar.Size = new System.Drawing.Size(594, 99);
            this.tab_localizar.TabIndex = 0;
            this.tab_localizar.Text = "Localizar";
            // 
            // tab_substituir
            // 
            this.tab_substituir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tab_substituir.Controls.Add(this.lbl_substituir);
            this.tab_substituir.Controls.Add(this.panel_sepSubstituir);
            this.tab_substituir.Controls.Add(this.txt_substituir);
            this.tab_substituir.Controls.Add(this.panel_sepOriginal);
            this.tab_substituir.Controls.Add(this.btn_substituir);
            this.tab_substituir.Controls.Add(this.cbx_caseSubst);
            this.tab_substituir.Controls.Add(this.lbl_original);
            this.tab_substituir.Controls.Add(this.txt_original);
            this.tab_substituir.Location = new System.Drawing.Point(4, 27);
            this.tab_substituir.Name = "tab_substituir";
            this.tab_substituir.Padding = new System.Windows.Forms.Padding(3);
            this.tab_substituir.Size = new System.Drawing.Size(594, 99);
            this.tab_substituir.TabIndex = 1;
            this.tab_substituir.Text = "Substituir";
            // 
            // lbl_substituir
            // 
            this.lbl_substituir.AutoSize = true;
            this.lbl_substituir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_substituir.ForeColor = System.Drawing.Color.White;
            this.lbl_substituir.Location = new System.Drawing.Point(306, 2);
            this.lbl_substituir.Name = "lbl_substituir";
            this.lbl_substituir.Size = new System.Drawing.Size(110, 22);
            this.lbl_substituir.TabIndex = 12;
            this.lbl_substituir.Text = "Substituir: ";
            // 
            // panel_sepSubstituir
            // 
            this.panel_sepSubstituir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel_sepSubstituir.Location = new System.Drawing.Point(307, 52);
            this.panel_sepSubstituir.Name = "panel_sepSubstituir";
            this.panel_sepSubstituir.Size = new System.Drawing.Size(275, 3);
            this.panel_sepSubstituir.TabIndex = 11;
            // 
            // txt_substituir
            // 
            this.txt_substituir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txt_substituir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_substituir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_substituir.ForeColor = System.Drawing.Color.White;
            this.txt_substituir.Location = new System.Drawing.Point(307, 26);
            this.txt_substituir.Name = "txt_substituir";
            this.txt_substituir.Size = new System.Drawing.Size(275, 22);
            this.txt_substituir.TabIndex = 11;
            // 
            // panel_sepOriginal
            // 
            this.panel_sepOriginal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel_sepOriginal.Location = new System.Drawing.Point(12, 52);
            this.panel_sepOriginal.Name = "panel_sepOriginal";
            this.panel_sepOriginal.Size = new System.Drawing.Size(275, 3);
            this.panel_sepOriginal.TabIndex = 10;
            // 
            // btn_substituir
            // 
            this.btn_substituir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_substituir.FlatAppearance.BorderSize = 0;
            this.btn_substituir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_substituir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_substituir.ForeColor = System.Drawing.Color.White;
            this.btn_substituir.Location = new System.Drawing.Point(489, 61);
            this.btn_substituir.Name = "btn_substituir";
            this.btn_substituir.Size = new System.Drawing.Size(93, 32);
            this.btn_substituir.TabIndex = 8;
            this.btn_substituir.Text = "Substituir";
            this.btn_substituir.UseVisualStyleBackColor = false;
            this.btn_substituir.Click += new System.EventHandler(this.Replace_Click);
            // 
            // cbx_caseSubst
            // 
            this.cbx_caseSubst.AutoSize = true;
            this.cbx_caseSubst.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_caseSubst.ForeColor = System.Drawing.Color.White;
            this.cbx_caseSubst.Location = new System.Drawing.Point(12, 67);
            this.cbx_caseSubst.Name = "cbx_caseSubst";
            this.cbx_caseSubst.Size = new System.Drawing.Size(372, 26);
            this.cbx_caseSubst.TabIndex = 9;
            this.cbx_caseSubst.Text = "Diferenciar maiúsculas de minúsculas";
            this.cbx_caseSubst.UseVisualStyleBackColor = true;
            // 
            // lbl_original
            // 
            this.lbl_original.AutoSize = true;
            this.lbl_original.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_original.ForeColor = System.Drawing.Color.White;
            this.lbl_original.Location = new System.Drawing.Point(12, 2);
            this.lbl_original.Name = "lbl_original";
            this.lbl_original.Size = new System.Drawing.Size(93, 22);
            this.lbl_original.TabIndex = 7;
            this.lbl_original.Text = "Original: ";
            // 
            // txt_original
            // 
            this.txt_original.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txt_original.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_original.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_original.ForeColor = System.Drawing.Color.White;
            this.txt_original.Location = new System.Drawing.Point(12, 26);
            this.txt_original.Name = "txt_original";
            this.txt_original.Size = new System.Drawing.Size(275, 22);
            this.txt_original.TabIndex = 6;
            // 
            // form_locate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(594, 132);
            this.Controls.Add(this.tab_editar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_locate";
            this.Text = "Localizar";
            this.tab_editar.ResumeLayout(false);
            this.tab_localizar.ResumeLayout(false);
            this.tab_localizar.PerformLayout();
            this.tab_substituir.ResumeLayout(false);
            this.tab_substituir.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_locate;
        private System.Windows.Forms.Label lbl_locate;
        private System.Windows.Forms.Panel panel_sepLocate;
        private System.Windows.Forms.Button btn_prox;
        private System.Windows.Forms.Button btn_ant;
        private System.Windows.Forms.CheckBox cbx_caseLocali;
        private System.Windows.Forms.TabControl tab_editar;
        private System.Windows.Forms.TabPage tab_localizar;
        private System.Windows.Forms.TabPage tab_substituir;
        private System.Windows.Forms.Panel panel_sepOriginal;
        private System.Windows.Forms.Button btn_substituir;
        private System.Windows.Forms.CheckBox cbx_caseSubst;
        private System.Windows.Forms.Label lbl_original;
        private System.Windows.Forms.TextBox txt_original;
        private System.Windows.Forms.Label lbl_substituir;
        private System.Windows.Forms.Panel panel_sepSubstituir;
        private System.Windows.Forms.TextBox txt_substituir;
    }
}