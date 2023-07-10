internal class Program
{
    private static void Main(string[] args)
    {
        /*
         * In C#, generic type constraints are used to restrict the types
         * that can be used as type arguments for a generic type parameter.
         * This helps to ensure that the generic type parameter 
         * is used only with the specified types 
         * and provides compile-time safety to the code
         */
        MyList<string> strList = new MyList<string>();
        strList.AddItem("my name");
        strList.AddItem("is");
        strList.AddItem("mahmoud");
        Console.WriteLine(strList.ToString());

        Console.WriteLine(" " + string.Join(" ", strList.GetList()));

        MyList<int> intList = new MyList<int>();
        intList.AddItem(1);
        intList.AddItem(2);
        intList.AddItem(3);
        intList.AddItem(4);
        Console.WriteLine(intList.ToString());
        intList.RemoveItem(3);
        Console.WriteLine(intList.ToString()); // [ 1 , 2 , 3 ] 
        intList.RemoveItem(4); // unvalid index
        Console.ReadKey();
    }
}

public class MyList<T> where T : IEquatable<T>
{
    // 1. T : class - ensures that T is a reference type.
    // 2. T : interface - specifies an interface that T must implement, like IEquatable<T> in this case.
    // 3. T : struct - ensures that T is a value type.
    // 4. T : new () - requires that T has a default constructor parameterless.
    private T[] _items;
    public void AddItem(T item)
    {
        if (isEmpity())
        {
            _items = new T[] { item };
        }
        else
        {
            var disLen = _items.Length + 1;
            T[] distnation = new T[disLen];
            for (int i = 0; i < _items.Length; i++)
            {
                distnation[i] = _items[i];
            }
            distnation[distnation.Length - 1] = item;
            this._items = distnation;
        }

    }
    public void RemoveItem(int index)
    {
        if (isEmpity())
            Console.WriteLine("List does`nt contain any item to remove");
        else
        {
            if (index >= 0 && index < _items.Length) // handel unvalid index 
            {
                var disLen = _items.Length - 1;
                T[] distnation = new T[disLen];
                for (int i = 0; i < _items.Length; i++)
                {
                    if (i == index)
                        continue;
                    distnation[i] = _items[i];
                }
                this._items = distnation;
            }
            else
                Console.WriteLine("unvalid index");

        }

    }
    private bool isEmpity()
    {
        if (_items is null || _items.Length == 0)
            return true;
        else
            return false;
    }

    public override string ToString()
    {
        var whatToDisplay = "[ ";
        if (isEmpity())
        {
            return "List is Empity";
        }
        else
        {
            foreach (var item in _items)
            {
                whatToDisplay += item;
                if (!item.Equals(_items[^1]))
                    whatToDisplay += " , ";
            }
            whatToDisplay += " ]";
        }

        return whatToDisplay;
    }

    public T[] GetList()
    {
        if (isEmpity())
            return new T[] { };
        else
            return _items;
    }

}