internal class StoppedException : Exception
{

    public StoppedException(string location, string message) : base(message)
    {
        Location = location;
    }

    public string Location { get; set; }

    public override string ToString()
    {
        return $"stopped at {Location} becouse of {this.Message}";
    }

}
