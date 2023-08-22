using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10084788_PROG6221_POE_PART_2
{
    abstract class Expense
    {
        // expense is an abstract class
        public double availAmount; // variable to hold available amount after expense deductions

        public abstract void CalculateMonthly();



    }
}
