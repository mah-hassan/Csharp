internal class Program
{
    private static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            Employee employee = new Employee("mahmoud", "hassan",10);
            Console.WriteLine(employee);
            Console.WriteLine("click y key if you want to show password and n to skip");
            char? key = Console.ReadLine()[0];
            if (key == 'y')
            {
                Console.WriteLine("Your Password is "+employee.Password);
                Console.WriteLine("............\n");
            }
            else
            {
                Console.WriteLine("............\n");
                continue;
            }                            
        }
        Console.ReadKey();
    }
}