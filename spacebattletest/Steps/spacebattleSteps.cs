using System;
using TechTalk.SpecFlow;
using Xunit;
using spacebattleLib;

namespace spacebattletest.Steps;

[Binding]
public sealed class SpacebattleStepDefinitions
{
    Spaceship ship = new();
    Action moveDelegate; // для проверки равенства
    Action rotateDelegate; // для проверки равенства
    Action currentDelegate; // для проверки исключения
    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void Даны_координаты_корабля(double firstCord, double secondCord)
    {
        ship.position = new double[] {firstCord, secondCord};
    }
    [Given("космический корабль, положение в пространстве которого невозможно определить")]
    public void Невозможно_определить_координаты_корабля()
    {
        ship.position = new double[] {double.NaN, double.NaN};
    }
    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void Даны_значения_скорости(double firstCord, double secondCord)
    {
        ship.speed = new double[] {firstCord, secondCord};
    }
    [Given("скорость корабля определить невозможно")]
    public void Невозожно_определить_скорость_корабля()
    {
        ship.speed = new double[] {double.NaN, double.NaN};
    }
    [Given("изменить положение в пространстве космического корабля невозможно")]
    public void Изменить_положение_невозможно()
    {
        ship.movePossible = false;
    }

    [When("происходит прямолинейное равномерное движение без деформации")]
    public void Когда_происходит_прямолинейное_движение_без_деформации()
    {
        moveDelegate = () => ship.Move();
        currentDelegate = moveDelegate;
    }

    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void Корабль_перемещается_в_точку(double firstCord, double secondCord)
    {
        moveDelegate();
        double[] result = ship.position;
        double[] answer = new double[] {firstCord, secondCord};
        Assert.Equal(answer, result);
    }
    [Then("возникает ошибка Exception")]
    public void Возникает_ошибка_Exception()
    {
        Assert.Throws<Exception>(() => currentDelegate());
    }

    [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
    public void Корабль_иммет_топливо_объёмом(double fuelAmount)
    {
        ship.fuelAmount = fuelAmount;
    }
    [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
    public void Корабль_имеет_скорость_расхода_топлива(double fuelConsumption)
    {
        ship.fuelConsumption = fuelConsumption;
    }
    
    [Then(@"новый объем топлива космического корабля равен (.*) ед")]
    public void Новый_объём_топлива(double newFuelAmount)
    {
        moveDelegate();
        Assert.Equal(newFuelAmount, ship.fuelAmount);
    }

    [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
    public void Корабль_имеет_угол_наклона(double angle)
    {
        ship.angle = angle;
    }
    [Given(@"имеет мгновенную угловую скорость (.*) град")]
    public void Корабль_имеет_угловую_скорость(double angleSpeed)
    {
        ship.angleSpeed = angleSpeed;
    }
    [Given("космический корабль, угол наклона которого невозможно определить")]
    public void Угол_наклона_корабля_не_определён()
    {
        ship.angle = double.NaN;
    }
    [Given("мгновенную угловую скорость невозможно определить")]
    public void Угловая_скорость_корабля_не_определена()
    {
        ship.angleSpeed = double.NaN;
    }
    [Given("невозможно изменить уголд наклона к оси OX космического корабля")]
    public void Невозможно_изменить_угол_наклона_корабля()
    {
        ship.rotatePossible = false;
    }

    [When("происходит вращение вокруг собственной оси")]
    public void Когда_происходит_вращение_вокруг_собственной_оси()
    {
        rotateDelegate = () => ship.Rotate();
        currentDelegate = rotateDelegate;
    }

    [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
    public void Угол_наклона_корабля_составляет(double newAngle)
    {
        rotateDelegate();
        double result = ship.angle;
        Assert.Equal(newAngle, result);
    }
}
