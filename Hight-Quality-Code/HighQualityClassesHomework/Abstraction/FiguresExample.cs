﻿namespace Abstraction
{
    using System;

    internal class FiguresExample
    {
        private static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine(circle);
            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine(rect);
        }
    }
}
