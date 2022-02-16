using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour, IUpdaptable
{
    public Leader leader;
    public Dinasour[] dinasours;

    List<Dinasour> dinasoursInFlock;

    public void Init()
    {
        dinasoursInFlock = new List<Dinasour>();
        leader.Init();
        dinasoursInFlock.Add(leader);

        foreach (Dinasour dinasour in transform.GetComponentsInChildren<Dinasour>())
        {
            // add them to the list then the array
        }

        foreach (Dinasour dinasour in dinasours)
        {
            dinasour.Init();
            //dinasour.ourFlock = dinasour.LinkToFlock(this);
            dinasoursInFlock.Add(dinasour);
        }
    }

    public void PostInit()
    {
        leader.PostInit();
        foreach (Dinasour dinasour in dinasours)
        {
            dinasour.PostInit();
        }
    }

    public void Refresh()
    {
        leader.Refresh();
        foreach (Dinasour dinasour in dinasours)
        {
            dinasour.Refresh();
        }
    }

    public void FixedRefresh()
    {
        leader.FixedRefresh();
        foreach (Dinasour dinasour in dinasours)
        {
            dinasour.FixedRefresh();
        }
    }

    public List<Dinasour> GetOtherDinasoursInFlock(Dinasour dinasour)
    {
        List<Dinasour> temp = new List<Dinasour>(dinasoursInFlock);
        temp.Remove(dinasour);
        return temp;
    }
}
