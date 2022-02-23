using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour, IUpdaptable
{
    [Range(1f, 10f)]
    public float speed = 5f;
    protected float maxSpeed = 10f;
    protected float sqrMaxDistance = 20f;

    protected Rigidbody rb;
    protected FlockWeights weights;
    protected Flock ourFlock;

    protected Dinosaur[] GetAllDinosaurs { get { return FlockManager.Instance.GetAllDinosaurs(); } }
    protected List<Dinosaur> GetOtherDinosaursInFlock { get { return ourFlock.GetOtherDinosaursInFlock(this); } }

    protected float GetLavaHeight { get { return LavaManager.Instance.lava.transform.position.y; } }
    protected float SqrDistanceToLeader { get { return Vector3.SqrMagnitude(transform.position - ourFlock.leader.transform.position); } }
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

    public virtual void Refresh()
    {
        DesireDirectionVectors theVector = new DesireDirectionVectors();
        theVector.leaderAlignement = LeaderAlignment();
        theVector.neighborsAvoidance += NeighborsAvoidance();
        theVector.neighborsCohesion += NeighborsCohesion();

        theVector.OutputRays(transform.position);
        UnityEngine.Debug.DrawRay(transform.position, transform.forward, Color.red);

        ApplyForces(theVector.GetAverage(), theVector);
    }

    public void FixedRefresh()
    {
        // fixed refresh does not work at all
    }

    protected virtual void ApplyForces(Vector3 dir, DesireDirectionVectors desiredPkg)
    {
        transform.forward = ourFlock.leader.transform.forward;

        float sqrMagnitudeOfDir = Vector3.SqrMagnitude(dir);
        speed = maxSpeed * Mathf.Clamp01(sqrMagnitudeOfDir/sqrMaxDistance);

        if (!desiredPkg.ConfirmSanity())
        {
            Debug.Log("ApplyForces function, Name: " + transform.name);
        }

        rb.AddForce(dir.normalized * speed);
    }

    protected virtual void DinosaursDeath()
    {
        if (transform.position.y < GetLavaHeight)
        {
            // delete this poor dinosaur
        }
    }

    #region Flocking Calculations

    public virtual Vector3 WayPointAttraction()
    {
        return Vector3.zero;
    }

    public virtual Vector3 LeaderAlignment()
    {
        return (ourFlock.leader.transform.position - transform.position) * weights.alignment;
    }

    public virtual Vector3 NeighborsCohesion()
    {
        Vector3 cohesionVector = Vector3.zero;

        foreach (Dinosaur dinasour in GetOtherDinosaursInFlock)
        {
            cohesionVector += dinasour.transform.position - transform.position;
        }
        cohesionVector /= GetOtherDinosaursInFlock.Count;

        return cohesionVector * weights.cohesion;
    }

    public virtual Vector3 NeighborsAvoidance()
    {
        Vector3 avoidanceVector = Vector3.zero;
        float currentSqrManitude;
        float avoidanceVectorSqrManitude;
        int numToAvoid = 1;
        float sqrDistanceToAvoid = 25f;

        if (Vector3.SqrMagnitude(transform.position - ourFlock.leader.transform.position) < sqrDistanceToAvoid)
        {
            avoidanceVectorSqrManitude = (sqrDistanceToAvoid - SqrDistanceToLeader) / sqrDistanceToAvoid;
            avoidanceVector += (transform.position - ourFlock.leader.transform.position) * avoidanceVectorSqrManitude;
        }


        foreach (Dinosaur dinasour in GetOtherDinosaursInFlock)
        {
            if (Vector3.SqrMagnitude(transform.position - dinasour.transform.position) < sqrDistanceToAvoid)
            {
                numToAvoid++;
                currentSqrManitude = Vector3.SqrMagnitude(transform.position - dinasour.transform.position);
                avoidanceVectorSqrManitude = (sqrDistanceToAvoid - currentSqrManitude) / sqrDistanceToAvoid;
                avoidanceVector += (transform.position - dinasour.transform.position) * avoidanceVectorSqrManitude;
            }
        }

        if (numToAvoid != 0)
            avoidanceVector /= numToAvoid;

        if (avoidanceVector.z < -100000 || avoidanceVector.z > 100000)
        {
            Debug.Log(string.Format("avoidanceFunction, ERROR: avoidanceVector {0}, numToAvoid {1}, sqrDistanceToAvoid {2}, SqrDistanceToLeader {3}",
                                        avoidanceVector, numToAvoid, sqrDistanceToAvoid, SqrDistanceToLeader));
        }

        return avoidanceVector * weights.avoidance;
    }
    #endregion

    public class DesireDirectionVectors
    {
        public float debugDrawMult = .1f;
        public Vector3 neighborsAvoidance;
        public Vector3 neighborsCohesion;
        public Vector3 leaderAlignement;

        public Vector3 GetAverage()
        {
            Vector3 desireDir = Vector3.zero;

            desireDir += neighborsCohesion;
            desireDir += neighborsAvoidance;
            desireDir += leaderAlignement;
            desireDir /= 3f;

            return desireDir;
        }

        public void OutputRays(Vector3 pos)
        {
            //UnityEngine.Debug.DrawRay(pos, neighborsAvoidance * debugDrawMult, Color.green);
            //UnityEngine.Debug.DrawRay(pos, neighborsCohesion * debugDrawMult, Color.red);
            //UnityEngine.Debug.DrawRay(pos, followLeader * debugDrawMult, Color.yellow);
            //UnityEngine.Debug.DrawRay(pos, followLeader * debugDrawMult, Color.black);
            //UnityEngine.Debug.DrawRay(pos, GetAverage()      * debugDrawMult, Color.blue);
        }

        public bool ConfirmSanity()
        {
            Vector3 avrg = GetAverage();

            if (avrg.z < -100000 || avrg.z > 100000)
            {
                Debug.LogError("Something went wrong: " + ToString());
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return string.Format("ERROR: neighborsAvoidance {0}, neighborsCohesion {1}, leaderAlignement {2}, average {3}",
                                        neighborsAvoidance, neighborsCohesion, leaderAlignement, GetAverage());
        }
    }
}
