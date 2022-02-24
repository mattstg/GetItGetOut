using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour, IUpdaptable
{
    public Leader leader;
    public Dinosaur[] dinosaurs;
    List<Dinosaur> dinosaursInFlock;
    List<Dinosaur> allDinosaursInOtherFlocks;

    public void Init()
    {
        dinosaursInFlock = new List<Dinosaur>();
        leader.Init();

        allDinosaursInOtherFlocks = new List<Dinosaur>(FlockManager.Instance.GetAllDinosaurs());

        foreach (Dinosaur dinosaur in transform.GetComponentsInChildren<Dinosaur>())
        {
            // add them to the list then the array
            // I think i will delete it
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

    public List<Dinosaur> GetOtherFlocks(Dinosaur dinosaur, List<Dinosaur> flock)
    {
        List<Dinosaur> temp = new List<Dinosaur>(allDinosaursInOtherFlocks);
        foreach (Dinosaur dino in flock)
        {
            temp.Remove(dino);
        }
        temp.Remove(dinosaur);
        return temp;
    }
}