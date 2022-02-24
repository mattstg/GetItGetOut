using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour , IUpdaptable
{
    public enum BuildingState
    {
        Alive,
        Destroyed,
        FullyMelted
    }

    public float minRandomRange;
    public float maxRandomRange;

    public BuildingState buildingState;
    public long TimerBeforCollapseInSeconds;

    private List<Rigidbody> parts;
    private Rigidbody parentRb;
    private MeshCollider[] meshCollider;
    private BoxCollider[] boxCollider;
    private int partsDisactivated;

    private long timeCountDown;

    public void Init()
    {
        SetCache();
    }

    public void PostInit()
    {
        if (TimerBeforCollapseInSeconds < 0)
            TimerBeforCollapseInSeconds = 0;

        timeCountDown = (long)Time.time + TimerBeforCollapseInSeconds;
    }

    public void Refresh()
    {
        if (buildingState == BuildingState.Alive)
        {
            IsTimerOut();
            LavaCollision();
        }

        if (buildingState == BuildingState.Destroyed && buildingState != BuildingState.FullyMelted)
        {
            ToggleOffPartsInLava();
        }
    }

    public void FixedRefresh()
    {
       
    }

    private void SetCache()
    {
        boxCollider = GetComponents<BoxCollider>();
        parentRb = GetComponent<Rigidbody>();
        parts = new List<Rigidbody> (GetComponentsInChildren<Rigidbody>());
        parts.RemoveAt(0);

        meshCollider = GetComponentsInChildren<MeshCollider>();
    }

    private void Explosion()
    {
        if (buildingState == BuildingState.Destroyed)
            return;

        buildingState = BuildingState.Destroyed;

        foreach (var collider in boxCollider)
        {
            collider.enabled = false;
        }
        Destroy(parentRb);

        for (int i = 0; i < parts.Count; i++)
        {
            meshCollider[i].enabled = true;
            parts[i].isKinematic = false;
            Vector3 direction = new Vector3(Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange));
            parts[i].AddForce(direction, ForceMode.Impulse);
        } 
    }
    
    private void LavaCollision()
    {
        float y = LavaManager.Instance.lava.transform.position.y;
        if (transform.position.y <= y)
        {
            Explosion();
        }
    }

    private void IsTimerOut()
    {
        if (Time.time >= timeCountDown)
        {
            Explosion();
        }
    }

    private void ToggleOffPartsInLava()
    {
        foreach (var part in parts)
        {
            if (part.gameObject.activeInHierarchy && LavaManager.Instance.lava.transform.position.y > part.position.y)
            {
                part.gameObject.SetActive(false);
                partsDisactivated++;
                if (partsDisactivated == parts.Count)
                {
                    buildingState = BuildingState.FullyMelted;
                }
            }
        }
    }
}
