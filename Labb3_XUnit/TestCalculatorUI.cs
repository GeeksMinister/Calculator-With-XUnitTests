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



    private Dictionary<string, decimal?> GetSampleHistory()
    {
        return new Dictionary<string, decimal?>()
        {
            [@"13+8-7*2/73"] = 20.808219178082191780821917808219m,
            [@"82+2-1*2/20"] = 83.9m,
            [@"15+8-7*2/41"] = 22.658536585365853658536585365854m,
            [@"55+8-7*2/55"] = 62.745454545454545454545454545455m,
            [@"13+8-7*2/29"] = 20.517241379310344827586206896552m,
        };
    }

    [Theory]
    [InlineData(@"15+8-7*2/41")]
    [InlineData(@"82+2-1*2/20")]
    [InlineData(@"13+8-7*2/73")]
    [InlineData(@"55+8-7*2/55")]
    [InlineData(@"7+1-4*2+903")]
    public void LoadHistoryCalculations_ReturnReusableValue(string expression)
    {
        CalculatorUI.HistoryCalculations = GetSampleHistory();

        foreach (var item in CalculatorUI.HistoryCalculations)
        {
            var result = new DataTable().Compute(item.Value + expression, "").ToString();
            Assert.True(decimal.TryParse(result, out decimal actual));
        }


    }

}
