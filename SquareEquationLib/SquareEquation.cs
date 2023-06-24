﻿namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = Math.Pow(10, -9);
        double d = Math.Pow(b, 2) - 4 * a * c;
        if (a == 0 || a == double.NaN || a == double.PositiveInfinity || a == double.NegativeInfinity
            || b == double.NaN || b == double.PositiveInfinity || b == double.NegativeInfinity
            || c == double.NaN || c == double.PositiveInfinity || c == double.NegativeInfinity)
        {
            throw new System.ArgumentException();
        }
        // else if (Math.Abs(d) < eps)
        else if (d > -eps && d <= eps)
        {
            double xFirst = -b / (2 * a);
            return new double[1] {xFirst};
        }
        else if (d < 0)
        {
            return Array.Empty<double>();
        }
        else
        {
            double xFirst = -(b + Math.Sign(b) * Math.Sqrt(d)) / (2 * a);
            double xSecond = c / xFirst;
            return new Double[2]{xFirst, xSecond};
        }
    }
}
