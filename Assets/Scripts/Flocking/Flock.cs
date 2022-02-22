using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour, IUpdaptable
{
    public Leader leader;
    public Dinosaur[] dinosaurs;
    List<Dinosaur> dinosaursInFlock;

    public void Init()
    {
        dinosaursInFlock = new List<Dinosaur>();
        leader.Init();
        //dinosaursInFlock.Add(leader);

        foreach (Dinosaur dinosaur in transform.GetComponentsInChildren<Dinosaur>())
        {
            // add them to the list then the array
        }

        foreach (Dinosaur dinosaur in dinosaurs)
        {
            dinosaur.Init();
            dinosaursInFlock.Add(dinosaur);
        }
    }

    public void PostInit()
    {
        leader.PostInit();
        foreach (Dinosaur dinosaur in dinosaurs)
        {
            dinosaur.PostInit();
        }
    }

    public void Refresh()
    {
        leader.Refresh();
        foreach (Dinosaur dinosaur in dinosaurs)
        {
            dinosaur.Refresh();
        }
    }

    public void FixedRefresh()
    {
        leader.FixedRefresh();
        foreach (Dinosaur dinosaur in dinosaurs)
        {
            dinosaur.FixedRefresh();
        }
    }

    public List<Dinosaur> GetOtherDinosaursInFlock(Dinosaur dinosaur)
    {
        List<Dinosaur> temp = new List<Dinosaur>(dinosaursInFlock);
        temp.Remove(dinosaur);
        return temp;
    }
}
