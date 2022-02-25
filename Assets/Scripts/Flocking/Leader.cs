using UnityEngine;

public class Leader : Dinosaur
{
    Vector3 currentWaypoint;
    float direction;

    float minimum = 10f;
    float maximum = 50f;
    float timer;
    int currentWaypointIndex;
    public Transform[] wayPoints;

    public override void Init()
    {
        base.Init();
        rb.GetComponent<Rigidbody>();
        timer = Random.Range(minimum, maximum);
        wayPoints = GameLinks.Instance.dinosaurWayPoints;
    }

    public override void Refresh()
    {
        UnityEngine.Debug.DrawRay(transform.position, transform.forward, Color.red); // for debug

        Vector3 dir = Vector3.zero;
        dir += WayPointAttraction();
        dir += BuildingAvoidance();
        dir /= 2f;
        ApplyForces(dir, null);
        DinosaursDeath();
    }

    protected override void ApplyForces(Vector3 dir, DesireDirectionVectors desiredPkg)
    {   
        transform.forward = dir;
        rb.AddForce(dir.normalized * speed);

        #region For Debug
        if (dir.z < -100000 || dir.z > 100000)
        {
            Debug.Log("LEADER BROKEN");
        }
        #endregion
    }

    protected override void DinosaursDeath()
    {
        base.DinosaursDeath();
    }

    public override Vector3 WayPointAttraction()
    {
        if (currentWaypoint != GetRandomWayPoint())
        {
            currentWaypoint = GetRandomWayPoint();
        }
        return (currentWaypoint - transform.position) * weights.targetPos;
    }

    protected override Vector3 BuildingAvoidance()
    {
        return base.BuildingAvoidance();
    }

    public Vector3 GetRandomWayPoint()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            currentWaypointIndex = Random.Range(0, wayPoints.Length);
            if (currentWaypointIndex == wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
            timer = Random.Range(minimum, maximum);
        }
        return wayPoints[currentWaypointIndex].position;
    }
}