namespace VariablesDataExpressionsAndConstantsHomework
{
    using System;

    public class Figure
    {
        private double height;
        private double width;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height must be greater than zero!");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width must be greater than zero!");
                }

                this.width = value;
            }
        }

        public static Figure GetRotatedFigure(Figure figure, double angleOfTheFigureThatWillBeRotaed)
        {
            double rotatedFigureWidth = (Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * figure.Width) +
                                        (Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * figure.Height);
            double rotatedFigureHeigth = (Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * figure.Width) +
                                         (Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * figure.Height);

            Figure figureAfterRotated = new Figure(rotatedFigureWidth, rotatedFigureHeigth);

            return figureAfterRotated;
        }
    }
}
