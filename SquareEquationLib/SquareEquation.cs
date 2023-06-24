﻿namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = Double.Epsilon;
        if (a == 0)
        {
            throw new System.ArgumentException();
        }
        else
        {
            double d = Math.Pow(b, 2) - 4 * a * c;
            double xFirst = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2;
            double xSecond = c / xFirst;
            return new Double[2]{xFirst, xSecond};
            //pepega
        }
        throw new NotImplementedException();
        // ATTENTION!!
    }
}
