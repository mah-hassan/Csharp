using System.Linq;

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

        var managers = employees.ToLookup(x => x.Rule).ToDictionary(x => x.Key, x => x.ToList());

        foreach (var item in managers)
        {

            Console.WriteLine($"\n{item.Key}: ");
            foreach (var employee in item.Value)
            {
                Console.Write(employee);
            }
        }
    }
}