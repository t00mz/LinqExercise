using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers

            var sum = numbers.Sum();


            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine();

            //TODO: Print the Average of numbers

            var avg = numbers.Average();

            Console.WriteLine($"Average: {avg}");
            Console.WriteLine();

            //TODO: Order numbers in ascending order and print to the console

            var ascendingOrder = numbers.OrderBy(num => num);

            Console.WriteLine("Ascending");
            foreach (var number in ascendingOrder)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            //TODO: Order numbers in decsending order and print to the console

            var descendingOrder = numbers.OrderByDescending(num => num);
            Console.WriteLine("Descending");
            foreach (var number in descendingOrder)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6

            var greaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("Numbers greater than 6 in collection:");
            foreach (var number in greaterThanSix)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("First 4 numbers in the ascending order collection:");
            foreach (var number in ascendingOrder.Take(4))
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order

            Console.WriteLine("Changed value of index 4, printed collection in descending order:");
            numbers[4] = 200;
            foreach (var number in descendingOrder)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();


            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            // TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an
            // S and order this in ascending order by FirstName.

            Console.WriteLine("Print employees if first name starts with C or S, and ordered in ascending order by first name:");

            var filtered =
                employees.Where(person => person.FirstName.StartsWith("C") || person.FirstName.StartsWith("S")).OrderBy(person => person.FirstName);

            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }

            Console.WriteLine();

            // TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by
            // Age first and then by FirstName in the same result.

            Console.WriteLine("Print employees full name and age, if they are over 26. Order by age then by first name:");

            var overTwnetySix = employees.Where(person => person.Age > 26).OrderBy(person => person.Age).ThenBy(person => person.FirstName);

            foreach (var employee in overTwnetySix)
            {
                Console.WriteLine($"Employee Fullname: {employee.FullName}");
                Console.WriteLine($"Employee Age: {employee.Age}");
            }    

            Console.WriteLine();

            // TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or
            // equal to 10 AND Age is greater than 35.

            var yeoEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            var sumOfYoe = yeoEmployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYoe = yeoEmployees.Average(emp => emp.YearsOfExperience);

            Console.WriteLine($"Sum of years of experience: {sumOfYoe}");
            Console.WriteLine($"Average of years of experience: {avgOfYoe}");

            Console.WriteLine();

            // TODO: Add an employee to the end of the list without using employees.Add()

            Console.WriteLine("List of employees after adding Jerry:");

            employees = employees.Append(new Employee("Jerry", "Bakers", 32, 3)).ToList();

            foreach(var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName}, {employee.Age}");
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
