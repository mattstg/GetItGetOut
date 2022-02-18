public class FlockWeights
{
    public float targetPos;
    public float cohesion;
    public float avoidance;
    public float alignment;
    public float obstacleAvoidance;
    public float lavaAvoidance;

    public FlockWeights()
    {
       targetPos = 5f;
       cohesion = 8f;
       avoidance = 1f;
       alignment = 10f;
       obstacleAvoidance = 5f;
       lavaAvoidance = 5f;
    }
}
