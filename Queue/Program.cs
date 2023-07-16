using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        PrintingJob printingJob1 = new PrintingJob("documentation.docx", 3);
        PrintingJob printingJob2 = new PrintingJob("report.pdf", 1);
        PrintingJob printingJob3 = new PrintingJob("lecture-one.ppt", 5);
        PrintingJob printingJob4 = new PrintingJob("Exam.pdf", 100);


        Queue<PrintingJob> Jobs = new Queue<PrintingJob>(); // FIFO
        Jobs.Enqueue(printingJob1);
        Jobs.Enqueue(printingJob2);
        Jobs.Enqueue(printingJob3);
        Jobs.Enqueue(printingJob4);

        Random random = new Random();

        while (Jobs.Count > 0)
        {
            System.Threading.Thread.Sleep(random.Next(1, 6) * 1000);
            Console.WriteLine(Jobs.Dequeue());
        }
        Console.WriteLine("\n...............\n");

        // TryPeek and TryDequeue also exist in stack
        // pack property gives the pack of queue and stack without deleting
        Queue<int> numbers = new Queue<int>();
        if (numbers.TryPeek(out int n))
        {
            Console.WriteLine(n);
        }
        else
            Console.WriteLine("Queue is Empity");

    }

}

internal class PrintingJob
{
    public string FileName { get; set; }
    private readonly short _copies;

    public PrintingJob(string fileName, short copies)
    {
        FileName = fileName;
        _copies = copies;
    }

    public override string ToString()
    {
        return $"Printing {FileName} x{_copies} Copies has completed";
    }
}