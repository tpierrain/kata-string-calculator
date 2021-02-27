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

            var numberCandidates = Spliter.Split(numbers);

            foreach (var numberCandidate in numberCandidates)
            {
                var parsedNumber = Parser.ParserTryParsedNumber(numberCandidate);

                if (Filter.Pass(parsedNumber))
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

        private static bool HasFoundNegativeValue(List<int> negativeValues)
        {
            return negativeValues.Count > 0;
        }
    }
}