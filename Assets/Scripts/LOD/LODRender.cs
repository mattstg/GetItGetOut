using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODRender : MonoBehaviour, IUpdaptable
{
    private HashSet<Collider> m_Colliders;

    private long timeRefreshCycle = 1000;
    private long timerEnd;
    public int LODRange;


    public void Init()
    {
        m_Colliders = new HashSet<Collider>(GameObject.FindObjectsOfType<Collider>());
        timerEnd = (long)Time.deltaTime + timeRefreshCycle;
        
    }

    public void PostInit()
    {
        
    }

    public void Refresh()
    {
        
    }
    public void FixedRefresh()
    {
        
    }



    private Vector3 GetPLayerPos()
    {

        //need info on player pos
        return new Vector3(0,0,0);
    }
}
