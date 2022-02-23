using UnityEngine;

public class Leader : Dinosaur
{
    Vector3 currentWaypoint;
    float direction;

    public override void Init()
    {
        base.Init();
        rb.GetComponent<Rigidbody>();
    }

    public override void Refresh()
    {
        UnityEngine.Debug.DrawRay(transform.position, transform.forward, Color.red);
        ApplyForces(WayPointAttraction());
    }

    protected override void ApplyForces(Vector3 dir)
    {
        transform.forward = dir;
        rb.AddForce(dir.normalized * speed);
    }

    protected override void DinosaursDeath()
    {
        base.DinosaursDeath();
    }

    public override Vector3 WayPointAttraction()
    {
        if (currentWaypoint != WaypointManager.Instance.GetRandomWayPoint())
        {
            currentWaypoint = WaypointManager.Instance.GetRandomWayPoint();
        }
        return (currentWaypoint - transform.position) * weights.targetPos;
    }
}
