using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : Manager
{
    #region Singleton
    private static WaypointManager instance;
    public static WaypointManager Instance => instance ??= new WaypointManager();
    protected WaypointManager() { }
    #endregion
    float minimum = 10f;
    float maximum = 50f;
    float timer;
    int currentWaypointIndex;
    public Transform[] wayPoints;

    public override void Init()
    {
        timer = Random.Range(minimum, maximum);
        wayPoints = GameLinks.Instance.dinosaurWayPoints;
    }

    public override void PostInit()
    {}

    public override void Refresh()
    {}

    public override void FixedRefresh()
    {}

    public Vector3 GetRandomWayPoint()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            currentWaypointIndex = Random.Range(0, wayPoints.Length);
            if (currentWaypointIndex == wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
            timer = Random.Range(minimum, maximum);
        }
        return wayPoints[currentWaypointIndex].position;
    }
}
