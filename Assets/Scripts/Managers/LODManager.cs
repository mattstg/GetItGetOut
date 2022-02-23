using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LODManager : Manager
{
    #region singleton

    private static LODManager instance;
    public static LODManager Instance => instance ??= new LODManager();
    private LODManager() { }
    #endregion

    private LODRender lod;
    

    public override void Init()
    {
        lod = new LODRender();  
        lod.Init();
    }

    public override void PostInit()
    {
        lod.PostInit();
    }

    public override void Refresh()
    {
        lod.Refresh();  
    }
    public override void FixedRefresh()
    {
        lod.FixedRefresh();
    }
}
