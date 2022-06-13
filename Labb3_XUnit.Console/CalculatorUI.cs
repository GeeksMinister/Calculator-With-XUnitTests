global using static System.Console;
global using System.Data;


public class CalculatorUI
{
#pragma warning disable CS8602

    public static Dictionary<string, decimal?> HistoryCalculations = new Dictionary<string, decimal?>();

    public static void PrintMenu()
    {
        while (true)
        {
            Clear();
            Write($"\n\t\t\t\t\t\t* ((\tCalculator - XUnit\t)) * \n\n\n" +
                "  [1] Do basic calculation with two values\n\n" +
                "  [2] Make complex calculation by a math expression\n\n" +
                "  [3] Continue working from a history calculation\n\n" +
                "  [4] Exit \n\n\n" +
                "   \t-Choose:  ");
            int.TryParse(ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    Clear();
                    BasicCalculationInput();
                    Redirecting();
                    break;
                case 2:
                    Clear();
                    MathExpressionInput();
                    Redirecting();
                    break;
                case 3:
                    Clear();
                    PrintHistoryCalculations();
                    Redirecting();
                    break;
                case 4:
                    Clear();
                    WriteLine("\n\n\n\n\t\tHave a wonderful day :-)");
                    Thread.Sleep(1800);
                    return;
                default:
                    WriteLine("\t\tInvalid input!   " +
                    "Please choose from 1 - 4\n");
                    ReadKey();
                    break;
            }
        }
    }

    private static void Redirecting()
    {
        Write("\n\n\n\t\tPress 'Enter' to return to the main menu");
        ReadLine();
    }

    public static (char? mathOperator, decimal? value1, decimal? value2) BasicCalculationInput()
    {
        char[] validOperators = { '+', '-', '*', '/', '%' };
        char mathOperator = ' ';
        decimal value1;
        decimal value2;
        decimal result;
        CancelButton();
        while (!validOperators.Contains(mathOperator))
        {
            Write("\n\n\tType in an operator [ + ] [ - ] [ * ] [ / ] [ % ]:  ");
            string input = ReadLine().Trim().ToUpper();
            if (input == "C")
            {
                return (null, null, null);
            }
            if (input != string.Empty)
            {
                mathOperator = input[0];
            }
        }
        try { Clear(); }
        catch (IOException) { }

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
        result = Calculator.BasicCalculation(mathOperator, value1, value2);

        string expression = $"{value1} {mathOperator} {value2}";
        Write($"\n\n\t{value1} {mathOperator} {value2} = {result:#.##}");
        if (!HistoryCalculations.ContainsKey(expression))
        {
            HistoryCalculations.Add($"{value1} {mathOperator} {value2}", result);
        }
        return (mathOperator, value1, value2);
    }

    public static void MathExpressionInput()
    {
        decimal? result = null;
        string expression = string.Empty;
        CancelButton();
        while (result is null)
        {
            Write("\n\n\tPlease type in a valid math expression:  ");
            result = Calculator.ComputeMathExpression(expression = ReadLine().Trim());
            if (expression.ToUpper() == "C") return;
        }
        Write($"\n\n\t{expression} = {result:#.##}");
        if (!HistoryCalculations.ContainsKey(expression))
        {
            HistoryCalculations.Add($"{expression}", result);
        }
    }

    public static void PrintHistoryCalculations()
    {
        if (!HistoryCalculations.Any())
        {
            WriteLine($"\n\n\tThe history is Empty !");
            return;
        }
        CancelButton();
        int count = 0;
        foreach (var item in HistoryCalculations)
        {
            count++;
            Write($"\n\n\t[{count}]  {item.Key:#.##} = {item.Value:#.##}");
        }
        SelectAndContinueCalculation(count);
    }

    public static void SelectAndContinueCalculation(int count)
    {
        int select = 0;
        Write("\n\n\tSelect a value:  ");
        while (select > count || select <= 0)
        {
            string? input;
            int.TryParse(input = ReadLine(), out select);
            if (input.Trim().ToUpper() == "C") return;
        }
        try { Clear(); }
        catch (IOException) { }

        string? historyValue = HistoryCalculations.ElementAt(select - 1).Value.ToString();
        decimal? result = null;
        string expression = string.Empty;
        while (result is null)
        {
            Write($"\n\n\tPlease type in a valid math expression:  {historyValue}");
            result = Calculator.ComputeMathExpression(historyValue + (expression = ReadLine().Trim()));
        }
        expression = historyValue + expression;
        Write($"\n\n\t{expression} = {result:#.##}");
        if (!HistoryCalculations.ContainsKey(expression))
        {
            HistoryCalculations.Add($"{expression}", result);
        }
    }

    public static void CancelButton()
    {
        try 
        {
            SetCursorPosition(60, 1);
            Write("[Type in ' C ' to cancel]");
        }
        
        catch (IOException) { }
    }
}