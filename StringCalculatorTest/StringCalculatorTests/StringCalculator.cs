namespace StringCalculatorTests
{
    public class StringCalculator
    {
        public int Add(string expression)
        {
            if (expression == string.Empty)
            {
                return 0;
            }

            var defaultDelimiter = ',';

            if (HasCustomDelimiterPrefix(expression))
            {
                defaultDelimiter = ExtractCustomDelimiter(expression);
                expression = RemoveCustomDelimiterPrefix(expression);
            }

            var numbers = expression.Split(defaultDelimiter, '\n');

            var sum = 0;
            foreach (var number in numbers)
            {
                sum += int.Parse(number);
            }

            return sum;
        }

        private static bool HasCustomDelimiterPrefix(string expression)
        {
            return expression.StartsWith("//");
        }

        private static string RemoveCustomDelimiterPrefix(string expression)
        {
            return expression.Substring(4);
        }

        private static char ExtractCustomDelimiter(string expression)
        {
            return expression[2];
        }
    }
}