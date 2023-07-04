namespace spacebattleLib;
public class Spaceship
{
    public static double[] Move(double[] position, double[] speed, bool movementPossibility)
    {
        for (int i = 0; i < position.Count(); i++)
        {
            if (double.IsNaN(position[i]) || double.IsNaN(speed[i]) || !movementPossibility)
            {
                throw new Exception();
            }
        }
        for (int i = 0; i < position.Count(); i++)
        {
            position[i] += speed[i];
        }
        return position;
    }
}
