using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPart: MonoBehaviour
{
    Audio.BuildingPart audio = new Audio.BuildingPart();
    public bool IsActive { get; set; }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.layer == LayerMask.NameToLayer("Building") || collision.gameObject.layer == LayerMask.NameToLayer("DestructibleBuilding")) && IsActive)
        {
            audio.PlayCollision(gameObject);
        }
    }

}
