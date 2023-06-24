namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        if (a == 0)
        {
            throw new System.ArgumentException();
        }
        else
        {
            double d = Math.Pow(b, 2);
            double x_first = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2;
            double x_second = c / x_first;
            return new Double[2]{x_first, x_second};
            //pepega
        }
        throw new NotImplementedException();
        // ATTENTION!!
    }
}
