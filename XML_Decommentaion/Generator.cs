
/// <include file='Generator.xml' path='/doc/members/member[@name="Generator"]/*'/>
internal class Generator
{
    private static int sequance = 1;
    /// <include file='Generator.xml' path='/doc/members/member[@name="GenerateId"]/*'/>
    public string GenerateId(string fName, string lName, DateTime hireDate)
    {
        string id = "";
        if (fName == null)
            throw new InvalidOperationException($"{nameof(fName)} can't be null");
        if (lName == null)
            throw new InvalidOperationException($"{nameof(lName)} can't be null");
        if (hireDate.Date < DateTime.Now.Date)
            throw new InvalidOperationException($"{nameof(hireDate)} can't be in the past");

        id += $"{lName.ToUpper()[0]}{fName.ToUpper()[0]}-{hireDate.ToString("yy")}{hireDate.ToString("MM")}{hireDate.ToString("dd")}{sequance++}";
        return id;
    }
    /// <include file='Generator.xml' path='/doc/members/member[@name="GeneratePassword"]/*'/>

    public string GeneratePassword(int length)
    {
        const string ValidScope = "qazwsxedcrfvtgbyhnujmikolp0123456789.+-*/_@#$%^&!`~ZAQWSXCDERFVBGTYHNMJUIOPLK";
        Random random = new Random();
        string password = "";
        while (length > 0)
        {
            password += ValidScope[random.Next(ValidScope.Length)];
            length--;
        }
        return password;
    }
}