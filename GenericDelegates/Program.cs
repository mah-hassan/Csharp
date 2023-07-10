internal class Program
{
    public delegate bool Filter(int number); // Non Generic delegate
    public delegate bool GenericFilter<in T>(T pevoit); // Generic delegate
    /*
     * the in keyword is used to specify that the type parameter can only appear in input positions
     * (i.e., as method parameter types)
     * while the out keyword is used to specify that the type parameter can only appear in output positions 
     * (i.e., as method return types).
     * public delegate T GenericFilter<out T>(int pevoit); 
     */

    /* Action VS Func VS Predicate.
     * The `Action` delegate represents a method that takes one or more input parameters, but does not return a value.
     * The `Func` delegate represents a method that takes one or more input parameters and returns a value.
     * The `Predicate` delegate represents a method that takes one input parameter and returns a Boolean value.
     * In other words, `Action` is used for methods that perform an action
     * `Func` is used for methods that return a value
     * `Predicate` is used for methods that return a Boolean value.
     * All three delegates can have up to 16 type parameters, with the last one always representing the return type (if any).
     * `Action<int, string>` represents a method that takes an integer and a string input parameter, but does not return a value.
     * `Func<int, string, bool>` represents a method that takes an integer and a string input parameter, and returns a Boolean value.
     * `Predicate<int>` represents a method that takes an integer input parameter and returns a Boolean value.
     */
    private static void Main(string[] args)
    {
        IEnumerable<int> myList = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        FilterList(myList, n => n % 2 == 0, () => Console.WriteLine("Non Generic delegate")); // Even numbers
        FilterList(myList, n => n % 2 != 0, () => Console.WriteLine("Non Generic delegate")); // Odd numbers
        IEnumerable<decimal> myDecList = new decimal[] { 0.0m, 1, 0m, 2.0m, 3.0m, 4.0m, 5.0m, 6.0m, 7.0m, 8.0m, 9.0m, 10.0m };
        // using generic delegate we can pass any list type
        FilterAnyList(myDecList, n => n % 2 == 0, () => Console.WriteLine("using Generic delegate"));
        FilterAnyList(myList, n => n % 2 == 0, () => Console.WriteLine("using Generic delegate"));

        // solve same problwm using built in Generic delegate
        Filter_(myList, n => n % 2 == 0, () => Console.WriteLine("using Predicate built in Generic delegate"));
        Filter__(myDecList, n => n % 2 == 0, () => Console.WriteLine("using Func built in Generic delegate"));

        Console.ReadKey();
    }
    // using Non Generic delegate
    static void FilterList(IEnumerable<int> _list, Filter filter, Action action)
    {
        action();
        Console.Write("{");
        foreach (var item in _list)
        {
            if (filter(item))
            {
                if (!item.Equals(_list.Last()))
                    Console.Write($"{item} , ");
                else
                    Console.Write($"{item}");
            }
        }
        Console.Write("}\n");
    }

    // using Generic delegate
    static void FilterAnyList<T>(IEnumerable<T> _list, GenericFilter<T> filter, Action action)
    {
        action();
        Console.Write("{");
        foreach (var item in _list)
        {
            if (filter(item))
            {
                if (item != null)
                {
                    if (!item.Equals(_list.Last()))
                        Console.Write($"{item} , ");
                    else
                        Console.Write($"{item}");
                }
            }
        }
        Console.Write("}\n");
    }
    // solve same problwm using Predicate built in Generic delegate
    static void Filter_<T>(IEnumerable<T> _list, Predicate<T> filter, Action action)
    {
        action();

        Console.Write("{");
        foreach (var item in _list)
        {
            if (filter(item))
            {

                if (item != null)
                {
                    if (!item.Equals(_list.Last()))
                        Console.Write($"{item} , ");
                    else
                        Console.Write($"{item}");
                }
            }
        }
        Console.Write("}\n");
    }

    // solve same problwm using Func built in Generic delegate

    static void Filter__<T>(IEnumerable<T> _list, Func<T, bool> filter, Action action)
    {
        action();
        Console.Write("{");
        foreach (var item in _list)
        {
            if (filter(item))
            {
                if (item != null)
                {
                    if (!item.Equals(_list.Last()))
                        Console.Write($"{item} , ");
                    else
                        Console.Write($"{item}");
                }

            }
        }
        Console.Write("}\n");
    }
}