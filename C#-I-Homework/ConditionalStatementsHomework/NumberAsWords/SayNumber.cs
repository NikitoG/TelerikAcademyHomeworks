//Problem 11.* Number as Words

//Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.

using System;

class SayNumber
{
    static void Main()
    {
        ushort number;
        string input;
        do
        {
            Console.Write("Enter a number: ");
            input = Console.ReadLine();
        } while (!ushort.TryParse(input, out number));

        string[] words = {
                                 "zero",
                                 "one",
                                 "two",
                                 "three", 
                                 "four",
                                 "five",
                                 "six",
                                 "seven",
                                 "eight",
                                 "nine",
                                 "ten",
                                 "eleven",
                                 "twelve",
                                 "thirteen"
                             };

        if (number > 999)
        {
            Console.WriteLine("Wrong input!");
        }
        else if (number <= 13)
        {
            Console.WriteLine("{0} -> {1}", number, words[number]);
        }
        else if ((number >= 14) && (number < 20))
        {
            if (number == 15)
            {
                Console.WriteLine("{0} -> fifteen", number);
            }
            else
            {
                Console.WriteLine("{0} -> {1}", number, words[number - 10] + "teen");
            }
        }
        else if ((number > 19) && (number < 100))
        {
            switch (number / 10)
            {
                case 2:
                    Console.WriteLine("{0} -> {1}{2}", number, "twenty ", words[number % 10]);
                    break;
                case 3:
                    Console.WriteLine("{0} -> {1}{2}", number, "thirty ", words[number % 10]);
                    break;
                case 5:
                    Console.WriteLine("{0} -> {1}{2}", number, "fifty ", words[number % 10]);
                    break;
                default:
                    Console.WriteLine("{0} -> {1}{2}", number, words[number / 10] + "ty ", words[number % 10]);
                    break;
            }
        }
        else if (number % 100 == 0)
        {
            Console.WriteLine("{0} -> {1} {2}", number, words[number / 100], "hundred");
        }
        else
        {
            string hundreds = words[number / 100] + " hundred";
            int tents = number % 100;
            string strTents;

            if (tents <= 13)
            {
                strTents = words[tents];
            }
            else if ((tents >= 14) && (tents < 20))
            {
                if (tents == 15)
                {
                    strTents = "fifteen";
                }
                else
                {
                    strTents = words[tents - 10] + "teen";
                }
            }
            else
            {
                switch (tents / 10)
                {
                    case 2:
                        strTents = "twenty " + words[tents % 10];
                        break;
                    case 3:
                        strTents = "thirty " + words[tents % 10];
                        break;
                    case 5:
                        strTents = "fifty " + words[tents % 10];
                        break;
                    default:
                        strTents = words[tents / 10] + "ty " + words[tents % 10];
                        break;
                }
            }

            Console.WriteLine("{0} -> {1} {2} {3} {4}", number, words[number / 100], "hundred", "and", strTents);


        }
    }
}
