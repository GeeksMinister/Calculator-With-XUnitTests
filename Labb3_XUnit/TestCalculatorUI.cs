namespace Labb3_XUnit;

public class TestCalculatorUI
{
    [Theory]
    [InlineData("+", "22", "11")]
    [InlineData("-", "4.5", "45")]
    [InlineData("*", "82", "33")]
    [InlineData("/", "24", "71")]
    [InlineData("%", "12", "91")]
    public void BasicCalculationInput_ReturnValidInput(string mathOperator, string value1, string value2)
    {
        var stringReader = new StringReader($"{mathOperator}\r\n{value1}\r\n{value2}");
        SetIn(stringReader);
        (char actualOperator, decimal actualValue1, decimal actualValue2) = CalculatorUI.BasicCalculationInput();

        Assert.Equal(mathOperator[0], actualOperator);
        Assert.Equal(decimal.Parse(value1), actualValue1);
        Assert.Equal(decimal.Parse(value2), actualValue2);
    }
}

public class CalculatorUI
{
#pragma warning disable CS8602
    public static (char mathOperator, decimal value1, decimal value2) BasicCalculationInput()
    {
        char[] validOperators = "+-*/%".ToCharArray();
        char mathOperator = ' ';
        decimal value1;
        decimal value2;

        while (!validOperators.Contains(mathOperator))
        {
            Write("\n\n\tType in an operator [ + ] [ - ] [ * ] [ / ] [ % ]:  ");
            mathOperator = ReadLine().Trim()[0];
        }

        Write("\n\n\tType in the first value: ");
        while (!decimal.TryParse(ReadLine().Trim(), out value1))
        {
            Write("\n\n\tType in the first value: ");
        }

        Write("\n\n\tType in the second value: ");
        while (!decimal.TryParse(ReadLine().Trim(), out value2))
        {
            Write("\n\n\tType in the second value: ");
        }
        return (mathOperator, value1, value2);
    }
}