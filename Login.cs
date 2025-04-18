using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Classes;

namespace Biblioteca
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void btnInserir_Click(object sender, EventArgs e)
        {
            conf.User = txtNome.Text;

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Insira um nome de utilizador", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Close();
            }
        }
    }
}
