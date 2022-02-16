using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    bool gameHasStarted;
    public  Animator houseAnimation;
    public Transform player;
    float yPosition=2;

    private void Update()
    {
        if (gameHasStarted)
        {
            Physics.gravity = new Vector3(0, 3F, 0);
        }
    }
    public void StartMainCsene()
    {
        gameHasStarted = true;
        HouseCelingGetsOpen();
        Invoke("StartGame", 5);

    }

    void StartGame()
    {
        Physics.gravity = new Vector3(0, -5F, 0);

        SceneManager.LoadScene("TestMapWIthParsa");
    }

    void HouseCelingGetsOpen()
    {

        houseAnimation.enabled = true;
    }
}
