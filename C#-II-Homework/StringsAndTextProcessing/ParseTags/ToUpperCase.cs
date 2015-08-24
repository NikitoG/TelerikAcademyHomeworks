//Problem 5. Parse tags

//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to upper-case.
//The tags cannot be nested.
//Example: We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.

//The expected result: We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

using System;
using System.Text;


class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a text: ");
        string inputText = Console.ReadLine();
        string start = "<upcase>";
        string end = "</upcase>";

        StringBuilder changeText = new StringBuilder();
        for (int i = 0; i < inputText.Length; i++)
        {
            if (i <= inputText.Length - end.Length)
            {
                if (string.Compare(inputText.Substring(i, start.Length), start) == 0)
                {
                    for (int j = i; j < inputText.Length - end.Length; j++)
                    {
                        if (string.Compare(inputText.Substring(j, end.Length), end) == 0)
                        {
                            changeText.Append(inputText.Substring(i + start.Length, j - (i + start.Length)).ToUpper());
                            i = j + end.Length - 1;
                            break;
                        }
                    }

                }
                else
                {
                    changeText.Append(inputText[i]);
                }
            }
            else
            {
                changeText.Append(inputText[i]);
            }


        }

        Console.WriteLine(changeText.ToString());

    }
}

