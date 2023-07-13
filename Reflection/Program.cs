using System.Reflection;
internal class Program
{
    private static void Main(string[] args)
    {

        BankAccount bankAccount = new BankAccount(0.0m, "abc123");
        bankAccount.OnNegativeBalance += BankAccount_OnNegativeBalance;
        //bankAccount.Deposit(500m);
        //Console.WriteLine(bankAccount);
        //bankAccount.Withdrow(1000m);
        //Console.WriteLine(bankAccount);

        var t = typeof(BankAccount);
        Type[] parametersType = { typeof(decimal) };
        MethodInfo? method = t.GetMethod("Deposit");
        try
        {
            method.Invoke(bankAccount, new object[] { 100m }); // invoking method during runtime
            Console.WriteLine(bankAccount);
        }
        catch
        {


        }

        //do
        //{

        //    string input = "" + Console.ReadLine();
        //    object? obj = null;
        //    try
        //    {

        //        string? assemblyName =""+typeof(Program).Assembly.GetName().Name;
        //        var entry = Activator.CreateInstance(assemblyName, input);
        //        obj = entry?.Unwrap();
        //    }
        //    catch 
        //    {
        //        Console.WriteLine("exception");
        //    }
        //    switch (obj)
        //    {
        //        case ClassA A:
        //            Console.WriteLine(A);
        //            break;
        //        case ClassB B:
        //            Console.WriteLine(B);
        //            break;
        //        case ClassC C:
        //            Console.WriteLine(C);
        //            break;
        //        default: 
        //            Console.WriteLine("unknown class");
        //            break;
        //    }
        //} while (true);
    }

    private static void BankAccount_OnNegativeBalance(object? sender, EventArgs e)
    {
        BankAccount? bankAccount = sender as BankAccount;
        Console.WriteLine("negative balance");

    }
}


internal class BankAccount
{
    private decimal balance;
    private string acountNubmer;
    public event EventHandler OnNegativeBalance;

    public BankAccount(decimal balance, string acountNubmer)
    {
        this.balance = balance;
        this.acountNubmer = acountNubmer;
    }


    public void Deposit(decimal ammount) => balance += ammount;
    public void Withdrow(decimal ammount)
    {
        balance -= ammount;
        if (balance < 0)
        {
            OnNegativeBalance.Invoke(this, null);
            balance = 0;
        }

    }

    public override string ToString()
    {
        return $"{{\n AccountNumber: {acountNubmer}\n Balance: {balance}\n}}";
    }
}

internal class ClassA
{
    public override string ToString()
    {
        return $"{{ A }}";
    }
}
internal class ClassB
{
    public override string ToString()
    {
        return $"{{ B }}";
    }
}
internal class ClassC
{
    public override string ToString()
    {
        return $"{{C}}";
    }
}