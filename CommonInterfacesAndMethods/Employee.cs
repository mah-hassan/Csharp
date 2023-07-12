internal class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? Department { get; set; }
    public decimal Salary { get; set; }

    public override bool Equals(object? other)
    {
        if (other is null || !(other is Employee))
            return false;

        var otherEmployee = other as Employee;


        return otherEmployee?.Id == this.Id
            && otherEmployee?.Name == this.Name
            && otherEmployee?.Department == this.Department
            && otherEmployee?.Title == this.Title &&
            otherEmployee?.Salary == this.Salary;
    }
    public override int GetHashCode()
    {
        int hash = 17;
        hash = (hash * 23) + Id.GetHashCode();
        hash = (hash * 23) + Salary.GetHashCode();
        hash = (hash * 23) + Department.GetHashCode();
        hash = (hash * 23) + Name.GetHashCode();
        hash = (hash * 23) + Title.GetHashCode();
        return hash;
    }
    public static bool operator ==(Employee a, Employee b) => a.Equals(b);
    public static bool operator !=(Employee a, Employee b) => !(a.Equals(b));

}

