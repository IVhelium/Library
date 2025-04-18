using Biblioteca.Classes;
using Biblioteca.MenuStrip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Gerir : Form
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\";
        string file = "Livros.txt";
        string file2 = "Revistas.txt";

        public List<Livro> livro = new List<Livro>();
        public List<Revista> revista = new List<Revista>();

        private string titulo, autor, genero, editora;
        private int nPaginas;
        private float pReco = 0;
        private DateTime data;

        public Gerir()
        {
            InitializeComponent();
            adicionarSort();

            //Adicionar Escolha

            cmbEscolha.Items.Add("Livro");
            cmbEscolha.Items.Add("Revista");

            limpar();
        }

        public void adicionarSort()
        {
            //Adicionar sort

            if (cmbEscolha.Text == "Livro")
            {
                cmbBoxSort.Items.Add("Listar por autor");
                cmbBoxSort.Items.Add("Listar por titulo");
                cmbBoxSort.Items.Add("Listar por genero");
                cmbBoxSort.Items.Add("Listar por ID");
                cmbBoxSort.Items.Add("Listar por Nº de paginas");
                cmbBoxSort.Items.Add("Listar por data");
                cmbBoxSort.Items.Add("Listar por preço");
            }
            else if (cmbEscolha.Text == "Revista")
            {
                cmbBoxSort.Items.Add("Listar por editora");
                cmbBoxSort.Items.Add("Listar por titulo");
                cmbBoxSort.Items.Add("Listar por ID");
                cmbBoxSort.Items.Add("Listar por Nº de paginas");
                cmbBoxSort.Items.Add("Listar por data");
                cmbBoxSort.Items.Add("Listar por preço");
            }
        }

        public void adicionarColumn()
        {
            //Adicionar colunas

            if (cmbEscolha.Text == "Livro")
            {
                dataGridView1.Columns.Add("ColAutor", "Autor");
                dataGridView1.Columns.Add("ColTitulo", "Titulo");
                dataGridView1.Columns.Add("ColGenero", "Genero");
                dataGridView1.Columns.Add("ColNPaginas", "Nº Paginas");
                dataGridView1.Columns.Add("ColData", "Data");
                dataGridView1.Columns.Add("ColId", "Id");
                dataGridView1.Columns.Add("ColPreco", "Preço");
            }
            else if (cmbEscolha.Text == "Revista")
            {
                dataGridView2.Columns.Add("ColEditora", "Editora");
                dataGridView2.Columns.Add("ColTitulo", "Titulo");
                dataGridView2.Columns.Add("ColNPaginas", "Nº Paginas");
                dataGridView2.Columns.Add("ColData", "Data");
                dataGridView2.Columns.Add("ColId", "Id");
                dataGridView2.Columns.Add("ColPreco", "Preço");
            }
        }

        public void limpar()
        {
            lblAutor.Visible = false;
            lblEditora.Visible = false;
            lblTitulo.Visible = false;
            lblGenero.Visible = false;
            lblNpaginas.Visible = false;
            lblData.Visible = false;
            lblEliminar.Visible = false;

            btnAdicionar.Visible = false;
            btnRemover.Visible = false;
            btnSort.Visible = false;
            btnListar.Visible = false;

            btnSort.Enabled = false;

            txtAutor.Visible = false;
            txtEditora.Visible = false;
            txtTitulo.Visible = false;
            txtJenero.Visible = false;
            txtNumPaginas.Visible = false;
            txtData.Visible = false;

            cmbBoxSort.Visible = false;

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
        }

        public void limparTxt()
        {
            if (cmbEscolha.Text == "Livro")
            {
                txtAutor.ResetText();
                txtTitulo.ResetText();
                txtJenero.ResetText();
                txtNumPaginas.ResetText();
                txtData.ResetText();
            }
            else if (cmbEscolha.Text == "Revista")
            {
                txtEditora.ResetText();
                txtTitulo.ResetText();
                txtNumPaginas.ResetText();
                txtData.ResetText();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                titulo = txtTitulo.Text;
                autor = txtAutor.Text;
                editora = txtEditora.Text;
                genero = txtJenero.Text;
                nPaginas = int.Parse(txtNumPaginas.Text);
                data = DateTime.Parse(txtData.Text);

                Verificar ver = new Verificar();
                Preco prec = new Preco(nPaginas, pReco); //Класс конструктор

                if (ver.verifica(titulo, autor, editora, genero, nPaginas.ToString(), data.ToString()) == true)
                {
                    if (cmbEscolha.SelectedItem.ToString() == "Livro") //Inserir Livro
                    {
                        dataGridView1.Visible = true;
                        dataGridView2.Visible = false;

                        dataGridView1.Columns.Clear();

                        adicionarColumn();

                        Livro liv = new Livro(autor, titulo, genero, nPaginas, data, prec.PrecoLivComIVA()); //Класс конструктор

                        dataGridView1.Rows.Add(autor, titulo, genero, nPaginas, data, liv.Id, prec.PrecoLivComIVA().ToString("F2") + " €");

                        livro.Add(liv);

                        liv.inserirLivro();
                        liv.infDoc();

                        limparTxt();
                    }
                    else if (cmbEscolha.SelectedItem.ToString() == "Revista") //Inserir Revista
                    {
                        dataGridView1.Visible = false;
                        dataGridView2.Visible = true;

                        dataGridView2.Columns.Clear();

                        adicionarColumn();

                        Revista rev = new Revista(editora, titulo, nPaginas, data, prec.PrecoRevComIVA()); //Класс конструктор

                        dataGridView2.Rows.Add(editora, titulo, nPaginas, data, rev.Id, prec.PrecoRevComIVA().ToString("F2") + " €");

                        revista.Add(rev);

                        rev.inserirRevista();
                        rev.infDoc();

                        limparTxt();
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO");
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();

            sort();
        }

        private void sort()
        {
            Sort sort = new Sort();

            if (cmbEscolha.Text == "Livro")
            {
                livro = sort.sortLivro(livro, cmbBoxSort.SelectedItem.ToString());

                dataGridView1.Rows.Clear();

                foreach (var item in livro)
                {
                    dataGridView1.Rows.Add(item.Autor, item.Titulo, item.Genero, item.Paginas, item.Data, item.Id, item.Preco.ToString("F2") + " €");
                }
            }
            else if (cmbEscolha.Text == "Revista")
            {
                revista = sort.sortRevista(revista, cmbBoxSort.SelectedItem.ToString());

                dataGridView2.Rows.Clear();

                foreach (var item in revista)
                {
                    dataGridView2.Rows.Add(item.Editora, item.Titulo, item.Paginas, item.Data, item.Id, item.Preco.ToString("F2") + " €");
                }
            }
        }

        public void VerTudo()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            string autor, titulo, genero, id, editora, nPaginasStr, dataStr, precoStr;

            if (cmbEscolha.Text == "Livro")
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;

                dataGridView1.Columns.Clear();

                try
                {
                    adicionarColumn();

                    dataGridView1.Visible = true;
                    dataGridView2.Visible = false;

                    //Открытие файла и добавление данных в таблицу Книги
                    StreamReader ler = new StreamReader(path + file);

                    while (ler.EndOfStream == false)
                    {
                        autor = ler.ReadLine();
                        titulo = ler.ReadLine();
                        genero = ler.ReadLine();
                        nPaginasStr = ler.ReadLine();
                        dataStr = ler.ReadLine();
                        id = ler.ReadLine();
                        precoStr = ler.ReadLine();

                        if (int.TryParse(nPaginasStr, out int nPaginas) && DateTime.TryParse(dataStr, out DateTime data) && float.TryParse(precoStr, out float preco))
                        {
                            Preco prec = new Preco(nPaginas, pReco); //Класс конструктор

                            Livro liv = new Livro(autor, titulo, genero, nPaginas, data, prec.PrecoLivComIVA()); //Класс конструктор

                            livro.Add(liv);

                            dataGridView1.Rows.Add(autor, titulo, genero, nPaginas, data, id, prec.PrecoLivComIVA().ToString("F2") + " €");
                        }
                        else
                        {
                            throw new ArgumentException("Lista esta vazio ou elementos inseridos no ficheiro esta errados");
                        }
                        
                    }

                    ler.Close();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO");
                }
            }
            else if (cmbEscolha.Text == "Revista")
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;

                dataGridView2.Columns.Clear();

                try
                {
                    adicionarColumn();

                    dataGridView1.Visible = false;
                    dataGridView2.Visible = true;

                    //Открытие файла и добавление данных в таблицу Ревисты
                    StreamReader ler = new StreamReader(path + file2);

                    while (ler.EndOfStream == false)
                    {
                        editora = ler.ReadLine();
                        titulo = ler.ReadLine();
                        nPaginasStr = ler.ReadLine();
                        dataStr = ler.ReadLine();
                        id = ler.ReadLine();
                        precoStr = ler.ReadLine();

                        if (int.TryParse(nPaginasStr, out int nPaginas) && DateTime.TryParse(dataStr, out DateTime data) && float.TryParse(precoStr, out float preco))
                        {
                            Preco prec = new Preco(nPaginas, pReco); //Класс конструктор

                            Revista rev = new Revista(editora, titulo, nPaginas, data, prec.PrecoRevComIVA()); //Класс конструктор

                            revista.Add(rev);

                            dataGridView2.Rows.Add(editora, titulo, nPaginas, data, id, prec.PrecoRevComIVA().ToString("F2") + " €");
                        }
                        else
                        {
                            throw new ArgumentException("Lista esta vazio ou elementos inseridos no ficheiro esta errados");
                        }
                    }

                    ler.Close();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO");
                }
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (cmbEscolha.Text == "Livro")
            {
                List<string> dados = new List<string>();

                int l = dataGridView1.RowCount;
                int pos;

                if (l <= 0)
                {
                    throw new ArgumentException("Não existe livros para eliminar");
                }
                else
                {
                    StreamReader ler = new StreamReader(path + file);

                    while (ler.EndOfStream == false)
                    {
                        dados.Add(ler.ReadLine());
                    }

                    ler.Close();

                    int linha = dataGridView1.CurrentRow.Index;

                    string texto = dataGridView1.Rows[linha].Cells[0].Value.ToString();

                    if (linha == 0)
                    {
                        pos = 0;
                    }
                    else
                    {
                        pos = linha * 7;
                    }

                    if (linha == dataGridView1.CurrentRow.Index)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            dados.RemoveAt(pos);
                        }
                    }

                    dataGridView1.Rows.RemoveAt(linha);

                    StreamWriter esc = new StreamWriter(path + file, false, Encoding.UTF8);

                    foreach (var item in dados)
                    {
                        esc.WriteLine(item);
                    }
                    esc.Close();

                    lblEliminar.Text = "Eliminado: " + texto;
                }
            }
            else if (cmbEscolha.Text == "Revista")
            {
                List<string> dados = new List<string>();

                int l = dataGridView2.RowCount;
                int pos;

                if (l <= 0)
                {
                    throw new ArgumentException("Não existe revistas para eliminar");
                }
                else
                {
                    StreamReader ler = new StreamReader(path + file2);

                    while (ler.EndOfStream == false)
                    {
                        dados.Add(ler.ReadLine());
                    }

                    ler.Close();

                    int linha = dataGridView2.CurrentRow.Index;

                    string texto = dataGridView2.Rows[linha].Cells[0].Value.ToString();

                    if (linha == 0)
                    {
                        pos = 0;
                    }
                    else
                    {
                        pos = linha * 6;
                    }

                    if (linha == dataGridView2.CurrentRow.Index)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            dados.RemoveAt(pos);
                        }
                    }

                    dataGridView2.Rows.RemoveAt(linha);

                    StreamWriter esc = new StreamWriter(path + file2, false, Encoding.UTF8);

                    foreach (var item in dados)
                    {
                        esc.WriteLine(item);
                    }
                    esc.Close();

                    lblEliminar.Text = "Eliminado: " + texto;
                }
            }
        }

        private void CmbBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = cmbBoxSort.SelectedItem.ToString();
            
            switch (s)
            {
                case "Listar por autor":
                    cmbBoxSort.Items.Clear();
                    cmbBoxSort.Items.Add("Voltar");
                    cmbBoxSort.Items.Add("A: A - Z");
                    cmbBoxSort.Items.Add("A: Z - A");
                    break;

                case "Listar por editora":
                    cmbBoxSort.Items.Clear();
                    cmbBoxSort.Items.Add("Voltar");
                    cmbBoxSort.Items.Add("E: A - Z");
                    cmbBoxSort.Items.Add("E: Z - A");
                    break;

                case "Listar por titulo":
                    cmbBoxSort.Items.Clear();
                    cmbBoxSort.Items.Add("Voltar");
                    cmbBoxSort.Items.Add("T: A - Z");
                    cmbBoxSort.Items.Add("T: Z - A");
                    break;

                case "Listar por genero":
                    cmbBoxSort.Items.Clear();
                    cmbBoxSort.Items.Add("Voltar");
                    cmbBoxSort.Items.Add("G: A - Z");
                    cmbBoxSort.Items.Add("G: Z - A");
                    break;

                case "Listar por ID":
                    cmbBoxSort.Items.Clear();
                    cmbBoxSort.Items.Add("Voltar");
                    cmbBoxSort.Items.Add("ID: 1 - 10");
                    cmbBoxSort.Items.Add("ID: 10 - 1");
                    break;

                case "Listar por Nº de paginas":
                    cmbBoxSort.Items.Clear();
                    cmbBoxSort.Items.Add("Voltar");
                    cmbBoxSort.Items.Add("P: 1 - 10");
                    cmbBoxSort.Items.Add("P: 10 - 1");
                    break;

                case "Listar por data":
                    cmbBoxSort.Items.Clear();
                    cmbBoxSort.Items.Add("Voltar");
                    cmbBoxSort.Items.Add("D: 1 - 10");
                    cmbBoxSort.Items.Add("D: 10 - 1");
                    break;

                case "Listar por preço":
                    cmbBoxSort.Items.Clear();
                    cmbBoxSort.Items.Add("Voltar");
                    cmbBoxSort.Items.Add("Pr: 1 - 10");
                    cmbBoxSort.Items.Add("Pr: 10 - 1");
                    break;

                case "Voltar":
                    cmbBoxSort.Items.Clear();
                    adicionarSort();
                    btnSort.Enabled = false;
                    break;

                default:
                    break;
            }

            if ((cmbBoxSort.Text == "A: A - Z" || cmbBoxSort.Text == "A: Z - A") || (cmbBoxSort.Text == "E: A - Z" || cmbBoxSort.Text == "E: Z - A") || (cmbBoxSort.Text == "T: A - Z" || cmbBoxSort.Text == "T: Z - A") || (cmbBoxSort.Text == "G: A - Z" || cmbBoxSort.Text == "G: Z - A") || (cmbBoxSort.Text == "ID: 1 - 10" || cmbBoxSort.Text == "ID: 10 - 1") || (cmbBoxSort.Text == "P: 1 - 10" || cmbBoxSort.Text == "P: 10 - 1") || (cmbBoxSort.Text == "D: 1 - 10" || cmbBoxSort.Text == "D: 10 - 1") || (cmbBoxSort.Text == "Pr: 1 - 10" || cmbBoxSort.Text == "Pr: 10 - 1"))
            {
                btnSort.Enabled = true;
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            VerTudo();
        }

        private void cmbEscolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpar();

            if (cmbEscolha.SelectedItem.ToString() == "Revista")
            {
                lblEditora.Visible = true;
                lblTitulo.Visible = true;
                lblNpaginas.Visible = true;
                lblData.Visible = true;
                lblEliminar.Visible = true;

                lblEditora.Enabled = true;

                lblAutor.Enabled = false;
                lblGenero.Enabled = false;

                btnAdicionar.Visible = true;
                btnRemover.Visible = true;
                btnSort.Visible = true;
                btnListar.Visible = true;

                txtEditora.Visible = true;
                txtTitulo.Visible = true;
                txtJenero.Visible = true;
                txtNumPaginas.Visible = true;
                txtData.Visible = true;

                txtEditora.Enabled = true;

                txtAutor.Enabled = false;
                txtJenero.Enabled = false;

                cmbBoxSort.Visible = true;

                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
            }
            else if (cmbEscolha.SelectedItem.ToString() == "Livro")
            {
                lblAutor.Visible = true;
                lblTitulo.Visible = true;
                lblGenero.Visible = true;
                lblNpaginas.Visible = true;
                lblData.Visible = true;
                lblEliminar.Visible = true;

                lblAutor.Enabled = true;
                lblGenero.Enabled = true;

                lblEditora.Enabled = false;

                btnAdicionar.Visible = true;
                btnRemover.Visible = true;
                btnSort.Visible = true;
                btnListar.Visible = true;

                txtAutor.Visible = true;
                txtTitulo.Visible = true;
                txtJenero.Visible = true;
                txtNumPaginas.Visible = true;
                txtData.Visible = true;

                txtAutor.Enabled = true;
                txtJenero.Enabled = true;

                txtEditora.Enabled = false;

                cmbBoxSort.Visible = true;

                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
            }

            adicionarSort();
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

        private void gestãoDeLivrosCtrlGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gerir ger = new Gerir();
            Fechar.Fechar_Form(this, ger);
        }

        private void comprarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Comprar comp = new Comprar();
            Fechar.Fechar_Form(this, comp);
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir imp = new Imprimir();
            Fechar.Fechar_Form(this, imp);
        }
    }
}