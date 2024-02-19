using System;
using System.Collections.Generic;

abstract class Expression
{
    public abstract int Interpret();
}

class NumberExpression : Expression
{
    private int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }

    public override int Interpret()
    {
        return _number;
    }
}

class AdditionExpression : Expression
{
    private Expression _left;
    private Expression _right;

    public AdditionExpression(Expression left, Expression right)
    {
        _left = left;
        _right = right;
    }

    public override int Interpret()
    {
        return _left.Interpret() + _right.Interpret();
    }

   
}

class SubtractionExpression : Expression
{
    private Expression _left;
    private Expression _right;

    public SubtractionExpression(Expression left, Expression right)
    {
        _left = left;
        _right = right;
    }

    public override int Interpret()
    {
        return _left.Interpret() - _right.Interpret();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number, operation '+' or '-', second number and press Enter:");
        string input = Console.ReadLine();

        string[] tokens = input.Split(' ');

        if (tokens.Length != 3)
        {
            Console.WriteLine("Invalid expression format");
            return;
        }

        if (!int.TryParse(tokens[0], out int firstNumber) || !int.TryParse(tokens[2], out int secondNumber))
        {
            Console.WriteLine("Invalid number format");
            return;
        }

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
                Console.WriteLine("Unsupported operation");
                return;
        }
        Console.WriteLine($"Result: {expression.Interpret()}");
    }
}
