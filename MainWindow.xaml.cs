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
using System.Windows.Navigation;
using System.Windows.Shapes;

// Problem 4
namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // When the Bank Charges button is clicked
        private void btnBank_Click(object sender, RoutedEventArgs e)
        {
            BankView bank = new BankView();
            bank.Show();
        }

        // When the Fast Freight Shipping button is clicked
        private void btnShipping_Click(object sender, RoutedEventArgs e)
        {
            ShippingView shipping = new ShippingView();
            shipping.Show();
        }

        // When the Population of Organisms button is clicked
        private void btnPopulation_Click(object sender, RoutedEventArgs e)
        {
            PopulationView population = new PopulationView();
            population.Show();
        }
    }
}
