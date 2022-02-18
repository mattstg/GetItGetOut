using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public FixedJoint joint;
    //   public GameObject chain;
    public Transform barrel;
    public Gun chainGrapGun;
    public GameObject gun;

    [System.NonSerialized]
        public bool hit;
    [System.NonSerialized]
    public Vector3 collitionPositon;
    public Collision collisionObj;


    private void OnCollisionEnter(Collision collision)
    {
        collisionObj = collision;
        if (chainGrapGun.isShoot && hit ==false )
        {
            if (collision.gameObject.tag == "Grappable")
            {
                joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
                collitionPositon = collision.contacts[0].point;
                joint.connectedAnchor = collitionPositon;
                hit = true;



                chainGrapGun.lr.positionCount = 2;
                chainGrapGun.AddSpringJoint(collitionPositon, collision.gameObject.GetComponent<Rigidbody>());
                Debug.Log("hitBuilding");
            }
            if (collision.gameObject.tag == "Treasure")
            {               
                joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
                collitionPositon = collision.contacts[0].point;
                joint.connectedAnchor = collitionPositon;
                hit = true;



                chainGrapGun.lr.positionCount = 2;
                chainGrapGun.AddSpringJointToTreasure(collitionPositon+ collision.contacts[0].normal , collision.gameObject.GetComponent<Rigidbody>(), collision.gameObject);
            }

        }

    }

    public void DestroyJoint()
    {
        hit = false;
        Destroy(joint);
    }



}
