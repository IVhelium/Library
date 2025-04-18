using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Classes;

namespace Biblioteca.MenuStrip
{
    public partial class Comprar : Form
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\";
        string pathComp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\Compras\";
        string file = "Livros.txt";
        string file2 = "Revistas.txt";
        string file5 = "compLivros.txt";
        string file6 = "compRevistas.txt";

        public List<Livro> livro = new List<Livro>();
        public List<Revista> revista = new List<Revista>();

        private float pReco = 0;
        private float _total = 0;

        public Comprar()
        {
            InitializeComponent();
            adicionarSort();
            adicionarColmn();
            adicionarPesquisar();

            cmbEscolha.Items.Add("Livro");
            cmbEscolha.Items.Add("Revista");
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
                cmbPesquisar.Items.Add("P: Preço");
            }
            else if (cmbEscolha.Text == "Revista")
            {
                cmbPesquisar.Items.Clear();
                cmbPesquisar.Items.Add("P: Editora");
                cmbPesquisar.Items.Add("P: Titulo");
                cmbPesquisar.Items.Add("P: Nº Paginas");
                cmbPesquisar.Items.Add("P: Data");
                cmbPesquisar.Items.Add("P: ID");
                cmbPesquisar.Items.Add("P: Preco");
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
                dataGridView1.Columns.Add("ColPreco", "Preço");
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
                dataGridView2.Columns.Add("ColPreco", "Preço");
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

                            dataGridView1.Rows.Add(autor, titulo, genero, nPaginas, data, id, prec.PrecoLivComIVA().ToString("F2") + " €");
                        }
                        else
                        {
                            throw new ArgumentException("Lista esta vazio ou elementos inserisdos no ficheiro esta errados");
                        }
                    }
                    ler.Close();

                    StreamReader lerTot = new StreamReader(path + file5);

                    while (lerTot.EndOfStream == false)
                    {
                        string autorTot = lerTot.ReadLine();
                        string tituloTot = lerTot.ReadLine();
                        string generoTot = lerTot.ReadLine();
                        string paginasTot = lerTot.ReadLine();
                        string dataTot = lerTot.ReadLine();
                        string idTot = lerTot.ReadLine();
                        string precoTot = lerTot.ReadLine();

                        if (int.TryParse(paginasTot, out int nPaginas) && DateTime.TryParse(dataTot, out DateTime data) && float.TryParse(precoTot, out float preco))
                        {
                            _total += preco;

                            label1.Text = "Preço Final: " + _total.ToString("F2") + " €";

                            if (preco == 0)
                            {
                                btnComprar.Enabled = false;
                                btnCarrinho.Enabled = true;
                            }
                            else
                            {
                                btnComprar.Enabled = true;
                                btnCarrinho.Enabled = true;
                            }
                        }
                    }
                    lerTot.Close();
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

                            Revista rev = new Revista(editora, titulo, nPaginas, data,prec.PrecoRevComIVA()); //Класс конструктор

                            revista.Add(rev);

                            dataGridView2.Rows.Add(editora, titulo, nPaginas, data, id, prec.PrecoRevComIVA().ToString("F2") + " €");
                        }
                        else
                        {
                            throw new ArgumentException("Lista esta vazio ou elementos inserisdos no ficheiro esta errados");
                        }
                    }
                    ler.Close();

                    StreamReader lerTot = new StreamReader(path + file6);

                    while (lerTot.EndOfStream == false)
                    {
                        string editoraTot = lerTot.ReadLine();
                        string tituloTot = lerTot.ReadLine();
                        string paginasTot = lerTot.ReadLine();
                        string dataTot = lerTot.ReadLine();
                        string idTot = lerTot.ReadLine();
                        string precoTot = lerTot.ReadLine();

                        if (int.TryParse(paginasTot, out int nPaginas) && DateTime.TryParse(dataTot, out DateTime data) && float.TryParse(precoTot, out float preco))
                        {
                            _total += preco;

                            label1.Text = "Preço Final: " + _total.ToString("F2") + " €";

                            if (preco == 0)
                            {
                                btnComprar.Enabled = false;
                            }
                            else
                            {
                                btnComprar.Enabled = true;
                            }
                        }
                    }
                    lerTot.Close();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO");
                }
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

        private string CriarPathComp()
        {
            string pathRecibo = pathComp + conf.User;

            if (!Directory.Exists(pathRecibo))
            {
                Directory.CreateDirectory(pathRecibo);
            }

            return pathRecibo;
        }

        private string CriarFileComp(string TitulFile, string TipoFile)
        {
            int NumFile = 1;
            CriarPathComp();
            string newFile;

            do
            {
                newFile = $"{TitulFile}{NumFile}{TipoFile}";
                NumFile++;
            }
            while (File.Exists(Path.Combine(CriarPathComp(), newFile)));

            return Path.Combine(CriarPathComp(), newFile);
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            string pesquisar = txtProcurar.Text;

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            if (cmbEscolha.Text == "Livro")
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;

                StreamReader ler = new StreamReader(path + file);

                while (ler.EndOfStream == false)
                {
                    string autor = ler.ReadLine();
                    string titulo = ler.ReadLine();
                    string genero = ler.ReadLine();
                    string paginas = ler.ReadLine();
                    string data = ler.ReadLine();
                    string id = ler.ReadLine();
                    string preco = ler.ReadLine();

                    string tipoPesquisa = cmbPesquisar.SelectedItem.ToString();

                    switch (tipoPesquisa)
                    {
                        case "P: Autor":
                            if (autor.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(autor, titulo, genero, paginas, data, id, preco);
                            }
                            break;
                        case "P: Titulo":
                            if (titulo.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(autor, titulo, genero, paginas, data, id, preco);
                            }
                            break;
                        case "P: Genero":
                            if (genero.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(autor, titulo, genero, paginas, data, id, preco);
                            }
                            break;
                        case "P: Nº Paginas":
                            if (paginas.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(autor, titulo, genero, paginas, data, id, preco);
                            }
                            break;
                        case "P: Data":
                            if (data.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(autor, titulo, genero, paginas, data, id, preco);
                            }
                            break;
                        case "P: ID":
                            if (id.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(autor, titulo, genero, paginas, data, id, preco);
                            }
                            break;
                        case "P: Preço":
                            if (preco.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(autor, titulo, genero, paginas, data, id, preco);
                            }
                            break;
                        default:
                            MessageBox.Show("Não selecionou o tipo de pesquisa", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }

                }
                ler.Close();
            }
            else if (cmbEscolha.Text == "Revista")
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;

                StreamReader ler = new StreamReader(path + file2);

                while (ler.EndOfStream == false)
                {
                    string editora = ler.ReadLine();
                    string titulo = ler.ReadLine();
                    string paginas = ler.ReadLine();
                    string data = ler.ReadLine();
                    string id = ler.ReadLine();
                    string preco = ler.ReadLine();

                    string tipoPesquisa = cmbPesquisar.Text;

                    switch (tipoPesquisa)
                    {
                        case "P: Editora":
                            if (editora.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(editora, titulo, paginas, data, id, preco);
                            }
                            break;
                        case "P: Titulo":
                            if (titulo.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(editora, titulo, paginas, data, id, preco);
                            }
                            break;
                        case "P: Nº Paginas":
                            if (paginas.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(editora, titulo, paginas, data, id, preco);
                            }
                            break;
                        case "P: Data":
                            if (data.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(editora, titulo, paginas, data, id, preco);
                            }
                            break;
                        case "P: ID":
                            if (id.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(editora, titulo, paginas, data, id, preco);
                            }
                            break;
                        case "P: Preço":
                            if (preco.StartsWith(pesquisar))
                            {
                                dataGridView1.Rows.Add(editora, titulo, paginas, data, id, preco);
                            }
                            break;
                        default:
                            MessageBox.Show("Não selecionou o tipo de pesquisa", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                    ler.Close();
                }
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            string pesquisar = txtProcurar.Text;

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            if (cmbEscolha.Text == "Livros")
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;

                StreamReader ler = new StreamReader(path + file);

                while (ler.EndOfStream == false)
                {
                    string autor = ler.ReadLine();

                    if (pesquisar == autor)
                    {
                        dataGridView1.Rows.Add(ler.ReadLine(), autor, ler.ReadLine(), ler.ReadLine(), ler.ReadLine(), ler.ReadLine(), ler.ReadLine());
                    }

                }
                ler.Close();
            }
            if (cmbEscolha.Text == "Revistas")
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;

                StreamReader ler = new StreamReader(path + file2);

                while (ler.EndOfStream == false)
                {
                    string editora = ler.ReadLine();

                    if (pesquisar == editora)
                    {
                        dataGridView1.Rows.Add(ler.ReadLine(), editora, ler.ReadLine(), ler.ReadLine(), ler.ReadLine(), ler.ReadLine());
                    }
                }
                ler.Close();
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            btnCarrinho.Enabled = true;
            VerTudo();
        }

        private void cmbEscolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "Preço Final: 0 €";
            btnVer.Enabled = true;
            btnProcurar.Enabled = true;
            cmbPesquisar.Enabled = true;
            limpar();
            adicionarSort();
            adicionarColmn();
            adicionarPesquisar();
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

        private void btnSort_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            sort();
        }

        private void btnCarrinho_Click(object sender, EventArgs e)
        {
            btnComprar.Enabled = false;

            if (cmbEscolha.Text == "Livro")
            {
                btnComprar.Enabled = true;
                //float total = this._total;

                int linha = dataGridView1.CurrentRow.Index;

                if (linha < 0)
                {
                    throw new ArgumentException("Seleciona livro");
                }
                else
                {
                    string autor = dataGridView1.Rows[linha].Cells[0].Value.ToString();
                    string titulo = dataGridView1.Rows[linha].Cells[1].Value.ToString();
                    string genero = dataGridView1.Rows[linha].Cells[2].Value.ToString();
                    int paginas = int.Parse(dataGridView1.Rows[linha].Cells[3].Value.ToString());
                    DateTime data = DateTime.Parse(dataGridView1.Rows[linha].Cells[4].Value.ToString());
                    string id = dataGridView1.Rows[linha].Cells[5].Value.ToString();
                    float preco = float.Parse(dataGridView1.Rows[linha].Cells[6].Value.ToString().Split('€')[0]);

                    Livro livro = new Livro(autor, titulo, genero, paginas, data, preco);

                    _total += preco;

                    label1.Text = "Preço Final: " + _total.ToString("F2") + " €";

                    livro.comprarLivro();
                }
            }
            else if (cmbEscolha.Text == "Revista")
            {
                btnComprar.Enabled = true;
                //float total = this._total;

                int linha = dataGridView2.CurrentRow.Index;

                if (linha > 0)
                {
                    throw new ArgumentException("Seleciona revista");
                }
                else
                {
                    string editora = dataGridView2.Rows[linha].Cells[0].Value.ToString();
                    string titulo = dataGridView2.Rows[linha].Cells[1].Value.ToString();
                    int paginas = int.Parse(dataGridView2.Rows[linha].Cells[2].Value.ToString());
                    DateTime data = DateTime.Parse(dataGridView2.Rows[linha].Cells[3].Value.ToString());
                    string id = dataGridView2.Rows[linha].Cells[4].Value.ToString();
                    float preco = float.Parse(dataGridView2.Rows[linha].Cells[5].Value.ToString().Split('€')[0]);

                    Revista revista = new Revista(editora, titulo, paginas, data, preco);

                    _total += preco;

                    label1.Text = "Preço Final: " + _total.ToString("F2") + " €";

                    revista.comprarRevista();
                }
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer comprar?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                if (cmbEscolha.Text == "Livro")
                {
                    List<string> dados = new List<string>();

                    CriarPathComp();
                    string recibo = CriarFileComp("LivRecibo", ".txt");

                    StreamReader ler = new StreamReader(path + file5);

                    while (ler.EndOfStream == false)
                    {
                        dados.Add(ler.ReadLine());
                    }
                    ler.Close();

                    StreamWriter inser = new StreamWriter(Path.Combine(CriarPathComp(), recibo), false, Encoding.UTF8);

                    foreach (var item in dados)
                    {
                        inser.WriteLine(item);
                    }
                    inser.Close();

                    MessageBox.Show($"Compra efetuada com sucesso, preço total {_total}, pode ver vosso recibo no ficheiro {recibo}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dados.Clear();

                    StreamWriter reset = new StreamWriter(path + file5, false, Encoding.UTF8);

                    foreach (var item in dados)
                    {
                        reset.WriteLine(item);
                    }
                    reset.Close();

                    _total = 0;
                    label1.Text = "Preço Final: 0 €";
                    btnComprar.Enabled = false;
                }
                else if (cmbEscolha.Text == "Revista")
                {
                    List<string> dados = new List<string>();

                    CriarPathComp();
                    string recibo = CriarFileComp("RevRecibo", ".txt");

                    StreamReader ler = new StreamReader(path + file6);

                    while (ler.EndOfStream == false)
                    {
                        dados.Add(ler.ReadLine());
                    }
                    ler.Close();

                    StreamWriter inser = new StreamWriter(Path.Combine(CriarPathComp(), recibo), false, Encoding.UTF8);

                    foreach (var item in dados)
                    {
                        inser.WriteLine(item);
                    }
                    inser.Close();

                    MessageBox.Show($"Compra efetuada com sucesso, preço total {_total}, pode ver vosso recibo no ficheiro {recibo}", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dados.Clear();

                    StreamWriter reset = new StreamWriter(path + file6, false, Encoding.UTF8);

                    foreach (var item in dados)
                    {
                        reset.WriteLine(item);
                    }
                    reset.Close();

                    _total = 0;
                    label1.Text = "Preço Final: 0 €";
                    btnComprar.Enabled = false;
                }
            }
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

        private void gestãoDeLivrosCtrlGToolStripMenuItem_Click_1(object sender, EventArgs e)
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
