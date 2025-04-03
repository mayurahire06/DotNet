using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            while (true)
            {
                Console.WriteLine("1: Filter a List of Numbers using Linq");
                Console.WriteLine("2: Selecting names from a list of objects");
                Console.WriteLine("3: Ordering a list of Strings");
                Console.WriteLine("4: Find the First Person that Meets a Condition");
                Console.WriteLine("5: Exit");
                Console.WriteLine("\nEnter your Choice:");

                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            FilterList();
                            break;
                        case 2:
                            SelectNames();
                            break;
                        case 3:
                            OrderStrings();
                            break;
                        case 4:
                            FindFirstPerson();
                            break;
                        case 5:
                            Console.WriteLine("Exiting the program.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

        static void FilterList()
        {
            Console.WriteLine("Filtering a List of Numbers:");
            List<int> list = new List<int>() { 10, 5, 20, 15, 25 };

            // Use LINQ to filter the list (numbers greater than 12)
            IEnumerable<int> list2 = list.Where(list1 => list1 > 12);
            foreach (int s in list2)
            {
                Console.WriteLine(s);
            }
        }

        static void SelectNames()
        {
            Console.WriteLine("Selecting names from a list of objects:");

            // Sample list of people objects
            List<Person> people = new List<Person>(){
                new Person { Name = "John", Age = 28 },
                new Person { Name = "Jane", Age = 24 },
                new Person { Name = "Tom", Age = 32 },
                new Person { Name = "Emily", Age = 22 }
            };

            // Use LINQ to select names
            var names = people.Select(p => p.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        static void OrderStrings()
        {
            Console.WriteLine("Ordering a list of Strings:");

            // Sample list of strings
            List<string> fruits = new List<string>() { "Apple", "Orange", "Banana", "Mango", "Grapes" };

            // Use LINQ to order the strings in ascending order
            var orderedFruits = fruits.OrderBy(fruit => fruit);

            Console.WriteLine("Fruits in ascending order:");
            foreach (var fruit in orderedFruits)
            {
                Console.WriteLine(fruit);
            }

            // Alternatively, to order in descending order:
            var orderedFruitsDesc = fruits.OrderByDescending(fruit => fruit);

            Console.WriteLine("\nFruits in descending order:");
            foreach (var fruit in orderedFruitsDesc)
            {
                Console.WriteLine(fruit);
            }
        }

        // Method to find the first person that meets a condition
        static void FindFirstPerson()
        {
            Console.WriteLine("Enter an age to find the first person older than that age:");

            // Read input for the age condition
            int ageCondition;
            if (int.TryParse(Console.ReadLine(), out ageCondition))
            {
                // Sample list of people objects
                List<Person> people = new List<Person>()
                {
                    new Person { Name = "John", Age = 28 },
                    new Person { Name = "Jane", Age = 24 },
                    new Person { Name = "Tom", Age = 32 },
                    new Person { Name = "Emily", Age = 22 }
                };

                // Use LINQ to find the first person who is older than the specified age
                var firstPerson = people.FirstOrDefault(p => p.Age > ageCondition);

                if (firstPerson != null)
                {
                    Console.WriteLine($"First person older than {ageCondition}: {firstPerson.Name}, Age: {firstPerson.Age}");
                }
                else
                {
                    Console.WriteLine($"No person found older than {ageCondition}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid age.");
            }
        }
    }

    // Person class to represent an object with Name and Age
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}