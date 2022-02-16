using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinasour : MonoBehaviour, IUpdaptable
{
    protected float maxSpeed = 10f;
    protected Rigidbody rb;
    protected FlockWeights weights;
    public Flock ourFlock;
    protected Dinasour[] GetAllDinasours { get { return FlockManager.Instance.GetAllDinasours(); } }
    protected List<Dinasour> GetDinasoursInFlock { get { return ourFlock.GetOtherDinasoursInFlock(this); } }
    protected List<Dinasour> getDinasoursInFlock;
    protected float GetLavaHeight { get { Debug.Log("not implemented for lava height"); return 0; } } // get value from lava manager
    protected float DistanceToLeader { get { return Vector3.Distance(transform.position, ourFlock.leader.transform.position); } } //Sqr magnitude is better
    //avoid obstacles by raycast

    public virtual void Init()
    {
        ourFlock = GetComponentInParent<Flock>();
        Debug.Log(ourFlock.name);
        weights = new FlockWeights();
        rb = GetComponent<Rigidbody>();
    }

    public void PostInit()
    {
    }

    public void Refresh()
    {
      //Debug.Log("Refresh in dinasour is called" + name);

        Vector3 desireDir = NeighborsAvoidance();
        desireDir += NeighborsCohesion();
        desireDir += WayPointAttraction();
        desireDir += LeaderAlignment();

        desireDir /= 4f;
        ApplyForces(desireDir);
    }

    public void FixedRefresh()
    {
    }

    private void ApplyForces(Vector3 dir)
    {
        rb.AddForce(dir * ((weights.targetPos + weights.cohesion)/2));
    }

    //public Flock LinkToFlock(Flock parentFlock)
    //{
    //    return parentFlock;
    //}

    #region Flocking Calculations
    const float distanceToAvoidNeighbour = 10f;

    public virtual Vector3 WayPointAttraction() { return Vector3.zero; }

    public virtual Vector3 LeaderAlignment()
    {
        //Vector3 facingDirection;
        return Vector3.zero;
    }

    public virtual Vector3 NeighborsCohesion()
    {
        Vector3 cohesionVector = Vector3.zero;

        foreach (Dinasour dinasour in GetDinasoursInFlock)
        {
            cohesionVector += dinasour.transform.position;
        }

        cohesionVector /= GetDinasoursInFlock.Count;

        return cohesionVector;
    }

    public virtual Vector3 NeighborsAvoidance()
    {
        return Vector3.zero;
    }
    #endregion
}
