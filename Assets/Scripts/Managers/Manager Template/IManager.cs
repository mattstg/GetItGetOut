public interface IManager<T> where T : IUpdaptable
{ 
    public abstract void Add(T item);
    public abstract void Remove(T item);
}
