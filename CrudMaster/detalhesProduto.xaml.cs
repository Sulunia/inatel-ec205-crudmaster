using System;
using System.Collections.Generic;
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
    /// Lógica interna para detalhesProduto.xaml
    /// </summary>
    public partial class detalhesProduto : Window
    {
        private List<int> numbers;
        private Produto antigo;
        private Produto novo;
        private produtoMain pM;
        private bool edit;


        public detalhesProduto(produtoMain pM)
        {
            InitializeComponent();
            this.pM = pM;

            //Adiciona números a lista de combo box
            numbers = new List<int>();
            for (int i = 0; i <= 300; i++)
            {
                numbers.Add(i);
            }
            comboNum.ItemsSource = numbers;
        }

        public detalhesProduto(produtoMain pM, Produto prod, bool edit)
        {
            InitializeComponent();
            this.antigo = prod;
            this.pM = pM;
            this.edit = edit;
            boxNome.Text = prod.nome;
            comboNum.Text = prod.quantidade.ToString();
            boxPreco.Text = prod.preco;
            boxFabr.Text = prod.fabricante;

        }

        private void buttonCancela_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonSalvar_Click(object sender, RoutedEventArgs e)
        {
            if(edit == true)
            {
                novo = new Produto(boxNome.Text, int.Parse(comboNum.Text), boxPreco.Text, boxFabr.Text);
                DAO.editaProduto(antigo, novo);

                MessageBox.Show("Edição realizada com sucesso.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);                
                this.Close();
                DAO.exibeProdutos(pM);

            }
            else
            {
                DAO.addProduto(new Produto(boxNome.Text, int.Parse(comboNum.Text), boxPreco.Text, boxFabr.Text));
                MessageBox.Show("Cadastro realizado com sucesso.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                DAO.exibeProdutos(pM);
            }
        }
    }
}
