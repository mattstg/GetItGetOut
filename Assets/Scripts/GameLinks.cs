using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class GameLinks : MonoBehaviour
{
    public static GameLinks Instance;
    public Transform[] respawnPositions;
    public Holster holster;
    public Lava lava;
    public GameObject XROrigin;
    public Rigidbody XROriginRb;
    public Inputs inputs;
    public TMP_Text UITime;
    public TMP_Text UIMoney;

    public void SetupGameLinks()
    {
        Instance = this;
    }
}
