//Problem 10. Employee Data

//A marketing company wants to keep record of its employees. Each record would have the following characteristics:

//First name
//Last name
//Age (0...100)
//Gender (m or f)
//Personal ID number (e.g. 8306112507)
//Unique employee number (27560000…27569999)
//Declare the variables needed to keep the information for a single employee using appropriate primitive data types. Use descriptive names. Print the data at the console.

using System;
using System.Collections.Generic;
using System.Linq;

class Employees
{
    static void Main()
    {



        IEnumerable<int> employeeNumber = Enumerable.Range(27560001, 99999);
       
            foreach (int number in employeeNumber)
            {

                

                    Console.WriteLine("Enter first name of employee:");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Enter last name of employee:");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("Enter age:");
                TryEnterAge:
                    string enterAge = Console.ReadLine();
                    byte age;
                    if (byte.TryParse(enterAge, out  age) && age < 100)
                    {
                    }
                    else
                    {
                        Console.WriteLine("Try again:");
                        goto TryEnterAge;
                    }

                    Console.WriteLine("Enter gender:");
                TryEnterGender:
                    string enterGender = Console.ReadLine();
                    char gender;
                    if(char.TryParse(enterGender, out  gender) && (gender == 'm' || gender == 'f'))
                    {
                    }
                    else
                    {
                        Console.WriteLine("You must enter \'f\' for female or \'m\' for male:");
                        goto TryEnterGender;
                    }

                    Console.WriteLine("Enter personal ID number:");
                TryEnterIDNumber:
                    string enterIdNumber = Console.ReadLine();
                    ulong personalId;
                    if (ulong.TryParse(enterIdNumber, out  personalId) && personalId <= 9999999999)
                    {
                    }
                    else
                    {
                        Console.WriteLine("Try again:");
                        goto TryEnterIDNumber;
                    }

                    Console.WriteLine("\n\t{0, -20} {1}", "Employees Number:", number);
                    Console.WriteLine("\t{0, -20} {1} {2}", "Name:", firstName, lastName);
                    Console.WriteLine("\t{0, -20} {1}", "Age:", age);
                    if (gender == 'm')
                    {
                        Console.WriteLine("\t{0, -20} {1}", "Gender:", "Male");
                    }
                    else
                    {
                        Console.WriteLine("\t{0, -20} {1}", "Gender:", "Female");
                    }
                    Console.WriteLine("\t{0, -20} {1}", "Personal ID:", personalId);

                    Console.WriteLine("\nFor exit press esc, to enter a new eployee press other button!!!");

                    ConsoleKeyInfo esc;
                    esc = Console.ReadKey(true);
                    if (esc.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("To exit press esc again!");
                        goto Final;
                    }
               
            }
        Final:
            Console.ReadKey();

    }   
}