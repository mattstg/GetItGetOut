using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : Manager<FlockManager, Flock>
{
    public Dinosaur[] GetAllDinosaurs()
    {
        Debug.Log("GetAllDinasours");
        return null;
    }

    public override void Init()
    {

        Flock[] allFlocks = GameObject.FindObjectsOfType<Flock>();
        foreach (Flock flock in allFlocks)
        {
            Add(flock);
            flock.Init();
        }
    }

    public override void PostInit()
    {
    }

    //public override void Refresh()
    //{
    //    base.Refresh();
    //}
    //public override void FixedRefresh()
    //{
    //    base.FixedRefresh();
    //}
}
