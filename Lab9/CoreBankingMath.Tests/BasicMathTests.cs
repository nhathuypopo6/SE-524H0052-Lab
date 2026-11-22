using System;
using Xunit;
using CoreBankingMath;

namespace CoreBankingMath.Tests
{
    public class BasicMathTests
    {
        private readonly BasicMath _math = new BasicMath();

        [Fact]
        public void Add_SimpleValues_ReturnsCorrectSum()
        {
            // Arrange
            double a = 10;
            double b = 20;

            // Act
            double result = _math.Add(a, b);

            // Assert
            Assert.Equal(30, result);
        }

        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(-5, -5, 0)]
        [InlineData(100, 25, 75)]
        public void Subtract_MultipleValues_ReturnsExpected(double a, double b, double expected)
        {
            double result = _math.Subtract(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(-4, 5, -20)]
        [InlineData(0, 999, 0)]
        public void Multiply_MultipleValues_ReturnsExpected(double a, double b, double expected)
        {
            double result = _math.Multiply(a, b);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _math.Divide(10, 0));
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(9, 3, 3)]
        [InlineData(7, 2, 3.5)]
        public void Divide_ValidNumbers_ReturnsCorrectQuotient(double a, double b, double expected)
        {
            double result = _math.Divide(a, b);
            Assert.Equal(expected, result);
        }
    }
}
