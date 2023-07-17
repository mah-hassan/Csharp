internal class Program
{
    private static void Main(string[] args)
    {

        var video1 = new Video("lesson1", "www.youtube/lesson1.com", new TimeSpan(00, 20, 00));
        var video2 = new Video("lesson2", "www.youtube/lesson2.com", new TimeSpan(00, 40, 00));
        var video3 = new Video("lesson3", "www.youtube/lesson3.com", new TimeSpan(00, 56, 00));
        var video4 = new Video("lesson4", "www.youtube/lesson4.com", new TimeSpan(01, 20, 00));


        //LinkedList<Video> playList = new LinkedList<Video>();
        //playList.AddFirst(video1);
        //playList.AddAfter(playList.First, video2);
        //playList.AddAfter(playList.First.Next, video3);
        //playList.AddBefore(playList.Last, video4);

        //// add using LinkedListNode class
        //var node1 = new LinkedListNode<Video>(video1);
        //var node2 = new LinkedListNode<Video>(video2);
        //var node3 = new LinkedListNode<Video>(video3);
        //var node4 = new LinkedListNode<Video>(video4);
        //playList.AddFirst(node1);
        //playList.AddAfter(node1, node2);
        //playList.AddAfter(node2, node3);
        //playList.AddAfter(node3, node4);

        //foreach (var video in playList)
        //    Console.WriteLine(video);



        LinkedList<Video> playList = new LinkedList<Video>(new Video[]
        {
                video1,
                video2,
                video3,
                video4
        });

        var current = playList.First;
        ConsoleKeyInfo key;
        while (playList.Count > 0)
        {
            Console.WriteLine("Current Video \n" + current?.Value);
            Console.WriteLine("Press RightArrow for Next Video OR LeftArrow for Previous Video");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (current is null || current == playList.Last)
                {
                    Console.WriteLine("No More Videos");
                    current = playList.Last;
                }
                else
                    current = current.Next;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                if (current is null || current == playList.First)
                {
                    Console.WriteLine("No Previous Video");
                    current = playList.First;
                }
                else
                    current = current.Previous;
            }
            else
                continue;
        }



    } // End Main

}

internal class Video
{
    public string Name { get; set; }
    public string URL { get; set; }
    public TimeSpan Duration { get; set; }

    public Video(string name, string uRL, TimeSpan duration)
    {
        Name = name;
        URL = uRL;
        Duration = duration;
    }

    public override string ToString()
    {
        return $"\t{Name}({Duration}) \n\t\t{URL}\n========================================";
    }
}