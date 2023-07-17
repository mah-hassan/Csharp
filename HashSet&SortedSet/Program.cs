internal class Program
{
    private static void Main(string[] args)
    {

        var users = new List<User>
        {
            new User{Name = "Mahmoud H." , PhoneNumber = "+20 123 456 7891"},
            new User{Name = "Monky D Luffy." , PhoneNumber = "+20 123 456 7890"},
            new User{Name = "Ahmed A." , PhoneNumber = "+20 123 456 7892"},
            new User{Name = "Ali H." , PhoneNumber = "+20 123 456 7893"},
        };


        Console.WriteLine("HashSet\n.................");
        HashSet<User> HashList = new HashSet<User>(users);

        HashList.Add(new User { Name = "Monky D Luffy.", PhoneNumber = "+20 123 456 7890" }); // Ignore this becouse phonenumber exsits
        HashList.Add(new User { Name = "Monky D Luffy.", PhoneNumber = "+20 123 456 7895" }); // Add this

        foreach (var user in HashList)
            Console.WriteLine(user);


        Console.WriteLine("\nSortedSet\n.................");
        SortedSet<User> SortedList = new SortedSet<User>(users);
        // sortes the elements
        // in case reference sorts according to compareTo() so you shouid implement IComparable
        foreach (var user in SortedList)
            Console.WriteLine(user);
    }
}

internal class User : IComparable<User>
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + PhoneNumber.GetHashCode();
        return hash;
    }
    public override bool Equals(object? obj)
    {
        var other = obj as User;
        return other is null ? false : this.PhoneNumber.Equals(other.PhoneNumber);
    }
    // when using SortedSet with reference types you shouid implement IComparable interface
    public int CompareTo(User? other)
    {
        var _other = other as User;
        if (object.ReferenceEquals(_other, this)) return 0;


        return _other is null ? -1 : this.Name.CompareTo(_other.Name);
    }

    public override string ToString()
    {
        return $"{Name}\t{PhoneNumber}";
    }
}
