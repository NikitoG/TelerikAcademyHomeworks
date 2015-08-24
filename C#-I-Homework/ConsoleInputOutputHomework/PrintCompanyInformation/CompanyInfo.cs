//Problem 2. Print Company Information

//A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number.
//Write a program that reads the information about a company and its manager and prints it back on the console.

using System;

class CompanyInfo
{
    static void Main()
    {
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Phone number: ");
        string phoneNumber = Console.ReadLine();
        if(phoneNumber.Length < 7)
        {
            phoneNumber = "(no number)";
        }
        Console.Write("Fax number: ");
        string faxNumber = Console.ReadLine();
        if (faxNumber.Length < 7)
        {
            faxNumber = "(no fax)";
        }
        Console.Write("Web site: ");
        string webSite = Console.ReadLine();
        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Manager last name: ");
        string managerLastName = Console.ReadLine();

        byte managerAge;
        do
        {
            Console.Write("Enter the age of manager: ");
        } while (!byte.TryParse(Console.ReadLine(), out managerAge));

        Console.Write("Manager phone number: ");
        string managerPhone = Console.ReadLine();
        if (managerPhone.Length < 7)
        {
            managerPhone = "(no number)";
        }

        Console.WriteLine(companyName);
        Console.WriteLine("Address: " + companyAddress);
        Console.WriteLine("Tel. {0}", phoneNumber);
        Console.WriteLine("Fax: {0}", faxNumber);
        Console.WriteLine("Web site: {0}", webSite);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})",
            managerFirstName, managerLastName, managerAge, managerPhone);
    }
}
