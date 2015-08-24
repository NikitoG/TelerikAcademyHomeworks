//Problem 4. Print a Deck of 52 Cards

//Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers). The cards should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
//The card faces should start from 2 to A.
//Print each card face in its four possible suits: clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement.

using System;
using System.Text;

class PrintAllCards
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        string card = "2";
        string suit = "clubs";
        for (int i = 0; i < 13; i++)
        {
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    card = Convert.ToString(i + 2);
                    break;
                case 9:
                    card = "J";
                    break;
                case 10:
                    card = "Q";
                    break;
                case 11:
                    card = "k";
                    break;
                case 12:
                    card = "A";
                    break;

                default:
                    break;
            }
            for (int n = 0; n < 4; n++)
            {
                switch (n)
                {
                    case 0:
                        suit = Convert.ToString('\u2663');
                        //suit = "clubs";
                        break;
                    case 1:
                        suit = Convert.ToString('\u2666');
                        //suit = "diamonds";
                        break;
                    case 2:
                        suit = Convert.ToString('\u2665');
                        //suit = "hearts";
                        break;
                    case 3:
                        suit = Convert.ToString('\u2660');
                        //suit = "spades";
                        break;

                    default:
                        break;
                }
                Console.Write("{0, 2} of {1}, ", card, suit);
            }
            Console.WriteLine();
        }

        
    }
}
