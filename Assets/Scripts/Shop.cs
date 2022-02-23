using System.IO;
using UnityEngine;

public class Shop : Manager
{
    #region Singleton
    private static Shop instance;
    public static Shop Instance => instance ??= new Shop();
    private Shop() {}
    #endregion

    
    public Inventory inventory;
    public override void Refresh()
    {

    }

    public override void FixedRefresh()
    {

    }

    public override void Init()
    {
        ReadJSON();
        Debug.Log(JsonUtility.ToJson(inventory));
    }

    public override void PostInit()
    {

    }

    private void ReadJSON()
    {
        using (StreamReader r = new StreamReader("json/inventory.json"))
        {
            string json = r.ReadToEnd();
            inventory = (Inventory)JsonUtility.FromJson(json, typeof(Inventory));
        }
    }

    public void WriteJSON()
    {
        using (StreamWriter w = new StreamWriter("json/inventory.json"))
        {
            w.Flush();
            w.Write(JsonUtility.ToJson(inventory));
        }
    }
}
