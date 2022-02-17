using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaManager : Manager
{
    #region Singleton
    private static LavaManager instance;
    public static LavaManager Instance => instance ??= new LavaManager();
    protected LavaManager() { }
    #endregion

    public Lava Lava { get; private set; }

    public override void Init()
    {
        Lava = GameLinks.Instance.lava;
        Lava.Init();
    }

    public override void PostInit()
    {
        Lava.PostInit();
    }

    public override void Refresh()
    {
        Lava.Refresh();
    }

    public override void FixedRefresh()
    {
        Lava.FixedRefresh();
    }
}
