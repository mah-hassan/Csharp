internal class Program
{
    private static void Main(string[] args)
    {

        Employee employee1 = new Employee()
        {
            Id = 1,
            Name = "mahmoud",
            Title = "back-end developer",
            Department = "IT",
            Salary = 7500.0m
        };
        Employee employee2 = new Employee()
        {
            Id = 1,
            Name = "mahmoud",
            Title = "back-end developer",
            Department = "IT",
            Salary = 7500.0m
        };
        Employee employee3 = employee1;
        Console.WriteLine(employee1 == employee2); // false compare references(by default) except in string case
        Console.WriteLine(employee1 == employee3); // true compare references(also by defuilt) except in string case
        // both give true after we applayed Equals() and override == , !=
        Integers ints = new Integers(1, 2, 3);
        foreach (var i in ints)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine();

        // IComparable
        Random random = new Random();
        var temps = new List<Temperture>();
        for (int i = 0; i < 100; i++)
        {
            temps.Add(new Temperture(random.Next(-30, 50)));
        }

        temps.Sort();

        foreach (var i in temps)
        {
            Console.Write(i + "  ");
        }
        Console.ReadKey();
    }
}