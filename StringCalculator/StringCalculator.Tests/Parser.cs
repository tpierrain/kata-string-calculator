namespace StringCalculator.Tests
{
    public static class Parser
    {
        public static int? ParserTryParsedNumber(string numberCandidate)
        {
            var parsedNumber = TryParseNumber(numberCandidate);
            return parsedNumber;
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
    }
}