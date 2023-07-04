internal class Program
{
    private static void Main(string[] args)
    {

        int mark = 10;
        Demo demo = new Demo();
        // calling by value, no changes made on local mark (argument)
        demo.remarkValueCall(mark);
        Console.WriteLine($"your mark after remark by value calling = {mark}");

        // calling by refremce using ref.
        demo.remarkReferenceCall(ref mark);
        Console.WriteLine($"your mark after remark using refrence call = {mark}");

        // calling by refremce using out.
        int UnAssignedMark;
        demo.remarkReferenceCallByOut(out UnAssignedMark);
        Console.WriteLine($"your mark after remark using refrence call By out = {UnAssignedMark}");

        // Method OverLoading.
        Console.Write("please enter square side length Intger value: ");
        int nSideLength = Convert.ToInt32(Console.ReadLine());
        Console.Write("please enter square side length Double value: ");
        double dSideLength = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"Intger Area : {demo.squareArea(nSideLength)}");
        Console.WriteLine($"Double Area : {demo.squareArea(dSideLength)}");



        Console.ReadKey();
    }
    public class Demo
    {
        /* by defuilt prameter mark not the same argument mark
         * so you shouid pass the argument by reference using ref keyword in call and method defintion
         * note, when calling argument shouid hase an intial value only when using ref not out
         */

        public void remarkValueCall(int mark)
        {
            mark = mark >= 50 ? mark : 50;
        }
        public void remarkReferenceCall(ref int mark)
        {
            // note, when using ref the argument shouid be assigned to a value before calling same as value calling
            mark = mark >= 50 ? mark : 50;
        }
        public void remarkReferenceCallByOut(out int mark)
        {
            mark = 10; // using out you can pass unassigned argument
                       // but it shouid be assigned in method body
                       // simply it(out) delay assignment
                       // unlike ref the argument shouid be assigned to a value before calling
            mark = mark >= 50 ? mark : 50;
        }
        // Method Overloading → same name but diffrent signtrue
        // diffrent signtrue mean dif( return type ,parameter types ,parameter number ,parameter order)

        public int squareArea(int side)
        {
            return side * 4;
        }

        // this is a new feture in C# called expression bodied method
        // allows you to use => if body was only one expression insted of { } and return statment
        public double squareArea(double side) => side * 4;



    }
}

