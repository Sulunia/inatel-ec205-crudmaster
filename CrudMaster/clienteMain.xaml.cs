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
    /// Lógica interna para clienteMain.xaml
    /// </summary>
    public partial class clienteMain : Window
    {
        public clienteMain()
        {
            InitializeComponent();
        }

        private void clienteWin_Closed(object sender, EventArgs e)
        {
            mainMenu menu = new CrudMaster.mainMenu();
            menu.Show();
        }
    }
}
