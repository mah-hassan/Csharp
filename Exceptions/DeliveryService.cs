internal class DeliveryService
{
    private readonly Random _random = new Random();
    public void Start(Delivery delivery)
    {
        try
        {
            Processing(delivery);
            OnTheWay(delivery);
            Delivered(delivery);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            delivery.DeliveryStatus = DeliveryStatus.Faild;
        }

        catch (StoppedException ex)
        {
            Console.WriteLine(ex);
            delivery.DeliveryStatus = DeliveryStatus.Faild;
        }
        catch (InValidAddress ex)
        {
            Console.WriteLine(ex);
            delivery.DeliveryStatus = DeliveryStatus.Faild;
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex);
            delivery.DeliveryStatus = DeliveryStatus.Faild;
        }

    }

    private void Processing(Delivery delivery)
    {
        if (_random.Next(1, 10) == 2)
        {
            throw new InvalidOperationException("unable to process the order.");
        }
        ApplayProcess("Processing");
        delivery.DeliveryStatus = DeliveryStatus.Processing;
    }

    private void OnTheWay(Delivery delivery)
    {
        if (_random.Next(1, 5) == 2)
        {
            throw new StoppedException("32-street_of_onepiece", "Traffic Jam!!");
        }
        ApplayProcess("On The Way");
        delivery.DeliveryStatus = DeliveryStatus.OnTheWay;
    }

    private void Delivered(Delivery delivery)
    {
        if (_random.Next(1, 3) == 2)
        {
            throw new InValidAddress(delivery, "the address is wrong ");
        }
        ApplayProcess("Delivered");
        delivery.DeliveryStatus = DeliveryStatus.Delivered;
    }

    private void ApplayProcess(string title)
    {
        Console.Write(title);
        for (int i = 0; i < 3; i++)
        {
            System.Threading.Thread.Sleep(300);
            Console.Write('.');
        }
        Console.WriteLine();
    }

}

