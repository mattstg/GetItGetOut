using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour, IUpdaptable
{
    float minimum = 2f;
    float maximum = 4f;
    float timer;
    int currentWaypointIndex;
    public List<Transform> wayPoints;

    public void Init()
    {
        timer = Random.Range(minimum, maximum);
        Debug.Log(timer);

        Transform[] children = this.transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            wayPoints.Add(children[i]);
        }
    }

    public void PostInit()
    {

    }

    public void Refresh()
    {
        //check for Y height and remove ones under lava
    }

    public void FixedRefresh()
    {

    }

    public Vector3 GetRandomWayPoint()
    {
        timer -= Time.deltaTime;
        //Debug.Log(timer);
        if (timer <= 0)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex == wayPoints.Count)
            {
                currentWaypointIndex = 0;
            }
            timer = Random.Range(minimum, maximum);
            //Debug.Log("point " + WayPoints[currentWaypointIndex].name);
        }
        return wayPoints[currentWaypointIndex].position;
    }
}
