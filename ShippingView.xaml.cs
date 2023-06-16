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

        // When the Home button is clicked, return to Main Window
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = Application.Current.MainWindow as MainWindow;

            if (home == null)
            {
                home = new MainWindow();
                Application.Current.MainWindow = home;
            }
            home.Activate(); // activate or return the Main Window
            home.Show();

            Close(); // close current window
        }

        // When the Clear button is clicked, clear the text boxes and result label
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbWeight.Clear();
            tbDistance.Clear();

            lblTotalFeesResult.Content = "";
        }

        // When the Calculate button is clicked, call the CalcShippingCharge method
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            // Get values from text boxes for ShippingCharges instance variables
            double weight = Convert.ToDouble(tbWeight.Text);
            double distance = Convert.ToDouble(tbDistance.Text);

            // Set values for ShippingCharges instance
            shippingCharges.Weight = weight;
            shippingCharges.Distance = distance;

            // Calculate the total shipping charges
            double totalShippingCharges = shippingCharges.CalcShippingCharge(weight, distance);

            // Display the calculation result at the label
            lblTotalFeesResult.Content = "Total charge for shipping: " + totalShippingCharges.ToString("0.00") + "$";
        }

        // Clear the weight text box when it is clicked
        private void tbWeight_GotFocus(object sender, RoutedEventArgs e)
        {
            tbWeight.Text = string.Empty;
        }

        // Clear the distance text box when it is clicked
        private void tbDistance_GotFocus(object sender, RoutedEventArgs e)
        {
            tbDistance.Text = string.Empty;
        }
    }
}
