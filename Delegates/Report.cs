
public class Report
{
    public delegate bool IllegableSales(Employee employee);
    public void GenerateReport(Employee[] employees, string tital, IllegableSales isIllegable)
    {
        Console.WriteLine(tital);
        Console.WriteLine(" .................\n");
        foreach (Employee e in employees)
        {
            if (isIllegable(e))
                Console.WriteLine($" ID: {e.Id} | Name: {e.Name} | Gender: {e.Gender} | TotalSales: {e.TotalSales}");
        }
        Console.WriteLine("\n");

    }
}