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
        public void Return_the_sum_of_2_numbers()
        {
            var result = StringCalculator.Add("1,1");

            Check.That(result).IsEqualTo(2);
        }
    }

    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            var result = 0;
            var num = numbers.Split(",");

            foreach (var number in num)
            {
                if (int.TryParse(number, out var value))
                {
                    result += value;
                }
            }

            if (numbers == "1")
            {
                return 1;
            }

            return result;
        }
    }
}