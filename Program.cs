using System.Numerics;

namespace EasyLine_PascalTriangle 
{
    class PascalTriangle {
        
        public static BigInteger[] PascalTriangleBinomialCoefficient(int lineNumber)
        {
            int currentNumber = 1;
            BigInteger[] coefficients =  Array.Empty<BigInteger>();
            for(int line = lineNumber; line <= lineNumber; line++)
            {
                for(int counter = 1; counter <= line; counter++)
                {
                    coefficients = coefficients.Append(currentNumber).ToArray();
                    currentNumber = currentNumber * (line - counter) / counter;
                }
            }
            return coefficients;
        }

        public static void DrawPascalTriangle(int lines)
        {
            int value = 1;
            Console.WriteLine("\n Pascal's Triangle");
            for(int verticalLines = 0; verticalLines<lines; verticalLines++)
            {
                for(int space = 1; space <= lines-verticalLines; space++) Console.Write(" ");
                for(int horizontalLines = 0; horizontalLines <= verticalLines; horizontalLines++) 
                {
                    if (horizontalLines == 0 ||verticalLines == 0) value = 1;
                    else value = value*(verticalLines-horizontalLines+1)/horizontalLines;
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
        }
        
        public static BigInteger CalculateSquareOfCoefficients(BigInteger[] coefficients)
        {
            BigInteger sum = 0;
            for(int i=0; i<coefficients.Length; i++) coefficients[i] *= coefficients[i];
            foreach (BigInteger items in coefficients) sum+=items;
            return sum;
        }
            
        public static void Main()
        {
            while (true)
            {
                Console.Write("\nEnter the line number (enter \"-1\" to quit): ");
                    BigInteger[] coefArray = Array.Empty<BigInteger>();
                    try
                    {
                        int lineLength = int.Parse(Console.ReadLine()!);
                        if (lineLength == -1) Environment.Exit(0);
                        if (lineLength >= 0)
                        {
                            coefArray = PascalTriangleBinomialCoefficient(lineLength + 1);
                            Console.WriteLine("The Answer is: {0}", CalculateSquareOfCoefficients(coefArray));
                            Console.WriteLine("\nDo You want to see the Pascal's Triangle? (Y/N)");
                            string answer = Console.ReadLine()!.ToLower();
                            if (answer == "y") DrawPascalTriangle(lineLength + 1);
                            if (answer == "n") {Console.WriteLine("\nSee you later!"); Environment.Exit(0); }
                            else
                            {
                                Console.WriteLine("\nDo you want to continue? (Y/N)");
                                string showMustGoOn = Console.ReadLine()!.ToLower();
                                if (showMustGoOn == "y") continue;
                                Console.WriteLine("\nSee you later!"); Environment.Exit(0);
                            }
                            
                        }
                        else Console.WriteLine("\nPlease enter a Positive number!");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nInvalid input. Try again.");
                    }
            }

        }
    }
}