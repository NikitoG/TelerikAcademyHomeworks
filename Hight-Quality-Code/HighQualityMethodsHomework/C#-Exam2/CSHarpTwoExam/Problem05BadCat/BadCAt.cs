namespace Problem05BadCat
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Find the smallest possible number that corresponds to the digits order cat remember.
    /// </summary>
    public class BadCAt
    {
        private static List<int> permutation = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private static int[,] conditions;
        private static List<int> test = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        /// <summary>
        /// Find the number.
        /// </summary>
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            GetConditions(numberOfLines);
            GetResult();

            Console.WriteLine(string.Join(string.Empty, permutation));
        }

        /// <summary>
        /// Get the given conditions.
        /// </summary>
        /// <param name="numberOfConditions">Integer - number of conditions.</param>
        private static void GetConditions(int numberOfConditions)
        {
            conditions = new int[numberOfConditions, 2];

            for (int index = 0; index < numberOfConditions; index++)
            {
                string[] currentLine = Console.ReadLine().Split(' ');
                test.Remove(int.Parse(currentLine[0]));
                test.Remove(int.Parse(currentLine[3]));
                if (currentLine[2].CompareTo("before") == 0)
                {
                    conditions[index, 0] = int.Parse(currentLine[0]);
                    conditions[index, 1] = int.Parse(currentLine[3]);
                }
                else
                {
                    conditions[index, 1] = int.Parse(currentLine[0]);
                    conditions[index, 0] = int.Parse(currentLine[3]);
                }
            }
        }

        /// <summary>
        /// Get result.
        /// </summary>
        private static void GetResult()
        {
            foreach (var item in test)
            {
                permutation.Remove(item);
            }

            if (permutation[0] == 0)
            {
                permutation[0] = permutation[1];
                permutation[1] = 0;
            }

            bool nextPermutation = true;
            bool isResult = CheckConditions();
            while (!isResult)
            {
                nextPermutation = GetNextPermutation(permutation);
                isResult = CheckConditions();
            }
        }

        /// <summary>
        /// Check the result.
        /// </summary>
        /// <returns>Boolean - is result correct.</returns>
        private static bool CheckConditions()
        {
            bool isResult = true;
            for (int row = 0; row < conditions.GetLength(0); row++)
            {
                if (!(permutation.IndexOf(conditions[row, 0]) < permutation.IndexOf(conditions[row, 1])))
                {
                    isResult = false;
                    break;
                }
            }

            return isResult;
        }

        // get from http://olsen.org/alan/blog/?p=85
        /*

         * Transitions perm to the next lexigraphical permutation and

         * returns true, unless it is the last permutation, in which case

         * it resets to the first permutation and returns false

         */

        /// <summary>
        /// Transitions perm to the next lexicographical permutation and returns true, unless it is the 
        /// last permutation, in which case it resets to the first permutation and returns false
        /// </summary>
        /// <param name="perm">List of integers.</param>
        /// <returns>Boolean - returns true, unless it is the last permutation</returns>
        private static bool GetNextPermutation(List<int> perm)
        {
            int n = perm.Count;

            int k = -1;

            for (int i = 1; i < n; i++)
            {
                if (perm[i - 1] < perm[i])
                {
                    k = i - 1;
                }
            }

            if (k == -1)
            {
                for (int i = 0; i < n; i++)
                {
                    perm[i] = i;
                }

                return false;
            }

            int l = k + 1;
            for (int i = l; i < n; i++)
            {
                if (perm[k] < perm[i])
                {
                    l = i;
                }
            }

            int t = perm[k];
            perm[k] = perm[l];
            perm[l] = t;
            perm.Reverse(k + 1, perm.Count - (k + 1));
            return true;
        }
    }
}
