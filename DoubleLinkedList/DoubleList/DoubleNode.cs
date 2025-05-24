namespace DoubleList;

public class DoubleNode<T>
{
    public T Data { get; set; }
    public DoubleNode<T>? Next { get; set; }
    public DoubleNode<T>? Prev { get; set; }

    public DoubleNode(T data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}
