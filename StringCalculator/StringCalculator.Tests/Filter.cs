namespace StringCalculator.Tests
{
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