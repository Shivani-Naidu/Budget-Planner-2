using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10084788_PROG6221_POE_PART_2
{

    class HomeLoan : Expense
    {
        // declaration of variables needed in the HomeLoan class
        private double purchasePrice; // purchase price of property
        private double totalDeposit; // total deposit user has paid
        private double interestRate; // interest rate of monthly home loan repayment (percentage)
        private int repayMonths; // number of months to repay home loan
        private double homeLoanAmount; // calculates the monthly home loan repayment amount
        private double salaryAmount; // stores user's salary


        // get and sets for private variables decalred in HomeLoan class
        public double PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
        public double TotalDeposit { get => totalDeposit; set => totalDeposit = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }
        public int RepayMonths { get => repayMonths; set => repayMonths = value; }
        public double SalaryAmount { get => salaryAmount; set => salaryAmount = value; }
        public double HomeLoanAmount { get => homeLoanAmount; set => homeLoanAmount = value; }

        public override void CalculateMonthly()
        {
            //Formula to calculate monthly home loan repayment amount --> A = P (1 * (in))

            //variables used to in formula
            double principleAmount;
            double total;
            double years;
            double interest;

            principleAmount = PurchasePrice - TotalDeposit; // calculates purchase price after deposit
            years = RepayMonths / 12; // calculates months
            interest = InterestRate / 100; // sorts out interest rate

            total = principleAmount * (1 + (interest * years)); // the total amount that the user needs to pay
            HomeLoanAmount = Math.Round((total / repayMonths), 2); // calculates monthly home loan repayment
            Console.WriteLine("Your Monthly Home Loan Repayment Is: R" + HomeLoanAmount); // displays amount to user
            if (HomeLoanAmount > (salaryAmount / 3))
            {
                // displays warning if the monthly home loan repayment amount if greater than a third of the user's salary
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Approval Of The Home Loan Is Unlikely. \n" +
                                  "The Monthly Home Loan Repayment Is More Than A Third Of Your Monthly Salary.");
                Console.BackgroundColor = ConsoleColor.Black;
            }

            else
            {
                // also notifies user if their home is likely to be approved
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Your Home Loan Is Likely To Be Approved. ");
                Console.BackgroundColor = ConsoleColor.Black;

            }
        }

        public double CalculateAvailableAmount(int carOption, double carAmount, double salary, double expenses, double taxAmount, double accommodation)
        {
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

        public void BudgetReport(int carOption, string CarName, double carAmount, double insurance, double salary, double taxAmount, string output, double accommodation, double availAmount)
        {
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
                Console.WriteLine(output);
                Console.WriteLine();
                Console.WriteLine("Your Monthly Vehicle Repayment on " + CarName + " is: R" + carAmount);
                Console.WriteLine("Your Monthly Vehicle Repayment With Insurance Premium: R" + (carAmount + insurance));
                Console.WriteLine("Your Monthly Home Loan Repayment: R" + accommodation);

                Console.WriteLine("Your Monthly Available Amount After All Expense Deductions: R" + availAmount);
            }

            else
            {
                Console.WriteLine("Salary: R" + salary);
                Console.WriteLine("Tax Amount: R" + taxAmount);
                Console.WriteLine("Salary After Tax Deductions: R" + (salary - taxAmount));
                Console.WriteLine();
                Console.WriteLine("Your Monthly Expenses Are As Follows In Descending Order: ");
                Console.WriteLine(output);
                Console.WriteLine();
                Console.WriteLine("Your Monthly Home Loan Repayment: R" + accommodation);
                Console.WriteLine("Your Monthly Available Amount After All Expense Deductions: R" + availAmount);
            }
        }
    }
}



