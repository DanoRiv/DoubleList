namespace DoubleList;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _tail = null;
        _head = null;
    }

    public void AddAscending(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        var current = _head;
        while (current != null && current.Data.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        if (current == _head)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
        else if (current == null)
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
        else
        {
            newNode.Next = current;
            newNode.Prev = current.Prev;
            current.Prev!.Next = newNode;
            current.Prev = newNode;
        }
    }

    public void OrderDescending()
    {
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            while (next != null && current.Data.CompareTo(next.Data) < 0)
            {
                var temp = current.Data;
                current.Data = next.Data;
                next.Data = temp;
                next = next.Next;
            }
            current = current.Next;
        }
    }
    public string GetForward()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Next;
        }
        return output.Substring(0, output.Length - 5);
    }

    public string GetBackward()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Prev;
        }
        return output.Substring(0, output.Length - 5);
    }

    public string GetModes()
    {
        var output = string.Empty;
        if (_head == null)
        {
            output = "The list is empty.";
            return output;
        }

        List<T> elements = new();
        var current = _head;

        while (current != null)
        {
            elements.Add(current.Data);
            current = current.Next;
        }

        List<T> modes = new();
        int maxFrequency = 0;

        foreach (var item in elements)
        {
            int counter = 0;
            foreach (var i in elements)
            {
                if (item!.Equals(i))
                {
                    counter++;
                }
            }

            if (counter > maxFrequency)
            {
                maxFrequency = counter;
                modes.Clear();
                modes.Add(item);
            }
            else if (counter == maxFrequency && !modes.Contains(item))
            {
                modes.Add(item);
            }
        }

        output += $"Mode {maxFrequency}:\n";
        foreach (var mode in modes)
        {
           output += $"\t- {mode}\n";
        }
        return output.TrimEnd();
    }
    public string GetFrequencyGraph()
    {
        var output = string.Empty;
        if (_head == null)
        {
            output = "The list is empty.";
            return output;
        }

        List<T> elements = new();
        var current = _head;

        while (current != null)
        {
            elements.Add(current.Data);
            current = current.Next;
        }

        List<T> counted = new();

        foreach (var item in elements)
        {
            if (counted.Contains(item))
                continue;

            int frequency = 0;
            foreach (var element in elements)
            {
                if (item!.Equals(element))
                    frequency++;
            }

            counted.Add(item);
            output += $"{item} " + new string('*', frequency) + "\n";
        }

        return output.TrimEnd();
    }
    public bool Exists(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _head = current.Next; // Remove head
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev; // Remove tail
                }

                break;
            }
            current = current.Next;
        }
    }
    public void RemoveAll(T data)
    {
        var current = _head;

        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                var toRemove = current;

                current = current.Next;

                if (toRemove.Prev != null)
                    toRemove.Prev.Next = toRemove.Next;
                else
                    _head = toRemove.Next;

                if (toRemove.Next != null)
                    toRemove.Next.Prev = toRemove.Prev;
                else
                    _tail = toRemove.Prev;
            }
            else
            {
                current = current.Next;
            }
        }
    }

}
