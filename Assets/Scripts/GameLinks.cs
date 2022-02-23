using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLinks : MonoBehaviour
{
    public static GameLinks Instance;
    public Player player;
    public Transform[] respawnPositions;
    public Transform TreasursParents;
    public Holster holster;
    public Lava lava;
    public GameObject XROrigin;
    public Rigidbody XROriginRb;
    public Inputs inputs;
    public TMP_Text UITime;
    public TMP_Text UIMoney;
    public Button button;
    public Transform[] dinosaurWayPoints;

    public void SetupGameLinks()
    {
        Instance = this;
    }
}
