//Problem 9.* Binary floating-point

//Write a program that shows the internal binary representation of given 32-bit signed 
//floating-point number in IEEE 754 format (the C# type float).

using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryFloatingPoint
{
    class FloatingPoint
    {
        static void Main()
        {
            float number;
            do
            {
                Console.Write("Enter a 32-bit signed floating-point number: ");
            } while (!float.TryParse(Console.ReadLine(), out number));

            int[] sign = new int[1];
            if (number < 0)
            {
                sign[0] = 1;
            }

            float integralPart = (float)Math.Truncate(Math.Abs(number));
            float afterPoint = Math.Abs(Math.Abs(number)) - integralPart;

            List<int> pointPart = new List<int>();
            int index = 0;
            while ((afterPoint != 0) && index < 31)
            {
                pointPart.Add((int)Math.Truncate(afterPoint * 2));
                afterPoint = afterPoint * 2 - (int)Math.Truncate(afterPoint * 2);
                ++index;
            }


            int temp = (int)integralPart;
            List<int> intPart = new List<int>();
            while (temp != 0)
            {
                intPart.Add(temp % 2);
                temp /= 2;
            }

            intPart.Reverse();

            int[] mantissa = new int[23];
            int[] exponent = new int[8];
            index = 0;
            int exp = 0;
            if (Math.Abs(number) > 1)
            {
                for (int i = 1; i < intPart.Count; i++)
                {
                    mantissa[i - 1] = intPart[i];
                }
                for (int i = intPart.Count - 1; i < mantissa.Length; i++)
                {
                    if (index < pointPart.Count)
                    {
                        mantissa[i] = pointPart[index];
                        ++index;
                    }
                }
                exp = intPart.Count - 1 + 127;
            }
            else
            {
                index = pointPart.IndexOf(1) + 1;
                for (int i = 0; i < mantissa.Length; i++)
                {
                    if (index < pointPart.Count)
                    {
                        mantissa[i] = pointPart[index];
                        ++index;
                    }
                }
                exp = 127 - (pointPart.IndexOf(1) + 1);
            }

            temp = exp;
            index = exponent.Length - 1;
            while (temp != 0)
            {
                exponent[index] = temp % 2;
                temp /= 2;
                --index;
            }

            exponent.Reverse();

            Console.WriteLine("{0}|{1}|{2}", string.Join("", sign), string.Join("", exponent), string.Join("", mantissa));


        }
    }
}
