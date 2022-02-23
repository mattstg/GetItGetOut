using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour , IUpdaptable
{
    public enum BuildingState
    {
        Alive,
        ToDestroy,
        Destroyed
    }

    public float minRandomRange;
    public float maxRandomRange;

    public BuildingState buildingState;
    public long TimerBeforCollapseMs;

    public Rigidbody[] parts;
    private MeshCollider[] meshCollider;
    private BoxCollider[] boxCollider;

    private long timeCountDown;

    public void Init()
    {
        SetCache();
    }

    public void PostInit()
    {
        if (TimerBeforCollapseMs < 0)
            TimerBeforCollapseMs = 0;

        timeCountDown = (long)Time.deltaTime + TimerBeforCollapseMs;
    }

    public void Refresh()
    {
        if (buildingState == BuildingState.Alive)
            IsTimerOut();

        //LavaCollision();
        if (buildingState == BuildingState.ToDestroy)
            Explosion();
    }

    public void FixedRefresh()
    {
       
    }

    private void SetCache()
    {
        boxCollider = GetComponents<BoxCollider>();
        parts = GetComponentsInChildren<Rigidbody>();
        meshCollider = GetComponentsInChildren<MeshCollider>();
    }

    public void Explosion()
    {
        buildingState = BuildingState.Destroyed;
        foreach (var collider in boxCollider)
        {
            collider.enabled = false;
        }

        for (int i = 0; i < parts.Length; i++)
        {
            meshCollider[i].enabled = true;
            parts[i].isKinematic = false;
            Vector3 direction = new Vector3(Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange));
            parts[i].AddForce(direction, ForceMode.Impulse);
        } 
    }
    
    public void LavaCollision()
    {
        //logic for when building touches lava
        buildingState = BuildingState.ToDestroy;
    }

    public void IsTimerOut()
    {
        if (Time.deltaTime <= timeCountDown)
        {
            buildingState = BuildingState.ToDestroy;
        }
    }

}
