using System;
using System.Collections.Generic;

namespace StringCalculator.Tests
{
    /// <summary>
    /// Compute numbers expressed in a very specific string format.
    /// </summary>
    public static class StringCalculator
    {
        /// <summary>
        /// Add a list of positive numbers provided in a string using various delimiters (commas, \n), including ad-hoc/specified delimiters.
        /// </summary>
        /// <param name="numbers">The list of positive numbers.</param>
        /// <returns>The sum of all those numbers if they are valid (i.e. not greater than 1000).</returns>
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