internal class Program
{
    private static void Main(string[] args)
    {
        Date date1 = new Date(2002);        // Constractor OverLoading
        Date date2 = new Date(10, 8, 2002); // Constractor OverLoading

        Console.WriteLine(date1.displayDate());
        Console.WriteLine(date2.displayDate());

        // create Employee obj with Factory Method
        Employee e1 = Employee.Creat("Mahmoud", "Hassan", 200356);
        Console.Write(e1.printEmpINfo());

        Console.ReadKey();

    }

}

// factory method and private constractor.
// you can only create objects with factory method
public class Employee
{
    private string fname;
    private string lname;
    private int id;

    private Employee(string fname, string lname, int id)
    {
        this.fname = fname;
        this.lname = lname;
        this.id = id;
    }
    public static Employee Creat(string fname, string lname, int id)
    {
        return new Employee(fname, lname, id);
    }
    public string printEmpINfo() => $" ID : {id} \n first name : {fname} \n last name : {lname} ";

}

// date problem
public class Date
{
    private int day = 1;
    private int month = 1;
    private int year = 1;

    private static readonly int[] daysNonLeapYear = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    private static readonly int[] daysLeapYear = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    public Date(int day, int month, int year)
    {
        if (month > 0 && month <= 12 && year > 0 && year <= 9999)
        {
            bool leapYear = year % 4 == 0 && (year % 400 == 0 || year % 100 == 0) ? true : false;
            /* eng essam code
            int[] days = year % 4 == 0 && (year % 400 == 0 || year % 100 == 0) ? daysLeapYear : daysNonLeapYear;
            if (day <= days[month])
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }
            */

            if (leapYear)
            {
                if (day <= daysLeapYear[month])
                {
                    this.day = day;
                    this.month = month;
                    this.year = year;
                }
            }
            else
            {
                if (day <= daysNonLeapYear[month])
                {
                    this.day = day;
                    this.month = month;
                    this.year = year;
                }
            }
        }
    }

    public Date(int year) : this(1, 1, year) // to follow DRY principle
    {

    }
    public string displayDate() => $" {Convert.ToString(day).PadLeft(2, '0')} / {Convert.ToString(month).PadLeft(2, '0')} / {Convert.ToString(year).PadLeft(4, '0')} ";
}