using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour, IUpdaptable
{
    public const float MAX_LEVEL_HEIGHT = 300;
    public const float LEVEL_TIME = 300;//300 sec = 5min
    
    public void Init()
    {
      
    }

    public void PostInit()
    {

    }

    public void Refresh()
    {
        
    }

    public void FixedRefresh()
    {
        throw new System.NotImplementedException();
    }
}
