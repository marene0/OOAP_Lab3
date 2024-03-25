using System;

public class UnsupportedOperationException : Exception
{
    public UnsupportedOperationException() : base("Unsupported operation")
    {
    }
}

public class ExpressionParser
{
    public void ParseExpression(string[] tokens)
    {
        if (tokens.Length < 3)
        {
            Console.WriteLine("Invalid expression format");
            return;
        }

        double firstNumber = double.Parse(tokens[0]);
        double secondNumber = double.Parse(tokens[2]);

        char operation = char.Parse(tokens[1]);
        Expression expression;

        switch (operation)
        {
            case '+':
                expression = new AdditionExpression(new NumberExpression(firstNumber), new NumberExpression(secondNumber));
                break;
            case '-':
                expression = new SubtractionExpression(new NumberExpression(firstNumber), new NumberExpression(secondNumber));
                break;
            default:
                throw new UnsupportedOperationException();
        }

        Console.WriteLine($"Result: {expression.Interpret()}");
    }
}

public interface Expression
{
    double Interpret();
}

public class NumberExpression : Expression
{
    private readonly double _number;

    public NumberExpression(double number)
    {
        _number = number;
    }

    public double Interpret()
    {
        return _number;
    }
}

public class AdditionExpression : Expression
{
    private readonly Expression _expression1;
    private readonly Expression _expression2;

    public AdditionExpression(Expression expression1, Expression expression2)
    {
        _expression1 = expression1;
        _expression2 = expression2;
    }

    public double Interpret()
    {
        return _expression1.Interpret() + _expression2.Interpret();
    }
}

public class SubtractionExpression : Expression
{
    private readonly Expression _expression1;
    private readonly Expression _expression2;

    public SubtractionExpression(Expression expression1, Expression expression2)
    {
        _expression1 = expression1;
        _expression2 = expression2;
    }

    public double Interpret()
    {
        return _expression1.Interpret() - _expression2.Interpret();
    }

    

}
