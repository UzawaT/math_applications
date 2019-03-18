using System;

namespace IntegratePolynomial
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare variables
            int degree;
            double startPoint;
            double endPoint;
            double segments;
            bool validEntry = false;

            //display program description
            Console.WriteLine("--- Integration Calculator for Polynomial ---");
            Console.WriteLine("This program numerically calculates the integral of a polynomial at a given point.");

            //ask the user to enter the degree of polynomial
            Console.Write("Enter the degree of polynomial: ");

            //check for valid entry
            validEntry = int.TryParse(Console.ReadLine(), out degree);

            //ask the user to re-enter
            while (!validEntry || (degree < 0))
            {
                Console.Write("Invalid entry. Please re-enter the degree of polynomial: ");
                validEntry = int.TryParse(Console.ReadLine(), out degree);
            }

            //declare an array to hold the coefficients
            double[] coeff = new double[degree + 1];

            //ask the user to enter the coefficient values
            for (int i = degree; i >= 0; i--)
            {
                validEntry = false;

                while (!validEntry)
                {
                    Console.Write($"Enter the coefficient for x^{i}: ");
                    validEntry = double.TryParse(Console.ReadLine(), out coeff[i]);
                }
            }

            //display the equation entered
            DisplayPolynomial(degree, coeff);

            //ask the user to enter the starting point to calculate derivative
            Console.Write("Enter the value for starting point: ");
            validEntry = double.TryParse(Console.ReadLine(), out startPoint);

            if (!validEntry)
            {
                Console.Write("Invalid entry. Please re-enter the value for the staring point: ");
                validEntry = double.TryParse(Console.ReadLine(), out startPoint);
            }

            //ask the user to enter the end point to calculate derivative
            Console.Write("Enter the value for ending point: ");
            validEntry = double.TryParse(Console.ReadLine(), out endPoint);

            if (!validEntry || (endPoint < startPoint))
            {
                Console.Write("Invalid entry. Please re-enter the value for the ending point: ");
                validEntry = double.TryParse(Console.ReadLine(), out endPoint);
            }

            Console.WriteLine($"start = {startPoint}, end = {endPoint}");
            for (int i = 1; i <= 5; i++)
            {
                segments = Math.Pow(10, i);
                Console.WriteLine($"Answer({segments} segments): {CalculateIntegral(degree, coeff, startPoint, endPoint, segments).ToString("f5")}");
            }

            Console.Read();
        }

        public static void DisplayPolynomial(int degree, double[] coeff)
        {
            Console.Write("Equation: f(x) = ");
            for (int i = degree; i >= 0; i--)
            {
                Console.Write($"{coeff[i]}x^{i}");

                if (i != 0)
                {
                    Console.Write(" + ");
                }
            }
            Console.WriteLine();
        }

        //integration using trapezoid method
        public static double CalculateIntegral(int degree, double[] coeff, double start, double end, double segments)
        {
            double answer = 0;
            double leftVal;
            double rightVal;
            double leftHeight = 0;
            double rightHeight = 0;
            double segmentWidth = (end - start) / segments;

            for (int i = 0; i < segments; i++)
            {
                leftHeight = 0;
                rightHeight = 0;
                leftVal = start + i * segmentWidth;
                rightVal = leftVal + segmentWidth;

                for (int j = degree;  j >= 0; j--)
                {
                    leftHeight += coeff[j] * Math.Pow(leftVal, j);
                    rightHeight += coeff[j] * Math.Pow(rightVal, j);
                }

                answer += (leftHeight + rightHeight) * segmentWidth / 2;
            }

            return answer;
        }
    }
}
