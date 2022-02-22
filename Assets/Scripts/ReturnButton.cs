using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnButton : MonoBehaviour
{
    public Transform player;


    public void StartMainCsene()
    {
        Physics.gravity = new Vector3(0, 3F, 0);
        
        Invoke(nameof(StartGame), 5);
        
    }

    void StartGame()
    {
         
        Physics.gravity = new Vector3(0, -5F, 0);
        SceneManager.LoadScene("UIstartScene");
    }

}