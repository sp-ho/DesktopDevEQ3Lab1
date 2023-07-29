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

        // When the Bank Charges radio button is checked, disable other radio buttons
        public void rbBank_Checked(object sender, RoutedEventArgs e)
        {
            rbShipping.IsChecked = false;
            rbPopulation.IsChecked = false;
        }

        // When the Fast Freight Shipping radio button is checked, disable other radio buttons
        public void rbShipping_Checked(object sender, RoutedEventArgs e)
        {
            rbBank.IsChecked = false;
            rbPopulation.IsChecked = false;
        }

        // When the Population of Organisms radio button is checked, disable other radio buttons
        public void rbPopulation_Checked(object sender, RoutedEventArgs e)
        {
            rbBank.IsChecked = false;
            rbShipping.IsChecked = false;
        }

        // Go to the window of checked radio button
        public void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)rbBank.IsChecked) // if Bank Charges radio button is checked
            {
                BankView bank = new BankView();
                bank.Show();
            }
            else if ((bool)rbShipping.IsChecked) // if Shipping Charges radio button is checked
            {
                ShippingView shipping = new ShippingView();
                shipping.Show();
            }
            else if ((bool)(rbPopulation.IsChecked)) // if Population of Organisms radio button is checked
            {
                PopulationView population = new PopulationView();
                population.Show();
            }
            else // if no radio button is checked
            {
                MessageBox.Show("Choose a radio button.");
            }
        }
    }
}
