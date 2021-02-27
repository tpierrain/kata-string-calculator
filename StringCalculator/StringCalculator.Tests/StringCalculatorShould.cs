using System;
using NFluent;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorShould
    {
        [Test]
        public void Add_EmptyString()
        {
            var result = StringCalculator.Add("");

            Check.That(result).IsEqualTo(0);
        }

        [Test]
        public void Return_the_number_when_calling_Add_with_one_number()
        {
            var result = StringCalculator.Add("1");

            Check.That(result).IsEqualTo(1);
        }

        [Test]
        public void Return_the_sum_of_2_numbers_separated_with_commas()
        {
            var result = StringCalculator.Add("1,1");

            Check.That(result).IsEqualTo(2);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("1\n7,3,2\n1", 14)]
        [TestCase("1,\n", 1)]
        public void Identify_numbers_separated_with_newline(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);

            Check.That(result).IsEqualTo(expectedResult);
        }

        [Test]
        public void Allow_to_handle_a_different_delimiter_when_specified_at_the_beginning_of_the_string()
        {
            var result = StringCalculator.Add("//;\n1;2");

            Check.That(result).IsEqualTo(3);
        }

        [TestCase("-1,2", "Negatives not allowed: -1")]
        [TestCase("2,-4,3,-5", "Negatives not allowed: -4,-5")]
        public void Throw_ArgumentOutOfRangeException_when_calling_with_a_negative_number(string numbers, string exceptionMessage)
        {
            Check.ThatCode(() => StringCalculator.Add(numbers))
                .Throws<Exception>()
                .WithMessage(exceptionMessage);
        }

        [Test]
        public void Ignore_numbers_bigger_than_1000()
        {
            var result = StringCalculator.Add("1001,2");

            Check.That(result).IsEqualTo(2);
        }
    }
}