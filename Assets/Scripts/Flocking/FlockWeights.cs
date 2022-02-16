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
       cohesion = 5f;
       avoidance = 5f;
       alignment = 5f;
       obstacleAvoidance = 5f;
       lavaAvoidance = 5f;
    }
}
