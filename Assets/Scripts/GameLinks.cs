using UnityEngine;

public class GameLinks : MonoBehaviour
{
    public static GameLinks Instance;

    public Holster holster;

    public void SetupGameLinks()
    {
        Instance = this;
    }
}
