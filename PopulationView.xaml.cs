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
            tbStart.Clear();
            tbDailyIncrease.Clear();
            tbNumDays.Clear();

            tBlockDailyPopulation.Text = "";
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
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

            population.StartingSize = startPopulation;
            population.NumberOfDays = numberOfDays;
            population.DailyIncreasePercent = dailyIncreasePercent;

            List<int> dailyPopulations = population.calcDailyPopulation();

            tBlockDailyPopulation.Text = string.Join(", ", dailyPopulations);
        }
    }
}
