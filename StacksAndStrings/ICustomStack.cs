namespace StacksAndStrings
{
    public interface ICustomStack<T>
    {
        bool IsEmpty { get; }
        int Size { get; }

        T Pop();
        void Push(T item);
    } 
}
