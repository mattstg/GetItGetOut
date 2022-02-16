using System;
using UnityEngine;

public class Holster : MonoBehaviour, IUpdaptable
{
    public GameObject centerEyeAnchor;
    public Transform XROrigin;
    
    public void Init()
    {
        
    }

    public void PostInit()
    {
        
    }

    public void Refresh()
    {
        Vector3 centerEyePosition = centerEyeAnchor.transform.position;

        float y = XROrigin.position.y + (centerEyePosition.y - XROrigin.position.y) / 2;
        transform.position = new Vector3(centerEyePosition.x, y, centerEyePosition.z);
        transform.rotation = centerEyeAnchor.transform.rotation;
}

    public void FixedRefresh()
    {
        
    }
}
