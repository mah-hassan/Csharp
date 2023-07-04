internal class Program
{
    private static void Main(string[] args)
    {
        // Logical And &&
        Console.WriteLine("Logical And && :");
        Console.WriteLine(true && true);  //True
        Console.WriteLine(true && false); //False
        Console.WriteLine(false && true); //False
        Console.WriteLine(false && false);//False

        // Logical Or ||
        Console.WriteLine("Logical Or || :");
        Console.WriteLine(true || true);  //True
        Console.WriteLine(true || false); //True
        Console.WriteLine(false || true); //True
        Console.WriteLine(false || false);//False

        // Logical Xor ^
        Console.WriteLine("Logical Xor ^ :");
        Console.WriteLine(true ^ true);  //False
        Console.WriteLine(true ^ false); //True
        Console.WriteLine(false ^ true); //True
        Console.WriteLine(false ^ false);//False

        // short circuit(2x &,|) VS complete circuit(1x &,|)
        // bool isShortCircuit = false && check();  // complete circuit → gives false without runing check()
        // bool isShortCircuit = false & check();  // short circuit → gives false and run check()
        // bool isShortCircuit = true || check(); // complete circuit → gives true without runing check()
        // bool isShortCircuit = true | check(); // short circuit → gives true and run check()
        // Console.WriteLine(isShortCircuit);

        var vipThreashoild = 75.0m;
        var subscribtionCost = 60.0m;
        var isVip = subscribtionCost >= vipThreashoild ? true : false;
        Console.WriteLine($"is this a VIP user : {isVip} .");

        Console.ReadKey();
    }

    static bool check()
    {
        Console.WriteLine("Not a short circuit...");
        return true;
    }
}