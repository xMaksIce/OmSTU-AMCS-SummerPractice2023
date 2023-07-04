namespace spacebattleLib;
public class Spaceship
{
    public double[] position = new double[2];
    public double[] speed = new double[2];
    public double fuelAmount = 0;
    public double fuelConsumption = 0;
    public double angle = 0;
    public double angleSpeed = 0;
    public bool movePossible = true;
    public bool rotatePossible = true;
    public void Move()
    {
        if (fuelAmount < fuelConsumption)
        {
            throw new Exception();
        }
        fuelAmount -= fuelConsumption;
        for (int i = 0; i < position.Count(); i++)
        {
            if (double.IsNaN(position[i]) || double.IsNaN(speed[i]) || !movePossible)
            {
                throw new Exception();
            }
        }
        for (int i = 0; i < position.Count(); i++)
        {
            position[i] += speed[i];
        }
        return;
    }
    public void Rotate()
    {
        if (double.IsNaN(angle) || double.IsNaN(angleSpeed) || !rotatePossible)
        {
            throw new Exception();
        }
        angle += angleSpeed;
        return;
    }
}
