using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Problem 1
namespace Lab1
{
    public class BankCharges
    {
        // Instance variables 
        private double accBalance;      // current account balance
        private int nbOfChecks;         // number of checks written
        private double totalFees;       // total bank service fees
        private double monthlyFee = 10; // fixed monthly base fee

        // Default constructor
        public BankCharges() { }

        // Constructor with parameters
        public BankCharges(double accBalance, int nbOfChecks)
        {
            this.accBalance = accBalance;
            this.nbOfChecks = nbOfChecks;
        }

        // Getters and setters
        public double AccBalance { get => accBalance; set => accBalance = value; }
        public int NbOfChecks { get => nbOfChecks; set => nbOfChecks = value; }

        // Method to calculate the bank service fees
        public double CalcServiceFees()
        {
            double checkFee = 0; // initialize the checkFee to zero

            if (nbOfChecks < 20)
            {
                checkFee = 0.1;
            }
            else if (nbOfChecks >= 20 && nbOfChecks < 40)
            {
                checkFee = 0.08;
            }
            else if (nbOfChecks >= 40 && nbOfChecks < 60)
            {
                checkFee = 0.06;
            }
            else
                checkFee = 0.1;

            totalFees = monthlyFee + (nbOfChecks * checkFee);

            if (accBalance < 400)
            {
                totalFees += 15;
            }
            return totalFees;
        } 
    }
}
