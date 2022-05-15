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
        
        public static void CalculateSquareOfCoefficients(BigInteger[] coefficients)
        {
            BigInteger sum = 0;
            for(int i=0; i<coefficients.Length; i++) coefficients[i] *= coefficients[i];
            foreach (BigInteger items in coefficients) sum+=items;
            Console.WriteLine("\nAnswer: {0} ", sum);
        }
            
        public static void Main()
        {
            try
            {
                Console.Write("\nEnter the line number: ");
                BigInteger[] coefArray =  Array.Empty<BigInteger>();
                int lineLength = Int32.Parse(Console.ReadLine()!);
                coefArray = PascalTriangleBinomialCoefficient(lineLength + 1);
                CalculateSquareOfCoefficients(coefArray);
                Console.WriteLine("\nDo You want to see the Pascal's Triangle? (Y/N)");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y") DrawPascalTriangle(lineLength + 1);
                else Console.WriteLine("\nGoodbye!");
            }
            catch (Exception)
            {
                Console.WriteLine("Please Enter a valid number");
            }
            
        }
    }
}