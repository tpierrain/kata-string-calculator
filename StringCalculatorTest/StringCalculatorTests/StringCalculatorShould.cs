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
            var stringCalculator = new StringCalculator();
            
            var sum = stringCalculator.Add("");

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
        public void Sum_2_numbers()
        {
            var stringCalculator = new StringCalculator();

            var sum = stringCalculator.Add("1,2");

            Check.That(sum).IsEqualTo(3);
        }

        [Test]
        public void Sum_3_numbers()
        {
            var stringCalculator = new StringCalculator();

            var sum = stringCalculator.Add("1,2,1");

            Check.That(sum).IsEqualTo(4);
        }

        [Test]
        public void Return_the_sum_when_expression_also_contains_a_newline_as_delimiter()
        {
            var stringCalculator = new StringCalculator();

            var sum = stringCalculator.Add("1\n2,3");

            Check.That(sum).IsEqualTo(6);
        }

        [Test]
        public void Support_custom_delimiter_when_expression_start_with_slashes()
        {
            // Arrange
            var stringCalculator = new StringCalculator();
            // Act
            var sum = stringCalculator.Add("//;\n1;2");
            // Assert
            Check.That(sum).IsEqualTo(3);
        }

        [Test]
        public void Raise_exception_when_expression_contains_negatives_number()
        {
            var stringCalculator = new StringCalculator();

            Check.ThatCode(() => stringCalculator.Add("-1,2"))
                .Throws<Exception>().WithMessage("Negatives not allowed: -1");
        }
    }
}