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

            numbers = new List<int>();
            for (int i = 0; i <= 300; i++)
            {
                numbers.Add(i);
            }
            comboNum.ItemsSource = numbers;

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
                if (checaNum(comboNum.Text, true) == false || checaNum(boxPreco.Text, false) == false || checaPalavra(boxNome.Text) == false || checaPalavra(boxFabr.Text) == false)
                    MessageBox.Show("Por favor preencha os campos corretamente!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    novo = new Produto(boxNome.Text, int.Parse(comboNum.Text), boxPreco.Text, boxFabr.Text);
                    DAO.edita_produto(antigo, novo);

                    MessageBox.Show("Edição realizada com sucesso.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    DAO.exibeProdutos(pM);
                }
            }
            else
            {

                //if (!int.TryParse(comboNum.Text, out int number) )
                if(checaNum(comboNum.Text, true) == false || checaNum(boxPreco.Text, false) == false || checaPalavra(boxNome.Text) == false || checaPalavra(boxFabr.Text) == false)
                    MessageBox.Show("Por favor preencha os campos corretamente!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    DAO.cadastrar_produto(new Produto(boxNome.Text, int.Parse(comboNum.Text), boxPreco.Text, boxFabr.Text));
                    MessageBox.Show("Cadastro realizado com sucesso.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    DAO.exibeProdutos(pM);
                }
            }
        }
        private bool checaNum(string sVal, bool quant)
        {
            int value, countN = 0, countV = 0;
            bool after = false;
            foreach (char c in sVal)
            {
                if (quant != true)
                {
                    value = Convert.ToInt32(c);
                    if ((value > 57) || (value < 48))
                        if (value != 44)
                            return false;
                    if (after == true)
                        countN++;
                    if (value == 44)
                    {
                        after = true;
                        countV++;
                    }
                    if ((countV > 1) || (countN > 2))
                        return false;
                }
                else
                {
                    value = Convert.ToInt32(c);
                    Console.WriteLine(value);
                    if ((value > 57) || (value < 48))
                        return false;
                }
            }
            return true;
        }

        private bool checaPalavra(string checa)
        {
            int value;
            foreach (char c in checa)
            {
                value = Convert.ToInt32(c);
                if ((value < 65) || (value > 90))
                    if ((value < 97) || (value > 122))
                        if ((value > 57) || (value < 48))
                            return false;               
                
            }
            return true;
        }


    }
}
