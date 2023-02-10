namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.Write("Write the equation: ");
                input = Console.ReadLine()!;
            }
            while (input == string.Empty);
            input = input.Replace(" ", "");

            OperationSplitter(input);
        }

        static string OperationSplitter(string input)
        {
            char[] operations = { '+', '-', '*', '/' };
            string operation = "";
            int startPoint = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    OperationSplitter(input[(i + 1)..]);
                }
                else if (char.IsDigit(input[i]) || (operations.Contains(input[i]) && !operation.Any(c => operations.Contains(c))))
                {
                    if (startPoint == -1)
                    {
                        startPoint = i;
                    }
                    operation += input[i];
                }
                if (input[i] == ')' || i == input.Length - 1 || ((operations.Contains(input[i]) && !operation.Any(c => operations.Contains(c)))))
                {
                    
                }
            }
            return "";
        }

        static int Equation(int value1, char operation, int value2)
        {
            switch (operation)
            {
                case '+':
                    return value1 + value2;

                case '-':
                    return value1 - value2;

                case '*':
                    return value1 * value2;

                case '/':
                    return value1 / value2;

                default:
                    throw new Exception();
            }
        }
    }
}