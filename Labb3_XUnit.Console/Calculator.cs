public static class Calculator
{
#pragma warning disable CS8604

    public static decimal BasicCalculation(char mathOperator, decimal value1, decimal value2)
    {
        switch (mathOperator)
        {
            case '+': return value1 + value2;
            case '-': return value1 - value2;
            case '*': return value1 * value2;

            case '/':
                if (value2 == 0)
                {
                    return 0;
                }
                else
                {
                    return value1 / value2;
                }

            case '%': return value1 % value2;
            default:
                throw new ArgumentException("Invalid operator was passed in");
        }
    }

    public static decimal? ComputeMathExpression(string expression)
    {
        try
        {
            var resultObject = new DataTable().Compute(expression, "");
            decimal result = decimal.Parse(resultObject.ToString());
            return result;
        }
        catch (Exception ex) when (ex is EvaluateException ||
                                  ex is SyntaxErrorException)
        {
            return null;
        }
    }

}