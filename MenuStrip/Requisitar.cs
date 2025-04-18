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
using Biblioteca.Classes;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace Biblioteca.MenuStrip
{
    public partial class Requisitar : Form
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\";
        string pathReq = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\Requisicoes\";
        string file = "Livros.txt";
        string file2 = "Revistas.txt";

        public List<Livro> livro = new List<Livro>();
        public List<Revista> revista = new List<Revista>();

        private float pReco = 0;

        public Requisitar()
        {
            InitializeComponent();
            adicionarSort();
            adicionarColmn();
            adicionarPesquisar();

            cmbEscolha.Items.Add("Livro");
            cmbEscolha.Items.Add("Revista");

            //Создание файла
            CriarPathReq();
            CriarFileReq("LivRequisitado", ".txt");
            CriarFileReq("ReqRequisitado", ".txt");
        }

        public void adicionarSort()
        {
            //Adicionar sort

            if (cmbEscolha.Text == "Livro")
            {
                cmbBoxSort.Items.Clear();
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
                cmbBoxSort.Items.Clear();
                cmbBoxSort.Items.Add("Listar por editora");
                cmbBoxSort.Items.Add("Listar por titulo");
                cmbBoxSort.Items.Add("Listar por ID");
                cmbBoxSort.Items.Add("Listar por Nº de paginas");
                cmbBoxSort.Items.Add("Listar por data");
                cmbBoxSort.Items.Add("Listar por preço");
            }
        }

        public void adicionarPesquisar()
        {
            //Adicionar pesquisar

            if (cmbEscolha.Text == "Livro")
            {
                cmbPesquisar.Items.Clear();
                cmbPesquisar.Items.Add("P: Autor");
                cmbPesquisar.Items.Add("P: Titulo");
                cmbPesquisar.Items.Add("P: Genero");
                cmbPesquisar.Items.Add("P: ID");
                cmbPesquisar.Items.Add("P: Nº Paginas");
                cmbPesquisar.Items.Add("P: Data");
            }
            else if (cmbEscolha.Text == "Revista")
            {
                cmbPesquisar.Items.Clear();
                cmbPesquisar.Items.Add("P: Editora");
                cmbPesquisar.Items.Add("P: Titulo");
                cmbPesquisar.Items.Add("P: Nº Paginas");
                cmbPesquisar.Items.Add("P: Data");
                cmbPesquisar.Items.Add("P: ID");
            }
        }

        public void adicionarColmn()
        {
            //Adicionar colunas

            if (cmbEscolha.Text == "Livro")
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;

                dataGridView1.Columns.Clear();
                dataGridView2.Columns.Clear();
                dataGridView1.Columns.Add("ColAutor", "Autor");
                dataGridView1.Columns.Add("ColTitulo", "Titulo");
                dataGridView1.Columns.Add("ColGenero", "Genero");
                dataGridView1.Columns.Add("ColNPaginas", "Nº Paginas");
                dataGridView1.Columns.Add("ColData", "Data");
                dataGridView1.Columns.Add("ColId", "Id");
            }
            else if (cmbEscolha.Text == "Revista")
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;

                dataGridView1.Columns.Clear();
                dataGridView2.Columns.Clear();
                dataGridView2.Columns.Add("ColEditora", "Editora");
                dataGridView2.Columns.Add("ColTitulo", "Titulo");
                dataGridView2.Columns.Add("ColNPaginas", "Nº Paginas");
                dataGridView2.Columns.Add("ColData", "Data");
                dataGridView2.Columns.Add("ColId", "Id");
            }
        }

        public void limpar()
        {
            cmbPesquisar.Items.Clear();
            cmbBoxSort.Items.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            string autor, titulo, genero, id, editora, nPaginasStr, dataStr, precoStr;

            btnDevolver.Enabled = false;
            btnRequisitar.Enabled = true;

            cmbBoxSort.Enabled = true;

            if (cmbEscolha.Text == "Livro")
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;

                dataGridView1.Columns.Clear();

                try
                {
                    adicionarSort();
                    adicionarColmn();

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

                            dataGridView1.Rows.Add(autor, titulo, genero, nPaginas, data, id);
                        }
                        else
                        {
                            throw new ArgumentException("Lista esta vazio ou elementos inserisdos no ficheiro esta errados");
                        }
                    }
                    ler.Close();

                    CriarPathReq();
                    string reqP = CriarFileReq("LivRequisitado", ".txt");

                    StreamReader lerReqL = new StreamReader(Path.Combine(CriarPathReq(), reqP));

                    while (lerReqL.EndOfStream == false)
                    {
                        if (lerReqL.ReadLine() == null)
                        {
                            btnDevolver.Enabled = false;
                            btnVerReq.Enabled = false;
                        }
                        else
                        {
                            btnVerReq.Enabled = true;
                        }
                    }
                    lerReqL.Close();
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
                    adicionarSort();
                    adicionarColmn();

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

                            dataGridView2.Rows.Add(editora, titulo, nPaginas, data, id);
                        }
                        else
                        {
                            throw new ArgumentException("Lista esta vazio ou elementos inserisdos no ficheiro esta errados");
                        }
                    }
                    ler.Close();

                    CriarPathReq();
                    string reqP = CriarFileReq("ReqRequisitado", ".txt");

                    StreamReader lerReqR = new StreamReader(Path.Combine(CriarPathReq(), reqP));

                    while (lerReqR.EndOfStream == false)
                    {
                        if (lerReqR.ReadLine() == null)
                        {
                            btnDevolver.Enabled = false;
                            btnVerReq.Enabled = false;
                        }
                        else
                        {
                            btnVerReq.Enabled = true;
                            btnDevolver.Enabled = true;
                        }
                    }
                    lerReqR.Close();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO");
                }
            }
        }

        private void cmbEscolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "Requisitado: ";
            btnVer.Enabled = true;
            cmbPesquisar.Enabled = true;
            limpar();
            adicionarSort();
            adicionarColmn();
            adicionarPesquisar();
        }

        private string CriarPathReq()
        {
            string pathRecibo = pathReq + conf.User;

            if (!Directory.Exists(pathRecibo))
            {
                Directory.CreateDirectory(pathRecibo);
            }

            return pathRecibo;
        }

        private string CriarFileReq(string TitulFile, string TipoFile)
        {
            CriarPathReq();
            string newFile;

            newFile = $"{TitulFile}{TipoFile}";

            if (!System.IO.File.Exists(Path.Combine(CriarPathReq(), newFile)))
            {
                System.IO.File.Create(Path.Combine(CriarPathReq(), newFile));
            }

            return Path.Combine(CriarPathReq(), newFile);
        }

        private void btnRequisitar_Click(object sender, EventArgs e)
        {
            if (cmbEscolha.Text == "Livro")
            {
                CriarPathReq();
                string reqP = CriarFileReq("LivRequisitado", ".txt");

                bool req = false;

                int linha = dataGridView1.CurrentRow.Index;

                string autor = dataGridView1.Rows[linha].Cells[0].Value.ToString();
                string titulo = dataGridView1.Rows[linha].Cells[1].Value.ToString();
                string genero = dataGridView1.Rows[linha].Cells[2].Value.ToString();
                int paginas = int.Parse(dataGridView1.Rows[linha].Cells[3].Value.ToString());
                DateTime data = DateTime.Parse(dataGridView1.Rows[linha].Cells[4].Value.ToString());
                string id = dataGridView1.Rows[linha].Cells[5].Value.ToString();

                StreamReader ler = new StreamReader(Path.Combine(CriarPathReq(), reqP));

                Livro livro = new Livro(autor, titulo, genero, paginas, data, pReco);

                while (ler.EndOfStream == false)
                {
                    if (autor == ler.ReadLine() && titulo == ler.ReadLine() && genero == ler.ReadLine() && paginas.ToString() == ler.ReadLine() && data.ToString() == ler.ReadLine() && id == ler.ReadLine())
                    {
                        req = true;
                            
                        livro._emprestado = true;
                        livro.emprestado(titulo);
                    }
                    else
                    {
                        livro._emprestado = false;
                    }
                }
                ler.Close();

                if (!req)
                {
                    StreamWriter escrever = new StreamWriter(Path.Combine(CriarPathReq(), reqP), true, Encoding.UTF8);

                    escrever.WriteLine(autor);
                    escrever.WriteLine(titulo);
                    escrever.WriteLine(genero);
                    escrever.WriteLine(paginas);
                    escrever.WriteLine(data);
                    escrever.WriteLine(id);
                    escrever.Close();

                    label1.Text = "Requisitado: " + id;
                    btnVerReq.Enabled = true;
                }
            }
            else if (cmbEscolha.Text == "Revista")
            {
                CriarPathReq();
                string reqP = CriarFileReq("ReqRequisitado", ".txt");

                bool req = false;

                int linha = dataGridView2.CurrentRow.Index;

                string editora = dataGridView2.Rows[linha].Cells[0].Value.ToString();
                string titulo = dataGridView2.Rows[linha].Cells[1].Value.ToString();
                int paginas = int.Parse(dataGridView2.Rows[linha].Cells[2].Value.ToString());
                DateTime data = DateTime.Parse(dataGridView2.Rows[linha].Cells[3].Value.ToString());
                string id = dataGridView2.Rows[linha].Cells[4].Value.ToString();

                StreamReader ler = new StreamReader(Path.Combine(CriarPathReq(), reqP));

                Revista revista = new Revista(editora, titulo, paginas, data, pReco);

                while (ler.EndOfStream == false)
                {
                    if (editora == ler.ReadLine() && titulo == ler.ReadLine() && paginas.ToString() == ler.ReadLine() && data.ToString() == ler.ReadLine() && id == ler.ReadLine())
                    {
                        req = true;

                        revista._emprestado = true;
                        revista.emprestado(titulo);
                    }
                    else
                    {
                        revista._emprestado = false;
                    }
                }
                ler.Close();

                if (!req)
                {
                    StreamWriter escrever = new StreamWriter(Path.Combine(CriarPathReq(), reqP));

                    escrever.WriteLine(editora);
                    escrever.WriteLine(titulo);
                    escrever.WriteLine(paginas);
                    escrever.WriteLine(data);
                    escrever.WriteLine(id);
                    escrever.Close();

                    label1.Text = "Requisitado: " + id;
                    btnVerReq.Enabled = true;
                }
            }
        }

        private void btnVerReq_Click(object sender, EventArgs e)
        {
            listarReq();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (cmbEscolha.Text == "Livro")
            {
                List<string> dados = new List<string>();

                string reqP = CriarFileReq("LivRequisitado", ".txt");

                int linha = dataGridView1.CurrentRow.Index;
                int pos;

                if (linha == 0)
                {
                    pos = 0;
                }
                else
                {
                    pos = linha * 6;
                }

                StreamReader ler = new StreamReader(Path.Combine(CriarPathReq(), reqP));

                while (ler.EndOfStream == false)
                {
                    dados.Add(ler.ReadLine());
                }
                ler.Close();

                if (linha == dataGridView1.CurrentRow.Index)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        dados.RemoveAt(pos);
                    }
                }

                StreamWriter escrever = new StreamWriter(Path.Combine(CriarPathReq(), reqP), false, Encoding.UTF8);

                foreach (var item in dados)
                {
                    escrever.WriteLine(item);
                }
                escrever.Close();

                dataGridView1.Rows.RemoveAt(linha);
            }
            else if (cmbEscolha.Text == "Revista")
            {
                List<string> dados = new List<string>();

                string reqP = CriarFileReq("ReqRequisitado", ".txt");

                int linha = dataGridView2.CurrentRow.Index;
                int pos;

                if (linha == 0)
                {
                    pos = 0;
                }
                else
                {
                    pos = linha * 5;
                }

                StreamReader ler = new StreamReader(Path.Combine(CriarPathReq(), reqP));

                while (ler.EndOfStream == false)
                {
                    dados.Add(ler.ReadLine());
                }
                ler.Close();

                if (linha == dataGridView2.CurrentRow.Index)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        dados.RemoveAt(pos);
                    }
                }

                StreamWriter escrever = new StreamWriter(Path.Combine(CriarPathReq(), reqP), false, Encoding.UTF8);

                foreach (var item in dados)
                {
                    escrever.WriteLine(item);
                }
                escrever.Close();

                dataGridView2.Rows.RemoveAt(linha);
            }

            listarReq();
        }

        public void listarReq()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            if (cmbEscolha.Text == "Livro")
            {
                CriarPathReq();
                string reqP = CriarFileReq("LivRequisitado", ".txt");

                StreamReader ler = new StreamReader(Path.Combine(CriarPathReq(), reqP));

                while (ler.EndOfStream == false)
                {
                    dataGridView1.Rows.Add(ler.ReadLine(), ler.ReadLine(), ler.ReadLine(), ler.ReadLine(), ler.ReadLine(), ler.ReadLine());

                    if (ler.ReadLine() == null)
                    {
                        btnDevolver.Enabled = false;
                    }
                    else
                    {
                        btnDevolver.Enabled = true;
                    }
                }
                ler.Close();
            }
            else if (cmbEscolha.Text == "Revista")
            {
                CriarPathReq();
                string reqP = CriarFileReq("ReqRequisitado", ".txt");

                StreamReader ler = new StreamReader(Path.Combine(CriarPathReq(), reqP));

                while (ler.EndOfStream == false)
                {
                    dataGridView2.Rows.Add(ler.ReadLine(), ler.ReadLine(), ler.ReadLine(), ler.ReadLine(), ler.ReadLine());

                    if (ler.ReadLine() == null)
                    {
                        btnDevolver.Enabled = false;
                    }
                    else
                    {
                        btnDevolver.Enabled = true;
                    }
                }
                ler.Close();
            }
        }

        private void cmbBoxSort_SelectedIndexChanged(object sender, EventArgs e)
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

        public void sort()
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

        private void btnSort_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            sort();
        }

        private void cmbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProcurar.Enabled = true;
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

        private void publicarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comprar comp = new Comprar();
            Fechar.Fechar_Form(this, comp);
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
            Biblioteca bib = new Biblioteca();
            bib.ShowDialog();
        }
    }
}
