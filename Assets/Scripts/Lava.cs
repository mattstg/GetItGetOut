using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour, IUpdaptable
{
    public const float MAX_LEVEL_HEIGHT = 427;
    public const float LEVEL_TIME = 427;//300 sec = 5min1
    public float TimeRemaining => LEVEL_TIME - (transform.position.y * LEVEL_TIME / MAX_LEVEL_HEIGHT);

    float lavaSpeed;
    Rigidbody lavaRB;

    public GameObject soundEmitter;

    public void Init()
    {
        lavaRB= GetComponent<Rigidbody>();
        //lavaRB.velocity = transform.up* RisingLavaSpeed(LEVEL_TIME);
        lavaSpeed = MAX_LEVEL_HEIGHT / LEVEL_TIME;
    }

    public void PostInit()
    {

    }

    public void Refresh()
    {
        Vector3 pos = transform.position;
        pos.y += Time.deltaTime * lavaSpeed;
        transform.position = pos;
    }

    public void FixedRefresh()
    {
    }

    float RisingLavaSpeed(float timer)
    {
        return MAX_LEVEL_HEIGHT / timer;

    }
}
