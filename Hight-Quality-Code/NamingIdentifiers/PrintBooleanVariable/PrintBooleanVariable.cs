namespace PrintBooleanVariable
{
    using System;

    public class PrintBooleanVariable
    {
        private const int MaxCount = 6;

        public static void Main()
        {
            PrintVariable printer = new PrintVariable();
            printer.Print(true);
        }
    }
}
