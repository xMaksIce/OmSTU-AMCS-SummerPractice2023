namespace SalonLib.Test;

public class ServiceLocatorTest
{

    [Fact]
    public void Service3Test()
    {
        var expected = "В кабинете";
        var actual = SalonLib.ServiceLocator.GetService("Писать статьи");
        Assert.Equal(expected, actual);
    }
}