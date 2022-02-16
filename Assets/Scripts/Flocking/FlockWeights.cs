using UnityEngine;

public class FlockWeights : MonoBehaviour
{
    public float targetPos;
    public float cohesion;
    public float avoidance;
    public float alignment;
    public float obstacleAvoidance;
    public float lavaAvoidance;

    public FlockWeights()
    {
       targetPos = 10;
       cohesion = 10;
       avoidance = 10;
       alignment = 10;
       obstacleAvoidance = 10;
       lavaAvoidance = 10;
    }
}
