internal class Program
{
    private static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee{Id = 1 , Name = "John", Rule = "CEO", ReportTo = null},
            new Employee{Id = 2 , Name = "Jane", Rule = "COO", ReportTo = 1},
            new Employee{Id = 3 , Name = "Bob", Rule = "CFO", ReportTo = 1},
            new Employee{Id = 4 , Name = "Alice", Rule = "CTO", ReportTo = 1},
            new Employee{Id = 5 , Name = "Tom", Rule = "Manager", ReportTo = 2},
            new Employee{Id = 6 , Name = "Jerry", Rule = "Manager", ReportTo = 2},
            new Employee{Id = 6 , Name = "Jerry", Rule = "Manager", ReportTo = 2},
            new Employee{Id = 8 , Name = "Sara", Rule = "Manager", ReportTo = 3},
            new Employee{Id = 9 , Name = "David", Rule = "Manager", ReportTo = 4},
            new Employee{Id = 10, Name = "Emily", Rule = "Manager", ReportTo = 4},
        };
        Console.WriteLine("Before Adding Range Count: " + employees.Count + "\t capacity: " + employees.Capacity);
        Employee[] emps = new Employee[]
        {
            new Employee{Id = 11, Name = "Alex", Rule = "Team Lead", ReportTo = 5},
            new Employee{Id = 12, Name = "Sophie", Rule = "Team Lead", ReportTo = 5},
            new Employee{Id = 13, Name = "Max", Rule = "Team Lead", ReportTo = 6},
            new Employee{Id = 14, Name = "Lily", Rule = "Team Lead", ReportTo = 6},
            new Employee{Id = 15, Name = "Chris", Rule = "Team Lead", ReportTo = 7},
            new Employee{Id = 16, Name = "Alice", Rule = "Backend Developer", ReportTo = 10},
            new Employee{Id = 17, Name = "Bob", Rule = "Frontend Developer", ReportTo = 11},
            new Employee{Id = 18, Name = "Ali", Rule = "Backend Developer", ReportTo = 10},
            new Employee{Id = 19, Name = "Ahmed", Rule = "Frontend Developer", ReportTo = 11},
        };
        employees.AddRange(emps);
        Console.WriteLine("After Adding Range Count: " + employees.Count + "\t capacity: " + employees.Capacity);
        // when reaching the bound capacity is doubled"x2" her it was 16 became 32
        // count represent actual number of elements in lis

        employees.RemoveAll(x => x.Rule == "Team Lead");
        Console.WriteLine("After removing Range Count: " + employees.Count + "\t capacity: " + employees.Capacity);

        //foreach (Employee emp in employees)
        //{           
        //    Console.WriteLine(emp.ToString());
        //}
        employees.Remove(new Employee { Id = 6, Name = "Jerry", Rule = "Manager", ReportTo = 2 });
        Console.WriteLine("After removing one item Count: " + employees.Count + "\t capacity: " + employees.Capacity);

        employees.Remove(new Employee { Id = 6, Name = "Jerry", Rule = "Manager", ReportTo = 2 });
        Console.WriteLine("After removing again Count: " + employees.Count + "\t capacity: " + employees.Capacity);
        // so when removing,inserting it`s bad fpr performance becouse it shifts the entiry items upon the removed or inserted
        Console.WriteLine("at index 5 " + employees[5]);
    }
}

internal class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Rule { get; set; }
    public int? ReportTo { get; set; }

    public override string ToString()
    {
        return $"ID: {Id} \nName: {Name} \nRule: {Rule} \nReportTo: {ReportTo}";
    }
    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 7) + Id.GetHashCode();
        hash = (hash * 7) + Name.GetHashCode();
        hash = (hash * 7) + Rule.GetHashCode();
        hash = (hash * 7) + ReportTo.GetHashCode();
        return hash;
    }

    public override bool Equals(object? obj)
    {
        Employee? emp = obj as Employee;
        return emp is { } && this.Id == emp.Id
            && this.Name == emp.Name
            && this.Rule == emp.Rule
            && this.ReportTo == emp.ReportTo;
    }
}