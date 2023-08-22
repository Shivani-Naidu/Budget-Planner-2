using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace ST10084788_PROG6221_POE_PART_2
{
    public class Program
    {
        // Create global objects of the classes that we will need to access later on in the program
        PopulateArrays populateArrays = new PopulateArrays(); // Object of the PopulateArrays class
        HomeLoan hml = new HomeLoan(); // Object of the HomeLoan class
        Rental rental = new Rental();   // Object of the Rental class
        Vehicle vehicle = new Vehicle(); // Object of the Vehicle class   


        // Global declaration of the variables that we will get the values for from the user
        public double salary;
        public double taxAmount;
        public double groceriesAmount;
        public double waterAndLights;
        public double travelCosts;
        public double phoneBills;

        public int VehicleOption; // Holds an integer value that determines if the user chooses to buy a car or not

        public delegate void DelNotifyUser(double a, double b, double c); // Delegate that is used to notify the user when
                                                                          // their expenses exceed over 75% of their salary

        public static void Main(string[] args)
        {
            WelcomeAnimation(); // Calls WelcomeAnimation method which displays a simple animation and welcome message
            ShowSpinner(); // Displays a spinner

            Program progObj = new Program(); // Object of the main class
            progObj.DisplayMenu();  // Calls DisplayMenu method

            Console.ReadLine(); // Console.ReadLine() is used at the end of the main program to ensure that the program
                                // stays open
        }

        public void DisplayMenu()
        {
            // The DisplayMenu method displays the menu to the user and accepts the input (a menu item) and then calls the 
            // relevant method

            // Display menu to user
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("========================================================================");
            Console.WriteLine("Main Menu");
            Console.WriteLine("========================================================================");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Please Choose One Of The Following Items: \n" +
                              "1. Run Budget Planner Application. \n" +
                              "2. Exit Application.");

            bool bValidate = true; // boolean variable that controls the while loop, it is set to true so that the loop
                                   // will always run first then validate the value that the user has entered
            string menuItem = Console.ReadLine(); // Variable that holds the user's input
            while (bValidate)
            {
                if (string.IsNullOrEmpty(menuItem) || !(menuItem.Equals("1") || menuItem.Equals("2")))
                {
                    //if statement checks if the user has entered anything- if they have entered an item,
                    //it checks if the input is valid (the user can only enter 1 or 2 as options)

                    //displays an error message indicating that the user has not entered a valid input
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Menu Item Selected. Please Try Again.");
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.WriteLine("Choose One Of The Following Items: \n" +
                                      "1. Run Budget Planner Application. \n" +
                                      "2. Exit Application.");

                    menuItem = Console.ReadLine(); // reads in user's input again since their previous entry was invalid
                }
                else // if the user has entered a valid menu item, the boolean variable is set to false
                {
                    bValidate = false; // exists the loop since the boolean variable is now false
                }
            }

            if (!bValidate)
            {
                switch (menuItem) // calls the necessary methods based on user's input
                {
                    case "1": BudgetPlanner(); break; // calls BugetPlanner method if the user has entered '1'
                    case "2": ExitApplication(); break; // calls ExitApplication method if the user has entered '2'
                }
            }
        }

        public void BudgetPlanner()
        {
            // The BudgetPlanner method asks the user to enter the estimated amount for each of the basic expenses
            // it then stores these expenses to an arraylist that holds all expenses

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("========================================================================");
            Console.WriteLine("Budget Planner");
            Console.WriteLine("========================================================================");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Let Us Commence With The Budget Planner Application! \n" +
                              "Please Note: Enter All Decimal Values With A Comma (,) --> Example: '15,2' \n" +
                              "\nPlease Enter Your Gross Salary Before Deductions >> ");

            // get salary amount from user
            salary = 0;
            while (!double.TryParse(Console.ReadLine(), out salary)) //The while loops ensures that user has not entered
                                                                     //an invalid data type or if they have provided a null
                                                                     //value for salary
            {
                ValidateData("Salary"); // calls ValidateData method if they have entered an invalid input
            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Salary Saved Successfully!"); // notifies user that the salary amount has been saved
            Console.BackgroundColor = ConsoleColor.Black;
            hml.SalaryAmount = salary;  // saves the salary amount to the HomeLoan class
            Console.WriteLine();

            // get tax amount from user
            Console.WriteLine("Please Enter Your Estimated Monthly Tax Amount >> ");
            taxAmount = 0;
            while (!double.TryParse(Console.ReadLine(), out taxAmount)) //The while loops ensures that user has not entered
                                                                        //an invalid data type or if they have provided a null
                                                                        //value for the tax amount
            {
                ValidateData("Tax Amount"); // calls ValidateData method if they have entered an invalid input
            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Tax Amount Saved Successfully!"); // notifies user that the tax amount has been saved
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

            //get groceries amount from user
            Console.WriteLine("Please Enter Your Estimated Expenditure On Groceries >> ");
            groceriesAmount = 0;
            while (!double.TryParse(Console.ReadLine(), out groceriesAmount)) //The while loops ensures that user has not entered
                                                                              //an invalid data type or if they have provided a null
                                                                              //value for groceries
            {
                ValidateData("Groceries");  // calls ValidateData method if they have entered an invalid input
            }
            populateArrays.arrExpenseName.Add("Groceries"); // adds 'groceries' as an expense to the arraylist
            populateArrays.arrExpenseCost.Add(groceriesAmount); // adds groceries amount to the arraylist

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Expenditure Amount On Groceries Saved Successfully!"); // notifies user that the groceries amount has been saved
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

            //get water and lights amount from user
            Console.WriteLine("Please Enter Your Estimated Expenditure On Water And Lights >> ");
            waterAndLights = 0;
            while (!double.TryParse(Console.ReadLine(), out waterAndLights))  //The while loops ensures that user has not entered
                                                                              //an invalid data type or if they have provided a null
                                                                              //value for water and lights
            {
                ValidateData("Water And Lights"); // calls ValidateData method if they have entered an invalid input
            }
            populateArrays.arrExpenseName.Add("Water And Lights"); // adds 'water and lights' as an expense to the arraylist
            populateArrays.arrExpenseCost.Add(waterAndLights); // adds lights and water amount to the arraylist
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Expenditure Amount On Water And Lights Saved Successfully!"); // notifies user that the water and lights
                                                                                             // amount has been saved
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

            // get travel costs from user
            Console.WriteLine("Please Enter Your Estimated Expenditure On Travel Costs (Including Fuel) >> ");
            travelCosts = 0;
            while (!double.TryParse(Console.ReadLine(), out travelCosts)) //The while loops ensures that user has not entered
                                                                          //an invalid data type or if they have provided a null
                                                                          //value for travel costs
            {
                ValidateData("Travel Costs"); // calls ValidateData method if they have entered an invalid input

            }
            populateArrays.arrExpenseName.Add("Travel Costs");  // adds 'travel costs' as an expense to the arraylist
            populateArrays.arrExpenseCost.Add(travelCosts); // adds travel costs amount to the arraylist
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Travel Costs Saved Successfully!"); // notifies user that the travel costs have been saved
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

            // get phone billing amount from user
            Console.WriteLine("Please Enter Your Estimated Expenditure On Cellphone And Telephone Billing >> ");
            phoneBills = 0;
            while (!double.TryParse(Console.ReadLine(), out phoneBills))  //The while loops ensures that user has not entered
                                                                          //an invalid data type or if they have provided a null
                                                                          //value for phone billing costs
            {
                ValidateData("Cellphone And Telephone Billing"); // calls ValidateData method if they have entered an invalid input
            }
            populateArrays.arrExpenseName.Add("Phone Bill"); // adds 'phone bill' as an expense to the arraylist
            populateArrays.arrExpenseCost.Add(phoneBills); // adds phone bill amount to the arraylist
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Phone Billing Costs Saved Successfully!"); // notifies user that the phone bill amount has been saved
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

            MoreExpensesOrVehicle(); // calls MoreExpensesOrVehicle method once the user has entered values for all the basic expenses
        }

        public void ValidateData(string expenseName)
        {
            // The ValidateData method is used to notify users they have not entered a valid value for an expense 
            // and asks them to re-enter the value

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Please Enter A Valid Numerical Value For " + expenseName);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Enter The Amount For " + expenseName + " Again >> ");
        }

        public void MoreExpensesOrVehicle()
        {
            // The MoreExpensesOrVehicle method asks the user whether they want to add any additional expenses that they may have
            // or if they want to proceed with the rest of the application
            Console.WriteLine();
            Console.WriteLine("Do You Have Any Other Expenses? \n" +
                              "Press 1 To Add An Expense \n" +
                              "Or 2 To Continue With The Application.");

            bool bValidate = true; // boolean variable that controls the while loop, it is set to true so that the loop
                                   // will always run first then validate the value that the user has entered
            string menuItem = Console.ReadLine(); // Variable that reads the user's input
            while (bValidate)
            {
                if (string.IsNullOrEmpty(menuItem) || !(menuItem.Equals("1") || menuItem.Equals("2")))
                {
                    // if statement checks if the user has entered anything and if they have entered an item,
                    // it checks if the input is valid (the user can only enter 1 or 2 as options)

                    // displays an error message indicating that the user has not entered a valid input

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Menu Item Selected. Please Try Again.");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Do You Have Any Other Expenses? \n" +
                                      "Press 1 To Add An Expense \n" +
                                      "Or 2 To Continue With The Application.");
                    menuItem = Console.ReadLine(); // reads in user's input again since their previous entry was invalid
                }
                else
                {
                    bValidate = false;  // sets the boolean variable to false if the user has entered a valid input
                }
            }

            if (!bValidate) // The following statements occur if the boolean variable is set to false
            {
                switch (menuItem) // calls the relevant method based on what the user has entered 
                {
                    case "1": ExtraExpenses(); break; // calls ExtraExpenses method if the user has entered '1'
                    case "2": carChoice(); break; // calls carChoice method if the user has entered '2'
                }
            }
        }

        public void ExtraExpenses()
        {
            // The ExtraExpenses method asks the user to list all their additional expenses and their relevant costs
            Console.WriteLine("What Is The Name Of Your Additional Expense?");
            string addExpense = Console.ReadLine(); // reads input from user
            bool bValidate = true; // boolean variable that controls the while loop 
            while (bValidate)
            {
                if (string.IsNullOrEmpty(addExpense)) // checks if the user has not entered a null anything
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Try Again.");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Enter The Name Of The Additional Expense >> ");
                    addExpense = Console.ReadLine(); // asks user to enter expense name again since they have not entered anything
                }
                else // if the user has entered an expense name, the following steps occur
                {
                    bValidate = false; // exists loop since boolean varibale is set to false

                }
            }

            // saves the expense name to the arraylist
            populateArrays.arrExpenseName.Add(addExpense);

            // asks user to enter the cost of this additional expense
            Console.WriteLine("Enter Your Estimated Expenditure On " + addExpense + " >> ");
            double addExpenseAmount = 0;

            while (!double.TryParse(Console.ReadLine(), out addExpenseAmount)) // The while loops ensures that user has not
                                                                               // entered an invalid data type
                                                                               // or if they have provided a blank response
            {
                ValidateData(addExpense); // calls ValidateData method if the user enters an invalid input
            }
            populateArrays.arrExpenseCost.Add(addExpenseAmount); //adds expense cost to arraylist if they entered
                                                                 //a valid value
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Expenditure Amount On " + addExpense + " Saved Successfully!"); // notifies the user
                                                                                               // that the amount has been saved
            Console.BackgroundColor = ConsoleColor.Black;

            MoreExpensesOrVehicle(); // Calls MoreExpensesOrVehicle method to ask the user if they want to add
                                     // any more expenses or continue with rest of the application
        }

        public void Accommodation()
        {
            //The Accommodation method asks the user if they would like to buy a property or rent an accomodation.
            // Based on the user's input, it will then call the relevant method

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("========================================================================");
            Console.WriteLine("Accomodation");
            Console.WriteLine("========================================================================");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Please Select Your Accommodation Type. Enter The Appropriate Number. \n" +
                              "1. Rent An Accommodation. \n" +
                              "2. Buy A Property. ");

            bool bValidate = true;  // boolean variable that controls the while loop 
            string menuItem = Console.ReadLine(); // reads input from user
            while (bValidate)
            {
                // checks if the user has not entered a value, or if they have entered an invalid value
                // the user can only choose between '1' or '2' as options
                if (string.IsNullOrEmpty(menuItem) || !(menuItem.Equals("1") || menuItem.Equals("2")))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Menu Item Selected.");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Please Select Your Accommodation Type. Enter The Appropriate Number. \n" +
                                      "1. Rent An Accommodation. \n" +
                                      "2. Buy A Property. ");

                    menuItem = Console.ReadLine();  // reads in user's input again since their previous entry was invalid
                }
                else // the following occurs if the user has entered a valid input -- either '1' or '2'
                {
                    bValidate = false; // exits loop since boolean variable is set to false
                }
            }

            if (!bValidate)
            {
                switch (menuItem) // calls relevant method based on user's valid input
                {
                    case "1": RentAccommodation(); break; //calls RentAccommodation method if user enters '1'
                    case "2": BuyProperty(); break; //calls BuyProperty method if user enters '2'
                }

            }
        }

        public void BuyProperty()
        {
            //The BuyProperty method asks users to enter the necessary information,
            //it will then calculate the monthly loan repayment amount

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("========================================================================");
            Console.WriteLine("Home Loan Calculator - Buying A Property");
            Console.WriteLine("========================================================================");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Please Enter The Purchase Price Of The Property >> "); // asks user to enter purchase price of property
            double PurchasePrice = 0;
            while (!double.TryParse(Console.ReadLine(), out PurchasePrice)) // checks if the input is a numeric value
            {
                ValidateData("Purchase Price Of Property"); //calls ValidateData method if user does not enter a numeric value
            }
            hml.PurchasePrice = PurchasePrice; // saves purchase price if they have entered a valid numeric value
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Purchase Price Saved Successfully!");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Please Enter Total Deposit Paid >> "); // asks user to enter the total deposit paid
            double TotalDeposit = 0;
            while (!double.TryParse(Console.ReadLine(), out TotalDeposit))  // checks if the input is a numeric value
            {
                ValidateData("Total Deposit"); //calls ValidateData method if user does not enter a numeric value
            }
            hml.TotalDeposit = TotalDeposit; // saves total deposit if they have entered a valid numeric value
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Total Deposit Saved Successfully!");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Please Enter Interest Rate (Percentage) >> ");  // asks user to enter the interest rate
            double InterestRate = 0;
            while (!double.TryParse(Console.ReadLine(), out InterestRate)) // checks if the input is a numeric value
            {
                ValidateData("Interest Rate (Percentage)"); //calls ValidateData method if user does not enter a numeric value
            }
            hml.InterestRate = InterestRate; // saves interest rate if they have entered a valid numeric value
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Interest Rate Saved Successfully!");
            Console.BackgroundColor = ConsoleColor.Black;


            Console.WriteLine("Please Enter The Number Of Months To Repay Home Loan (Either 240 Or 360)"); // asks user to enter number of
                                                                                                           // months to repay the home loan
            int RepayMonths = 0;
            while (!int.TryParse(Console.ReadLine(), out RepayMonths)) // checks if the input is a numeric value
            {
                ValidateData("Months To Repay Home Loan (Either 240 OR 360)"); //calls ValidateData method if user does not enter a numeric value
            }
            string monthsNeeded = RepayMonths.ToString(); // converts the number of months to a string data type
            bool bValidate = true; // boolean variable to control while loop
            while (bValidate)
            {
                if (!(monthsNeeded.Equals("240") || monthsNeeded.Equals("360")))
                {
                    // if statement checks if the user has not entered a valid input for the amount of months needed
                    // the user can only choose between 240 or 360 months

                    ValidateData("Of Months To Repay Home Loan (either 240 OR 360)");  //calls ValidateData method if user does not enter either 240 or 360
                    RepayMonths = int.Parse(Console.ReadLine()); // asks user to re-enter number of months
                    monthsNeeded = RepayMonths.ToString(); // converts value to string so that it can be tested again in the loop
                }

                else
                {
                    bValidate = false; // breaks loop if the user has entered 240 or 360 months
                }
            }

            // saves number of months if the user has entered either 240 or 360
            hml.RepayMonths = RepayMonths; // saves number of months to HomeLoan class
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Number Of Months To Repay The Loan Saved Successfully!");
            Console.BackgroundColor = ConsoleColor.Black;


            LoadingSummary(); // notifies user that the summary report is loading
            vehicle.CalculateMonthly(); // calculates the monthly repayment for the vehicle
            hml.CalculateMonthly(); // calculates the monthly home loan repayment
            hml.CalculateAvailableAmount(VehicleOption, vehicle.VehicleMonthlyAmount, salary, populateArrays.sumArr(), taxAmount, hml.HomeLoanAmount); // works out available amount after expense deductions
            hml.BudgetReport(VehicleOption, vehicle.ModelAndMake, vehicle.VehicleMonthlyAmount, vehicle.InsurancePremium, salary, taxAmount, populateArrays.sortArray(), hml.HomeLoanAmount, hml.availAmount); // displays budget report

            DelegateMethod();
        }

        public void RentAccommodation()
        {
            // RentAccommodation() method asks the user to enter their rental amount
            // and then saves the valid rental amount to the rental class

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("========================================================================");
            Console.WriteLine("Rental Accomodation");
            Console.WriteLine("========================================================================");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Please Enter The Rental Amount >>"); // asks user to enter rental amount
            double rentalAmount = 0;
            while (!double.TryParse(Console.ReadLine(), out rentalAmount)) // checks if they have entered a numeric value
            {
                ValidateData("Rent");  //calls ValidateData method if user does not enter a numeric value
            }
            Console.BackgroundColor = ConsoleColor.Green;
            rental.RentalAmount = rentalAmount;
            Console.WriteLine("Rental Amount Saved Successfully!"); // saves rental amount if it is valid
            Console.BackgroundColor = ConsoleColor.Black;

            LoadingSummary(); // notifies user that the summary report is loading
            vehicle.CalculateMonthly();  // calculates the monthly repayment for the vehicle
            rental.CalculateAvailableAmount(VehicleOption, vehicle.VehicleMonthlyAmount,  salary, populateArrays.sumArr(), taxAmount, rentalAmount); // calculates available amount after expense deductions
            rental.BudgetReport(VehicleOption, vehicle.ModelAndMake, vehicle.VehicleMonthlyAmount, vehicle.InsurancePremium, salary, taxAmount, populateArrays.sortArray(), rentalAmount, rental.availAmount); // displays budget report
            DelegateMethod();

        }



        public void ExitApplication()
        {
            // asks the user if they would like to exit the application
            Console.WriteLine("Are You Sure That You Want To Exit The Application? \n" +
                              "Press 1 To Exit Application \n" +
                              "Or 2 To Return To Main Menu.");
            bool bString = true; // boolean variable controls the while loop
            string menuItem = Console.ReadLine(); // reads user's input
            while (bString)
            {
                if (string.IsNullOrEmpty(menuItem) || !(menuItem.Equals("1") || menuItem.Equals("2")))
                {
                    //if statement checks if the user has entered anything and if they did, it checks if the input is valid
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Menu Item Selected.");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Are You Sure That You Want To Exit The Application? \n" +
                                      "Press 1 To Exit Application. \n " +
                                      "Or 2 To Return To Main Menu.");
                    menuItem = Console.ReadLine(); // asks user to re-enter rental amount if it is invalid
                }
                else
                {

                    bString = false; // terminates loop if input is found to be valid
                }


            }

            if (!bString) // the following occurs if the boolean variable is set to false
            {
                switch (menuItem)
                {
                    case "1": System.Environment.Exit(0); break; // terminates program
                    case "2": DisplayMenu(); break;  // displays main menu to user again
                }
            }

        }

        public void LoadingSummary()
        {
            // notifies user that their information has been saved and displays a timer to load the Budget Report
            Console.WriteLine("All Your Information Has Been Successfully Saved! \n" +
                              "Please Wait Patiently While We Generate Your Budget Report!");
            Console.WriteLine("Loading...");
            for (int i = 5; i >=0 ; i--)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Time Left: " + i);
                Thread.Sleep(500);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }


        static void ShowSpinner()
        {
            var counter = 0;
            Console.WriteLine("Initializing Program...");
            for (int i = 0; i < 20; i++) // controls the spinner cycle
            {
                switch (counter % 4)
                {
                    // spinner animations
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                counter++;
                Thread.Sleep(100); // speed of spinner
            }

            Console.Clear(); // clears spinner one loop is terminated
        }


        static void WelcomeAnimation()
        {

            //displays simple animation and welcome message
            for (int i = 0; i < 6; i++) //outer loop
            {
                for (int j = 0; j < 2; j++) // inner loop
                {
                    Console.Clear(); // clears animation as they load

                    Console.Write("       . . . . o o o o o o", Console.ForegroundColor = ConsoleColor.Blue);
                    for (int s = 0; s < j / 2; s++) // loop to move animation
                    {
                        Console.Write(" o", ConsoleColor.Blue);
                    }
                    Console.WriteLine();

                    var margin = "".PadLeft(j);
                    Console.WriteLine(margin + "Welcome To The Budget Planner Application", ConsoleColor.Blue);


                    Thread.Sleep(100);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;

        }

        public void EndOfProgram()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("========================================================================");
            Console.WriteLine("You've Reached The End Of The Budget Planner Application!");
            Console.WriteLine("========================================================================");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Please Select One Of The Folowwing Items: \n" +
                              "1. Return To Main Menu. \n" +
                              "2. Exit Application");

            bool bValidate = true; // boolean variable that controls the while loop
            string menuItem = Console.ReadLine(); // Variable that reads the user's input
            while (bValidate)
            {
                if (string.IsNullOrEmpty(menuItem) || !(menuItem.Equals("1") || menuItem.Equals("2")))
                {
                    //if statement checks if the user has entered anything and if they did, it checks if the input is valid


                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Invalid Menu Item Selected");

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Please Choose One Of The Following Items: \n" +
                                      "1. Return To Main Menu. \n" +
                                      "2. Exit Application.");

                    menuItem = Console.ReadLine(); // reads in user's input again since their entry was invalid
                }
                else
                {
                    bValidate = false; // breaks loop if the user's input is valid
                }


            }

            if (!bValidate)  // controls what happens if the user enters a valid input
            {
                switch (menuItem) // calls necessary methods based on user's input
                {
                    case "1": populateArrays.arrExpenseName.Clear(); populateArrays.arrExpenseCost.Clear(); DisplayMenu(); break; // calls DisplayMenu() method
                    case "2": ExitApplication(); break; // calls ExitApplication() method
                }
            }


        }

        public void carChoice()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("========================================================================");

            Console.WriteLine("Vehicle");
            Console.WriteLine("========================================================================");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Would You Like To Purchase A Vehicle? Enter The Appropriate Number. \n" +
                              "1. Purchase A Vehicle \n" +
                              "2. Continue With Application. ");

            bool bValidate = true;  // boolean variable that controls the while loop 
            string menuItem = Console.ReadLine(); // reads input from user
            while (bValidate)
            {
                // checks if the user has not entered a value, or if they have entered an invalid value
                if (string.IsNullOrEmpty(menuItem) || !(menuItem.Equals("1") || menuItem.Equals("2")))
                {
                    bValidate = true;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Invalid Menu Item Selected.");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Would You Like To Purchase A Vehicle? Enter The Appropriate Number. \n" +
                                      "1. Purchase A Vehicle \n" +
                                      "2. Continue With Application. ");


                    menuItem = Console.ReadLine();  // reads in user's input again since their entry was invalid
                }
                else
                {
                    bValidate = false; // breaks loop if the user's input is valid
                }

            }


            if (!bValidate) // calls appropriate method if the user's input is valid
            {
                switch (menuItem)
                {
                    case "1": VehicleOption = 1; EnterVehicleDetails(); break; //calls RentAccommodation() method
                    case "2": VehicleOption = 0; Accommodation(); break; //calls BuyProperty() method
                }
            }

        }

        public void EnterVehicleDetails()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("========================================================================");
            Console.WriteLine("Please Enter The Required Details Below To Purchase A Vehicle");
            Console.WriteLine("========================================================================");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Please Enter The Vehicle Make And Model Number"); // asks user to enter the vehicle make
                                                                                 // and model number 
            string modelAndMake = Console.ReadLine(); // reads user's input
            bool bValidate = true;

            while (bValidate)
            {
                if (string.IsNullOrEmpty(modelAndMake)) // checks if the user has not entered a value                                      
                {
                    Console.BackgroundColor = ConsoleColor.Red;

                    Console.WriteLine("Do Not Leave Field Blank.");
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.WriteLine("Please Enter The Vehicle Make And Model Number Again >> ");
                    vehicle.ModelAndMake = Console.ReadLine();  // read user's input again
                }
                else
                {
                    bValidate = false; // breaks the loop if the user has entered a valid input
                }

            }

            // saves the vehicle make and model number

            Console.BackgroundColor = ConsoleColor.Green;
            vehicle.ModelAndMake = modelAndMake;
            Console.WriteLine("Make And Model Number Saved Successfully!");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Please Enter The Purchase Price Of The Vehicle >> "); // asks user to enter purchase price of vehicle
            double purchasePrice = 0;
            while (!double.TryParse(Console.ReadLine(), out purchasePrice)) // checks if the input is a numeric value
            {
                ValidateData("Purchase Price Of Vehicle"); // calls ValidateData method if the user has
                                                           // entered an invalid input
            }

            Console.BackgroundColor = ConsoleColor.Green;
            vehicle.PurchasePrice = purchasePrice;
            Console.WriteLine("Purchase Price Saved Successfully!");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Please Enter Total Deposit For Vehicle >> "); // asks user to enter total deposit
            double totalDeposit = 0;
            while (!double.TryParse(Console.ReadLine(), out totalDeposit))  // checks if the input is a numeric value
            {
                ValidateData("Total Deposit For Vehicle"); // calls ValidateData method if the user has
                                                           // entered an invalid input
            }

            Console.BackgroundColor = ConsoleColor.Green;
            vehicle.TotalDeposit = totalDeposit;
            Console.WriteLine("Total Deposit Saved Successfully!");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Please Enter Interest Rate (Percentage) >>");  // asks user to enter interest rate
            double interestRate = 0;
            while (!double.TryParse(Console.ReadLine(), out interestRate)) // checks if the input is a numeric value
            {
                ValidateData("Interest Rate (Percentage)"); // calls ValidateData method if the user has
                                                            // entered an invalid input
            }

            Console.BackgroundColor = ConsoleColor.Green;
            vehicle.InterestRate = interestRate;
            Console.WriteLine("Interest Rate Saved Successfully!");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Please Enter The Estimated Monthly Insurance Premium >> ");  // asks user to enter the insurance premium
            double insurancePremium = 0;
            while (!double.TryParse(Console.ReadLine(), out insurancePremium)) // checks if the input is a numeric value
            {
                ValidateData("Insurance Premium"); // calls ValidateData method if the user has
                                                   // entered an invalid input
            }

            vehicle.InsurancePremium = insurancePremium;
            populateArrays.arrExpenseName.Add("Insurance Premium");
            populateArrays.arrExpenseCost.Add(insurancePremium);

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Interest Premium Saved Successfully!");
            Console.BackgroundColor = ConsoleColor.Black;


            Console.WriteLine("All Vehicle Details Have Been Saved Sucessfully!");

            Accommodation();

        }

        public void NotifyUser(double rentalAmount, double rentalAvailAmount, double homeLoanAvailAmount)
        {

            //The NotifyUser method notifies the user if their expenses have exceeded over 755 of their salary

            // checks if the rental amount is zero, if it is zero, then it calculates 75% of the HomeLoan available amount
            if (rentalAmount == 0)
            {
                if (homeLoanAvailAmount < (salary * 0.75))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Warning! Your Expenses Have Exceeded Over 75% Of Your Salary.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your Expenses Have Not Exceeded Over 75% Of Your Salary.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

            else

            {
                // calculates 75% of the HomeLoan available amount

                if ((rentalAvailAmount) < (salary * 0.75))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Warning! Your Expenses Have Exceeded Over 75% Of Your Salary.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your Expenses Have Not Exceeded Over 75% Of Your Salary.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }


            }
        }

        public void DelegateMethod()
        {

            // Delegate used to call the NotifyUser method

            DelNotifyUser delegateNotify = new DelNotifyUser(NotifyUser);
            delegateNotify(rental.RentalAmount, rental.availAmount, hml.availAmount);

            EndOfProgram();
        }

    }
}




