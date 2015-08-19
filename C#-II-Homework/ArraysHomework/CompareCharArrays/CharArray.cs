//Problem 3. Compare char arrays

//Write a program that compares two char arrays lexicographically (letter by letter).

using System;
using System.Linq;

class CharArray
{
    static void Main()
    {
        Console.Write("Number of element in a first array = ");
        int arrLength1 = int.Parse(Console.ReadLine());
        char[] charArray1 = new char[arrLength1];
        for (int i = 0; i < charArray1.Length; i++)
        {
            Console.Write("charArray1[{0}] = ", i);
            charArray1[i] = char.Parse(Console.ReadLine());
        }

        Console.Write("Number of element in a second array = ");
        int arrLength2 = int.Parse(Console.ReadLine());
        char[] charArray2 = new char[arrLength2];
        for (int i = 0; i < charArray2.Length; i++)
        {
            Console.Write("charArray2[{0}] = ", i);
            charArray2[i] = char.Parse(Console.ReadLine());
        }

        string longerArray = "";
        int index = arrLength1;
        
        if (arrLength1 != arrLength2)
        {
            longerArray = arrLength1 > arrLength2 ? "charArray1" : "charArray2";
            index = arrLength1 > arrLength2 ? arrLength2 : arrLength1;
            Console.WriteLine("{0} array is longer!", longerArray);

        }

        char charOne;
        char charTwo;
        bool isEqual = true;
        for (int i = 0; i < index; i++)
        {
            charOne = charArray1[i];
            charTwo = charArray2[i];
            if (char.IsLetter(charOne))
            {
                charOne = char.ToUpper(charOne);
            }
            if (char.IsLetter(charTwo))
            {
                charTwo = char.ToUpper(charTwo);
            }
            if (charOne > charTwo)
            {
                Console.WriteLine("Lexicographically charArray2 is befor charArray1!");
                isEqual = false;
                break;
            }
            else if (charTwo > charOne)
            {
                Console.WriteLine("Lexicographically charArray1 is befor charArray2!");
                isEqual = false;
                break;
            }
        }
        if (isEqual && arrLength1 == arrLength2)
        {
            Console.WriteLine("First array is equal to second array!");
           
        }
        if (isEqual && arrLength1 != arrLength2)
        {
            Console.WriteLine("Lexicographically {0} is on the second position!", longerArray);
        }

    }
}