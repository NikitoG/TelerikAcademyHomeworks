namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionsHomework
    {
        public static void Main()
        {
            var substr = SubArrayMethods.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = SubArrayMethods.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = SubArrayMethods.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = SubArrayMethods.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            Console.WriteLine(SubArrayMethods.ExtractEnding("I love C#", 2));
            Console.WriteLine(SubArrayMethods.ExtractEnding("Nakov", 4));
            Console.WriteLine(SubArrayMethods.ExtractEnding("beer", 4));

            try
            {
                Console.WriteLine(SubArrayMethods.ExtractEnding("Hi", 100));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(string.Format("{0} is prime: {1}", 23, PrimeNumbers.Check(23)));
            Console.WriteLine(string.Format("{0} is prime: {1}", 33, PrimeNumbers.Check(33)));

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
