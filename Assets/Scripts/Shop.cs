using System;
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
        inventory = new Inventory();
        inventory.money = 0;
        ReadJSON();
    }

    public override void PostInit()
    {

    }

    private void ReadJSON()
    {
        #if UNITY_EDITOR
        
        try
        {
            using (StreamReader r = new StreamReader("json/inventory.json"))
            {
                string json = r.ReadToEnd();
                inventory = (Inventory)JsonUtility.FromJson(json, typeof(Inventory));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        #endif
    }

    public void WriteJSON()
    {
        #if UNITY_EDITOR
        
        try
        {
            using (StreamWriter w = new StreamWriter("json/inventory.json"))
            {
                w.Flush();
                w.Write(JsonUtility.ToJson(inventory));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        #endif

    }

    public override void Clean()
    {
        inventory = null;
    }
}
