internal class Program
{
    private static void Main(string[] args)
    {
        // primary expression is an expression that return a single valuke
        // var value = math.cos(30) + 1;
        // Console.WriteLine($"\'primary expression\' return a single value : {value}");

        /* null operator
         * 1.null coalescing operator ?? → check is null do what after it
         * 2.conditional null ? → without it gives NullReferenceException we use it to prevent this error 
         * (it mean in case not null do)
         * NullReferenceException occur when you try to do somthing with Null varable 
         */
        // String s1 = null;
        // s1 = s1 ?? "mahmoud";
        // s1 = s1 ?? "someoneelse"; // s1 still = 'mahmoud' becouse here its not null so what after ?? does not excuted
        // s1 = s1?.ToUpper();
        // Console.WriteLine(s1);  

        // switch statment

        Console.Write($"L.E : ");
        decimal EGP;
        var EGP2USA = 30.9m;
        var EGP2EUR = 33.7186m;
        string EgpInput = Console.ReadLine();
        EGP = stringToDec(EgpInput);
        Console.Write("convert to usa or eur :");
        string type = Console.ReadLine()?.ToUpper();
        switch (type)
        {
            case "USA":
                Console.WriteLine($"{EGP} = {EGP / EGP2USA} $.");
                break;
            case "EUR":
                Console.WriteLine($"{EGP} = {EGP / EGP2EUR} EUR.");
                break;
            default:
                Console.WriteLine("not supported carance");
                break;
        }


        // many cases to run one code block
        /*   console.write("enter gpa (or leave blank for default): ");
           string input = console.readline();
           double gpa = input is null ? 1.5 : double.parse(input);
           switch (gpa)
           {
               case 2.6:
               case 2.8:
                   console.writeline('b');
                   break;
               case 3.2:
               case 3.5:
                   console.writeline('a');
                   break;
               default:
                   console.writeline("do not pass.");
                   break;
           }*/
        /* new feture in C# 8
         var order = 1;
         string anime = order switch
         {
             1 => "the best forever,one peice. \n the one peice is real.",
             2 => "narouto",
             _ => "you anime is a gabidje .",// _ works as default in traditional switch.

         };
         Console.WriteLine(anime);
        */
        // select based on type
        /* Object o = "one peice";
        switch (o){
            case int i:
                Console.WriteLine($"{i} is an intger value .");
                break;
            case String s:
                Console.WriteLine($"{s} is a string type .");
                break;
            default:
                Console.WriteLine(o);
                break;

        }
        */
        /*
        // int[] chain = new int[10];
        Console.Write("{ ");
        for (int i = 0,prev=0,current=1; i < 10; i++)
        {
            Console.Write(prev + " , ");
            int newFib = prev + current;
            prev = current;
            current = newFib;

        }
        Console.Write(" }");
        */
        /* Jamb statment 
         * 1.break
         * 2.continue
         * 3.return
         * goto → make a label like start: and use goto to go to this label ex: goto start;
         */
        Console.ReadKey();
    }
    
    static decimal stringToDec(string s)
    {
        if (decimal.TryParse(s, out decimal output))
        {
            return output;
        }
        else
        {
            return 61.8m;
        }

    }
}