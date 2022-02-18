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
    public Rigidbody playerRB;
    private SpringJoint jointToPlayer;
    private SpringJoint jointTreasureToPlayer;

    [System.NonSerialized]
    public bool isShoot;
    Vector3 pos2;

    
    private float mindis = 1;
    private float maxdis = 1;
    private void Start()
    {
        player = GameLinks.Instance.XROrigin;
        playerRB = GameLinks.Instance.XROriginRb;


    }
    private void FixedUpdate()
    {
        if (bullet.hit)
        {
            if (selectButton.action.ReadValue<float>() == 1 && bullet.collisionObj.gameObject.tag== "Grappable")
            {
                jointToPlayer.maxDistance -=100*Time.fixedDeltaTime;
                jointToPlayer.minDistance -=100*Time.fixedDeltaTime;
             //   Debug.Log(maxdis);
            }
            //if (selectButton.action.ReadValue<float>() == 1 && bullet.collisionObj.gameObject.tag == "Treasure")
            //{
            //     bullet.collisionObj.gameObject.GetComponent<Rigidbody>().AddForce((player.transform.position- bullet.collisionObj.gameObject.transform.position) * force * Time.deltaTime);

            //    Debug.Log("hey ");
            //}
        }

    }
    private void LateUpdate()
    {
        pos2 = bullet.transform.position;
        if (bullet.hit)
        {
          //  Debug.Log(pos2);

            DrawRope(pos2);
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
        Destroy(jointTreasureToPlayer);


    }
    private void Update()
    {
        CheckIfObjectStillExistToGrap();
        MakeRayCastToHit();
    }

    public void AddSpringJoint(Vector3 PointToSwing, Rigidbody rbConnected)
    {
        Transform obj = rbConnected.GetComponent<Transform>();
        jointToPlayer = player.gameObject.AddComponent<SpringJoint>();
        jointToPlayer.autoConfigureConnectedAnchor = false;
        jointToPlayer.connectedBody = rbConnected;
        jointToPlayer.connectedAnchor = obj.InverseTransformPoint(PointToSwing);
        jointToPlayer.anchor = new Vector3(0, 0, 0);
        // jointToPlayer.connectedAnchor = PointToSwing;
        float distanceFromPoint = Vector3.Distance(player.transform.position, PointToSwing);
        jointToPlayer.enableCollision = true;
        jointToPlayer.maxDistance = distanceFromPoint * 0.7f;
        jointToPlayer.minDistance = distanceFromPoint * 0.1f;


        jointToPlayer.spring = 4.5f;
        jointToPlayer.damper = 7f;
        jointToPlayer.massScale = 4.5f;

    }
    public void AddSpringJointToTreasure(Vector3 PointToSwing, Rigidbody rbConnected,GameObject TreasureGameObject)
    {
        jointTreasureToPlayer = TreasureGameObject.AddComponent<SpringJoint>();
        jointTreasureToPlayer.autoConfigureConnectedAnchor = false;
        jointTreasureToPlayer.connectedBody = playerRB;
        jointTreasureToPlayer.connectedAnchor =new Vector3(0,0,0);
        jointTreasureToPlayer.anchor = new Vector3(0, 0, 0);
        // jointToPlayer.connectedAnchor = PointToSwing;
        float distanceFromPoint = Vector3.Distance(player.transform.position, PointToSwing);

        jointTreasureToPlayer.maxDistance = distanceFromPoint * 0.7f;
        jointTreasureToPlayer.minDistance = distanceFromPoint * 0.1f;
        jointToPlayer.enableCollision = true;


        jointTreasureToPlayer.spring = 4.5f;
        jointTreasureToPlayer.damper = 7f;
        jointTreasureToPlayer.massScale = 5f;

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
        if (Physics.Raycast(ray, out hit, Vector3.Distance(barrel.position, bullet.gameObject.transform.position) - 1)&& bullet.hit)
            if (hit.transform.gameObject != hit.transform.gameObject)
            {
                DestroySpringJoint();
            }

    }
    void CheckIfObjectStillExistToGrap()
    {
        //if(bullet.hit) {
        //    if (bullet.collisionObj.contacts[0].otherCollider.gameObject.(//////destuctionFunction ==true )
        //    {
        //        DestroySpringJoint();
        //    }


        //}
        
    

    }
     


}
