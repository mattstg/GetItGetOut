using UnityEngine;

public class Player : MonoBehaviour ,IUpdaptable
{
    public Rigidbody rb;
    public GameObject gun1;
    public GameObject gun2;

    private Audio.Player audio;

    public void Init()
    {
    }

    public void PostInit()
    {
        rb = GetComponent<Rigidbody>();
        
        var obj = Resources.Load<GameObject>("Prefabs/Guns/" + InitialGameSettings.guntype.ToString());

        if (obj)
        {
            gun1 = GameObject.Instantiate(obj);
            gun2 = GameObject.Instantiate(obj);
            GameLinks.Instance.inputs.gunLeft = gun1.GetComponentInChildren<Gun>();
            GameLinks.Instance.inputs.gunRight = gun2.GetComponentInChildren<Gun>();
        }
        else
        {
            Debug.Log("Could not find gun: " + InitialGameSettings.guntype.ToString());
        }

        InitAudio();
    }



    public void FixedRefresh()
    {
    }


    public void Refresh()
    {
        bool playerUnderLava = transform.position.y - 2 < LavaManager.Instance.lava.transform.position.y;
        bool timeExpired = LavaManager.Instance.TimeRemaining < 0;
        if (playerUnderLava || timeExpired)
        {
            WatchManager.Instance.LoadMainScene();
        }
    }

    private void InitAudio()
    {
        audio = new Audio.Player();
        audio.PlayWind(gameObject);
    }

}
