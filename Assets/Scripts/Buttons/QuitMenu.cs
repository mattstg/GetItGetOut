using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitMenu : MonoBehaviour
{
    public Button YesButton;
    public Button NoButton;

    public void Awake()
    {
        if (YesButton)
        {
            YesButton.onClick.AddListener(ChangeScene);
        }

        if (NoButton)
        {
            NoButton.onClick.AddListener(CloseQuitMenu);
        }
    }

    public void ChangeScene()
    {
        
        SceneManager.LoadScene("UIstartScene");
    }

    public void CloseQuitMenu()
    {
        gameObject.SetActive(false);
    }
}
