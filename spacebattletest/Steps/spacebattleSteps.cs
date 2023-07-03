using System;
using TechTalk.SpecFlow;
using Xunit;
using spacebattleLib;

namespace spacebattletest.Steps;

[Binding]
public sealed class SpacebattleStepDefinitions
{
    private double[] shipCords = new double[2];
    private double[] speedCords = new double[2];
    private bool movementPossibility = true;
    private double[] result = new double[2];
    private double[] answer = new double[2];
    private Exception catchedException = new(); 

    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void Даны_координаты_корабля(double firstCord, double secondCord)
    {
        shipCords = new double[] {firstCord, secondCord};
    }
    [Given("космический корабль, положение в пространстве которого невозможно определить")]
    public void Невозможно_определить_координаты_корабля()
    {
        shipCords = new double[] {double.NaN, double.NaN};
    }
    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void Даны_значения_скорости(double firstCord, double secondCord)
    {
        speedCords = new double[] {firstCord, secondCord};
    }
    [Given("скорость корабля определить невозможно")]
    public void Невозожно_определить_скорость_корабля()
    {
        speedCords = new double[] {double.NaN, double.NaN};
    }
    [Given("изменить положение в пространстве космического корабля невозможно")]
    public void Изменить_положение_невозможно()
    {
        movementPossibility = false;
    }

    [When("происходит прямолинейное равномерное движение без деформации")]
    public void Когда_происходит_прямолинейное_движение_без_деформации()
    {
        try 
        {
            result = Spacebattle.Move(shipCords, speedCords, movementPossibility);
        }
        catch (Exception exc)
        {
            catchedException = exc;
        }
    }

    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void Корабль_перемещается_в_точку(double firstCord, double secondCord)
    {
        answer = new double[] {firstCord, secondCord};
        Assert.Equal(answer, result);
    }
    [Then("возникает ошибка Exception")]
    public void Возникает_ошибка_Exception()
    {
        Assert.ThrowsAsync<Exception>(() => throw catchedException);
    }
}
