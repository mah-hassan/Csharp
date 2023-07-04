internal class Program
{
    private static void Main(string[] args)
    {
        // short,int,long all are alises to (int16,int32,int64)in order
        // unsigned types take the whole range from 0 to max no negative value
        // (1) implicit conversion...
        // when you convert same types but from smail to large

        /* int n = 2113;
         long l = n;
         Console.WriteLine(l); */

        /* in this example we converted same types int32 to int64
         * but note from smail which is int32 to large int64 so compiler do it without any action
         */



        // (2) explicit conversion...
        // you have to write type you want to convert to (casting) like (int)d.
        // you have to take action with yourself,compiler cannot do it direct  
        // losing data can occure so take care 
        /* int x = 15;
         short y = (short)x;
         Console.WriteLine(y);
         double x2 = 15.5;
         int y2 = (int)x2; // here you will lose 0.5
         Console.WriteLine(y2); // print 15 not 15.5
        */

        //....................................

        /* (3)Boxing VS UnBoxing
         * Boxing when you convert value type to reference type 
         * store value of value type varable into reference type in heap
         * you donot need to do anything compiler does it implicitly
         * .....................................................
         * UnBoxing when you convert reference type to value type
         * get value of reference type from heap and store it in value type varable in stack
         * you have to do casting explicitly..
         */

        /*
        int x = 10; // value type
        Object obj; // reference type
        obj = x;    // Boxing → conversion occure implicitly by compiler
        Console.WriteLine(obj);
        int y = (int)obj;
        // unboxing → you have to do explicit conversion with yourself
        Console.WriteLine(y);
        */

        //...................................

        /* (4)String values to numerical value
         * 1. use type.Parse(string varable) type can be any numerical datatype lik int,double,...
         * 2. use type.TryParse(string varable , out + declare numerical varable) return bool
         * 3. using Convert class
         * TryParse is better becouse we can handel if string is not a number or overflow
         */
        /* string s = "10";
         // using type.Parse()
         int x = int.Parse(s); // return 10 as int
         int x2 = Convert.ToInt32(s);
         Console.WriteLine(x);
         Console.WriteLine($"using Convert class {x2}");
         // using type.TryParse()
         string s2 = "111111111111111111111111"; // overflow → unvalid number
         string s3 = "10x"; // not a number → unvalid number
         StringParser(s2);
         StringParser(s3);
        */

        //................................
        /* (5) 
         * 1.BitConverter class → use GetBytes() to conver any type to array of bytes
         */

        int number = 7520;
        var bytes = BitConverter.GetBytes(number);
        foreach (var b in bytes)
        {
            //Console.Write(b + "\t");

            var binary = Convert.ToString(b, 2).PadLeft(8, '0');
            var result = $"Byte → {b} : Binary → {binary}.";
            Console.WriteLine(result);
        }

        string BestAnime = "one peice";
        char[] letters = BestAnime.ToCharArray();
        foreach (var l in letters)
        {
            int ASCII = Convert.ToInt32(l); // can use (int)l also
            var result = $"ASCII Code → {ASCII} : binary → {Convert.ToString(ASCII, 2).PadLeft(8, '0')} : Hex → {ASCII:x}.  ";
            Console.WriteLine(result);
        }

        // now from ASCII Code i want to get string back
        string phrase = "";
        int[] ASCIICodes = { 111, 110, 101, 32, 112, 101, 105, 99, 101 };
        foreach (var code in ASCIICodes)
        {
            char letter = (char)code;
            phrase += letter;
        }
        Console.WriteLine(phrase);
        Console.ReadKey();
    }
    static void StringParser(string s)
    {

        if (int.TryParse(s, out int y))
        {
            Console.WriteLine(y);
        }
        else
        {
            Console.WriteLine("unvalid number");
        }

    }

}