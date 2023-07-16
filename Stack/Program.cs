using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Stack<WebPage> back = new Stack<WebPage>();
        Stack<WebPage> forward = new Stack<WebPage>();

        while (true)
        {
            Console.WriteLine("Press Enter to enter a url or back arrow ← or forward arrow → or Esc key to exit...");
            ConsoleKeyInfo key = Console.ReadKey(true);
            var action = "";
            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("enter url:");
                action += Console.ReadLine();

            }
            action = action.ToLower();
            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    if (forward.Count > 0)
                    {
                        back.Push(forward.Pop());
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (back.Count > 0)
                    {
                        forward.Push(back.Pop());
                    }
                    break;
                case ConsoleKey.Escape:
                    Console.Write("Exiting...");
                    break;
                case ConsoleKey.Enter:
                    back.Push(new WebPage(action));
                    break;
                default:
                    Console.WriteLine("unknown key");
                    break;

            }


            ClearTerminal(back, forward);


        }

    }

    static void ClearTerminal(Stack<WebPage> PrevouisWebPages, Stack<WebPage> ForwardWebPages)
    {
        Console.Clear();
        Console.WriteLine("Back History");
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        foreach (var page in PrevouisWebPages)
        {
            Console.WriteLine(page);
        }
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("Forward History");
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        foreach (var page in ForwardWebPages)
        {
            Console.WriteLine(page);
        }

        Console.BackgroundColor = ConsoleColor.Black;
    }
}

internal class WebPage
{
    public string URL { get; set; }
    public DateTimeOffset VisitTime { get; private set; }
    public WebPage(string url)
    {
        this.URL = url;
        this.VisitTime = DateTimeOffset.UtcNow;
    }

    public override string ToString()
    {
        return $"[{VisitTime}] {URL}";
    }

}