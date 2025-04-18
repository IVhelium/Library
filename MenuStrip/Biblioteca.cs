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

namespace Biblioteca.MenuStrip
{
    public partial class Biblioteca : Form
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\";
        string file = "Livros.txt";
        string file2 = "Revistas.txt";

        public Biblioteca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fich = path + file;

            try
            {
                string lerFich = File.ReadAllText(fich);
                MessageBox.Show(lerFich, "Livros");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fich = path + file2;

            try
            {
                string lerFich = File.ReadAllText(fich);
                MessageBox.Show(lerFich, "Revistas");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO");
            }
        }
    }
}
