using System;
using System.Collections.Generic;
using System.Text;

class ExpressionCalculator
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter the expression:");
            string expression = Console.ReadLine();
            List<Token> RPN = FromInfixToRPN(expression);
            double answer = ExecuteRPN(RPN);
            Console.WriteLine("Answer: " + answer);
        }
        catch (Exception)
        {
            Console.WriteLine("Error!");
        }
    }

    static public double ExecuteRPN(List<Token> expression)
    {
        // the stack of operators which is used to store the operands
        Stack<double> operands = new Stack<double>();

        // passing through all the tokens of the expression
        for (int i = 0; i < expression.Count; i++)
        {
            // if the token is a number - push it onto the stack.
            if (expression[i].type == TokenType.Number)
            {
                operands.Push(double.Parse(expression[i].value));
                continue;
            }

            // if the token is an operator - evaluate the operator with the poped values as operands.
            if (expression[i].type == TokenType.Operator)
            {
                switch (expression[i].value)
                {
                    case "+":
                        operands.Push(operands.Pop() + operands.Pop());
                        break;
                    case "-":
                        operands.Push(-operands.Pop() + operands.Pop());
                        break;
                    case "*":
                        operands.Push(operands.Pop() * operands.Pop());
                        break;
                    case "/":
                        operands.Push(1 / operands.Pop() * operands.Pop());
                        break;
                    case "~":
                        operands.Push(-operands.Pop());
                        break;
                    default:
                        throw new Exception("Unknown operator " + expression[i].value);
                }
            }

            // if the token is a function - evaluate the operator with the poped values as arguments.
            if (expression[i].type == TokenType.Function)
            {
                double x;
                double y;
                switch (expression[i].value)
                {
                    case "sqrt":
                        operands.Push(Math.Sqrt(operands.Pop()));
                        break;
                    case "ln":
                        operands.Push(Math.Log(operands.Pop()));
                        break;
                    case "pow":
                        y = operands.Pop();
                        x = operands.Pop();
                        operands.Push(Math.Pow(x, y));
                        break;
                    default:
                        throw new Exception("Invalid operator or function " + expression[i]);
                }
            }
        }

        // if there are more than one value in the stack -  the expression is invalid.
        if (operands.Count != 1)
        {
            throw new Exception("Invalid expression!");
        }
        else // otherwise - that value is the result of the calculation.
        {
            return operands.Pop();
        }
    }

    static List<Token> FromInfixToRPN(string expression)
    {
        // the returned list of tokens
        List<Token> output = new List<Token>();
        // the stack of operators which is used to temporarily store the operators
        Stack<Token> operators = new Stack<Token>();
        // flag which indicates whether the previous token is number. This is used when a 
        // minus sign is met to determine if it is unary minus or ordinary minus.
        bool previousIsNumeric = false;

        // passing through all the chars of the expression
        for (int index = 0; index < expression.Length; index++)
        {
            // if the token is white space
            if (expression[index] == ' ')
            {
                continue;
            }

            // if the token is number
            if (expression[index] >= '0' && expression[index] <= '9')
            {
                StringBuilder number = new StringBuilder();
                number.Append(expression[index]);
                index++;

                // looping through all the chars of the number and stores them in a StringBuilder
                while ((index < expression.Length) && ((expression[index] >= '0' && expression[index] <= '9') 
                                                    || expression[index] == '.'))
                {
                    number.Append(expression[index]);
                    index++;
                }

                output.Add(new Token(number.ToString(), TokenType.Number));
                previousIsNumeric = true;

                // if we are at the end of the expression string
                if (index >= expression.Length)
                {
                    break;
                }
            }

            // if the token is a function
            if (expression[index] >= 'a' && expression[index] <= 'z')
            {
                StringBuilder function = new StringBuilder(expression[index].ToString());
                index++;

                // looping through all the chars of the number and stores them in a StringBuilder
                while ((index < expression.Length) && (expression[index] >= 'a' && expression[index] <= 'z'))
                {
                    function.Append(expression[index]);
                    index++;
                }

                string value = function.ToString().ToLower();
                operators.Push(new Token(value.ToLower(), TokenType.Function));
                previousIsNumeric = false;

                if (index >= expression.Length)
                {
                    break;
                }
            }

            // if the token is a function argument separator (a comma):
            if (expression[index] == ',')
            {
                // until the token at the top of the stack is a left parenthesis, 
                // pops operators off the stack onto the output queue. 
                while (operators.Count > 0 && operators.Peek().type != TokenType.LeftParenthesis)
                {
                    output.Add(operators.Pop());
                }

                // if no left parentheses are encountered, either the separator was misplaced or parentheses were mismatched.
                previousIsNumeric = false;

                if (operators.Count == 0)
                {
                    throw new Exception("Parentheses mismatch or function argument separator was misplaced.");
                }

                continue;
            }

            // if the token is operator
            Token currentOperator = new Token("", TokenType.Unknown);

            // if the operator is plus or regular minus
            if (expression[index] == '+' || (expression[index] == '-' && previousIsNumeric))
            {
                currentOperator.value = expression[index].ToString();
                currentOperator.type = TokenType.Operator;
                currentOperator.precedence = 2;
            }
            else if (expression[index] == '-' && !previousIsNumeric) // if the operator is unary minus
            {
                currentOperator.value = "~";
                currentOperator.type = TokenType.Operator;
                currentOperator.precedence = 5;
            }
            else if (expression[index] == '*' || expression[index] == '/') // if the operator is multiplication or division
            {
                currentOperator.value = expression[index].ToString();
                currentOperator.type = TokenType.Operator;
                currentOperator.precedence = 3;
            }

            if (currentOperator.type == TokenType.Operator)
            {
                /* *    
                * while there is an operator token, o2, at the top of the stack and
                * either o1 is left-associative and its precedence is less than or equal to that of o2
                * or o1 has precedence less than that of o2
                * pops o2 off the stack onto the output queue;
                * */
                while (operators.Count > 0 && operators.Peek().type == TokenType.Operator)
                {
                    Token previous = operators.Peek();

                    if ((currentOperator.isLeftToRight && currentOperator.precedence <= previous.precedence) 
                                                        || currentOperator.precedence < previous.precedence)
                    {
                        output.Add(operators.Pop());
                    }
                    else
                    {
                        break;
                    }
                }

                operators.Push(currentOperator);
                previousIsNumeric = false;
                continue;
            }

            // if the token is a left parenthesis
            if (expression[index] == '(')
            {
                operators.Push(new Token("(", TokenType.LeftParenthesis));
                previousIsNumeric = false;
                continue;
            }

            // if the token is a right parenthesis
            if (expression[index] == ')')
            {
                // until the token at the top of the stack is a left parenthesis, 
                // pops operators off the stack onto the output queue.
                while (operators.Count > 0 && operators.Peek().type != TokenType.LeftParenthesis)
                {
                    output.Add(operators.Pop());
                }

                // if the stack runs out without finding a left parenthesis, then there are mismatched parentheses.
                if (operators.Count == 0)
                {
                    throw new Exception("Parentheses mismatch.");
                }

                // pops the left parenthesis from the stack, but not onto the output queue.
                operators.Pop();

                // if the token at the top of the stack is a function token, pops it onto the output queue.
                if (operators.Count > 0 && operators.Peek().type == TokenType.Function)
                {
                    output.Add(operators.Pop());
                    previousIsNumeric = true;
                }
                else 
                {
                    previousIsNumeric = false;
                }
                continue;
            }
        }

        while (operators.Count > 0)
        {
            if (operators.Peek().type == TokenType.LeftParenthesis || operators.Peek().type == TokenType.RightParenthesis)
            {
                throw new Exception("Parentheses mismatch.");
            }
            output.Add(operators.Pop());
        }

        return output;
    }
}