using System;
using System.Collections.Generic;

namespace StringCalculator.Tests
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            var result = 0;
            var negativeValues = new List<int>();

            var numberCandidates = Parser.Split(numbers);

            foreach (var numberCandidate in numberCandidates)
            {
                var parsedNumber = TryParseNumber(numberCandidate);

                if (parsedNumber.HasValue && ShouldNotBeIgnored(parsedNumber))
                {
                    RememberValueIfNegative(value: parsedNumber.Value, negativeValues);

                    result += parsedNumber.Value;
                }
            }

            if (HasFoundNegativeValue(negativeValues))
            {
                throw new Exception($"Negatives not allowed: {string.Join(',', negativeValues)}");
            }

            return result;
        }

        private static void RememberValueIfNegative(int value, List<int> negativeValues)
        {
            if (value < 0)
            {
                negativeValues.Add(value);
            }
        }

        private static bool ShouldNotBeIgnored(int? validParsedNumber)
        {
            return validParsedNumber.Value <= 1000;
        }

        private static int? TryParseNumber(string number)
        {
            var succeeded = int.TryParse(number, out var value);

            if (succeeded)
            {
                return value;
            }

            return null;
        }

        private static bool HasFoundNegativeValue(List<int> negativeValues)
        {
            return negativeValues.Count > 0;
        }
    }
}