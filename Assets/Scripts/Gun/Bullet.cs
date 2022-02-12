using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    FixedJoint joint;
    //   public GameObject chain;
    public Transform barrel;
    public Gun chainGrapGun;
    public GameObject gun;

    [System.NonSerialized]
        public bool hit;
    [System.NonSerialized]
    public Vector3 collitionPositon;
    


    private void OnCollisionEnter(Collision collision)
    {
        if (chainGrapGun.isShoot)
        {
            if (collision.gameObject.tag == "Grappable")
            {
                joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
                collitionPositon = collision.contacts[0].point;
                joint.connectedAnchor = collitionPositon;
                hit = true;



                chainGrapGun.lr.positionCount = 2;
                chainGrapGun.Swing(collitionPositon, collision.gameObject.GetComponent<Rigidbody>());
            }

        }

    }
    public void DestroyJoint()
    {
        hit = false;
        Destroy(joint);
    }


}
