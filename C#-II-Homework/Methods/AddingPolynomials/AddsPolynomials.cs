//Problem 11. Adding polynomials

//Write a method that adds two polynomials.
//Represent them as arrays of their coefficients.

//Problem 12. Subtracting polynomials

//Extend the previous program to support also subtraction and multiplication of polynomials.

using System;

class AddsPolynomials
{
    static void Main()
    {
        int[] firstPolynomial = GetPolynomial();
        PrintPolynomial(firstPolynomial);
        int[] secondPolynomial = GetPolynomial();
        PrintPolynomial(secondPolynomial);

        Console.WriteLine("When we add two polynomials, result is: ");
        if (firstPolynomial.Length > secondPolynomial.Length)
        {
            int[] sumOfTwoPolynomial = AddsTwoPolynomials(firstPolynomial, secondPolynomial);
            PrintPolynomial(sumOfTwoPolynomial);
        }
        else
        {
            int[] sumOfTwoPolynomial = AddsTwoPolynomials(secondPolynomial, firstPolynomial);
            PrintPolynomial(sumOfTwoPolynomial);
        }

        Console.WriteLine("When we substract two polynomials, result is: ");

        int[] substarct = SubstarctTwoPolynomials(firstPolynomial, secondPolynomial);
        PrintPolynomial(substarct);

        int[] substarctTwoOne = SubstarctTwoPolynomials(secondPolynomial, firstPolynomial);
        PrintPolynomial(substarctTwoOne);

        Console.WriteLine("When we multiply two polynomials, result is: ");

        int[] multiply = MultiplicationTwoPolynomials(firstPolynomial, secondPolynomial);
        PrintPolynomial(multiply);
    }

    static int[] GetPolynomial()
    {
        int degree;
        do
        {
            Console.Write("Write polynomial degree: ");
        } while (!(int.TryParse(Console.ReadLine(), out degree) && degree > 0));

        int[] coefficientsPolynomial = new int[degree + 1];
        Console.WriteLine("Enter coefficients: ");
        for (int i = 0; i < degree + 1; i++)
        {
            Console.Write("X^{0} -> ", i);
            coefficientsPolynomial[i] = int.Parse(Console.ReadLine());
        }

        return coefficientsPolynomial;
    }

    static void PrintPolynomial(int[] polynomial)
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if (i == polynomial.Length - 1)
            {
                if (polynomial[i] != 0)
                {
                    Console.Write("{0}X{1}", polynomial[i] == 1 ? "" : polynomial[i].ToString() + "*", i == 1 ? "" : "^" + i.ToString());
                }
            }
            else if (i == 0)
            {

                if (polynomial[i] != 0)
                {
                    if (polynomial[i] < 0)
                    {
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.Write(" + ");
                    }
                    Console.Write("{0}", Math.Abs(polynomial[i]));
                }
            }
            else
            {
                if (polynomial[i] != 0)
                {

                    if (polynomial[i] < 0)
                    {
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.Write(" + ");
                    }

                    Console.Write("{0}X{1}", Math.Abs(polynomial[i]) == 1 ? "" : Math.Abs(polynomial[i]).ToString() + "*",
                                                i == 1 ? "" : "^" + i.ToString());
                }
            }

        }

        Console.Write(" => ");
        Console.Write("[" + string.Join(", ", polynomial) + "]");
        Console.WriteLine();
    }

    static int[] AddsTwoPolynomials(int[] firstPolynomial, int[] secondPolynomial)
    {
        int[] result = new int[firstPolynomial.Length];
        Array.Copy(firstPolynomial, result, firstPolynomial.Length);
        for (int i = 0; i < secondPolynomial.Length; i++)
        {
            result[i] += secondPolynomial[i];
        }

        return result;
    }

    static int[] SubstarctTwoPolynomials(int[] firstPolynomial, int[] secondPolynomial)
    {
        int length;
        if (firstPolynomial.Length >= secondPolynomial.Length)
        {
            length = firstPolynomial.Length;
        }
        else
        {
            length = secondPolynomial.Length;
        }

        int[] result = new int[length];
        Array.Copy(firstPolynomial, result, firstPolynomial.Length);
        for (int i = 0; i < secondPolynomial.Length; i++)
        {
            result[i] -= secondPolynomial[i];
        }

        return result;
    }

    static int[] MultiplicationTwoPolynomials(int[] firstPolynomial, int[] secondPolynomial)
    {
        int length = firstPolynomial.Length + secondPolynomial.Length - 1;
        int[] result = new int[length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = 0;
        }
        for (int i = 0; i < firstPolynomial.Length; i++)
        {
            for (int j = 0; j < secondPolynomial.Length; j++)
            {
                result[i + j] += firstPolynomial[i] * secondPolynomial[j];
            }
        }
        return result;
    }
}

