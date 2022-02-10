using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<Manager> managers = new List<Manager>();

    #region GameFlow (MainEntry)
    private void Awake()
    {
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
    #endregion
}
