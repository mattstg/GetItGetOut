using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Gun : MonoBehaviour
{
    public float speed = 100;
    public float force = 100;

    public Bullet bullet;
    public Rigidbody BulletRB;
    public Transform barrel;
    public LineRenderer lr;
   
    //force

    public InputActionReference selectButton;
    public GameObject player;
    private SpringJoint jointToPlayer;

    [System.NonSerialized]
    public bool isShoot;

    private void LateUpdate()
    {
        if (bullet.hit)
        {
            if (selectButton.action.ReadValue<float>() == 1 )
            {
                player.GetComponent<Rigidbody>().AddForce((bullet.collitionPositon - player.transform.position) * force * Time.deltaTime);

            }
            DrawRope(bullet.joint.connectedBody.transform.position);
        }

        if (!isShoot)
        {
            bullet.gameObject.transform.position = barrel.position;
            bullet.gameObject.transform.rotation = barrel.rotation;

        }
        
    }

    //  public XRController controller;

    // Update is called once per frame
    public void FireBullet()
    {
        bullet.gameObject.transform.position = barrel.position;
        bullet.gameObject.transform.rotation = barrel.rotation;
        //  controller.gameObject.GetComponent<XRDirectInteractor>().playHapticsOnSelectEnter = true;
        isShoot = true;
        BulletRB.velocity = speed * barrel.forward;

    }
    public void DestroySpringJoint()
    {
        isShoot = false;
        bullet.DestroyJoint();
        lr.positionCount = 0;
        Destroy(jointToPlayer);

    }
    private void Update()
    {
        //if (ChechIfActivated(controller))
        //{
        //    Debug.Log("isPressed");
        //}
        MakeRayCastToHit();
    }

    public void AddSpringJoint(Vector3 PointToSwing, Rigidbody rbConnected)
    {
        jointToPlayer = player.gameObject.AddComponent<SpringJoint>();
        jointToPlayer.autoConfigureConnectedAnchor = false;
        jointToPlayer.connectedBody = rbConnected;
        jointToPlayer.connectedAnchor = rbConnected.gameObject.transform.position - PointToSwing;
        jointToPlayer.anchor = new Vector3(0, 0, 0);
        // jointToPlayer.connectedAnchor = PointToSwing;
        float distanceFromPoint = Vector3.Distance(player.transform.position, PointToSwing);

        jointToPlayer.maxDistance = distanceFromPoint * 0.7f;
        jointToPlayer.minDistance = 0;


        jointToPlayer.spring = 4.5f;
        jointToPlayer.damper = 7f;
        jointToPlayer.massScale = 4.5f;

    }

    void DrawRope(Vector3 hitPoint)
    {
        if (!bullet.hit) return;

        lr.SetPosition(0, barrel.position);
        lr.SetPosition(1, hitPoint);

    }

    void MakeRayCastToHit()
    {
        RaycastHit hit;
        Ray ray = new Ray(barrel.position, (bullet.gameObject.transform.position - player.transform.position).normalized);
        if (Physics.Raycast(ray, out hit, Vector3.Distance(barrel.position, bullet.gameObject.transform.position) - 1))
            if (hit.transform.gameObject.tag =="Grappable")
            {
                DestroySpringJoint();
            }

    }
     


}
