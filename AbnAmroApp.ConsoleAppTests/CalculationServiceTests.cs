using AbnAmroApp.ConsoleApp;
using FluentAssertions;
using Xunit;

namespace AbnAmroApp.ConsoleAppTests
{
    public class CalculationServiceTests
    {
        [Theory]
        [InlineData(0, 3)]
        [InlineData(3, 3)]
        [InlineData(90, 3)]
        [InlineData(-18, 3)]
        [InlineData(0, 5)]
        [InlineData(5, 5)]
        [InlineData(75, 5)]
        [InlineData(-40, 5)]
        [InlineData(0, 4)]
        [InlineData(4, 4)]
        [InlineData(24, 4)]
        [InlineData(-32, 4)]
        public void IsDivisibleBy_GivenANumberDividableByX_WhenTheDivisorIsX_ShouldReturnTrue(int number, int divisor)
        {
            // arrange
            var service = new CalculationService();

            // act
            bool result = service.IsDivisibleBy(number, divisor);

            // assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(4, 3)]
        [InlineData(-5, 3)]
        [InlineData(1, 5)]
        [InlineData(6, 5)]
        [InlineData(-9, 5)]
        [InlineData(1, 4)]
        [InlineData(5, 4)]
        [InlineData(-9, 4)]
        public void IsDivisibleBy_GivenANumberNotDividableByX_WhenTheDivisorIsX_ShouldReturnFalse(int number, int divisor)
        {
            // arrange
            var service = new CalculationService();

            // act
            bool result = service.IsDivisibleBy(number, divisor);

            // assert
            result.Should().BeFalse();
        }
    }
}