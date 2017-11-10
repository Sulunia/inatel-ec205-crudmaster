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

        public static void addPessoa(Pessoa p)
        {
            pessoaLista.Add(p);
            Debug.WriteLine("[DAO] Added new Pessoa to list.");
        }

        public static void initialize()
        {
            var path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
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
        }

    }
}
