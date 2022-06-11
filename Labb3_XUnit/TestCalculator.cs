namespace Labb3_XUnit;

public class TestCalculator
{
    [Theory]
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





}


public static class Calculator
{
    public static decimal BasicCalculation(char mathOperator, decimal value1, decimal value2)
    {
        switch (mathOperator)
        {
            case '+': return value1 + value2;
            case '-': return value1 - value2;
            case '*': return value1 * value2;
            case '/': return value1 / value2;
            case '%': return value1 % value2;
            default:
                throw new ArgumentException();
        }
    }



}