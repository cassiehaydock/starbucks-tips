using System;
using System.Collections.Generic;
using System.Text;

//Cassandra Haydock - 2022
namespace StarbTips
{
    class Program
    {
        static void Main(string[] args)
        {
            //intiliaze a linked list to hold all the worker objects
            DoublyLinkedList employees = new DoublyLinkedList();
            //create an array of the anmes of all employess 
            string[] names = {"Tima", "Cat", "Blen", "Christian", "Janice", "Erica", "Rachel", "Seann", "Shea", "Jaymi",
             "Bella", "Amir", "Thy", "Atilla", "Maddy", "John", "Abdullah", "Cass", "Bethany", "Abe", "Meredith",
             "Nicole", "Mariah", "Jace", "Sean", "Kale", "Matthew"};

            //create worker objects out of the names and add to the list
            foreach(string x in names)
            {
                Workers ex = new Workers(x);
                employees.AddLast(ex);
            }

            Console.WriteLine("Welcome to the Starbucks Tip Counter!:)");
            int choice = 0;
            string name;
            while (choice != -1)
            {
                //promot the user to enter a code to choose which action they wish to complete 
                Console.WriteLine(Environment.NewLine + "Here are your options:");
                Console.WriteLine("1) Add a new employee");
                Console.WriteLine("2) Insert hours for all employees");
                Console.WriteLine("3) Update hours for one employee");
                Console.WriteLine("4) Delete an employee");
                Console.WriteLine("5) Calculate tip distribution");
                Console.WriteLine("6) Display all employee information");
                Console.WriteLine("-1) Exit.");
                choice = ReadInt("I require an integer selection");
                switch (choice)
                {
                    //enter one employee into the list
                    case 1:
                        {
                            //prompt and read the response from the user
                            Console.Write("Please enter the name of the new employee: ");
                            name = Convert.ToString(Console.ReadLine());
                            //create a newworker object
                            Workers newemp = new Workers(name);
                            //add to the back of the list
                            employees.AddLast(newemp);
                        }
                        break;
                    //update the hours for each employee in the list
                    case 2:
                        {
                            //call UpdateHoursAll()
                            employees.UpdateHoursAll();
                        }
                        break;
                    //update the hours of one employee
                    case 3:
                        {
                            //prompt to enter name of which employee to update
                            Console.Write("Enter the name of the employee to update: ");
                            //convert input to string
                            name = Convert.ToString(Console.ReadLine());
                            //call UpdateHoursOne and pass the name of the employee
                            employees.UpdateHoursOne(name);
                        }
                        break;
                    //delete and employee from the list
                    case 4:
                        {
                            //prompt to enter name of employee to delete
                            Console.Write("Enter the name of the employee to delete: ");
                            //convert input into string
                            name = Convert.ToString(Console.ReadLine());
                            //call delete and pass the name of the employee to delete
                            employees.Delete(name);
                        }
                        break;
                    //calculate tip distribution
                    case 5:
                        {
                            //call Tip Distribution
                            employees.TipDistribution();
                        }
                        break;
                    //display all information
                    case 6:
                        {
                            //call DisplayAll()
                            employees.DisplayAll();
                        }
                        break;

                }//end switch
            }//end big while

        }
        //Ask the user for a integer value
        //Handle bad input, only exits once a numeric value is received
        static int ReadInt(string prompt)
        {
            int choice = -1;
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            while (!int.TryParse(input, out choice))
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
            }
            return choice;
        }

    }//end program
}
