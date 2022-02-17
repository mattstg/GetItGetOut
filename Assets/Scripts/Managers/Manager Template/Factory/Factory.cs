using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public interface IFactory
{
    public void Init();
    public void PostInit();
}

public abstract class Factory<T, E, A> : IFactory where T : class, new() where E : System.Enum
{
    #region Singleton
    private static T instance;
    public static T Instance => instance ??= new T();
    protected Factory() 
    {
        prefabDictionnary = new Dictionary<E, GameObject>();
    }
    #endregion

    private string PREFAB_LOCATION => "Prefabs/" + typeof(E).ToString();
    private Dictionary<E, GameObject> prefabDictionnary;

    public void Init()
    {
        E[] allPrefabTypes = System.Enum.GetValues(typeof(E)).Cast<E>().ToArray();
        
        foreach(E element in allPrefabTypes)
        {
            prefabDictionnary.Add(element, Resources.Load<GameObject>(PREFAB_LOCATION + element));
        }
    }

    public abstract void PostInit();

    public E Create(E type, A args)
    {
        E toReturn;
        toReturn = (E)ObjectPool.

        return 
    }
    



}
