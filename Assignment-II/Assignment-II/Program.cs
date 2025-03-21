using System;

//Simple Calculator
namespace Assignment_II
{
    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("\nCalculator Menu");
            Console.WriteLine("1. Add Numbers");
            Console.WriteLine("2. Subtract Numbers");
            Console.WriteLine("3. Multiply Numbers");
            Console.WriteLine("4. Divide Numbers");
            Console.WriteLine("5. Calculate Percentage");
            Console.WriteLine("6. Quit");
            Console.Write("Select operation: ");
        }

        static void HandleNumbers(int choice)
        {
            Console.Write("Enter first number: ");
            var num1 = GetNumber();
            Console.Write("Enter second number: ");
            var num2 = GetNumber();

            if (num1.isInt && num2.isInt)
            {
                RunIntOperation(choice, num1.intValue, num2.intValue);
            }
            else
            {
                RunDoubleOperation(choice, num1.doubleValue, num2.doubleValue);
            }
        }

        static (bool isInt, int intValue, double doubleValue) GetNumber()
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int i)) return (true, i, i);
            if (double.TryParse(input, out double d)) return (false, 0, d);
            Console.WriteLine("Invalid number, using 0");
            return (true, 0, 0);
        }

        static void RunIntOperation(int choice, int a, int b)
        {
            switch (choice)
            {
                case 1: Console.WriteLine($"Result: {a + b}"); break;
                case 2: Console.WriteLine($"Result: {a - b}"); break;
                case 3: Console.WriteLine($"Result: {a * b}"); break;
                case 4:
                    if (b == 0) Console.WriteLine("Cannot divide by zero");
                    else Console.WriteLine($"Result: {(double)a / b}");
                    break;
            }
        }

        static void RunDoubleOperation(int choice, double a, double b)
        {
            switch (choice)
            {
                case 1: Console.WriteLine($"Result: {a + b}"); break;
                case 2: Console.WriteLine($"Result: {a - b}"); break;
                case 3: Console.WriteLine($"Result: {a * b}"); break;
                case 4:
                    if (b == 0) Console.WriteLine("Cannot divide by zero");
                    else Console.WriteLine($"Result: {a / b}");
                    break;
            }
        }

        static void HandlePercentage()
        {
            Console.Write("Enter total value: ");
            var total = GetNumber();
            Console.Write("Enter obtained value: ");
            var obtained = GetNumber();

            if (total.doubleValue == 0)
            {
                Console.WriteLine("Total cannot be zero");
                return;
            }

            double percentage = (obtained.doubleValue / total.doubleValue) * 100;
            Console.WriteLine($"Percentage: {percentage:F2}%");
        }

        static void Main()
        {
            int choice;
            do
            {
                ShowMenu();
                choice = int.Parse(Console.ReadLine());

                if (choice == 5) HandlePercentage();
                else if (choice >= 1 && choice <= 4) HandleNumbers(choice);

            } while (choice != 6);
        }
    }
}
