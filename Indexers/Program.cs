internal class Program
{
    private static void Main(string[] args)
    {
        var myIp = new IP(192,168,10,1);
        ////IP myIp = new IP("192.168.-2.5");

        var firstSegment = myIp[0]; // use indexing with objects hawever it does not support it

        Console.WriteLine(myIp.Address());
        Console.WriteLine($"First Segment in IP : {firstSegment}");


        Console.WriteLine("\n...................\n");


        string[,] chessBoard = new string[8, 8]
        {
            {"Rook", "Knight", "Bishop", "Queen", "King", "Bishop", "Knight", "Rook"},
            {"Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn"},
            {"", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", ""},
            {"", "", "", "", "", "", "", ""},
            {"Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn"},
            {"Rook", "Knight", "Bishop", "Queen", "King", "Bishop", "Knight", "Rook"}
        };

        Chess chess = new Chess(chessBoard);
        Console.WriteLine(chess[8, 'a']); // use indexing with objects hawever it does not support it

        Console.ReadKey();

    }
}

public class Chess
{
    private string[,] _board = new string[8, 8];
    public Chess(string[,] board)
    {
        this._board = board;
    }

    public string this[int file, char rankLetter]
    {
        get
        {
            int rank = evaluateRank(rankLetter);
            --file; // becouse indexing start with zero
            --rank; // and they pass from 1 to 8 not 0 to 7
            if (this._board[file, rank] != "")
                return $"Peice: {this._board[file, rank]}\nColor: {getColor(file, rankLetter)} ";
            else
                return "Empity ";
        }
    }

    // private Methods

    private int evaluateRank(char ranksLetter)
    {
        ranksLetter = char.ToUpper(ranksLetter);
        int rank = ranksLetter switch
        {
            'A' => 1,
            'B' => 2,
            'C' => 3,
            'D' => 4,
            'E' => 5,
            'F' => 6,
            'G' => 7,
            'H' => 8,
            _ => 0,
        };
        return rank;
    }

    private string getColor(int file, char rankLetter)
    {
        int rank = evaluateRank(rankLetter);
        --file; // becouse indexing start with zero
        --rank; // and they pass from 1 to 8 not 0 to 7
        string color = "";
        if (file % 2 == 0)
        {
            if ((file + rank) % 2 == 0)
                color = "black";
            else
                color = "weight";
        }
        else
        {
            if (rank % 2 != 0)
                color = "black";
            else
                color = "weight";
        }
        return color;
    }
}


public class IP
{
    private int[] _segments = new int[4];
    private bool valid = true;
    public IP()
    {

    }
    public IP(string ip)
    {
        string[] segments = ip.Split('.');
        for (int i = 0; i < segments.Length; i++)
        {
            if (int.Parse(segments[i]) >= 0 && int.Parse(segments[i]) <= 255)
                this._segments[i] = Convert.ToInt32(segments[i]);
            else
            {
                valid = false;
                break;
            }
        }

    }

    public IP(int segment1, int segment2, int segment3, int segment4)
    {

        this._segments[0] = segment1;
        this._segments[1] = segment2;
        this._segments[2] = segment3;
        this._segments[3] = segment4;
        foreach (int seg in this._segments)
        {
            if (seg < 0 || seg > 255)
            {
                valid = false;
                break;
            }
        }
    }

    // Indexers enabels you to have indexing with types does not support indexing

    public int this[int index]
    {
        get
        {
            if (valid)
                return this._segments[index];
            else
                return -1;
        }
    }


    public string Address() => valid ? string.Join(".", _segments) : "invailed ip address";

}