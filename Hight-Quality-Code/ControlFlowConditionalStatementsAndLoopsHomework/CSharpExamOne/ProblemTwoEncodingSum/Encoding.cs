namespace CSharpExamOne
{
    using System;
    using System.Numerics;

    public class Encoding
    {
        public static void Main()
        {
            const char EndOfProgram = '@';
            const char CheckDigit = '0';
            const char CheckLetterToUpper = 'A';
            const char CheckLetterToLower = 'a';

            BigInteger module = BigInteger.Parse(Console.ReadLine());
            string inputText = Console.ReadLine();

            BigInteger inputLenght = inputText.Length;

            BigInteger result = 0;
            for (int i = 0; i < inputLenght; i++)
            {
                if (inputText[i] == EndOfProgram)
                {
                    break;
                }

                if (((inputText[i] - CheckDigit) <= 9) && ((inputText[i] - CheckDigit) >= 0))
                {
                    result = result * (inputText[i] - CheckDigit);
                }
                else if (((inputText[i] - CheckLetterToLower) <= 25) && ((inputText[i] - CheckLetterToLower) >= 0))
                {
                    result = result + (inputText[i] - CheckLetterToLower);
                }
                else if (((inputText[i] - CheckLetterToUpper) <= 25) && ((inputText[i] - CheckLetterToUpper) >= 0))
                {
                    result = result + (inputText[i] - CheckLetterToUpper);
                }
                else
                {
                    result = result % module;
                }
            }

            Console.WriteLine(result);
        }
    }
}
