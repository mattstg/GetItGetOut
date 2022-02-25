using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : Manager<FlockManager, Flock>
{
    Flock[] allFlocks;
    List <Dinosaur> allDinosaurs;
    public override void Init()
    {
        allDinosaurs = new List<Dinosaur>();
        allFlocks = GameObject.FindObjectsOfType<Flock>();

        foreach (Flock flock in allFlocks)
        {
            Add(flock);
            flock.Init();
        }

        foreach (Flock flock in allFlocks)
        {
            allDinosaurs.Add(flock.GetComponentInChildren<Dinosaur>());
            allDinosaurs.Add(flock.GetComponentInChildren<Leader>());
        }
    }

    public override void PostInit()
    { }

    public List<Dinosaur> GetAllDinosaurs()
    {
        return allDinosaurs;
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