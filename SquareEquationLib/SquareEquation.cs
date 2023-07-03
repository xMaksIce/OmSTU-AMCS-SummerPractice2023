namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double d = Math.Pow(b, 2) - 4 * a * c;
        double eps = Math.Pow(10, -9);
        if (Math.Abs(a) < eps || double.IsNaN(a) || double.IsInfinity(a) 
            || double.IsNaN(b) || double.IsInfinity(b)
            || double.IsNaN(c) || double.IsInfinity(c))
        {
            throw new System.ArgumentException();
        }
        else if (Math.Abs(d) < eps)
        {
            double xFirst = -b / (2 * a);
            return new double[1]{xFirst};
        }
        else if (d > 0)
        { 
            // код решателя уравнений был изменён четыре коммита назад,
            // чтобы добавить проверку коэффициента b на равенство нулю
            if (Math.Abs(b) > eps)
            {
                double xFirst = -(b + Math.Sign(b) * Math.Sqrt(d)) / (2 * a);
                double xSecond = c / xFirst;
                return new Double[2]{xFirst, xSecond};
            }
            else
            {
                double xFirst = Math.Sqrt(-4 * a * c) / (2 * a);
                double xSecond = -xFirst;
                return new Double[2]{xFirst, xSecond};
            }
        }
        else
        {
            return Array.Empty<double>();
        }
    }
}