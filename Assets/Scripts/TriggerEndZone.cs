using System;
using UnityEngine;

public class TriggerEndZone : MonoBehaviour
{
    private int playerLayer;
    private int treasureLayer;

    private void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        treasureLayer = LayerMask.NameToLayer("Treasure");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == playerLayer)
        {
            WatchManager.Instance?.EnteredInTriggerZone();
        }
        else if (other.gameObject.layer == treasureLayer)
        {
            other.GetComponent<Treasure>().IsInSafeZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            WatchManager.Instance?.ExitedTriggerZone();
        }
        else if (other.gameObject.layer == treasureLayer)
        {
            other.GetComponent<Treasure>().IsInSafeZone = false;
        }
    }
}
