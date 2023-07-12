internal class Employee
{
    private Generator Generator = new Generator();
    public string Id { get; private set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public DateTime HireDate { get; set; }
    public string Password { get; private set; }
    public Employee(string fName, string lName,int passwordLength)
    {
        FName = fName;
        LName = lName;
        HireDate = DateTime.Now;
        Id = Generator.GenerateId(FName, LName, HireDate);
        Password = Generator.GeneratePassword(passwordLength);
    }

    public override string ToString()
    {
        return $"ID: {Id}\nFirst Name: {FName.ToUpper()}\nLast Name: {LName.ToUpper()}\nHiring Date: {HireDate.Date.ToString("yy/MM/dd")}";
    }
}
