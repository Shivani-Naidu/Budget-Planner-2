using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10084788_PROG6221_POE_PART_2
{
    class Vehicle : Expense
    {
        //variables needed to calculate the vehicle monthly repayment amount
        private string modelAndMake;
        private double purchasePrice;
        private double totalDeposit;
        private double interestRate;
        private double insurancePremium;
        private double vehicleMonthlyAmount;



        public string ModelAndMake { get => modelAndMake; set => modelAndMake = value; }
        public double PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
        public double TotalDeposit { get => totalDeposit; set => totalDeposit = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }
        public double InsurancePremium { get => insurancePremium; set => insurancePremium = value; }
        public double VehicleMonthlyAmount { get => vehicleMonthlyAmount; set => vehicleMonthlyAmount = value; }

        public override void CalculateMonthly()
        {
            double principleAmount;
            double total;
            double years;
            double interest;
            double totalCost;
            
            // calculate monthly car amount 
            principleAmount = PurchasePrice - TotalDeposit; // calculates purchase price after deposit
            years = 5; // calculates months
            interest = InterestRate / 100; // sorts out interest rate

            total = principleAmount * (1 + (interest * years)); // the total amount that the user needs to pay
            totalCost = total / 60;
            VehicleMonthlyAmount = Math.Round((totalCost), 2); // calculates monthly home loan repayment


        }
    }
}
