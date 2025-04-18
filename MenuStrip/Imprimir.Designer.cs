namespace Biblioteca.MenuStrip
{
    partial class Imprimir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Imprimir));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestãoDeLivrosCtrlGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requisitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bibliotecaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnPreVisual = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnGuardarResult = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnVer = new System.Windows.Forms.Button();
            this.cmbPesquisar = new System.Windows.Forms.ComboBox();
            this.cmbEscolha = new System.Windows.Forms.ComboBox();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.cmbBoxSort = new System.Windows.Forms.ComboBox();
            this.lstBoxResult1 = new System.Windows.Forms.ListBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lstBoxResult2 = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestãoDeLivrosCtrlGToolStripMenuItem,
            this.comprarToolStripMenuItem,
            this.requisitarToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // gestãoDeLivrosCtrlGToolStripMenuItem
            // 
            this.gestãoDeLivrosCtrlGToolStripMenuItem.Name = "gestãoDeLivrosCtrlGToolStripMenuItem";
            this.gestãoDeLivrosCtrlGToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.gestãoDeLivrosCtrlGToolStripMenuItem.Text = "Gestão de livros       Ctrl + G";
            this.gestãoDeLivrosCtrlGToolStripMenuItem.Click += new System.EventHandler(this.gestãoDeLivrosCtrlGToolStripMenuItem_Click);
            // 
            // comprarToolStripMenuItem
            // 
            this.comprarToolStripMenuItem.Name = "comprarToolStripMenuItem";
            this.comprarToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.comprarToolStripMenuItem.Text = "Comprar                   Ctrl + P";
            this.comprarToolStripMenuItem.Click += new System.EventHandler(this.comprarToolStripMenuItem_Click);
            // 
            // requisitarToolStripMenuItem
            // 
            this.requisitarToolStripMenuItem.Name = "requisitarToolStripMenuItem";
            this.requisitarToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.requisitarToolStripMenuItem.Text = "Requisitar";
            this.requisitarToolStripMenuItem.Click += new System.EventHandler(this.requisitarToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // bibliotecaToolStripMenuItem
            // 
            this.bibliotecaToolStripMenuItem.Name = "bibliotecaToolStripMenuItem";
            this.bibliotecaToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.bibliotecaToolStripMenuItem.Text = "Biblioteca";
            this.bibliotecaToolStripMenuItem.Click += new System.EventHandler(this.bibliotecaToolStripMenuItem_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(388, 35);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(93, 32);
            this.btnImprimir.TabIndex = 29;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnPreVisual
            // 
            this.btnPreVisual.Enabled = false;
            this.btnPreVisual.Location = new System.Drawing.Point(485, 75);
            this.btnPreVisual.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreVisual.Name = "btnPreVisual";
            this.btnPreVisual.Size = new System.Drawing.Size(105, 32);
            this.btnPreVisual.TabIndex = 28;
            this.btnPreVisual.Text = "Pre-visualizar";
            this.btnPreVisual.UseVisualStyleBackColor = true;
            this.btnPreVisual.Click += new System.EventHandler(this.btnPreVisual_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Enabled = false;
            this.btnConfig.Location = new System.Drawing.Point(388, 75);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(93, 32);
            this.btnConfig.TabIndex = 27;
            this.btnConfig.Text = "Configurar";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnGuardarResult
            // 
            this.btnGuardarResult.Enabled = false;
            this.btnGuardarResult.Location = new System.Drawing.Point(485, 35);
            this.btnGuardarResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarResult.Name = "btnGuardarResult";
            this.btnGuardarResult.Size = new System.Drawing.Size(105, 32);
            this.btnGuardarResult.TabIndex = 26;
            this.btnGuardarResult.Text = "Guardar Result.";
            this.btnGuardarResult.UseVisualStyleBackColor = true;
            this.btnGuardarResult.Click += new System.EventHandler(this.btnGuardarResult_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 111);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(453, 244);
            this.dataGridView1.TabIndex = 30;
            // 
            // btnVer
            // 
            this.btnVer.Enabled = false;
            this.btnVer.Location = new System.Drawing.Point(146, 85);
            this.btnVer.Margin = new System.Windows.Forms.Padding(2);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(81, 22);
            this.btnVer.TabIndex = 44;
            this.btnVer.Text = "Ver Tudo";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // cmbPesquisar
            // 
            this.cmbPesquisar.Enabled = false;
            this.cmbPesquisar.FormattingEnabled = true;
            this.cmbPesquisar.Location = new System.Drawing.Point(145, 35);
            this.cmbPesquisar.Name = "cmbPesquisar";
            this.cmbPesquisar.Size = new System.Drawing.Size(172, 21);
            this.cmbPesquisar.TabIndex = 43;
            this.cmbPesquisar.SelectedIndexChanged += new System.EventHandler(this.cmbPesquisar_SelectedIndexChanged);
            // 
            // cmbEscolha
            // 
            this.cmbEscolha.FormattingEnabled = true;
            this.cmbEscolha.Location = new System.Drawing.Point(9, 35);
            this.cmbEscolha.Name = "cmbEscolha";
            this.cmbEscolha.Size = new System.Drawing.Size(132, 21);
            this.cmbEscolha.TabIndex = 42;
            this.cmbEscolha.SelectedIndexChanged += new System.EventHandler(this.cmbEscolha_SelectedIndexChanged);
            // 
            // txtProcurar
            // 
            this.txtProcurar.Enabled = false;
            this.txtProcurar.Location = new System.Drawing.Point(146, 61);
            this.txtProcurar.Margin = new System.Windows.Forms.Padding(2);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(171, 20);
            this.txtProcurar.TabIndex = 41;
            this.txtProcurar.TextChanged += new System.EventHandler(this.txtProcurar_TextChanged);
            // 
            // btnSort
            // 
            this.btnSort.Enabled = false;
            this.btnSort.Location = new System.Drawing.Point(9, 85);
            this.btnSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(132, 22);
            this.btnSort.TabIndex = 39;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // cmbBoxSort
            // 
            this.cmbBoxSort.Enabled = false;
            this.cmbBoxSort.FormattingEnabled = true;
            this.cmbBoxSort.Location = new System.Drawing.Point(9, 61);
            this.cmbBoxSort.Margin = new System.Windows.Forms.Padding(2);
            this.cmbBoxSort.Name = "cmbBoxSort";
            this.cmbBoxSort.Size = new System.Drawing.Size(132, 21);
            this.cmbBoxSort.TabIndex = 38;
            this.cmbBoxSort.SelectedIndexChanged += new System.EventHandler(this.cmbBoxSort_SelectedIndexChanged);
            // 
            // lstBoxResult1
            // 
            this.lstBoxResult1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxResult1.FormattingEnabled = true;
            this.lstBoxResult1.HorizontalScrollbar = true;
            this.lstBoxResult1.ItemHeight = 16;
            this.lstBoxResult1.Location = new System.Drawing.Point(467, 111);
            this.lstBoxResult1.Margin = new System.Windows.Forms.Padding(2);
            this.lstBoxResult1.Name = "lstBoxResult1";
            this.lstBoxResult1.Size = new System.Drawing.Size(123, 244);
            this.lstBoxResult1.TabIndex = 45;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(231, 85);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 22);
            this.btnGuardar.TabIndex = 40;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Enabled = false;
            this.btnRemover.Location = new System.Drawing.Point(323, 35);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(61, 72);
            this.btnRemover.TabIndex = 46;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(9, 111);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(453, 237);
            this.dataGridView2.TabIndex = 47;
            // 
            // lstBoxResult2
            // 
            this.lstBoxResult2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxResult2.FormattingEnabled = true;
            this.lstBoxResult2.HorizontalScrollbar = true;
            this.lstBoxResult2.ItemHeight = 16;
            this.lstBoxResult2.Location = new System.Drawing.Point(467, 111);
            this.lstBoxResult2.Margin = new System.Windows.Forms.Padding(2);
            this.lstBoxResult2.Name = "lstBoxResult2";
            this.lstBoxResult2.Size = new System.Drawing.Size(123, 244);
            this.lstBoxResult2.TabIndex = 48;
            // 
            // Imprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.cmbPesquisar);
            this.Controls.Add(this.cmbEscolha);
            this.Controls.Add(this.txtProcurar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.cmbBoxSort);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnPreVisual);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnGuardarResult);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.lstBoxResult1);
            this.Controls.Add(this.lstBoxResult2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Imprimir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestãoDeLivrosCtrlGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bibliotecaToolStripMenuItem;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnPreVisual;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnGuardarResult;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.ComboBox cmbPesquisar;
        private System.Windows.Forms.ComboBox cmbEscolha;
        private System.Windows.Forms.TextBox txtProcurar;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.ComboBox cmbBoxSort;
        private System.Windows.Forms.ToolStripMenuItem requisitarToolStripMenuItem;
        private System.Windows.Forms.ListBox lstBoxResult1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ListBox lstBoxResult2;
    }
}