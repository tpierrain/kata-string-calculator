namespace StringCalculator.Tests
{
    /// <summary>
    /// Filter for numbers (deciding to ignore those that are not valid or greater than 1000 for instance).
    /// </summary>
    public static class Filter
    {
        public static bool Pass(int? parsedNumber)
        {
            return parsedNumber.HasValue && ShouldNotBeIgnored(parsedNumber);
        }
        private static bool ShouldNotBeIgnored(int? validParsedNumber)
        {
            return validParsedNumber.Value <= 1000;
        }
    }
}