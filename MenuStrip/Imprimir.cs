using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Classes;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace Biblioteca.MenuStrip
{
    public partial class Imprimir : Form
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\";
        string pathImp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\Imprimir\";
        string file = "Livros.txt";
        string file2 = "Revistas.txt";
        string file7 = "impLivro.txt";
        string file8 = "impRevista.txt";

        public List<Livro> livro = new List<Livro>();
        public List<Revista> revista = new List<Revista>();

        private float pReco = 0;

        public Imprimir()
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

        private void btnVer_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            cmbBoxSort.Enabled = true;
            btnGuardar.Enabled = true;

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

                    //Открытие файла распечаток для добавления айди в ListBox
                    StreamReader ler2 = new StreamReader(pathImp + file7);

                    while (ler2.EndOfStream == false)
                    {
                        autor = ler2.ReadLine();
                        titulo = ler2.ReadLine();
                        genero = ler2.ReadLine();
                        nPaginasStr = ler2.ReadLine();
                        dataStr = ler2.ReadLine();
                        id = ler2.ReadLine();
                        precoStr = ler2.ReadLine();

                        if (id != null)
                        {
                            btnRemover.Enabled = true;
                            btnConfig.Enabled = true;
                            btnImprimir.Enabled = true;
                            btnPreVisual.Enabled = true;
                            btnGuardarResult.Enabled = true;

                            lstBoxResult2.Enabled = true;

                            lstBoxResult1.Items.Add(id);
                        }
                        else
                        {
                            btnRemover.Enabled = false;
                            btnConfig.Enabled = false;
                            btnImprimir.Enabled = false;
                            btnPreVisual.Enabled = false;
                            btnGuardarResult.Enabled = false;

                            lstBoxResult2.Enabled = false;
                        }
                    }
                    ler2.Close();
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

                            dataGridView2.Rows.Add(editora, titulo, nPaginas, data, id, prec.PrecoRevComIVA().ToString("F2") + " €");
                        }
                        else
                        {
                            throw new ArgumentException("Lista esta vazio ou elementos inserisdos no ficheiro esta errados");
                        }
                    }
                    ler.Close();

                    //Открытие файла распечаток для добавления айди в ListBox
                    StreamReader ler2 = new StreamReader(pathImp + file8);

                    while (ler2.EndOfStream == false)
                    {
                        editora = ler2.ReadLine();
                        titulo = ler2.ReadLine();
                        nPaginasStr = ler2.ReadLine();
                        dataStr = ler2.ReadLine();
                        id = ler2.ReadLine();
                        precoStr = ler2.ReadLine();

                        if (id != null)
                        {
                            btnRemover.Enabled = true;
                            btnConfig.Enabled = true;
                            btnImprimir.Enabled = true;
                            btnPreVisual.Enabled = true;
                            btnGuardarResult.Enabled = true;

                            lstBoxResult2.Enabled = true;

                            lstBoxResult2.Items.Add(id);
                        }
                        else
                        {
                            btnRemover.Enabled = false;
                            btnConfig.Enabled = false;
                            btnImprimir.Enabled = false;
                            btnPreVisual.Enabled = false;
                            btnGuardarResult.Enabled = false;

                            lstBoxResult2.Enabled = false;
                        }
                    }
                    ler2.Close();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO");
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbEscolha.Text == "Livro")
            {
                lstBoxResult1.Visible = true;
                lstBoxResult2.Visible = false;

                int l = dataGridView1.RowCount;
                int linha = dataGridView1.CurrentRow.Index;

                if (l <= 0)
                {
                    throw new ArgumentException("Não existe livros para guardar");
                }
                else
                {
                    if (linha >= 0)
                    {
                        string autor = dataGridView1.Rows[linha].Cells[0].Value.ToString();
                        string titulo = dataGridView1.Rows[linha].Cells[1].Value.ToString();
                        string genero = dataGridView1.Rows[linha].Cells[2].Value.ToString();
                        int paginas = int.Parse(dataGridView1.Rows[linha].Cells[3].Value.ToString());
                        DateTime data = DateTime.Parse(dataGridView1.Rows[linha].Cells[4].Value.ToString());
                        string id = dataGridView1.Rows[linha].Cells[5].Value.ToString();
                        float preco = float.Parse(dataGridView1.Rows[linha].Cells[6].Value.ToString().Split('€')[0]);

                        StreamWriter escrever = new StreamWriter(pathImp + file7, true, Encoding.UTF8);

                        escrever.WriteLine(autor);
                        escrever.WriteLine(titulo);
                        escrever.WriteLine(genero);
                        escrever.WriteLine(paginas);
                        escrever.WriteLine(data);
                        escrever.WriteLine(id);
                        escrever.WriteLine(preco);
                        escrever.Close();

                        lstBoxResult1.Items.Add(id);

                        btnConfig.Enabled = true;
                        btnImprimir.Enabled = true;
                        btnPreVisual.Enabled = true;
                        btnGuardarResult.Enabled = true;
                        btnRemover.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Selecione uma linha", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (cmbEscolha.Text == "Revista")
            {
                lstBoxResult1.Visible = false;
                lstBoxResult2.Visible = true;

                int l = dataGridView2.RowCount;
                int linha = dataGridView2.CurrentRow.Index;

                if (l <= 0)
                {
                    throw new ArgumentException("Não existe livros para guardar");
                }
                else
                {
                    if (linha >= 0)
                    {
                        string editora = dataGridView2.Rows[linha].Cells[0].Value.ToString();
                        string titulo = dataGridView2.Rows[linha].Cells[1].Value.ToString();
                        int paginas = int.Parse(dataGridView2.Rows[linha].Cells[2].Value.ToString());
                        DateTime data = DateTime.Parse(dataGridView2.Rows[linha].Cells[3].Value.ToString());
                        string id = dataGridView2.Rows[linha].Cells[4].Value.ToString();
                        float preco = float.Parse(dataGridView2.Rows[linha].Cells[5].Value.ToString().Split('€')[0]);

                        StreamWriter escrever = new StreamWriter(pathImp + file8, true, Encoding.UTF8);

                        escrever.WriteLine(editora);
                        escrever.WriteLine(titulo);
                        escrever.WriteLine(paginas);
                        escrever.WriteLine(data);
                        escrever.WriteLine(id);
                        escrever.WriteLine(preco);

                        lstBoxResult2.Items.Add(id);

                        btnConfig.Enabled = true;
                        btnImprimir.Enabled = true;
                        btnPreVisual.Enabled = true;
                        btnGuardarResult.Enabled = true;
                        btnRemover.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Selecione uma linha", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (cmbEscolha.Text == "Livro")
            {
                List<string> dados = new List<string>();

                string LinhaId = lstBoxResult1.SelectedItem?.ToString();

                try
                {
                    if (LinhaId != null)
                    {
                        StreamReader ler = new StreamReader(pathImp + file7);

                        while (ler.EndOfStream == false)
                        {
                            dados.Add(ler.ReadLine());
                        }
                        ler.Close();

                        for (int i = 0; i < dados.Count; i++) //Поиск ID из всего списка
                        {
                            if (dados[i] == LinhaId)
                            {
                                int primPos = Math.Max(0, i - 5); //Math.Max(0, i - 5) - определяет начальную позицию для удаления
                                int ultPos = Math.Min(7, dados.Count - primPos); //Math.Min(7, dados.Count - primPos) - определяет конечную позицию для удаления

                                dados.RemoveRange(primPos, ultPos); //Удаление элементов из списка
                            }
                        }

                        StreamWriter escrever = new StreamWriter(pathImp + file7, false, Encoding.UTF8);

                        foreach (var item in dados)
                        {
                            escrever.WriteLine(item);
                        }
                        escrever.Close();

                        lstBoxResult1.Items.Remove(LinhaId);

                        MessageBox.Show("Removido com sucesso", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new ArgumentException("Selecione um ID para remover");
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO");
                }
            }
            else if (cmbEscolha.Text == "Revista")
            {
                List<string> dados = new List<string>();

                string LinhaId = lstBoxResult2.SelectedItem?.ToString();

                try
                {
                    if (LinhaId != null)
                    {
                        StreamReader ler = new StreamReader(pathImp + file8);

                        while (ler.EndOfStream == false)
                        {
                            dados.Add(ler.ReadLine());
                        }
                        ler.Close();

                        for (int i = 0; i < dados.Count; i++) //Поиск ID из всего списка
                        {
                            if (dados[i] == LinhaId)
                            {
                                int primPos = Math.Max(0, i - 4); //Math.Max(0, i - 4) - определяет начальную позицию для удаления
                                int ultPos = Math.Min(6, dados.Count - primPos); //Math.Min(6, dados.Count - primPos) - определяет конечную позицию для удаления
                                dados.RemoveRange(primPos, ultPos);
                            }
                        }

                        StreamWriter escrever = new StreamWriter(pathImp + file8, false, Encoding.UTF8);

                        foreach (var item in dados)
                        {
                            escrever.WriteLine(item);
                        }
                        escrever.Close();

                        lstBoxResult2.Items.Remove(LinhaId);

                        MessageBox.Show("Removido com sucesso", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new ArgumentException("Selecione um ID para remover");
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO");
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int y = 100;

            e.Graphics.DrawString("Biblioteca do Ivan", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 100, 50);
            e.Graphics.DrawString("__________________________________________________________________", new Font("Arial", 12), Brushes.Black, 80, 80);
            

            if (cmbEscolha.Text == "Livro")
            {
                string autor, titulo, genero, id, nPaginasStr, dataStr, precoStr;

                try
                {
                    StreamReader ler = new StreamReader(pathImp + file7);

                    while (ler.EndOfStream == false)
                    {
                        autor = ler.ReadLine();
                        titulo = ler.ReadLine();
                        genero = ler.ReadLine();
                        nPaginasStr = ler.ReadLine();
                        dataStr = ler.ReadLine();
                        id = ler.ReadLine();
                        precoStr = ler.ReadLine();

                        y += 20;
                        e.Graphics.DrawString("Autor: " + autor, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 20;
                        e.Graphics.DrawString("Titulo: " + titulo, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 20;
                        e.Graphics.DrawString("Genero: " + genero, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 20;
                        e.Graphics.DrawString("Nº Paginas: " + nPaginasStr, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 20;
                        e.Graphics.DrawString("Data: " + dataStr, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 20;
                        e.Graphics.DrawString("ID: " + id, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 20;
                        e.Graphics.DrawString("Preço: " + precoStr, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 25;
                        e.Graphics.DrawString("__________________________________________________________________", new Font("Arial", 12), Brushes.Black, 80, y);
                        y += 20;

                        if (y >= 1000)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                    }
                    ler.Close();

                    StreamWriter escrever = new StreamWriter(pathImp + file7, false, Encoding.UTF8);

                    escrever.WriteLine();
                    escrever.Close();

                    lstBoxResult1.Items.Clear();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO");
                }
            }
            else if (cmbEscolha.Text == "Revista")
            {
                string titulo, id, editora, nPaginasStr, dataStr, precoStr;

                try
                {
                    StreamReader ler = new StreamReader(pathImp + file8);
                    
                    while (ler.EndOfStream == false)
                    {
                        editora = ler.ReadLine();
                        titulo = ler.ReadLine();
                        nPaginasStr = ler.ReadLine();
                        dataStr = ler.ReadLine();
                        id = ler.ReadLine();
                        precoStr = ler.ReadLine();

                        y += 20;
                        e.Graphics.DrawString("Autor: " + editora, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 20;
                        e.Graphics.DrawString("Titulo: " + titulo, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 20;
                        e.Graphics.DrawString("Nº Paginas: " + nPaginasStr, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 20;
                        e.Graphics.DrawString("Data: " + dataStr, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 20;
                        e.Graphics.DrawString("ID: " + id, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 20;
                        e.Graphics.DrawString("Preço: " + precoStr, new Font("Arial", 12), Brushes.Black, 100, y);
                        y += 25;
                        e.Graphics.DrawString("__________________________________________________________________", new Font("Arial", 12), Brushes.Black, 80, y);
                        y += 20;

                        if (y >= 1000)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                    }
                    ler.Close();

                    StreamWriter escrever = new StreamWriter(pathImp + file8, false, Encoding.UTF8);

                    escrever.WriteLine();
                    escrever.Close();

                    lstBoxResult2.Items.Clear();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO");
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void btnPreVisual_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void btnGuardarResult_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
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

        private void cmbEscolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnVer.Enabled = true;
            cmbPesquisar.Enabled = true;
            limpar();
            adicionarSort();
            adicionarColmn();
            adicionarPesquisar();
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
            Biblioteca bib = new Biblioteca();
            bib.ShowDialog();
        }
    }
}
