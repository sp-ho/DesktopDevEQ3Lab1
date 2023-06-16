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

// Problem 1
namespace Lab1
{
    /// <summary>
    /// Interaction logic for BankView.xaml
    /// </summary>
    public partial class BankView : Window
    {
        private BankCharges bankCharges;
        public BankView()
        {
            InitializeComponent();
            bankCharges = new BankCharges();
        }

        private void btnCalcFees_Click(object sender, RoutedEventArgs e)
        {
            // Get values from text boxes for BankCharges instance variables
            double balance = Convert.ToDouble(tbAccBalance.Text);
            int numberChecks = Convert.ToInt32(tbNbChecks.Text);

            // Set values for BankCharges instance
            bankCharges.AccBalance = balance;
            bankCharges.NbOfChecks = numberChecks;

            // Calculate the total fees
            double totalFees = bankCharges.CalcServiceFees();

            // Display the calculation result at the label
            lblTotalFeesResult.Content = "Total fees of this month: " + totalFees.ToString("0.00") + "$";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbAccBalance.Clear();
            tbNbChecks.Clear();

            lblTotalFeesResult.Content = "";
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = Application.Current.MainWindow as MainWindow;

            if (home == null)
            {
                home = new MainWindow();
                Application.Current.MainWindow = home;  
            }

            home.Activate();
            home.Show();
        }
    }
}
