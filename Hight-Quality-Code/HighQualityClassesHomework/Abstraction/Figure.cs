namespace Abstraction
{
    using System;
    using System.Text;

    public abstract class Figure : IFigure
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("I am a {0}. ", this.GetType().Name);
            result.AppendFormat("My perimeter is {0:F2}. My surface is {1:F2}.", this.CalculatePerimeter(), this.CalculateSurface());
            return result.ToString();
        }
    }
}
