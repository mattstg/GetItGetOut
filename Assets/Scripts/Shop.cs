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
        try
        {
            if (!File.Exists(Application.persistentDataPath + "/inventory.json"))
            {

                string path = "";

#if (UNITY_EDITOR || UNITY_STANDALONE_LINUX)
                path = "file://" + Application.streamingAssetsPath + "/GameData/inventory.json";
#endif

                if (Application.platform == RuntimePlatform.Android)
                {
                    path = Application.streamingAssetsPath + "/GameData/inventory.json";
                }

                UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(path);
                www.SendWebRequest();
                while (!www.isDone)
                {
                }

                byte[] loadBytes = www.downloadHandler.data;
                System.IO.File.WriteAllBytes(Application.persistentDataPath + "/inventory.json", loadBytes);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        

        try
        {
            using (StreamReader r = new StreamReader(Application.persistentDataPath + "/inventory.json"))
            {
                string json = r.ReadToEnd();
                inventory = (Inventory) JsonUtility.FromJson(json, typeof(Inventory));
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void WriteJSON()
    {
        string filePath = Application.persistentDataPath + "/inventory.json";
        
        try
        {
            using (StreamWriter w = new StreamWriter(filePath))
            {
                w.Write(JsonUtility.ToJson(inventory));
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }

    public override void Clean()
    {
        inventory = null;
    }
}
