using System;
using TechTalk.SpecFlow;
using SquareEquationLib;
using Xunit;

namespace SquareEquationBDD.Steps;
[Binding]
public class Steps
{
    private double[] coeffs = new double[3];
    private double[] result = new double[0];
    private double[] correctRoots = new double[0];
    private Exception catchedException = new Exception();

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
    public void Дано_уравнение_с_коэффициентами(string a, string b, string c)
    {
        string[] input = {a, b, c};
        for (int i = 0; i < 3; i++)
        {
            if (input[i] == "Double.PositiveInfinity")
            {
                coeffs[i] = double.PositiveInfinity;
            }
            else if (input[i] == "Double.NegativeInfinity")
            {
                coeffs[i] = double.NegativeInfinity;
            }
            else if (input[i] == "NaN")
            {
                coeffs[i] = double.NaN;
            }
            else
            {
                coeffs[i] = double.Parse(input[i]);
            }
        }
    }

    [When("вычисляются корни квадратного уравнения")]
    public void Когда_вычисляются_корни_уравнения()
    {
        try
        {
            result = SquareEquation.Solve(coeffs[0], coeffs[1], coeffs[2]);
        }
        catch (Exception exc)
        {
            catchedException = exc;
        }
    }

    [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
    public void Тогда_уравнение_имеет_два_корня(double xFirst, double xSecond)
    {
        correctRoots = new double[] {xFirst, xSecond};
        Array.Sort(correctRoots);
        Array.Sort(result);
        Assert.Equal(correctRoots, result);
    }

    [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
    public void Тогда_уравнение_имеет_один_корень(double x)
    {
        correctRoots = new double[] {x};
        Assert.Equal(correctRoots, result);
    }

    [Then("множество корней квадратного уравнения пустое")]
    public void Тогда_корней_нет()
    {
        int rootsAmount = 0;
        foreach (double num in result) rootsAmount++;
        Assert.Equal(0, rootsAmount);
    }

    [Then("выбрасывается исключение ArgumentException")]
    public void Тогда_выбрасывается_исключение_ArgumentException()
    {
        Assert.ThrowsAsync<ArgumentException>(() => throw catchedException);
    }
}