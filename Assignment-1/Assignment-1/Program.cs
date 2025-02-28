using System;
using System.IO;
using System.Globalization;
using System.Linq; // Added for LINQ operations

namespace Assignment_1
{
    internal class TypeCasting
    {
        public static void PerformTypeCasting()
        {
            Console.Write("Enter input to convert: ");
            string input = Console.ReadLine();

            TryConvert<int>(input, "Integer");
            TryConvert<bool>(input, "Boolean");
            TryConvert<double>(input, "Double");
            TryConvert<decimal>(input, "Decimal");
            TryConvert<DateTime>(input, "DateTime");
        }

        private static void TryConvert<T>(string input, string typeName)
        {
            try
            {
                // Use invariant culture for consistent conversions
                T value = (T)Convert.ChangeType(input, typeof(T), CultureInfo.InvariantCulture);
                Console.WriteLine($"{typeName} value: {value}");
            }
            catch (Exception ex) when (ex is InvalidCastException ||
                                      ex is FormatException ||
                                      ex is OverflowException ||
                                      ex is ArgumentNullException)
            {
                Console.WriteLine($"Input is not a valid {typeName}.");
            }
        }
    }

    internal class StringManipulation
    {
        public static void PerformStringOperations()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine() ?? string.Empty; // Handle null input

            Console.WriteLine($"Uppercase: {input.ToUpper()}");
            Console.WriteLine($"Lowercase: {input.ToLower()}");
            Console.WriteLine($"Trimmed: '{input.Trim()}'");
            Console.WriteLine($"Replaced 'l' with '*': {input.Replace('l', '*')}");

            // Improved count using LINQ
            int count = input.Count(c => c == 'l');
            Console.WriteLine($"Number of 'l' in the string: {count}");

            Console.WriteLine($"Formatted output: {string.Join("*", input.ToCharArray())}");
        }
    }

    internal class FileOperations
    {
        private const string FilePath = "output.txt";

        public static void AppendToFile()
        {
            try
            {
                DisplayCurrentFileContents();

                Console.Write("Enter text to append: ");
                string input = Console.ReadLine() ?? string.Empty;

                AppendTextToFile(input);
                DisplayUpdatedFileContents();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Operation failed: {ex.Message}");
            }
        }

        private static void DisplayCurrentFileContents()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    Console.WriteLine("Current file contents:");
                    Console.WriteLine(File.ReadAllText(FilePath));
                }
                else
                {
                    Console.WriteLine("File doesn't exist. Creating new file.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Read error: {ex.Message}");
            }
        }

        private static void AppendTextToFile(string input)
        {
            try
            {
                File.AppendAllText(FilePath, input + Environment.NewLine);
                Console.WriteLine("Text appended successfully.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: Missing write permissions.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Write error: {ex.Message}");
            }
        }

        private static void DisplayUpdatedFileContents()
        {
            try
            {
                Console.WriteLine("Updated contents:");
                Console.WriteLine(File.ReadAllText(FilePath));
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Read error: {ex.Message}");
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu:\n1. Type Conversion\n2. String Operations\n3. File Append\n4. Exit");
                Console.Write("Select option (1-4): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        TypeCasting.PerformTypeCasting();
                        break;
                    case "2":
                        StringManipulation.PerformStringOperations();
                        break;
                    case "3":
                        FileOperations.AppendToFile();
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}