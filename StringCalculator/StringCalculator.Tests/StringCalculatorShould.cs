using System;
using System.Collections.Generic;
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

        [Test]
        public void Throw_ArgumentOutOfRangeException_when_calling_with_a_negative_number()
        {
            Check.ThatCode(() => StringCalculator.Add("-1,2"))
                .Throws<Exception>()
                .WithMessage("Negatives not allowed: -1");
        }
    }

    public static class StringCalculator
    {
        private static readonly string _delimiterMarkup = "//";

        public static int Add(string numbers)
        {
            var result = 0;

            if (numbers.IndexOf("-") >= 0)
            {
                throw new Exception("Negatives not allowed: -1");
            }

            var splitNumbers = SplitNumbers(numbers);

            foreach (var number in splitNumbers)
            {
                if (int.TryParse(number, out var value))
                {
                    result += value;
                }
            }

            return result;
        }

        private static IEnumerable<string> SplitNumbers(string numbers)
        {
            var listOfOtherDelimiters = ExtractListOfOtherDelimiters(numbers);

            numbers = ReplaceAllOtherDelimitersWithComma(numbers, listOfOtherDelimiters);

            var splitNumbers = numbers.Split(",");

            return splitNumbers;
        }

        private static string ReplaceAllOtherDelimitersWithComma(string numbers, List<string> listOfOtherDelimiters)
        {
            foreach (var delimiter in listOfOtherDelimiters)
            {
                numbers = numbers.Replace(delimiter, ",");
            }

            return numbers;
        }

        private static List<string> ExtractListOfOtherDelimiters(string numbers)
        {
            var listOfOtherDelimiters = new List<string>() { "\n" };

            if (numbers.StartsWith(_delimiterMarkup))
            {
                var adHocDelimiter = numbers.Substring(2, numbers.IndexOf('\n') - 2);

                listOfOtherDelimiters.Add(adHocDelimiter);
            }

            return listOfOtherDelimiters;
        }
    }
}