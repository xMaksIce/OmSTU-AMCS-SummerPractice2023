namespace spacebattleLib;
public class Spacebattle
{
    public static double[] Move(double[] shipCords, double[] speedCords, bool movementIsPossible)
    {
        for (int i = 0; i < 2; i++)
        {
            if (shipCords[i] == double.PositiveInfinity || speedCords[i] == double.PositiveInfinity || 
                shipCords[i] == double.NegativeInfinity || speedCords[i] == double.NegativeInfinity ||
                shipCords[i] == double.NaN || speedCords[i] == double.NaN ||
                !movementIsPossible)
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
