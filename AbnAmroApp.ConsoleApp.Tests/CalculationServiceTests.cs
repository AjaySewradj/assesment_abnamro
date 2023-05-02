using System;
using System.Linq;
using AbnAmroApp.BusinessLogic;
using FluentAssertions;
using Xunit;

namespace AbnAmroApp.ConsoleApp.Tests
{
    public class CalculationServiceTests
    {
        [Fact]
        public void IsDivisibleBy_GivenANumber_WhenTheDivisorIsZero_ShouldReturnFalse()
        {
            // arrange
            int number = 10;
            int divisor = 0;
            var service = new CalculationService();

            // act
            bool result = service.IsDivisibleBy(number, divisor);

            // assert
            result.Should().BeFalse();
        }

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

        [Fact]
        public void Calculate_GivenHardcodedRange_WhenCalculateIsCalled_ShouldReturnExpectedRange()
        {
            // arrange
            var service = new CalculationService();

            // act
            var result = service.Calculate("John", "Doe");

            // assert
            result.Count().Should().Be(100);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Calculate_GivenInvalidFirstName_WhenCalculateIsCalled_ShouldThrowException(string firstName)
        {
            // arrange
            var service = new CalculationService();

            // act
            Action action = () => service.Calculate(firstName, "Doe");

            // assert
            action.Should().Throw<ArgumentNullException>().WithParameterName("firstName");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Calculate_GivenInvalidLastName_WhenCalculateIsCalled_ShouldThrowException(string lastName)
        {
            // arrange
            var service = new CalculationService();

            // act
            Action action = () => service.Calculate("John", lastName);

            // assert
            action.Should().Throw<ArgumentNullException>().WithParameterName("lastName");
        }

        [Fact]
        public void Calculate_GivenValidInput_WhenCalculateIsCalled_ShouldReturnExpectedValues()
        {
            // arrange
            const string firstName = "John";
            const string lastName = "Doe";
            const string fullName = $"{firstName} {lastName}";

            var service = new CalculationService();

            // act
            var result = service.Calculate(firstName, lastName);

            // assert
            result.First().Should().Be("1");
            result.Last().Should().Be(lastName);
            result[1].Should().Be("2");
            result[2].Should().Be(firstName);
            result[3].Should().Be("4");
            result[4].Should().Be(lastName);
            result[5].Should().Be(firstName);
            result[14].Should().Be(fullName);
            result[88].Should().Be("89");
            result[89].Should().Be(fullName);
        }
    }
}