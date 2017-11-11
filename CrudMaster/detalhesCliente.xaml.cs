using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrudMaster
{
    /// <summary>
    /// Lógica interna para detalheCliente.xaml
    /// </summary>
    public partial class detalhesCliente : Window
    {
        public List<Servico> servicos { get; set; }
        private clienteMain w;
        private Pessoa pessoa;
        private bool flag = false;
        private int index { get; set; } = -1;
        public detalhesCliente(clienteMain w)
        {
            this.w = w;
            servicos = new List<Servico>();
            InitializeComponent();
            this.servicos.Clear();
            flag = true;
        }

        public detalhesCliente(clienteMain w, Pessoa p, int index)
        {
            this.w = w;
            servicos = new List<Servico>();
            InitializeComponent();
            this.servicos.Clear();

            nomeBox.Text = p.nome;
            CPFBox.Text = p.cpf;
            enderecoBox.Text = p.endereço;
            telefoneBox.Text = p.telefone;
            emailBox.Text = p.email;
            servicos = p.servicos;
            this.index = index;

            listarServicos(p, "");
            pessoa = p;
        }

        public void listarServicos(Pessoa p, string f)
        {
            
            servicosView.SelectionMode = SelectionMode.Single;

            if (flag == false)
            {
                servicosView.Items.Clear();
                var clienteFile = new System.IO.StreamReader(DAO.path + @"\Clientes.txt");
                List<Servico> servicosRead = new List<Servico>();
                while ((clienteFile.BaseStream.Length != 0) && !clienteFile.EndOfStream)
                {
                    //Nome:Endereço:Telefone:CPF:Email%Descricao1:10/11/2017#Descricao2:10/11/2017
                    var line = clienteFile.ReadLine();

                    if (line.Length > 3)
                    {
                        var splitPessoaServico = line.Split('%');
                        var pessoaSubs = splitPessoaServico[0].Split(':');
                        if ((splitPessoaServico.Length == 2) && String.Equals(p.nome, pessoaSubs[0]))
                        {
                            var servicosSubs = splitPessoaServico[1].Split('#');
                            foreach (string s in servicosSubs)
                            {
                                var newservico = new Servico(s);
                                servicosRead.Add(newservico);
                            }
                        }
                    }
                }
                servicos = servicosRead;
                clienteFile.Close();


                foreach (Servico e in servicos)
                {
                    var row = new { Descricao = e.descricao, Data = e.previsao.ToShortDateString() };
                    servicosView.Items.Add(row);
                }
                flag = true;
            }
            else
            {
                Servico newServ = new Servico(f);
                var row = new { Descricao = newServ.descricao, Data = newServ.previsao.ToShortDateString() };
                servicosView.Items.Add(row);
            }
        }

        public void addServicoToCliente(string s)
        {
            //Por algum motivo obscuro, o C# não me permite mandar o servico direto.
            //Então converto ele pra string...e de volta.
            Servico serv = new Servico(s);
            servicos.Add(serv);
        }

        private void adicionaServico_Click(object sender, RoutedEventArgs e)
        {
            detalheServico detalhe = new CrudMaster.detalheServico(this, pessoa);
            detalhe.Show();
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            detalheCliente.Close();
        }

        private void salvarButton_Click(object sender, RoutedEventArgs e)
        {
            if (index != -1)
            {
                if (checaPalavra(nomeBox.Text, false) == false || checaNum(telefoneBox.Text) == false || checaPalavra(emailBox.Text, true) == false || checaNum(CPFBox.Text) == false || checaPalavra(enderecoBox.Text, true) == false)
                    MessageBox.Show("Por favor prencha todos os campos corretamente.\nNão use caracteres especiais como: '#', '%' e ':'.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    DAO.replacePessoa(new Pessoa(nomeBox.Text, telefoneBox.Text, CPFBox.Text, enderecoBox.Text, emailBox.Text, servicos), index);
                    MessageBox.Show("Cadastro alterado com sucesso.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                    detalheCliente.servicos.Clear();
                    detalheCliente.Close();
                    w.listarClientes();
                }                
            }
            else {
                if(checaPalavra(nomeBox.Text, false) == false || checaNum(telefoneBox.Text) == false || checaPalavra(emailBox.Text, true) == false || checaNum(CPFBox.Text) == false || checaPalavra(enderecoBox.Text, true) == false)
                    MessageBox.Show("Por favor prencha todos os campos corretamente.\nNão use caracteres especiais como: '#', '%' e ':'.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    DAO.addCliente(new Pessoa(nomeBox.Text, telefoneBox.Text, CPFBox.Text, enderecoBox.Text, emailBox.Text, servicos));
                    MessageBox.Show("Cadastro realizado com sucesso.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                    detalheCliente.servicos.Clear();
                    detalheCliente.Close();
                    w.listarClientes();
                }                
            }
        }

        private bool checaNum(string sVal)
        {
            int value;

            foreach (char c in sVal)
            {
                value = Convert.ToInt32(c);
                Console.WriteLine(value);
                if ((value > 57) || (value < 48))
                    return false;                
            }
            return true;
        }

        private bool checaPalavra(string checa, bool aux)
        {
            int value;
            foreach (char c in checa)
            {
                if(aux == false)
                {
                    value = Convert.ToInt32(c);
                    if ((value < 65) || (value > 90))
                        if ((value < 97) || (value > 122))
                            return false;
                }
                else
                {
                    value = Convert.ToInt32(c);
                    if(value == 35 || value == 37 || value == 58)
                        return false;
                }
            }
            return true;
        }
    }
}
