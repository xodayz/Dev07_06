namespace Tests;

public class LnkList
{
    private LnkNode? _head;

    public LnkList() =>
        _head = null;


    // O(1)

    public void Prepend(int value)
    {
        if (_head == null)
        {
            _head = new LnkNode(value);
            return;
        }

        _head = new LnkNode(value, _head);
    }

    // O(n)

    public void Append(int value)
    {
        if (_head == null)
        {
            _head = new LnkNode(value);
            return;
        }

        var current = _head;
        while (current.Next != null)
            current = current.Next;

        current.Next = new LnkNode(value);
    }

    // O(1)
    public int First()
    {
        if (_head == null)
            throw new InvalidOperationException();

        return _head.Value;
    }

    // O(?)
    public int Get(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        var current = _head;
        int currentIndex = 0;

        while (current != null)
        {
            if (currentIndex == index)
                return current.Value;

            current = current.Next;
            currentIndex++;
        }
        if (current == null)
        {

            throw new IndexOutOfRangeException();
        }
        return current.Value;
    }


    // O(n)
    public int Count()
    {
        var result = 0;

        var current = _head;

        while (current != null)
        {
            result++;
            current = current.Next;
        }

        return result;
    }

    // O(n)

    public IEnumerable<int> ToEnumerable()
    {
        var result = new List<int>();

        var current = _head;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }
        return result;
    }

    private class LnkNode
    {
        public int Value { get; }
        public LnkNode? Next { get; set; }

        public LnkNode(int value, LnkNode? next = null)
        {
            Value = value;
            Next = next;
        }
    }
}