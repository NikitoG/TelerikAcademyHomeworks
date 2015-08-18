namespace CohesionAndCoupling
{
    using System;

    public class CalculateDistanceBetweenTwoPoints
    {
        public static double In2DSpace(double xFirstPont, double yFirstPoint, double xSecondPoint, double ySecondPoint)
        {
            double distance = Math.Sqrt(((xSecondPoint - xFirstPont) * (xSecondPoint - xFirstPont)) + ((ySecondPoint - yFirstPoint) * (ySecondPoint - yFirstPoint)));
            return distance;
        }

        public static double In3DSpace(double xFirstPoint, double yFirstPont, double zFirstPont, double xSecondPoint, double ySecondPoint, double zSecondPoint)
        {
            double distance = Math.Sqrt(((xSecondPoint - xFirstPoint) * (xSecondPoint - xFirstPoint)) + ((ySecondPoint - yFirstPont) * (ySecondPoint - yFirstPont)) + ((zSecondPoint - zFirstPont) * (zSecondPoint - zFirstPont)));
            return distance;
        }
    }
}
