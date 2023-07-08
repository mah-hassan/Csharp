internal class Program
{
    private static unsafe void Main(string[] args)
    {

        DigtalSize size = new DigtalSize(8_796_093_022_208);
        Console.WriteLine(size.Display());

        // mew is not a mandatory but you have to explicitly intialize feilds

        DigtalSize* adress = &size;
        Console.WriteLine($"{(long)adress:x}");
        size = size.AddBit(1024);
        Console.WriteLine(size.Display());
        Console.WriteLine($"{(long)adress:x}");

        Point point = new Point(5, 10);
        point.Print();
        point.X = 15; // mutablity
        point.Print();

        Console.ReadKey();
    }

}

public class DigtalSize
{
    // it is a vlue type so it is not a good practise to use it in alarge data becouse it is in stack not heap
    // it is mutable which mean it`s feilds can be modefied after creation of obj
    // also it can be immutable by using readonly
    // can not intialize feilds only const
    // can not explicitly define a parameterless constractor it is implicitly present
    // No finalizers in struct do
    // does not support inheritance,Protected,virtual
    // recomended to use in max 16 byte it
    // is good at performance than class 
    public long Bit { get; set; }
    public DigtalSize(long bits)
    {
        this.Bit = bits;
    }

    private const long _BitToBit = 1;
    private const long _BitToByte = 8;
    private const long _BitToKB = 1024 * _BitToByte;
    private const long _BitToMB = 1024 * _BitToKB;
    private const long _BitToGB = 1024 * _BitToMB;
    private const long _BitToTB = 1024 * _BitToGB;


    private DigtalSize Add(long bits, long scale)
    {
        return new DigtalSize(bits * scale);
    }
    public DigtalSize AddBit(long bit)
    {
        return Add(bit, 1);
    }
    public DigtalSize AddByte(long bit)
    {
        return Add(bit, _BitToByte);
    }
    public DigtalSize AddKB(long bit)
    {
        return Add(bit, _BitToKB);
    }
    public string Display()
    {
        return $"{this.Bit:N0} Bit → {this.Bit / _BitToByte:N0} Byte \n{this.Bit:N0} Bit → {this.Bit / _BitToKB:N0} KB \n{this.Bit:N0} Bit → {this.Bit / _BitToMB:N0} MB \n{this.Bit:N0} Bit → {this.Bit / _BitToGB:N0} GB\n{this.Bit:N0} Bit → {this.Bit / _BitToTB:N0} TB";
    }

}

struct Point
{
    public int X;
    public int Y;
    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public void Print()
    {
        Console.WriteLine($"({this.X},{this.Y})");
    }
}