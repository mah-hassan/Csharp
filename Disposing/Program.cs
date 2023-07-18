internal class Program
{
    private static void Main(string[] args)
    {

        // using implicitly invoke currencyService.Dispose()
        // using statment is a try clr return it back as a try

        //using CurrencyService currencyService = new CurrencyService();
        //Console.WriteLine(currencyService.GetCurrencies());
        using (CurrencyService currencyService = new CurrencyService())
        {
            Console.WriteLine(currencyService.GetCurrencies());
        }
    }
}
public class CurrencyService : IDisposable
{
    private readonly HttpClient _client; // HttpClient contain unmanged code
    private bool disposed;

    public CurrencyService()
    {
        _client = new HttpClient();
    }
    public string GetCurrencies()
    {
        var url = @"https://coinbase.com/api/v2/currencies";
        return _client.GetStringAsync(url).Result;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed) // disposed is false this condtion shouid be true and obj will be dispossed
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
                _client.Dispose(); // Dispose of the HttpClient object
                Console.WriteLine("Disposed.........");
            }
            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null

            // if disposing is false, the method skips disposing of managed resources.
            // This is done because the method is being called from the finalizer,
            // and at that point, all managed objects have already been finalized by the garbage collector.
            disposed = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    ~CurrencyService()
    {
        // when forgeting using or calling Dispose() explicitly the finalizer call it
        Console.WriteLine("Disposed From finalizer");
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(false);
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(true);
        GC.SuppressFinalize(this); // to ensure calling Dispose only one time stop Finalizer
    }
}