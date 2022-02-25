using System;
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
    public Collider thingfIhit;
    public Rigidbody ConnectedRBToBullet;

    private readonly Audio.Bullet audio = new Audio.Bullet();

    private void OnCollisionEnter(Collision collision)
    {
        if (chainGrapGun.isShoot && hit == false)
        {
            thingfIhit = collision.contacts[0].otherCollider;
            SwingToBuildings(collision);
            SwingTheTreasures(collision);
            SwingTheDragons(collision);
            chainGrapGun.Audio.StopShoot(chainGrapGun.gameObject);
            audio.PlayGrapplingImpact(gameObject);
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
            chainGrapGun.AddSpringJointToTreasure(collitionPositon + collision.contacts[0].normal, gunRB, collision.gameObject);
        }

    }
    void SwingTheDragons(Collision collision)
    {
        if (collision.gameObject.tag == "Dragon")
        {
            ConnectedRBToBullet = collision.gameObject.GetComponent<Rigidbody>();
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = ConnectedRBToBullet;
            collitionPositon = collision.contacts[0].point;
            joint.connectedAnchor = collitionPositon;
            hit = true;
            collision.gameObject.GetComponent<Dinosaur>().Scream();

            this.transform.position = collision.contacts[0].point;

            chainGrapGun.lr.positionCount = 2;
            chainGrapGun.AddSpringJointToDragon(collitionPositon + collision.contacts[0].normal, collision.gameObject.GetComponent<Rigidbody>());
        }

    }

    public void DestroyJoint()
    {
        hit = false;
        Destroy(joint);

        thingfIhit = null;
    }


}
