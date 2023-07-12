internal class Temperture : IComparable
{
    private int _value;
    public Temperture(int value)
    {
        this._value = value;
    }
    public int Value => this._value;

    public int CompareTo(object? obj)
    {
        if (obj is null)
            return 1;
        Temperture? temp = obj as Temperture;
        return temp is null ? throw new ArgumentException("obj is`nt a Temperture.") : temp._value.CompareTo(this._value);
    }

    public override string ToString()
    {
        return Convert.ToString(this._value);
    }
}

