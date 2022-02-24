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
       targetPos = 10f;
       cohesion = 10f;
       avoidance = 20f;
       alignment = 5f;
       obstacleAvoidance = 20f;
       lavaAvoidance = 10f;
    }
}
