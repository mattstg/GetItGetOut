using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockEntry : MonoBehaviour
{
    void Start()
    {
        FlockManager.Instance.Init();
        FlockManager.Instance.PostInit();
    }

    void Update()
    {
        FlockManager.Instance.Refresh();
    }
}
