using UnityEngine;

public class Leader : Dinosaur
{
    WaypointManager waypoint;
    Vector3 currentWaypoint;
    float dire;

    public override void Init()
    {
        base.Init();
        waypoint = FindObjectOfType(typeof(WaypointManager)) as WaypointManager;
        waypoint.Init();
        rb.GetComponent<Rigidbody>();
    }

    public override void Refresh()
    {
        ApplyForces(WayPointAttraction());
    }

    protected override void ApplyForces(Vector3 dir)
    {
        //dire = Vector3.Angle(transform.forward, dir);
        rb.AddForce(dir.normalized);
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
