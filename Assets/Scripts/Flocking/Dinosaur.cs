using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour, IUpdaptable
{
    protected float maxSpeed = 10f;
    protected Vector3 desireDir;
    protected Rigidbody rb;
    protected FlockWeights weights;
    protected Flock ourFlock;
    protected Dinosaur[] GetAllDinosaurs { get { return FlockManager.Instance.GetAllDinosaurs(); } }
    protected List<Dinosaur> GetOtherDinosaursInFlock { get { return ourFlock.GetOtherDinosaursInFlock(this); } }
    protected float GetLavaHeight { get { Debug.Log("not implemented for lava height"); return 0; } } // get value from lava manager
    protected float DistanceToLeader { get { return Vector3.Distance(transform.position, ourFlock.leader.transform.position); } } //Sqr magnitude is better
    //avoid obstacles by raycast

    public virtual void Init()
    {
        rb = GetComponent<Rigidbody>();
        ourFlock = GetComponentInParent<Flock>();
        weights = new FlockWeights();
    }

    public void PostInit()
    {
    }

    public void Refresh()
    {
        desireDir = NeighborsAvoidance();
        desireDir += NeighborsCohesion();
        desireDir += WayPointAttraction();
        //desireDir += LeaderAlignment();

        desireDir /= 3f;
    }

    public void FixedRefresh()
    {
        ApplyForces(desireDir);
    }

    private void ApplyForces(Vector3 dir)
    {
        rb.AddForce(dir.normalized);
    }


    #region Flocking Calculations
    //const float distanceToAvoidNeighbour = 10f;

    public virtual Vector3 WayPointAttraction() { return Vector3.zero; }

    public virtual Vector3 LeaderAlignment()
    {
        //Vector3 facingDirection;
        return Vector3.zero;
    }

    public virtual Vector3 NeighborsCohesion()
    {
        Vector3 cohesionVector = Vector3.zero;

        foreach (Dinosaur dinasour in GetOtherDinosaursInFlock)
        {
            cohesionVector += dinasour.transform.position;
        }

        cohesionVector /= GetOtherDinosaursInFlock.Count;

        return cohesionVector * weights.cohesion;
    }

    public virtual Vector3 NeighborsAvoidance()
    {
        Vector3 avoidanceVector = Vector3.zero;
        int numToAvoid = 0;
        float sqrDistanceToAvoid = 10f;

        foreach (Dinosaur dinasour in GetOtherDinosaursInFlock)
        {
            if (Vector3.SqrMagnitude(transform.position - dinasour.transform.position) < sqrDistanceToAvoid)
            {
                numToAvoid++;
                avoidanceVector += transform.position - dinasour.transform.position;
                // need to recalculate the avoidance dir.
            }
        }

        if (numToAvoid != 0)
            avoidanceVector /= numToAvoid;

        return avoidanceVector * weights.avoidance;
    }
    #endregion
}
