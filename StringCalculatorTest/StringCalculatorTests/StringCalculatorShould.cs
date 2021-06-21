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
            var numbers = string.Empty;
            var expectedResult = 0;

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
            return 0;
        }
    }
}