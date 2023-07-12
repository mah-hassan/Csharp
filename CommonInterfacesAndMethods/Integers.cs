using System.Collections;

internal class Integers : IEnumerable
{
    private int[]? _values;

    public Integers(int n1, int n2, int n3)
    {
        _values = new int[] { n1, n2, n3 };
    }

    public IEnumerator GetEnumerator() => new Enumerator(this); // old way

    // don`t need this now use yield direct it will do everything implicitly for you.
    private class Enumerator : IEnumerator
    {
        private Integers _integers;
        private int _CurrentIndex = -1;
        public Enumerator(Integers integers)
        {
            _integers = integers;
        }

        public object? Current
        {
            get
            {
                if (_CurrentIndex == -1)
                    throw new InvalidOperationException("Not Started Yet");
                if (_CurrentIndex > _integers._values?.Length)
                    throw new InvalidOperationException("Enumeratoin Finished");

                return _integers._values?[_CurrentIndex];
            }
        }

        public bool MoveNext()
        {
            if (_CurrentIndex >= _integers._values?.Length - 1)
                return false;

            return ++_CurrentIndex < _integers._values?.Length;

        }


        public void Reset() => _CurrentIndex = -1;

    }
}

