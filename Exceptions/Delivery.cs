internal class Delivery
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string Address { get; set; }
    public DeliveryStatus DeliveryStatus { get; set; }
    public Delivery(int id, string customerName, string customerEmail, string address)
    {
        Id = id;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        Address = address;
    }

    public override string ToString()
    {
        return $"\n  ID: {Id} \n  Customer Name: {CustomerName} \n  Customer Email: {CustomerEmail} \n  Address: {Address} \n  Status: {DeliveryStatus}";
    }
}

internal enum DeliveryStatus
{
    Faild,
    Processing,
    OnTheWay,
    Delivered
}
