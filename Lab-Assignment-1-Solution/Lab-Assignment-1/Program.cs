using System;

namespace Lab_Assignment_1
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Shuffle first and last characters of a string");
                Console.WriteLine("2. Calculate sum of digits in a number");
                Console.WriteLine("3. Check if a number is palindrome");
                Console.WriteLine("4. Calculate square root of a number");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ShuffleFirstLastCharacters();
                        break;
                    case 2:
                        CalculateDigitSum();
                        break;
                    case 3:
                        CheckPalindrome();
                        break;
                    case 4:
                        CalculateSquareRoot();
                        break;
                    case 5:
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1-5.");
                        break;
                }
            }
        }

        static void ShuffleFirstLastCharacters()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            if (input.Length <= 1)
            {
                Console.WriteLine("The string is too short to shuffle first and last characters.");
                return;
            }

            char firstChar = input[0];
            char lastChar = input[input.Length - 1];
            string shuffledString = lastChar + input.Substring(1, input.Length - 2) + firstChar;

            Console.WriteLine($"Original string: {input}");
            Console.WriteLine($"Shuffled string: {shuffledString}");
        }

        static void CalculateDigitSum()
        {
            Console.Write("Enter a multi-digit integer: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return;
            }

            number = Math.Abs(number);
            int sum = 0;
            int temp = number;

            while (temp > 0)
            {
                sum += temp % 10;
                temp /= 10;
            }

            Console.WriteLine($"The sum of digits in {number} is: {sum}");
        }

        static void CheckPalindrome()
        {
            Console.Write("Enter a number to check for palindrome: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return;
            }

            // Without recursion
            int original = number;
            int reversed = 0;
            while (number > 0)
            {
                reversed = reversed * 10 + number % 10;
                number /= 10;
            }
            bool isPalindrome = original == reversed;

            // With recursion
            string numStr = original.ToString();
            bool isPalindromeRecursive = IsPalindromeRecursive(numStr, 0, numStr.Length - 1);

            Console.WriteLine($"Without recursion: {original} is {(isPalindrome ? "" : "not ")}a palindrome");
            Console.WriteLine($"With recursion: {original} is {(isPalindromeRecursive ? "" : "not ")}a palindrome");
        }

        static bool IsPalindromeRecursive(string str, int left, int right)
        {
            if (left >= right)
                return true;
            if (str[left] != str[right])
                return false;
            return IsPalindromeRecursive(str, left + 1, right - 1);
        }

        static void CalculateSquareRoot()
        {
            Console.Write("Enter a number to calculate its square root: ");
            string input = Console.ReadLine();

            if (!double.TryParse(input, out double number))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            try
            {
                if (number < 0)
                    throw new ArgumentException("Cannot calculate square root of a negative number.");

                double sqrt = Math.Sqrt(number);
                Console.WriteLine($"Square root of {number} is: {sqrt:F4}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

}

