using System.Collections.Generic;

public abstract class Manager : IUpdaptable
{
    public abstract void FixedRefresh();
    public abstract void Init();
    public abstract void PostInit();
    public abstract void Refresh();
}
public abstract class Manager<T, E> : Manager, IManager<E> where T : class, new() where E : IUpdaptable {

    #region Singleton
    private static T instance;
    public static T Instance => instance ??= new T();
    protected Manager() 
    {
        colletion = new HashSet<E>();
        toAdd = new Stack<E>();
        toRemove = new Stack<E>();
    }
    #endregion

    #region Variables & Properties

    protected HashSet<E> colletion;
    protected Stack<E> toAdd;
    protected Stack<E> toRemove;

    #endregion

    #region Public Methods
    public override void Refresh()
    {
        RemoveStackItemsFromCollection();
        UpdateCollection();
        AddStackItemsToCollection();
    }
    public override void FixedRefresh()
    {
        FixedUpdateCollection();
    }

    public void Add(E item)
    {
        toAdd.Push(item);
    }
    public void Remove(E item)
    {
        toRemove.Push(item);
    }
   
    #endregion

    #region Private Methods
    private void AddStackItemsToCollection()
    {
        while (toAdd.Count > 0)
        {
            colletion.Add(toAdd.Pop());
        }
    }
    private void RemoveStackItemsFromCollection()
    {
        while (toRemove.Count > 0)
        {
            colletion.Remove(toRemove.Pop());
        }
    }
    private void UpdateCollection()
    {
        foreach (var item in colletion)
        {
            item.Refresh();
        }
    }
    private void FixedUpdateCollection()
    {
        foreach (var item in colletion)
        {
            item.FixedRefresh();
        }
    }

    #endregion
}
