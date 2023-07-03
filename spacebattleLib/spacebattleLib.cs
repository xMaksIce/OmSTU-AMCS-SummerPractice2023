namespace spacebattleLib;

public class Spacebattle
{
    public static double[] Move(double[] shipCords, double[] speedCords)
    {
        return Movement(shipCords, speedCords);
    }
    public static double[] Move(double[] shipCords, double[] speedCords, bool movementIsPossible)
    {
        if (movementIsPossible)
        {
            return Movement(shipCords, speedCords);
        }
        else 
        {
            throw new Exception();
        }
    }
    private static double[] Movement(double[] shipCords, double[] speedCords)
    {
        for (int i = 0; i < 2; i++)
        {
            if (shipCords[i] == double.PositiveInfinity || speedCords[i] == double.PositiveInfinity || 
                shipCords[i] == double.NegativeInfinity || speedCords[i] == double.NegativeInfinity ||
                shipCords[i] == double.NaN || speedCords[i] == double.NaN)
                {
                    throw new Exception();
                }
        }
        for (int i = 0; i < 2; i++)
        {
            shipCords[i] += speedCords[i];
        }
        return shipCords;
    }
}
