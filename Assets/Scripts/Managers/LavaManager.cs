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

    public Lava lava { get; private set; }

    public float TimeRemaining => lava.TimeRemaining;

    public override void Init()
    {
        lava = GameLinks.Instance.lava;
        lava.Init();
    }

    public override void PostInit()
    {
        lava.PostInit();
    }

    public override void Refresh()
    {
        lava.Refresh();
    }

    public override void FixedRefresh()
    {
        lava.FixedRefresh();
    }

    public override void Clean()
    {
        return;
    }
}
