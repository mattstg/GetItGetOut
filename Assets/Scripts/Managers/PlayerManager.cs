using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Manager
{
    #region Singleton
    private static PlayerManager instance;
    public static PlayerManager Instance => instance ??= new PlayerManager();
    private PlayerManager() {}
    #endregion

    public Player player;


    public override void Init()
    {
        player = GameLinks.Instance.player;
        player.Init();
    }

    public override void PostInit()
    {
        player.PostInit();
    }

    public override void Refresh()
    {
        player.Refresh();
    }

    public override void FixedRefresh()
    {
        player.FixedRefresh();
    }

    public override void Clean()
    {
        return;
    }
}
