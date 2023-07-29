using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Lab1
{
    public class Population
    {
        // Instance variables
        private int startingSize;
        private double dailyIncreasePercent;
        private int numberOfDays;

        // Default constructor
        public Population() { }

        // Constructor with parameters
        public Population(int startingSize, double dailyIncreasePercent, int numberOfDays)
        {
            this.startingSize = startingSize;
            this.dailyIncreasePercent = dailyIncreasePercent;
            this.numberOfDays = numberOfDays;
        }

        // Getters and setters
        public int StartingSize { get => startingSize; set => startingSize = value; }
        public double DailyIncreasePercent { get => dailyIncreasePercent; set => dailyIncreasePercent = value; }
        public int NumberOfDays { get => numberOfDays; set => numberOfDays = value; }

        // Method to calculate the daily population
        public List<int> calcDailyPopulation()
        {
            List<int> dailyPopulation = new List<int>();
            double currentSize = startingSize;

            for (int i = 1; i <= numberOfDays; i++)
            {
                currentSize *= (1 + dailyIncreasePercent / 100);
                dailyPopulation.Add((int)currentSize); // display daily population in text block 
            }
        
            return dailyPopulation;
       }

    }
}
