using System.Collections.Generic;

namespace StringCalculator.Tests
{
    public static class Spliter
    {
        private static readonly string _delimiterMarkup = "//";

        public static IEnumerable<string> Split(string numbers)
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