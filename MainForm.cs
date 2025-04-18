using Biblioteca.Classes;
using Biblioteca.MenuStrip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class MainForm : Form
    {
        private string _user;

        public MainForm()
        {
            InitializeComponent();

            Login login = new Login();
            login.ShowDialog();

            _user = conf.User;

            lblBemVindo.Text = $"Bem-vindo {_user} à nossa biblioteca";
            lblVersao.Text = conf.versao;
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keyData)
        {
            if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.P) == Keys.P))
            {
                Comprar comp = new Comprar();
                Fechar.Fechar_Form(this, comp);
            }

            if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.G) == Keys.G))
            {
                Gerir ger = new Gerir();
                Fechar.Fechar_Form(this, ger);
            }

            if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.Tab) == Keys.Tab))
            {
                MainForm main = new MainForm();
                Fechar.Fechar_Form(this, main);
            }

            return base.ProcessCmdKey(ref message, keyData);
        }

        private void comprarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comprar comp = new Comprar();
            Fechar.Fechar_Form(this, comp);
        }

        private void gestãoDeLivrosCtrlGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gerir ger = new Gerir();
            Fechar.Fechar_Form(this, ger);
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir imp = new Imprimir();
            Fechar.Fechar_Form(this, imp);
        }

        private void requisitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Requisitar req = new Requisitar();
            Fechar.Fechar_Form(this, req);
        }

        private void bibliotecaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuStrip.Biblioteca bib = new MenuStrip.Biblioteca();
            bib.ShowDialog();
        }
    } 
}
