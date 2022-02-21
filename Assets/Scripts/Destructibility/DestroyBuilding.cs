using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    public Rigidbody[] parts;

    public float num1;
    public float num2;


    public void setParts()
    {
        parts = GetComponentsInChildren<Rigidbody>();
    } 


    public void Explosion()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            Vector3 direction = new Vector3(Random.Range(num1, num2), Random.Range(num1, num2), Random.Range(num1, num2));
            parts[i].isKinematic = false;
            parts[i].AddForce(direction, ForceMode.Impulse);
            //parts[i].rig set rb to true
            MeshCollider mesh = parts[i].GetComponent<MeshCollider>();
            mesh.enabled = true;
        }
    }

    public void lavaCollision()
    {
        
    }
}
