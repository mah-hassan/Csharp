internal class Program
{
    private static void Main(string[] args)
    {
        Subscription subscribe1 = new Subscription(15, 5, 2);
        Subscription subscribe2 = new Subscription(5, 2, 1);
        Console.WriteLine("subscribe1:..." + subscribe1.SubscriptionDuration());
        Console.WriteLine("subscribe2:..." + subscribe2.SubscriptionDuration());

        Subscription newSubscription = subscribe1 + subscribe2;
        Console.WriteLine("subscribe1 + subscribe2:.." + newSubscription.SubscriptionDuration());

        newSubscription = subscribe1 - subscribe2;
        Console.WriteLine("subscribe1 - subscribe2:.." + newSubscription.SubscriptionDuration());

        Console.WriteLine($"subscribe1 > subscribe2 → {subscribe1 > subscribe2}");
        Console.WriteLine($"subscribe1 < subscribe2 → {subscribe1 < subscribe2}");
        Console.WriteLine($"subscribe1 >= subscribe2 → {subscribe1 >= subscribe2}");
        Console.WriteLine($"subscribe1 <= subscribe2 → {subscribe1 <= subscribe2}");
        Console.WriteLine($"subscribe1 == subscribe2 → {subscribe1 == subscribe2}");
        Console.WriteLine($"subscribe1 != subscribe2 → {subscribe1 != subscribe2}");



        Console.ReadKey();
    }

}


public class Subscription
{
    public int Days { get; set; }
    public int Months { get; set; }
    public int Years { get; set; }

    public Subscription(int days, int months, int years)
    {
        this.Days = days;
        this.Months = months;
        this.Years = years;
    }

    public string SubscriptionDuration()
    {
        if (this.Days == 0)
            return $" Your Subscribtion is for {this.Months} Months and {this.Years} Year.";
        else if (this.Months == 0)
            return $" Your Subscribtion is for {this.Years} Year and {this.Days} Days.";
        else if (this.Years == 0)
            return $" Your Subscribtion is for {this.Months} Months and {this.Days} Days.";
        else
            return $" Your Subscribtion is for {this.Years} Year {this.Months} Months and {this.Days} Days.";
    }

    // operators overloading

    // + plus 
    public static Subscription operator +(Subscription subscription1, Subscription subscription2)
    {
        var days = subscription1.Days + subscription2.Days;
        var months = subscription1.Months + subscription2.Months;
        var years = subscription1.Years + subscription2.Years;
        return new Subscription(days, months, years);
    }
    // - minus
    public static Subscription operator -(Subscription subscription1, Subscription subscription2)
    {
        var days = subscription1.Days - subscription2.Days;
        var months = subscription1.Months - subscription2.Months;
        var years = subscription1.Years - subscription2.Years;
        return new Subscription(days, months, years);
    }

    // comparison operators overloading
    public static bool operator >(Subscription subscription1, Subscription subscription2)
    {
        if (subscription1.Years > subscription2.Years)
            return true;
        else if (subscription1.Years < subscription2.Years)
            return false;

        if (subscription1.Months > subscription2.Months)
            return true;
        else if (subscription1.Months < subscription2.Months)
            return false;

        if (subscription1.Days > subscription2.Days)
            return true;

        return false;
    }

    public static bool operator <(Subscription subscription1, Subscription subscription2)
    {
        if (subscription1.Years < subscription2.Years)
            return true;
        else if (subscription1.Years > subscription2.Years)
            return false;

        if (subscription1.Months < subscription2.Months)
            return true;
        else if (subscription1.Months > subscription2.Months)
            return false;

        if (subscription1.Days < subscription2.Days)
            return true;

        return false;
    }

    public static bool operator >=(Subscription subscription1, Subscription subscription2)
    {
        return (subscription1 > subscription2) || (subscription1 == subscription2);
    }

    public static bool operator <=(Subscription subscription1, Subscription subscription2)
    {
        return (subscription1 < subscription2) || (subscription1 == subscription2);
    }

    public static bool operator ==(Subscription subscription1, Subscription subscription2)
    {
        return (subscription1.Years == subscription2.Years) &&
               (subscription1.Months == subscription2.Months) &&
               (subscription1.Days == subscription2.Days);
    }

    public static bool operator !=(Subscription subscription1, Subscription subscription2)
    {
        return !(subscription1 == subscription2);
    }

}
