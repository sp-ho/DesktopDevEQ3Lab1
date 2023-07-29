using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class ShippingCharges
    {
        // Instance variables
        private double weight;
        private double distance;

        // Default constructor
        public ShippingCharges() {}

        // Constructor with parameters
        public ShippingCharges(double weight, double distance)
        {
            this.Weight = weight;
            this.Distance = distance;
        }

        // Getters and setters
        public double Weight { get => weight; set => weight = value; }
        public double Distance { get => distance; set => distance = value; }

        // Method to calculate the shipping charge
        public double CalcShippingCharge(double weight, double distance)
        {
            double shippingRate = 0;

            if (weight <= 2)
            {
                shippingRate = 1.1;
            }
            else if (weight > 2 && weight <= 6)
            {
                shippingRate = 2.2;
            }
            else if (weight > 6 && weight <= 10)
            {
                shippingRate = 3.7;
            }
            else
                shippingRate = 4.8;

            double totalShippingCharge = Math.Ceiling(distance / 500) * shippingRate;

            return totalShippingCharge;
        }
    }
}
