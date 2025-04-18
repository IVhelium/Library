namespace Biblioteca.MenuStrip
{
    partial class Requisitar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestãoDeLivrosCtrlGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requisitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bibliotecaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbPesquisar = new System.Windows.Forms.ComboBox();
            this.cmbEscolha = new System.Windows.Forms.ComboBox();
            this.btnRequisitar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.btnVerReq = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.cmbBoxSort = new System.Windows.Forms.ComboBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.imprimirToolStripMenuItem,
            this.bibliotecaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestãoDeLivrosCtrlGToolStripMenuItem,
            this.publicarToolStripMenuItem,
            this.requisitarToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // gestãoDeLivrosCtrlGToolStripMenuItem
            // 
            this.gestãoDeLivrosCtrlGToolStripMenuItem.Name = "gestãoDeLivrosCtrlGToolStripMenuItem";
            this.gestãoDeLivrosCtrlGToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.gestãoDeLivrosCtrlGToolStripMenuItem.Text = "Gestão de livros       Ctrl + G";
            this.gestãoDeLivrosCtrlGToolStripMenuItem.Click += new System.EventHandler(this.gestãoDeLivrosCtrlGToolStripMenuItem_Click);
            // 
            // publicarToolStripMenuItem
            // 
            this.publicarToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.publicarToolStripMenuItem.Name = "publicarToolStripMenuItem";
            this.publicarToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.publicarToolStripMenuItem.Text = "Comprar                   Ctrl + P";
            this.publicarToolStripMenuItem.Click += new System.EventHandler(this.publicarToolStripMenuItem_Click);
            // 
            // requisitarToolStripMenuItem
            // 
            this.requisitarToolStripMenuItem.Name = "requisitarToolStripMenuItem";
            this.requisitarToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.requisitarToolStripMenuItem.Text = "Requisitar";
            this.requisitarToolStripMenuItem.Click += new System.EventHandler(this.requisitarToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // bibliotecaToolStripMenuItem
            // 
            this.bibliotecaToolStripMenuItem.Name = "bibliotecaToolStripMenuItem";
            this.bibliotecaToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.bibliotecaToolStripMenuItem.Text = "Biblioteca";
            this.bibliotecaToolStripMenuItem.Click += new System.EventHandler(this.bibliotecaToolStripMenuItem_Click);
            // 
            // cmbPesquisar
            // 
            this.cmbPesquisar.Enabled = false;
            this.cmbPesquisar.FormattingEnabled = true;
            this.cmbPesquisar.Location = new System.Drawing.Point(193, 36);
            this.cmbPesquisar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPesquisar.Name = "cmbPesquisar";
            this.cmbPesquisar.Size = new System.Drawing.Size(228, 24);
            this.cmbPesquisar.TabIndex = 48;
            this.cmbPesquisar.SelectedIndexChanged += new System.EventHandler(this.cmbPesquisar_SelectedIndexChanged);
            // 
            // cmbEscolha
            // 
            this.cmbEscolha.FormattingEnabled = true;
            this.cmbEscolha.Location = new System.Drawing.Point(12, 36);
            this.cmbEscolha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEscolha.Name = "cmbEscolha";
            this.cmbEscolha.Size = new System.Drawing.Size(175, 24);
            this.cmbEscolha.TabIndex = 47;
            this.cmbEscolha.SelectedIndexChanged += new System.EventHandler(this.cmbEscolha_SelectedIndexChanged);
            // 
            // btnRequisitar
            // 
            this.btnRequisitar.Enabled = false;
            this.btnRequisitar.Location = new System.Drawing.Point(425, 69);
            this.btnRequisitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRequisitar.Name = "btnRequisitar";
            this.btnRequisitar.Size = new System.Drawing.Size(177, 55);
            this.btnRequisitar.TabIndex = 45;
            this.btnRequisitar.Text = "Requisitar";
            this.btnRequisitar.UseVisualStyleBackColor = true;
            this.btnRequisitar.Click += new System.EventHandler(this.btnRequisitar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label1.Location = new System.Drawing.Point(428, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 44;
            this.label1.Text = "Requisitado: ";
            // 
            // btnDevolver
            // 
            this.btnDevolver.Enabled = false;
            this.btnDevolver.Location = new System.Drawing.Point(608, 69);
            this.btnDevolver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(180, 55);
            this.btnDevolver.TabIndex = 43;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // txtProcurar
            // 
            this.txtProcurar.Enabled = false;
            this.txtProcurar.Location = new System.Drawing.Point(195, 68);
            this.txtProcurar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(227, 22);
            this.txtProcurar.TabIndex = 42;
            // 
            // btnVerReq
            // 
            this.btnVerReq.Enabled = false;
            this.btnVerReq.Location = new System.Drawing.Point(291, 97);
            this.btnVerReq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerReq.Name = "btnVerReq";
            this.btnVerReq.Size = new System.Drawing.Size(132, 27);
            this.btnVerReq.TabIndex = 41;
            this.btnVerReq.Text = "Ver Requisições";
            this.btnVerReq.UseVisualStyleBackColor = true;
            this.btnVerReq.Click += new System.EventHandler(this.btnVerReq_Click);
            // 
            // btnSort
            // 
            this.btnSort.Enabled = false;
            this.btnSort.Location = new System.Drawing.Point(12, 97);
            this.btnSort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(176, 27);
            this.btnSort.TabIndex = 40;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // cmbBoxSort
            // 
            this.cmbBoxSort.Enabled = false;
            this.cmbBoxSort.FormattingEnabled = true;
            this.cmbBoxSort.Location = new System.Drawing.Point(12, 68);
            this.cmbBoxSort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBoxSort.Name = "cmbBoxSort";
            this.cmbBoxSort.Size = new System.Drawing.Size(175, 24);
            this.cmbBoxSort.TabIndex = 39;
            this.cmbBoxSort.SelectedIndexChanged += new System.EventHandler(this.cmbBoxSort_SelectedIndexChanged);
            // 
            // btnVer
            // 
            this.btnVer.Enabled = false;
            this.btnVer.Location = new System.Drawing.Point(195, 97);
            this.btnVer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(91, 27);
            this.btnVer.TabIndex = 49;
            this.btnVer.Text = "Ver Tudo";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 129);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(773, 310);
            this.dataGridView1.TabIndex = 38;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 129);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(773, 310);
            this.dataGridView2.TabIndex = 46;
            // 
            // Requisitar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbPesquisar);
            this.Controls.Add(this.cmbEscolha);
            this.Controls.Add(this.btnRequisitar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.txtProcurar);
            this.Controls.Add(this.btnVerReq);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.cmbBoxSort);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Requisitar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requisitar";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestãoDeLivrosCtrlGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publicarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requisitarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bibliotecaToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbPesquisar;
        private System.Windows.Forms.ComboBox cmbEscolha;
        private System.Windows.Forms.Button btnRequisitar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.TextBox txtProcurar;
        private System.Windows.Forms.Button btnVerReq;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.ComboBox cmbBoxSort;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}