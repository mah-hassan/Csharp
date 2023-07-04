internal class Program
{
    private static void Main(string[] args)
    {
        Doller doller = new Doller(5.23m);
        doller.ammount = 0.2554852m;
        Console.WriteLine(Convert.ToString(doller.MyProperty));
        Console.ReadKey();
    }
}

public class Doller
{
    // properties it promoote encapsulation.
    // give us full control on the feild, the client use it as we want. 
    // property is a public way to access private feild
    // CLR convert property to setters and getters functions during compile time
    // so property is just a simple way to write setters and getters

    private decimal _ammount;

    public Doller()
    {

    }
    public Doller(decimal ammount)
    {
        this._ammount = vaildate(ammount);
    }
    // public decimal dynamicProperty { get; set; } // dynamicProperty simple property to only set and return a feild
    // no extra code like vaildation in set or any code
    // set just { this.feild = value } get { return this.feild }
    public decimal ammount
    {
        get
        {
            return this._ammount;
        }
        set
        {
            this._ammount = vaildate(value);
        }

    }

    public decimal MyProperty { get; } = 0.30m; // gives an intial value, it is read only 
    private decimal vaildate(decimal val) => val < 0 ? _ammount = 0 : _ammount = Math.Round(val, 2);

}