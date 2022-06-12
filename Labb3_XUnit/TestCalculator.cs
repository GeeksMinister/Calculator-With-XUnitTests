public class TestCalculator
{
#pragma warning disable CS8604

    [Theory]
    [InlineData('/', "22", "0", 0)]
    [InlineData('+', "22", "11", 22 + 11)]
    [InlineData('-', "22", "11", 22 - 11)]
    [InlineData('*', "22", "11", 22 * 11)]
    [InlineData('/', "22", "11", 22 / 11)]
    [InlineData('%', "22", "11", 22 % 11)]
    public void BasicCalculation_ValidMathOperation(
        char mathOperator, string value1, string value2, decimal result)
    {
        var actual = Calculator.BasicCalculation(mathOperator, decimal.Parse(value1), decimal.Parse(value2));
        Assert.Equal(result, actual);
    }

    [Theory]
    [InlineData('w', "22", "11")]
    [InlineData('B', "22", "11")]
    [InlineData(' ', "22", "11")]
    [InlineData('(', "22", "11")]
    [InlineData('x', "22", "11")]
    public void BasicCalculation_ThrowsArgumentException(char mathOperator, string value1, string value2)
    {
        Assert.Throws<ArgumentException>(() =>
        Calculator.BasicCalculation(mathOperator, decimal.Parse(value1), decimal.Parse(value2)));
    }

    [Theory]
    [InlineData(@"15+8-7*2/41")]
    [InlineData(@"82+2-1*2/20")]
    [InlineData(@"13+8-7*2/73")]
    [InlineData(@"55+8-7*2/55")]
    [InlineData(@"7+1-4*2/90")]
    public void MathExpressionInput_ReturnValidResult(string expression)
    {
        var actual = Calculator.ComputeMathExpression(expression);
        var expected = decimal.Parse(new DataTable().Compute(expression, "").ToString());
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(@"+15+")]
    [InlineData(@"44**3")]
    [InlineData(@"10//")]
    [InlineData(@"4ddd2")]
    [InlineData(@"Invalid")]
    public void MathExpressionInput_ReturnNull(string expression)
    {
        var actual = Calculator.ComputeMathExpression(expression);

        Assert.Null(actual);
    }



}
