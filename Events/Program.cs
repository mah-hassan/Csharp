using System.Data;

internal class Program // subscriber 
{
    private static void Main(string[] args)
    {
        Stock stock = new Stock("Gold");
        stock.Price = 100.0m;

        stock.OnStockPriceChange += ChangeOutputColor; // subscribe

        //Console.WriteLine($"{stock.Name} price before change : {stock.Price}");

        stock.ChangePriceByPercent(0.03m);
        stock.ChangePriceByPercent(-0.03m);
        stock.ChangePriceByPercent(0.0m);


        //Console.WriteLine($"{stock.Name} price after change : {stock.Price}");
        // UnSuscribe in Event
        stock.OnStockPriceChange -= ChangeOutputColor; // will not print 

        //Console.WriteLine($"{stock.Name} price before change : {stock.Price}");

        stock.ChangePriceByPercent(0.03m);
        stock.ChangePriceByPercent(-0.03m);
        stock.ChangePriceByPercent(0.0m);


        //Console.WriteLine($"{stock.Name} price after change : {stock.Price}");


        Console.ReadKey();
    }

    private static void ChangeOutputColor(Stock stock, decimal oldPrice)
    {
        if (stock.Price > oldPrice)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{stock.Name} New Price is: {stock.Price} up");
        }
        else if (stock.Price < oldPrice)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{stock.Name} New Price is: {stock.Price} down");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{stock.Name} New Price isnot changed");
        }
    }
}

public delegate void StockPriceChangeHandler(Stock stock, decimal oldPrice);

public class Stock // publisher
{
    private string _name;
    private decimal _price;

    public event StockPriceChangeHandler OnStockPriceChange;

    public decimal Price { get => this._price; set => this._price = value; }

    public string Name => this._name;


    public Stock(string stockName)
    {
        this._name = stockName;
    }

    public void ChangePriceByPercent(decimal percent)
    {
        decimal oldPrice = this._price;
        this._price += Math.Round(this._price * percent, 2);

        if (this.OnStockPriceChange != null) // check for subscribers
            this.OnStockPriceChange(this, oldPrice); // fire the event
    }
}
