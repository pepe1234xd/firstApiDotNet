namespace chat_signalr.Mapping
{
    public interface IConnectionMapping<T>
    {
        void Add(T name, string connectionId);
        List<string> getAll();
        void Removed(T name, string connectionId);
    }
}
