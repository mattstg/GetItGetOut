
using UnityEngine;

public class Treasure : MonoBehaviour, IUpdaptable
{
    public bool IsInSafeZone { get; set; }

    private Audio.Treasure audio;

    public void Init()
    {
        audio = new Audio.Treasure();
    }

    public void PostInit()
    {
        audio.PlayTreasureAmbiant(gameObject);
    }

    public void FixedRefresh()
    {
    }

    public void Refresh()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            audio.StopAllAudio(gameObject);
        }

        audio.PlayCollision(gameObject);
    }
}
