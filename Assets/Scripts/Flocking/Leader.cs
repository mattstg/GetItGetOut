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
        UnityEngine.Debug.DrawRay(transform.position, transform.forward, Color.red);
        Vector3 dir = Vector3.zero;
        dir += WayPointAttraction();
        dir += BuildingAvoidance();
        ApplyForces(dir, null);
    }

    protected override void ApplyForces(Vector3 dir, DesireDirectionVectors desiredPkg)
    {   
        transform.forward = dir;
        if(dir.z < -100000 || dir.z > 100000)
        {
            Debug.Log("LEADER BROKEN");
        }

        rb.AddForce(dir.normalized * speed);
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
