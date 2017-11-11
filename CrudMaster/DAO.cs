using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrudMaster
{
    class DAO
    {
        public static List<Pessoa> pessoaLista = new List<Pessoa>();
        public static List<Produto> produtoLista = new List<Produto>();
        public static List<Funcionario> funcionarioLista = new List<Funcionario>();

        public static StreamReader clienteFile;
        public static StreamReader produtoFile;
        
        public static string path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();

        public static void addCliente(Pessoa p)
        {
            pessoaLista.Add(p);
            Debug.WriteLine("[DAO] Added new Pessoa to list.");
            Debug.WriteLine("[DAO] Info: " + p.ToString());
            File.AppendAllText((path + @"\Clientes.txt"), p.ToString()+ '\r' + '\n');
            Debug.WriteLine("[DAO] Appended new Pessoa to persistent file.");
        }

        public static void addProduto(Produto prod)
        {
            produtoLista.Add(prod);
            File.AppendAllText((path + @"\Produtos.txt"), prod.aux() + Environment.NewLine);
        }

        public static void exibeProdutos(produtoMain pM)
        {
            pM.listaProduto.Items.Clear();
            produtoFile = new StreamReader((path + @"\Produtos.txt"));
            string line;       
            while ((line = produtoFile.ReadLine()) != null)
            {
                string[] parts = line.Split('/');
                var row = new { Nome = parts[0], Quantidade = parts[1], Preço = parts[2], Fabricante = parts[3] };
                pM.listaProduto.Items.Add(row);
            }
            produtoFile.Close();
        }

        public static void editaProduto(Produto antigo, Produto novo)
        {
            string text = File.ReadAllText(path + @"\Produtos.txt");
            text = text.Replace(antigo.nome + "/" + antigo.quantidade + "/" + antigo.preco + "/" + antigo.fabricante, novo.nome + "/" + novo.quantidade + "/" + novo.preco + "/" + novo.fabricante);
            File.WriteAllText((path + @"\Produtos.txt"), text);
        }

        public static void excluiProduto(Produto p)
        {
            string[] lines = System.IO.File.ReadAllLines(path + @"\Produtos.txt");

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path + @"\Produtos.txt"))
            {
                foreach (string line in lines)
                {
                    if (!line.Contains(p.nome + "/" + p.quantidade + "/" + p.preco + "/" + p.fabricante))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        public static void initialize()
        {
            string line;

            Debug.WriteLine("[DAO] Preparing to read file: " + path + @"\Clientes.txt!");
            if (File.Exists(path+ @"\Clientes.txt") == false)
            {
                try
                {
                    //Cria o arquivo no primeiro run
                    Debug.WriteLine("[DAO] Generating new txt file...");
                    File.WriteAllText(path + @"\Clientes.txt", "");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not create file handler! Try running as administrator!\n" +
                        "Exception: "+e.ToString());
                    throw;
                }
            }
            else
            {
                Debug.WriteLine("[DAO] File exists, loading from disk...");
            }
            clienteFile = new System.IO.StreamReader(path + @"\Clientes.txt");
            while((clienteFile.BaseStream.Length != 0) && !clienteFile.EndOfStream)
            {
                //Nome:Endereço:Telefone:CPF:Email%Descricao1:10/11/2017#Descricao2:10/11/2017
                List<Servico> servicosRead = new List<Servico>();
                line = clienteFile.ReadLine();
                if (line.Length > 3)
                {
                    var splitPessoaServico = line.Split('%');
                    var pessoaSubs = splitPessoaServico[0].Split(':');
                    if (splitPessoaServico.Length == 2)
                    {
                        var servicosSubs = splitPessoaServico[1].Split('#');
                        foreach (string s in servicosSubs)
                        {
                            var newservico = new Servico(s);
                            servicosRead.Add(newservico);
                        }
                    }
                    Pessoa p = new Pessoa(pessoaSubs[0], pessoaSubs[2], pessoaSubs[3], pessoaSubs[1], pessoaSubs[4], servicosRead);
                    pessoaLista.Add(p);
                }
            }
            clienteFile.Close();

            Debug.WriteLine("[DAO] Preparing to read file: " + path + @"\Produtos.txt!");
            if (File.Exists(path + @"\Produtos.txt") == false)
            {
                try
                {
                    //Cria o arquivo no primeiro run
                    Debug.WriteLine("[DAO] Generating new txt file...");
                    File.WriteAllText(path + @"\Produtos.txt", "");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not create file handler! Try running as administrator!\n" +
                        "Exception: " + e.ToString());
                    throw;
                }
            }
            else
            {
                Debug.WriteLine("[DAO] File exists, loading from disk...");
            }
            produtoFile = new System.IO.StreamReader(path + @"\Produtos.txt");
            produtoFile.Close();
        }

        public static void replacePessoa(Pessoa p, int index)
        {
            pessoaLista.ElementAt(index).nome = p.nome;
            pessoaLista.ElementAt(index).endereço = p.endereço;
            pessoaLista.ElementAt(index).cpf = p.cpf;
            pessoaLista.ElementAt(index).email = p.email;
            pessoaLista.ElementAt(index).telefone = p.telefone;
            pessoaLista.ElementAt(index).servicos = p.servicos;

            string text = File.ReadAllText(path + @"\Clientes.txt");
            var textSplit = text.Split('\n');
            textSplit[index] = pessoaLista.ElementAt(index).ToString() + '\r';
            text = "";
            foreach (string t in textSplit)
            {
                text = text + t + '\n';
            }
            File.WriteAllText(path + @"\Clientes.txt", text);
        }
    }
}
