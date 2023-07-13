
internal class Program
{
    private static void Main(string[] args)
    {
        DateTime date = DateTime.Now; // device time
        DateTimeOffset dateOffset = DateTimeOffset.Now; // device time + or - diffrence from utc time
        Console.WriteLine("DateTime → Device date: " + date);
        Console.WriteLine("DateTimeOffsetNow: " + dateOffset);
        DateTimeOffset dateOffsetUtcNow = DateTimeOffset.UtcNow; // utc time
        Console.WriteLine("DateTimeOffsetUtcNow: " + dateOffsetUtcNow);


        Console.WriteLine($"is {date.DayOfWeek} Week End: {DateHelper.isWeekEnd(date)}"); // instance method
        Console.WriteLine($"is {date.DayOfWeek} Week End: {date.isWeekEnd()}"); // extention method
        Console.WriteLine($"is {date.DayOfWeek} Week Day: {DateHelper.isWeekDay(date)}"); // instance method
        Console.WriteLine($"is {date.DayOfWeek} Week Day: {date.isWeekDay()}"); // extention method

    }
}

static class DateHelper
{
    public static bool isWeekEnd(this DateTime date)
        => date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday;
    
    public static bool isWeekDay(this DateTime date) => !isWeekEnd(date);
}