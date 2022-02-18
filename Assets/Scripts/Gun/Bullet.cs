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
    public Rigidbody gunRB;

    [System.NonSerialized]
        public bool hit;
    [System.NonSerialized]
    public Vector3 collitionPositon;
    public Collision collisionObj;
    public Rigidbody ConnectedRBToBullet;


    private void OnCollisionEnter(Collision collision)
    {
        collisionObj = collision;
        if (chainGrapGun.isShoot && hit ==false )
        {
            SwingToBuildings(collisionObj);
            SwingTheTreasures(collision);

        }

    }
    void SwingToBuildings(Collision collision)
    {
        if (collision.gameObject.tag == "Grappable")
        {
            ConnectedRBToBullet = collision.gameObject.GetComponent<Rigidbody>();
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = ConnectedRBToBullet;
            collitionPositon = collision.contacts[0].point;
            joint.connectedAnchor = collitionPositon;
            hit = true;


            this.transform.position = collision.contacts[0].point;

            chainGrapGun.lr.positionCount = 2;
            chainGrapGun.AddSpringJoint(collitionPositon + collision.contacts[0].normal, collision.gameObject.GetComponent<Rigidbody>());
            Debug.Log("hitBuilding");
        }
    }
    void SwingTheTreasures(Collision collision)
    {
        if (collision.gameObject.tag == "Treasure")
        {
            ConnectedRBToBullet = collision.gameObject.GetComponent<Rigidbody>();
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = ConnectedRBToBullet;
            collitionPositon = collision.contacts[0].point;
            joint.connectedAnchor = collitionPositon;
            hit = true;
            

            this.transform.position = collision.contacts[0].point;
            chainGrapGun.lr.positionCount = 2;
            chainGrapGun.AddSpringJointToTreasure(collitionPositon + collision.contacts[0].normal, collision.gameObject.GetComponent<Rigidbody>(), collision.gameObject);
        }

    }

    public void DestroyJoint()
    {
        hit = false;
        Destroy(joint);
    }



}
