using System;
using NFluent;
using NUnit.Framework;

namespace StringCalculatorTests
{
    [TestFixture]
    public class StringCalculatorShould
    {

        [Test]
        public void Return_zero_when_empty_string_is_given()
        {
            // Arrange - Given
            var stringCalculator = new StringCalculator();

            // Act - When
            var sum = stringCalculator.Add("");

            // Assert - Then
            Check.That(sum).IsEqualTo(0);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Return_a_number_when_string_contains_a_number(string numbers, int expected)
        {
            var stringCalculator = new StringCalculator();

            var sum = stringCalculator.Add(numbers);

            Check.That(sum).IsEqualTo(expected);
        }

        [Test]
        public void Be_able_to_Sum_2_numbers()
        {
            var stringCalculator = new StringCalculator();

            var sum = stringCalculator.Add("1,2");

            Check.That(sum).IsEqualTo(3);
        }
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == string.Empty)
            {
                return 0;
            }

            var sum = 0;
            var elements = numbers.Split(',');
            foreach (var element in elements)
            {
                sum += int.Parse(element);
            }

            return sum;
        }
    }
}