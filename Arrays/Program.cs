internal class Program
{
    private static void Main(string[] args)
    {
        // multi-dimensional array must be with same size
        int[,] myMultiDimensionalArray = new int[3, 4]
        {
            { 1, 5, 6, 8},
            { 8, 9, 5, 5},
            { 10, 2, 3, 7}
        };
        PrintArray(myMultiDimensionalArray);
        Console.WriteLine("\n........................\n");
        // Jagged Array can be with diffrent sizes
        int[][] myJaggedArray = new int[3][];

        myJaggedArray[0] = new int[] { 1, 2, 3,5,8,9,5,15,10 };
        myJaggedArray[1] = new int[] { 4, 5 };
        myJaggedArray[2] = new int[] { 6, 7, 8, 9 };
        PrintArray(myJaggedArray);
        Console.WriteLine("\n........................\n");

        /* Jagged Array(non-rectangular) VS multi-dimensional array(rectangular)
         * ................
         * Note that in a jagged array, each inner array is a separate object
         * and can have different lengths,
         * whereas in a multi-dimensional array, all the elements are stored in a single block of memory 
         * and must have the same length in each dimension
         */


        // Indices and ranges
        /* the end is exclusive 
         * use hat ^ to start from the end of array (backword)
         * indexes start with one in backword insted of zero in forword
        */

        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var slice1 = numbers[..3]; // will print {1,2,3} and 4(numbers[3]) exclusive.

        PrintArray(slice1);

        Console.WriteLine("......................");

        var slice2 = numbers[3..]; // will print from index 3 to the end of numbers[].
        PrintArray(slice2);  // { 4, 5, 6, 7, 8, 9 }

        Console.WriteLine("......................");

        var slice3 = numbers[2..^3]; // will print from index 2 to the third element from the end of the array
        PrintArray(slice3);  // { 3, 4, 5, 6 }

        Console.ReadKey();
    }
    static void PrintArray<T>(T[] arr)
    {
        Console.Write("{ ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i < arr.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(" }");
    }

    static void PrintArray<T>(T[,] arr)
    {
        Console.Write(" [ ");
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            Console.Write("{ ");
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j]);
                if (j < arr.GetLength(1) - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write(" }");
            
            if (i < arr.GetLength(0) - 1)
            {
                Console.Write("\n");
            }
        }
        Console.WriteLine(" ] ");
    }

    static void PrintArray<T>(T[][] arr)
    {
        Console.Write("[ ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{ ");
            for (int j = 0; j < arr[i].Length; j++)
            {
                Console.Write(arr[i][j]);
                if (j < arr[i].Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write(" }");

            if (i < arr.Length - 1)
            {
                Console.Write(",\n  ");
            }
        }
        Console.WriteLine(" ]");
    }

}