﻿using System.Numerics;

namespace EasyLine_PascalTriangle 
{
    class PascalTriangle {
        
        public static BigInteger[] PascalTriangleBinomialCoefficient(int lineNumber)
        {
            int currentNumber = 1;
            BigInteger[] coefficients =  Array.Empty<BigInteger>();
            for(int line = lineNumber; line <= lineNumber; line++)
            {
                for(int i = 1; i <= line; i++)
                {
                    coefficients = coefficients.Append(currentNumber).ToArray();
                    currentNumber = currentNumber * (line - i) / i;
                }
            }
            return coefficients;
        }

        public static void DrawPascalTriangle(int lines)
        {
            int value = 1;
            Console.WriteLine("\n Pascal's Triangle");
            for(int i = 0; i<lines; i++)
            {
                for(int space = 1; space <= lines-i; space++) Console.Write(" ");
                for(int j = 0; j <= i; j++) 
                {
                    if (j == 0||i == 0) value = 1;
                    else value = value*(i-j+1)/j;
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
            BigInteger[] coefArray =  Array.Empty<BigInteger>();
            Console.Write("\nEnter the line number: ");
            try
            {
                int lineLength = Int32.Parse(Console.ReadLine());
                coefArray= PascalTriangleBinomialCoefficient(lineLength+1);
                CalculateSquareOfCoefficients(coefArray);
                Console.WriteLine("\nDo You want to see the Pascal's Triangle? (Y/N)");
                string answer = Console.ReadLine();
                if (answer == "Y" || answer== "y") DrawPascalTriangle(lineLength+1);
                else Console.WriteLine("\nGoodbye!");
            }
            catch (Exception)
            {
                Console.WriteLine("Please Enter a valid number");
            }
        }
    }
}