namespace XUnit.Coverlet.MSBuild
{
    public class SquareEq_Tests
    {
        [Theory]
        [InlineData(0, 3, 1), InlineData(1e-12, 4, 1)]
        public void aIsZero_ThrowArgumentExc(double a, double b, double c) =>
            Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));

        [Theory]
        [InlineData(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity),
         InlineDate(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity),
         InlineData(double.NaN, double.NaN, double.NaN)]
        public void coeffsAreNotNumbers_ThrowArgumentExc(double a, double b, double c) =>
            Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
        
        [Theory]
        [InlineData(1, 2, 1)]
        public void oneRoot_rootAreEqual(double a, double b, double c)
        {
            double[] result = SquareEquation.Solve(a, b, c);
            double[] answer = {-1};
            Assert.Equal(answer, result);
        }

        [Theory]
        [InlineData(1, 4, 3)]
        public void twoRoots_rootsAreEqual(double a, double b, double c)
        {
            double[] result = SquareEquation.Solve(a, b, c);
            Array.Sort(result);
            double[] answer = {-3, -1};
            Assert.Equal(answer, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        public void zeroRoots_ArrayIsEmpty(double a, double b, double c)
        {
            double[] result = SquareEquation.Solve(a, b, c);
            int rootsAmount = result.Count();
            Assert.Equal(0, rootsAmount);
        }
    }
}