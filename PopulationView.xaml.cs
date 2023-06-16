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
    /// Interaction logic for PopulationView.xaml
    /// </summary>
    public partial class PopulationView : Window
    {
        private Population population;

        public PopulationView()
        {
            InitializeComponent();
            population = new Population();
        }

        // When Home button is clicked, return to Main Window
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
            tbStart.Clear();
            tbDailyIncrease.Clear();
            tbNumDays.Clear();

            tBlockDailyPopulation.Text = "";
        }

        // When the Calculate button is clicked, call the calcDailyPopulation method
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            // Get values from text boxes for Population instance variables
            int startPopulation = Convert.ToInt32(tbStart.Text);
            double dailyIncreasePercent = Convert.ToDouble(tbDailyIncrease.Text);
            int numberOfDays = Convert.ToInt32(tbNumDays.Text);

            // Validate and parse the starting size
            if (!int.TryParse(tbStart.Text, out startPopulation) || startPopulation < 2)
            {
                MessageBox.Show("Invalid starting size. Please enter a number greater than or equal to 2.", "Invalid Input");
                return;
            }

            // Validate and parse the daily increase percent
            if (!double.TryParse(tbDailyIncrease.Text, out dailyIncreasePercent) || dailyIncreasePercent < 0)
            {
                MessageBox.Show("Invalid daily increase percent. Please enter a positive number.", "Invalid Input");
                return;
            }

            // Validate and parse the number of days
            if (!int.TryParse(tbNumDays.Text, out numberOfDays) || numberOfDays < 1)
            {
                MessageBox.Show("Invalid number of days. Please enter a number greater than or equal to 1.", "Invalid Input");
                return;
            }

            // Set values for Population instance
            population.StartingSize = startPopulation;
            population.NumberOfDays = numberOfDays;
            population.DailyIncreasePercent = dailyIncreasePercent;

            // Create a list of integer data type to store the results of calculation
            List<int> dailyPopulations = population.calcDailyPopulation();

            // Display the population of each day in the text block
            tBlockDailyPopulation.Text = "Population of each day: \n" + string.Join(", ", dailyPopulations);
        }

        // Clear the starting size of population text box when it is clicked
        private void tbStart_GotFocus(object sender, RoutedEventArgs e)
        {
            tbStart.Text = string.Empty;
        }

        // Clear the daily increase percent text box when it is clicked
        private void tbDailyIncrease_GotFocus(object sender, RoutedEventArgs e)
        {
            tbDailyIncrease.Text = string.Empty;
        }

        // Clear the number of days text box when it is clicked
        private void tbNumDays_GotFocus(object sender, RoutedEventArgs e)
        {
            tbNumDays.Text = string.Empty;
        }
    }
}
