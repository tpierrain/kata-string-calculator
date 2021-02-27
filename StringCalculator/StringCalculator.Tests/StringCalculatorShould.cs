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
    }

    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            throw new NotImplementedException();
        }
    }
}