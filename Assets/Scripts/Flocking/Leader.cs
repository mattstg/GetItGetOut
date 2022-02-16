using UnityEngine;

public class Leader : Dinasour
{
    WaypointManager waypoint;
    Vector3 currentWaypoint;

    public override void Init()
    {
        base.Init();
        waypoint = FindObjectOfType(typeof(WaypointManager)) as WaypointManager;
        waypoint.Init();
        rb.GetComponent<Rigidbody>();
    }

    public override Vector3 WayPointAttraction()
    {
        if (currentWaypoint != waypoint.GetRandomWayPoint())
        {
            currentWaypoint = waypoint.GetRandomWayPoint();
        }
        return (currentWaypoint - transform.position).normalized;
    }
}
