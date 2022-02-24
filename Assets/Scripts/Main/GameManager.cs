using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<Manager> managers = new List<Manager>();

    #region GameFlow (MainEntry)
    private void Awake()
    {
        GameObject.FindObjectOfType<GameLinks>().SetupGameLinks();
        managers.Add(HolsterManager.Instance);
        managers.Add(PlayerManager.Instance);
        managers.Add(WatchManager.Instance);
        managers.Add(DestructionManager.Instance);
        managers.Add(LavaManager.Instance);
        managers.Add(FlockManager.Instance);
        managers.Add(TreasureManager.Instance);
        managers.Add(Shop.Instance);

        InitManagers();
    }

    private void Start()
    {
        PostInitManagers();
    } 

    private void Update()
    {
        RefreshManagers();
    }

    private void FixedUpdate()
    {
        FixedRefreshManagers();
    }

    private void OnDestroy()
    {
        CleanManagers();
    }
    #endregion

    #region Class Methods
    private void InitManagers()
    {
        foreach (var manager in managers)
        {
            manager.Init();
        }
    }

    private void PostInitManagers()
    {
        foreach (var manager in managers)
        {
            manager.PostInit();
        }
    }

    private void RefreshManagers()
    {
        foreach (var manager in managers)
        {
            manager.Refresh();
        }
    }

    private void FixedRefreshManagers()
    {
        foreach (var manager in managers)
        {
            manager.FixedRefresh();
        }
    }

    private void CleanManagers()
    {
        foreach (var manager in managers)
        {
            manager.Clean();
        }
    }
    #endregion
}
