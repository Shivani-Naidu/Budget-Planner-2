using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10084788_PROG6221_POE_PART_2
{
    public class PopulateArrays
    {

        // the PopulateArrays class holds the arrays needed for the program

        public ArrayList arrExpenseName = new ArrayList(); //Holds the expense name
        public ArrayList arrExpenseCost = new ArrayList(); // Holds the expense amount

        // Arrays that will be used to hold the converted arraylists
        public double[] costs;
        public string[] names;

        public double sumArr() // calculates the sum of all the expenses in the arraylist
        {
            double sum = arrExpenseCost.Cast<double>().Sum();
            // we have to use the cast function since the ArrayList called arrExpenseCost has been specified with a data type
            // the cast function will then let the program now that is a double data type
            return Math.Round(sum, 2); // returns the sum of ArrayList when method is called
        }

        public string sortArray()
        {

            // To sort the arraylists in order of descending order with the expense name, we will convert the 
            // arraylists to arrays, we will then sort them as parallel arrays and then print them in the reverse order
            string sort = ""; // we will then store the sorted arrays as a string output for display
            double[] costs = arrExpenseCost.ToArray(typeof(double)) as double[];
            string[] names = arrExpenseName.ToArray(typeof(string)) as string[];

            Array.Sort(costs, names);
            for (int i = names.Length - 1; i >= 0; i--)
            {
                sort += names[i] + ": R" + costs[i] + "\n";
            }

            return sort;

        }

    }
}





