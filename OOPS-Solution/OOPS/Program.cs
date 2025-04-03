using System;

// Interface Declaration
interface IEmployee
{
    void ShowDetails();
}

// Base Class
class Employee : IEmployee
{
    public string Name;
    public int ID;
    public static string Company = "Josh";

    // Public Constructor
    public Employee(string name, int id)
    {
        Name = name;
        ID = id;
        Console.WriteLine("Employee Constructor Called");
    }

    // Private Constructor (Not directly accessible)
    private Employee()
    {
        Console.WriteLine("Private Constructor Called");
    }

    // Static Constructor
    static Employee()
    {
        Console.WriteLine("Static Constructor Called - Initializing Company Data");
    }

    // Virtual Method
    public virtual void ShowDetails()
    {
        Console.WriteLine($"Employee: {Name}, ID: {ID}, Company: {Company}");
    }
}

// Derived Class
class Manager : Employee
{
    public string Department;

    // Constructor
    public Manager(string name, int id, string dept) : base(name, id)
    {
        Department = dept;
    }

    // Overriding the Base Class Method
    public override void ShowDetails()
    {
        Console.WriteLine($"Manager: {Name}, ID: {ID}, Department: {Department}, Company: {Company}");
    }
}

// Another Derived Class Using 'new' Keyword
class Intern : Employee
{
    public int Duration;

    public Intern(string name, int id, int duration) : base(name, id)
    {
        Duration = duration;
    }

    // Using 'new' to hide base class method
    public new void ShowDetails()
    {
        Console.WriteLine($"Intern: {Name}, ID: {ID}, Duration: {Duration} months, Company: {Company}");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Console.WriteLine("==== OOPS Implementation in C# ====");

        Employee emp = new Employee("Alice", 101);
        emp.ShowDetails();

        Manager mgr = new Manager("Bob", 102, "IT");
        mgr.ShowDetails();

        Intern intern = new Intern("Charlie", 103, 6);
        intern.ShowDetails();
    }
}