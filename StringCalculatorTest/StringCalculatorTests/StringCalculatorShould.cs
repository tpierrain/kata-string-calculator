using System;
using System.Reflection.Metadata;
using NFluent;
using NUnit.Framework;

namespace StringCalculatorTests
{
    [TestFixture]
    public class StringCalculatorShould
    {
        [Test]
        public void Return_Zero_when_Numbers_is_Empty()
        {
            // ARRANGE
            var numbers = "";
            var expectedResult = 0;
                
            var calculator = new StringCalculator();
            
            // ACT
            var result = calculator.Add(numbers);

            Check.That(result).IsEqualTo(expectedResult);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Return_a_number_when_numbers_Contains_only_1_number(string numbers, int expectedResult)
        {
            var calculator = new StringCalculator();

            // ACT
            var result = calculator.Add(numbers);

            Check.That(result).IsEqualTo(expectedResult);
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
            
            return int.Parse(numbers);
        }
    }
}