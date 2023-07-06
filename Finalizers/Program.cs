using System;

internal class Program
{
    private static void Main(string[] args)
    {
        MakeGarpdge();

        Console.WriteLine($"Before {GC.GetTotalMemory(false):N}"); // Before 1,921,360.00

        GC.Collect(); // calling finalizers ~Person()
        GC.WaitForPendingFinalizers();
        Console.WriteLine($"After {GC.GetTotalMemory(true):N}"); // After 524,400.00
        Console.ReadKey();
    }

    static void MakeGarpdge()
    {
        Person p;
        for (int i = 0; i < 1000; i++)
        {
            p = new Person();
            p.Name = $"{i}: mah-hassn";
        }
    }
}

public class Person
{
    public string Name { get; set; } = "";

    public void print()
    {
        Console.WriteLine(this.Name);
    }
    ~Person()
    {
        // excuted when obj is Disposed
        Console.WriteLine("Good bye! " + this.Name);
    }
}
