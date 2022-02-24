using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaRotation : MonoBehaviour
{
    public float rotation = 0;
    void Update()
    {
        transform.Rotate(0, rotation * Time.deltaTime, 0);
    }
}
