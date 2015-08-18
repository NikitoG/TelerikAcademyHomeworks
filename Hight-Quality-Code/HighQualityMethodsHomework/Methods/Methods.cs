namespace Methods
{
    using System;

    /// <summary>
    /// Random Methods
    /// </summary>
    internal class Methods
    {
        /// <summary>
        /// A method for calculating the area of a triangle when you know all three sides.
        /// </summary>
        /// <param name="firstSide">Double - first side.</param>
        /// <param name="secondSide">Double - second side.</param>
        /// <param name="thirdSide">Double - third side.</param>
        /// <returns>Double - the area of a triangle</returns>
        public static double CalcTriangleArea(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            if ((firstSide + secondSide < thirdSide) || (firstSide + thirdSide < secondSide) || (thirdSide + secondSide < firstSide))
            {
                throw new ArgumentOutOfRangeException("The sum of two sides of a triangle must be greater than the third!");
            }

            double semiperimeter = (firstSide + secondSide + thirdSide) / 2;
            double area = Math.Sqrt(semiperimeter * (semiperimeter - firstSide) * (semiperimeter - secondSide) * (semiperimeter - thirdSide));
            return area;
        }

        /// <summary>
        /// The method for converting given digit into word representations.
        /// </summary>
        /// <param name="number">Integer - digit.</param>
        /// <returns>String - word representations</returns>
        public static string DigitToWord(int number)
        {
            if (number < 0 || 9 < number)
            {
                throw new ArgumentOutOfRangeException("The number must be a positive digit!");
            }

            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            return digits[number];
        }

        /// <summary>
        /// The methods find max value of a given sequence.
        /// </summary>
        /// <param name="elements">Sequence of integer numbers.</param>
        /// <returns>Integer - largest number.</returns>
        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentOutOfRangeException("The array is empty!");
            }

            int maxElement = int.MinValue;
            for (int index = 0; index < elements.Length; index++)
            {
                if (elements[index] > maxElement)
                {
                    maxElement = elements[index];
                }
            }

            return maxElement;
        }

        /// <summary>
        /// The methods print number in a choose format.
        /// </summary>
        /// <param name="number">Integer - number.</param>
        /// <param name="format">FormatOptions - choose format.</param>
        public static void PrintAsNumber(object number, FormatOptions format)
        {
            switch (format)
            {
                case FormatOptions.FixedPoint:
                    Console.WriteLine("{0:f2}", number);
                    break;
                case FormatOptions.Percentage:
                    Console.WriteLine("{0:p0}", number);
                    break;
                case FormatOptions.AlignRight:
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Wrong formating otptions!");
            }
        }

        /// <summary>
        /// The method calculates distance between two points.
        /// </summary>
        /// <param name="xFirstPoint">Double - the x-coordinate of first point.</param>
        /// <param name="yFirstPoint">Double - the y-coordinate of first point.</param>
        /// <param name="xSecondPoint">Double - the x-coordinate of second point.</param>
        /// <param name="ySecondPoint">Double - the y-coordinate of second point.</param>
        /// <param name="isHorizontal">Boolean - is the line horizontal</param>
        /// <param name="isVertical">Boolean - is the line vertical</param>
        /// <returns>Double - distance between given two points.</returns>
        public static double CalcDistance(double xFirstPoint, double yFirstPoint, double xSecondPoint, double ySecondPoint, out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = yFirstPoint == ySecondPoint;
            isVertical = xFirstPoint == xSecondPoint;

            double xDistance = xSecondPoint - xFirstPoint;
            double yDistance = ySecondPoint - yFirstPoint;

            double distance = Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));
            return distance;
        }

        /// <summary>
        /// Test method.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToWord(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, FormatOptions.FixedPoint);
            PrintAsNumber(0.75, FormatOptions.Percentage);
            PrintAsNumber(2.30, FormatOptions.AlignRight);

            bool horizontal, vertical;
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "Vidin");

            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3), "Vidin", "gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
