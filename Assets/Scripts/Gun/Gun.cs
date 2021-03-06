using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Gun : MonoBehaviour
{
    public float Bulletspeed = 100;
    public float Reelingforce = 100;

    public Bullet bullet;
    public Rigidbody BulletRB;
    public Transform barrel;
    public LineRenderer lr;

    //force

    public InputActionReference selectButton;
    public GameObject player;
    public Rigidbody playerRB;
    public SpringJoint jointToPlayer;
    public SpringJoint jointTreasureToPlayer;
    public SpringJoint jointTreasureToDragon;

    [System.NonSerialized]
    public bool isShoot;
    Vector3 pos2;



    private float mindis = 1;
    private float maxdis = 1;

    //Audio
    public Audio.GrapplingGun Audio { get; private set; }

    private void Start()
    {
        player = GameLinks.Instance.XROrigin;
        playerRB = GameLinks.Instance.XROriginRb;
        Audio = new Audio.GrapplingGun();
    }

    public void GrappleHookAttachedToObject(Collider attachedObj, bool isTreasure)
    {

    }

    public void Reeling()
    {
        if (bullet.hit && bullet.thingfIhit.gameObject.tag == "Grappable")
        {

                jointToPlayer.maxDistance -= Reelingforce * Time.fixedDeltaTime;
                jointToPlayer.minDistance -= Reelingforce * Time.fixedDeltaTime;


          
            
        }
        if (bullet.hit && bullet.thingfIhit.gameObject.CompareTag("Treasure"))
        {
            jointTreasureToPlayer.minDistance -= Reelingforce * Time.fixedDeltaTime;
            jointTreasureToPlayer.maxDistance -= Reelingforce * Time.fixedDeltaTime;
        }
        if (bullet.hit && bullet.thingfIhit.gameObject.CompareTag("Dragon"))
        {
            jointTreasureToDragon.minDistance -= Reelingforce * Time.fixedDeltaTime;
            jointTreasureToDragon.maxDistance -= Reelingforce * Time.fixedDeltaTime;
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
        //sound
        bullet.gameObject.transform.position = barrel.position;
        bullet.gameObject.transform.rotation = barrel.rotation;
        //  controller.gameObject.GetComponent<XRDirectInteractor>().playHapticsOnSelectEnter = true;
        isShoot = true;
        BulletRB.velocity = Bulletspeed * barrel.forward;
        Audio.PlayShoot(gameObject);
    }

    public void DestroySpringJoint()
    {

        isShoot = false;
        bullet.DestroyJoint();
        lr.positionCount = 0;
        Destroy(jointToPlayer);
        Destroy(jointTreasureToPlayer);
        Destroy(jointTreasureToDragon);
        Audio.StopShoot(gameObject);

    }
    private void Update()
    {
        CheckIfObjectStillExistToGrap();
      //  MakeRayCastToHit();
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
        jointToPlayer.maxDistance = distanceFromPoint * 0.9f;
        jointToPlayer.minDistance = distanceFromPoint * 0.9f;


        jointToPlayer.spring = 100f;
        jointToPlayer.damper = 60f;
        //  jointToPlayer.massScale = 4.5f;

    }
    public void AddSpringJointToDragon(Vector3 PointToSwing, Rigidbody rbConnected)
    {
        Transform obj = rbConnected.GetComponent<Transform>();
        jointTreasureToDragon = player.gameObject.AddComponent<SpringJoint>();
        jointTreasureToDragon.autoConfigureConnectedAnchor = false;
        jointTreasureToDragon.connectedBody = rbConnected;
        jointTreasureToDragon.connectedAnchor = new Vector3(0, 0, 0);
        jointTreasureToDragon.anchor = new Vector3(0, 0, 0);
        // jointToPlayer.connectedAnchor = PointToSwing;
        float distanceFromPoint = Vector3.Distance(player.transform.position, PointToSwing);
        jointTreasureToDragon.enableCollision = true;
        jointTreasureToDragon.maxDistance = distanceFromPoint * 0.9f;
        jointTreasureToDragon.minDistance = distanceFromPoint *0.9f;


        jointTreasureToDragon.spring = 100f;
        jointTreasureToDragon.damper = 60f;
        //  jointToPlayer.massScale = 4.5f;

    }
    public void AddSpringJointToTreasure(Vector3 PointToSwing, Rigidbody rbConnected, GameObject TreasureGameObject)
    {
        jointTreasureToPlayer = TreasureGameObject.AddComponent<SpringJoint>();
        jointTreasureToPlayer.autoConfigureConnectedAnchor = false;
        jointTreasureToPlayer.connectedBody = playerRB;
        jointTreasureToPlayer.connectedAnchor = new Vector3(0, 0, 0);
        jointTreasureToPlayer.anchor = new Vector3(0, 0, 0);
        // jointToPlayer.connectedAnchor = PointToSwing;
        float distanceFromPoint = Vector3.Distance(player.transform.position, PointToSwing);

        jointTreasureToPlayer.maxDistance = distanceFromPoint * 0.9f;
        jointTreasureToPlayer.minDistance = distanceFromPoint * 0.9f;
        jointTreasureToPlayer.enableCollision = true;


        jointTreasureToPlayer.spring = 60f;
        jointTreasureToPlayer.damper = 30f;
        //  jointTreasureToPlayer.massScale = 1f;




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
        if (Physics.Raycast(ray, out hit, Vector3.Distance(barrel.position, bullet.gameObject.transform.position) - 1) && bullet.hit)
        {
            //if (hit.transform.gameObject != hit.transform.gameObject)
            //{
            //    DestroySpringJoint();
            //}

        }
           

    }
    void CheckIfObjectStillExistToGrap()
    {
        if (bullet.hit)
        {
            if (!bullet.thingfIhit.enabled)
            {
                DestroySpringJoint();
            }


        }



    }

}
