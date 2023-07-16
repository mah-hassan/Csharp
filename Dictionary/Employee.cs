internal class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Rule { get; set; }
    public int? ReportTo { get; set; }

    public override string ToString()
    {
        return $"\n\t\tID: {Id} \n\t\tName: {Name} \n\t\tRule: {Rule} \n\t\tReportTo: {ReportTo} \n";
    }
    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 7) + Id.GetHashCode();
        hash = (hash * 7) + Name.GetHashCode();
        hash = (hash * 7) + Rule.GetHashCode();
        hash = (hash * 7) + ReportTo.GetHashCode();
        return hash;
    }

    public override bool Equals(object? obj)
    {
        Employee? emp = obj as Employee;
        return emp is { } && this.Id == emp.Id
            && this.Name == emp.Name
            && this.Rule == emp.Rule
            && this.ReportTo == emp.ReportTo;
    }
}