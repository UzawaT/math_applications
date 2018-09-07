using System;

namespace DerivativePolynomial
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare variables
            int degree;
            double point;
            double delta;
            bool validEntry = false;

            //display program description
            Console.WriteLine("--- Derivative Calculator for Polynomial ---");
            Console.WriteLine("This program numerically calculates the derivative of a polynomial at a given point.");

            //ask the user to enter the degree of polynomial
            Console.Write("Enter the degree of polynomial: ");

            //check for valid entry
            validEntry = int.TryParse(Console.ReadLine(), out degree);

            //ask the user to re-enter
            while (!validEntry || degree < 0)
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

            //ask the user to enter the point to calculate derivative
            Console.Write("Enter the point where you want to calculate derivative: ");
            validEntry = double.TryParse(Console.ReadLine(), out point);

            if (!validEntry)
            {
                Console.Write("Invalid entry. Please re-enter the point where you want to calculate derivative: ");
                validEntry = double.TryParse(Console.ReadLine(), out point);
            }
            Console.WriteLine($"Answer: {CalculateDerivativeActual(degree, coeff, point)}");

            for (int i = 0; i < 5; i++)
            {
                delta = Math.Pow(10, (-1.0 * i));
                Console.WriteLine($"Answer(delta = {delta}): {CalculateDerivative(degree, coeff, point, delta).ToString("f5")}");
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

        //calculate derivative using (f(x + delta) - f(x))/delta
        public static double CalculateDerivative(int degree, double[] coeff, double point, double delta)
        {
            //declare variable
            double answer = 0;
            double f_x = 0;
            double f_x_plus_delta = 0;

            //calculate value
            for (int i = degree; i >= 0; i--)
            {
                f_x += coeff[i] * Math.Pow(point, i);
                f_x_plus_delta += coeff[i] * Math.Pow((point + delta), i);
            }

            //calculate derivative
            answer = (f_x_plus_delta - f_x) / delta;

            return answer;
        }

        public static double CalculateDerivativeActual(int degree, double[] coeff, double point)
        {
            //declare variable
            double answer = 0;

            //calculate value
            for (int i = degree; i > 0; i--)
            {
                answer += coeff[i] * i * Math.Pow(point, i - 1);
            }

            return answer;
        }
    }
}
