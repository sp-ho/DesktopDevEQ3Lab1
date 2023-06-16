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

namespace Lab1
{
    /// <summary>
    /// Interaction logic for ShippingView.xaml
    /// </summary>
    public partial class ShippingView : Window
    {
        private ShippingCharges shippingCharges;

        public ShippingView()
        {
            InitializeComponent();
            shippingCharges = new ShippingCharges();
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbWeight.Clear();
            tbDistance.Clear();

            lblTotalFeesResult.Content = "";
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            // Get values from text boxes for BankCharges instance variables
            double weight = Convert.ToDouble(tbWeight.Text);
            double distance = Convert.ToDouble(tbDistance.Text);

            // Set values for ShippingCharges instance
            shippingCharges.Weight = weight;
            shippingCharges.Distance = distance;

            // Calculate the total fees
            double totalShippingCharges = shippingCharges.CalcShippingCharge(weight, distance);

            // Display the calculation result at the label
            lblTotalFeesResult.Content = "Total charge for shipping: " + totalShippingCharges.ToString("0.00") + "$";
        }
    }
}
