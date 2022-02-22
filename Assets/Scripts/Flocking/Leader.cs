using UnityEngine;

public class Leader : Dinosaur
{
    WaypointManager waypoint;
    Vector3 currentWaypoint;
    float direction;

    public override void Init()
    {
        base.Init();
        waypoint = FindObjectOfType(typeof(WaypointManager)) as WaypointManager;
        waypoint.Init();
        rb.GetComponent<Rigidbody>();
    }

    public override void Refresh()
    {
        UnityEngine.Debug.DrawRay(transform.position, transform.forward, Color.red);
        ApplyForces(WayPointAttraction());
    }

    protected override void ApplyForces(Vector3 dir)
    {
        //direction = Vector3.Angle(transform.forward, dir);
        //rb.velocity += dir.normalized * speed *Time.deltaTime;
        //if(transform.forward - dir )
        transform.forward = dir;
        rb.AddForce(dir.normalized * speed);
    }

    public override Vector3 WayPointAttraction()
    {
        if (currentWaypoint != waypoint.GetRandomWayPoint())
        {
            currentWaypoint = waypoint.GetRandomWayPoint();
        }
        return (currentWaypoint - transform.position) * weights.targetPos;
    }
}
