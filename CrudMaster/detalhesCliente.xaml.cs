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
        private List<Servico> servicos = new List<Servico>();
        private clienteMain w;
        private int index { get; set; } = -1;
        public detalhesCliente(clienteMain w)
        {
            this.w = w;
            InitializeComponent();
            this.servicos.Clear();
        }

        public detalhesCliente(clienteMain w, Pessoa p, int index)
        {
            this.w = w;
            InitializeComponent();
            this.servicos.Clear();

            nomeBox.Text = p.nome;
            CPFBox.Text = p.cpf;
            enderecoBox.Text = p.endereço;
            telefoneBox.Text = p.telefone;
            emailBox.Text = p.email;
            servicos = p.servicos;
            this.index = index;
        }

        public void addServicoToCliente(string S)
        {
            //Por algum motivo obscuro, o C# não me permite mandar o servico direto.
            //Então converto ele pra string...e de volta.
            Debug.WriteLine(S);
            Servico serv = new Servico(S);
            servicos.Add(serv);
        }

        private void adicionaServico_Click(object sender, RoutedEventArgs e)
        {
            detalheServico detalhe = new CrudMaster.detalheServico(this);
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
                DAO.replacePessoa(new Pessoa(nomeBox.Text, telefoneBox.Text, CPFBox.Text, enderecoBox.Text, emailBox.Text, servicos), index);
                MessageBox.Show("Cadastro alterado com sucesso.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                detalheCliente.servicos.Clear();
                detalheCliente.Close();
                w.listarClientes();
            }
            else {
                DAO.addCliente(new Pessoa(nomeBox.Text, telefoneBox.Text, CPFBox.Text, enderecoBox.Text, emailBox.Text, servicos));
                MessageBox.Show("Cadastro realizado com sucesso.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                detalheCliente.servicos.Clear();
                detalheCliente.Close();
                w.listarClientes();
            }
        }
    }
}
