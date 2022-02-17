using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour ,IUpdaptable
{
    public Rigidbody rb;
    public GameObject gun1;
    public GameObject gun2;
    public void Init()
    {
    }

    public void PostInit()
    {
        var obj = Resources.Load<GameObject>("Prefabs/Guns/" + InitialGameSettings.guntype.ToString());

        if (obj)
        {
            gun1 = GameObject.Instantiate(obj);
            gun2 = GameObject.Instantiate(obj);
            GameLinks.Instance.inputs.gun1 = gun1.GetComponentInChildren<Gun>();
            GameLinks.Instance.inputs.gun2 = gun2.GetComponentInChildren<Gun>();
            

        }
        else
        {
            Debug.Log("Could not find gun: " + InitialGameSettings.guntype.ToString());
        }
    }



    public void FixedRefresh()
    {

    }


    public void Refresh()
    {
    }

}
