internal class Program
{
    private static void Main(string[] args)
    {
        Delivery delivery = new Delivery(1, "Mahmoud H", "any@any.com", "beni-suif");

        DeliveryService service = new DeliveryService();
        service.Start(delivery);
        Console.WriteLine(delivery);
        Console.ReadKey();
    }
}
