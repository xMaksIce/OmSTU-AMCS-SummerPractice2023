namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = Math.Pow(10, -9);
        if (Math.Abs(a) < eps || double.IsNaN(a) || double.IsInfinity(a) 
            || double.IsNaN(b) || double.IsInfinity(b)
            || double.IsNaN(c) || double.IsInfinity(c))
        {
            throw new System.ArgumentException();
        }
        else
        {
            double d = Math.Pow(b, 2) - 4 * a * c;
        }
        if (Math.Abs(d) < eps)
        {
            double xFirst = -b / (2 * a);
            return new double[1]{xFirst};
        }
        else if (d > 0)
        {
            double xFirst = -(b + Math.Sign(b) * Math.Sqrt(d)) / (2 * a);
            double xSecond = c / xFirst;
            return new Double[2]{xFirst, xSecond};
        }
        else
        {
            return Array.Empty<double>();
        }
    }
}
