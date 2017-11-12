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
        //Listas de acesso públicas
        public static List<Pessoa> pessoaLista = new List<Pessoa>();
        public static List<Produto> produtoLista = new List<Produto>();
        public static List<Funcionario> funcionarioLista = new List<Funcionario>();

        //Handlers de arquivo para leitura e escrita
        public static StreamReader clienteFile;
        public static StreamReader produtoFile;
        public static StreamReader funcionarioFile;

        //Variáveis miscelâneas
        public static string path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
        public static string userLogado { get; set; } = "";

        //Funções
        public static void cadastrar_cliente(Pessoa p)
        {
            pessoaLista.Add(p);
            Debug.WriteLine("[DAO] Added new Pessoa to list.");
            Debug.WriteLine("[DAO] Info: " + p.ToString());
            File.AppendAllText((path + @"\Clientes.txt"), p.ToString()+ '\r' + '\n');
            Debug.WriteLine("[DAO] Appended new Pessoa to persistent file.");
        }

        public static void cadastrar_produto(Produto prod)
        {
            produtoLista.Add(prod);
            File.AppendAllText((path + @"\Produtos.txt"), prod.ToString() + Environment.NewLine);
        }

        public static void edita_produto(Produto antigo, Produto novo)
        {
            string text = File.ReadAllText(path + @"\Produtos.txt");
            text = text.Replace(antigo.nome + "/" + antigo.quantidade + "/" + antigo.preco + "/" + antigo.fabricante, novo.nome + "/" + novo.quantidade + "/" + novo.preco + "/" + novo.fabricante);
            File.WriteAllText((path + @"\Produtos.txt"), text);
        }

        public static void excluir_produto(Produto p)
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

        public static void inicializar_dados()
        {
            string line;
            pessoaLista.Clear();
            funcionarioLista.Clear();
            produtoLista.Clear();

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

            //Funcionario
            Debug.WriteLine("[DAO] Preparing to read file: " + path + @"\Funcionarios.txt!");
            if (File.Exists(path + @"\Funcionarios.txt") == false)
            {
                try
                {
                    //Cria o arquivo no primeiro run
                    Debug.WriteLine("[DAO] Generating new txt file...");
                    File.WriteAllText(path + @"\Funcionarios.txt", "");
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
            funcionarioFile = new System.IO.StreamReader(path + @"\Funcionarios.txt");
            while ((funcionarioFile.BaseStream.Length != 0) && !funcionarioFile.EndOfStream)
            {
                //nome:senha:username
                List<Servico> servicosRead = new List<Servico>();
                line = funcionarioFile.ReadLine();
                if (line.Length > 3)
                {
                    var split = line.Split(':');
                    var s = new Funcionario(split[0], split[1], split[2]);
                    funcionarioLista.Add(s);
                }
            }
            funcionarioFile.Close();
        }

        public static void edita_cliente(Pessoa p, int index)
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

        public static void cadastrar_funcionario(Funcionario p)
        {
            funcionarioLista.Add(p);
            File.AppendAllText((path + @"\Funcionarios.txt"), p.ToString() + '\r' + '\n');
            Debug.WriteLine("[DAO] Wrote '" + p.ToString() + "' to the file.");
        }

        public static void excluir_funcionario(Funcionario removido)
        {
            //Remove funcionario da lista de funcionarios
            foreach (Funcionario item in funcionarioLista)
            {
                if (String.Equals(removido.nome, item.nome))
                {
                    funcionarioLista.Remove(item);
                    break;
                }
            }

            //Grava a lista inteira no arquivo denovo
            string result = "";
            foreach (Funcionario item in funcionarioLista)
            {
                result = result + item.ToString() + '\r' + '\n';
            }
            File.WriteAllText((path + @"\Funcionarios.txt"), result);
        }
    }
}
