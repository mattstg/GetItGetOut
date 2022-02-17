using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ReturnButton : MonoBehaviour
{
    public Transform player;


    public void StartMainCsene()
    {
        Physics.gravity = new Vector3(0, 3F, 0);
        Invoke("StartGame", 5);

    }

    void StartGame()
    {
         
        Physics.gravity = new Vector3(0, -5F, 0);
        SceneManager.LoadScene("UIstartScene");
    }

}