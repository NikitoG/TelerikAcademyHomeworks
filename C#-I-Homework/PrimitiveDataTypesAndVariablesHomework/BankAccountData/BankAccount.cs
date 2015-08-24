//Problem 11. Bank Account Data

//A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account.
//Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.

using System;
class BankAccount
{
    static void Main()
    {
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter second name: ");
        string secondName = Console.ReadLine();

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter current balance: ");
    BankBalance:
        string strBalance = Console.ReadLine();
        decimal balance;
        if (Decimal.TryParse(strBalance, out balance))
        {
        }
        else
        {
            Console.Write("Try again in correct format: ");
            goto BankBalance;
        }

        Console.Write("Enter bank: ");
        string bankName = Console.ReadLine();

        Console.Write("Enter IBAN: ");
        string iban = Console.ReadLine();

        Console.WriteLine("Enter credit cards number!");
        Console.Write("First card:");
    Card1:
        string strCard1 = Console.ReadLine();
        ulong firstCard;
        if(ulong.TryParse(strCard1, out firstCard) && firstCard <= 99999999999999999)
        {
        }
        else
        {
            Console.Write("Enter in correct foramt: ");
            goto Card1;
        }
        Console.Write("Second card: ");
    Card2:
        string strCard2 = Console.ReadLine();
        ulong secondCard;
        if (ulong.TryParse(strCard2, out secondCard) && secondCard <= 99999999999999999)
        {
        }
        else
        {
            Console.Write("Enter in correct foramt: ");
            goto Card2;
        }
        Console.Write("Third card: ");
    Card3:
        string strCard3 = Console.ReadLine();
        ulong thirdCard;
        if (ulong.TryParse(strCard3, out thirdCard) && thirdCard <= 99999999999999999)
        {
        }
        else
        {
            Console.Write("Enter in correct foramt: ");
            goto Card3;
        }

        Console.WriteLine("\n\t{0,-20} {1} {2} {3}","Bank Account on", firstName, secondName,lastName);
        Console.WriteLine("\t{0,-20} {1}","Available money:", balance.ToString("C"));
        Console.WriteLine("\t{0,-20} {1}", "In bank:", bankName);
        Console.WriteLine("\t{0,-20} {1}", "IBAN :", iban);
        Console.WriteLine("\tWith credit cards number:");
        Console.WriteLine("\t{0,-20} {1}", "Credit card 1:", firstCard);
        Console.WriteLine("\t{0,-20} {1}", "Credit card 2:", secondCard);
        Console.WriteLine("\t{0,-20} {1}", "Credit card 3:", thirdCard);
 
    }
}
