using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10084788_PROG6221_POE_PART_2
{
    class Rental : Expense
    {
        // Rental class extends Expense class

        private double rentalAmount;

        public double RentalAmount { get => rentalAmount; set => rentalAmount = value; }

        public override void CalculateMonthly()
        {
            RentalAmount = Math.Round(RentalAmount);

        }

        public double CalculateAvailableAmount(int carOption, double carAmount, double salary, double expenses, double taxAmount, double accommodation)
        {   // calculates available amount after expense deductions

            if (carOption == 1)
            {
                availAmount = Math.Round((salary - (taxAmount + expenses + accommodation + carAmount )), 2);
            }
            else
            {
                availAmount = Math.Round((salary - (taxAmount + expenses + accommodation)), 2);
            }

            return availAmount;
        }


        public void BudgetReport(int carOption, string CarName, double carAmount, double insurance, double salary, double taxAmount, string sort, double accommodation, double availAmount)
        {
            PopulateArrays parr = new PopulateArrays();
            // displays a summary of the the user's expenses, salary, tax amount, rental amount

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("========================================================================");
            Console.WriteLine("Budget Report Summary");
            Console.WriteLine("========================================================================");
            Console.BackgroundColor = ConsoleColor.Black;

            if (carOption == 1)
            {
                Console.WriteLine("Salary: R" + salary);
                Console.WriteLine("Tax Amount: R" + taxAmount);
                Console.WriteLine("Salary After Tax Deductions: R" + (salary - taxAmount));
                Console.WriteLine();
                Console.WriteLine("Your Monthly Expenses Are As Follows In Descending Order: ");
                Console.WriteLine(sort);
                Console.WriteLine();
                Console.WriteLine("Your Monthly Vehicle Repayment on " + CarName + " is: R" + carAmount);
                Console.WriteLine("Your Monthly Vehicle Repayment With Insurance Premium: R" + (carAmount + insurance));
                Console.WriteLine("Your Monthly Rental Amount: R" + accommodation);
                Console.WriteLine("Your Monthly Available Amount After All Expense Deductions: R" + availAmount);
            }

            else
            {
                Console.WriteLine("Salary: R" + salary);
                Console.WriteLine("Tax Amount: R" + taxAmount);
                Console.WriteLine("Salary After Tax Deductions: R" + (salary - taxAmount));
                Console.WriteLine();
                Console.WriteLine("Your Monthly Expenses Are As Follows In Descending Order: ");
                Console.WriteLine(sort);
                Console.WriteLine();
                Console.WriteLine("Your Monthly Rental Amount: R" + accommodation);
                Console.WriteLine("Your Monthly Available Amount After All Expense Deductions: R" + availAmount);
            }
        }
    }
}





