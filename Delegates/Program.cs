public delegate void ReqtangleHelper(decimal width, decimal height);
internal class Program
{
    private static void Main(string[] args)
    {
        var employees = new Employee[]
        {
            new Employee { Id = 1, Name = "John", TotalSales = 17000.50m, Gender = "m" },
            new Employee { Id = 2, Name = "Jane", TotalSales = 12000.75m, Gender = "f" },
            new Employee { Id = 3, Name = "Mahmoud", TotalSales = 6000.21m, Gender = "m" },
            new Employee { Id = 4, Name = "Alice", TotalSales = 8000.00m, Gender = "f" },
            new Employee { Id = 5, Name = "Bob", TotalSales = 15500.00m, Gender = "m" },
            new Employee { Id = 6, Name = "Sara", TotalSales = 9000.50m, Gender = "f" },
            new Employee { Id = 7, Name = "David", TotalSales = 11000.25m, Gender = "m" },
            new Employee { Id = 8, Name = "Mary", TotalSales = 7500.00m, Gender = "f" },
            new Employee { Id = 9, Name = "Tom", TotalSales = 1500.75m, Gender = "m" },
            new Employee { Id = 10, Name = "Emily", TotalSales = 19400.00m, Gender = "f" }
        };


        var report = new Report();

        //report.GenerateReport(employees, " LessThan10k", LessThan10k);
        //report.GenerateReport(employees, " Over10kLessThan15k", Over10kLessThan15k);
        //report.GenerateReport(employees, " Over15", Over15);
        // Lamda Expression → => 
        report.GenerateReport(employees, " LessThan10k", e => e.TotalSales < 10000.0m);
        report.GenerateReport(employees, " Over10kLessThan15k", e => e.TotalSales >= 10000.0m && e.TotalSales < 150000.0m);
        report.GenerateReport(employees, " Over15", e => e.TotalSales >= 15000.0m);


        // multicast delegate
        Reqtangle reqtangle = new Reqtangle { Width = 10.0m, Height = 12.0m };
        ReqtangleHelper reqtangleHelper;
        reqtangleHelper = reqtangle.GetArea;
        reqtangleHelper += reqtangle.GetParameter;
        reqtangleHelper(10.0m, 15.0m);
        Reprint(reqtangleHelper, reqtangle);
        Console.ReadKey();
    }

    // delegate allow to pass functions as an arguments
    // functions shouid have the same prototype as delegate
    static bool LessThan10k(Employee e) => e.TotalSales < 10000.0m;
    static bool Over10kLessThan15k(Employee e) => e.TotalSales >= 10000.0m && e.TotalSales < 150000.0m;
    static bool Over15(Employee e) => e.TotalSales >= 15000.0m;
    static void Reprint(ReqtangleHelper rect, Reqtangle R)
    {
        Console.WriteLine("\n\npass them as an arguments");
        Console.WriteLine("....................");
        rect(R.Width, R.Height);
    }

}

public class Reqtangle
{
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public void GetArea(decimal width, decimal height)
    {
        Console.WriteLine($"Reqtangle ({width}x{height}) Area is: {width * height} m^2");
    }
    public void GetParameter(decimal width, decimal height)
    {
        Console.WriteLine($"Reqtangle ({width}x{height}) Parameter is: {2 * (width + height)} m");
    }
}
