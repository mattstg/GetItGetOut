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
        string filePath = Application.streamingAssetsPath + "/GameData/inventory.json";

        #if UNITY_EDITOR
        try
        {
            using (StreamReader r = new StreamReader(filePath))
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
        
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("aaa");
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }

            string json;
            json = reader.text;
            inventory = (Inventory)JsonUtility.FromJson(json, typeof(Inventory));
        }
    }

    public void WriteJSON()
    {
        string filePath = Application.streamingAssetsPath + "/GameData/inventory.json";
        
        #if UNITY_EDITOR
        
        try
        {
            using (StreamWriter w = new StreamWriter(filePath))
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
