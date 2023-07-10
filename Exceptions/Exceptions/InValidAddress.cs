
internal class InValidAddress : Exception
{
    public InValidAddress(Delivery delivery, string message) : base(message)
    {
        Delivery = delivery;
    }

    private Delivery Delivery { get; set; }

    public override string ToString()
    {
        return $"InValidAddress: {Delivery.Address} \nDesc: {this.Message} their is no persson called {Delivery.CustomerName}. in this address";
    }
}