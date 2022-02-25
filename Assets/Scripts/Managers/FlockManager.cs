using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : Manager<FlockManager, Flock>
{
    Flock[] allFlocks;
    List <Dinosaur> allDinosaurs;
    
    #region batching
    //const int batches = 4;
    //int currentBatchNumber = 0;
    #endregion

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

    #region Batching method
    //public override void Refresh()
    //{
    //    for (int i = currentBatchNumber; i < allFlocks.Length; i+= batches)
    //    {
    //        allFlocks[i].Refresh();
    //    }
    //    currentBatchNumber = (currentBatchNumber + 1) % batches;
    //}
    #endregion

    public List<Dinosaur> GetAllDinosaurs()
    {
        return allDinosaurs;
    }

}