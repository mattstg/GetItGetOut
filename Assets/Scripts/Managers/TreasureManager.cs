using UnityEngine;

public class TreasureManager : Manager<TreasureManager, Treasure>
{
    private GameObject treasurePrefab;

    public int TreasureInSafeZone()
    {
        int i = 0;
        
        foreach (var item in colletion)
        {
            if (item.IsInSafeZone)
                i++;
        }

        return i;
    }

    public override void Init()
    {
        treasurePrefab = Resources.Load<GameObject>("Prefabs/Treasure/Tresure");
        for (int i = 0; i < GameLinks.Instance.respawnPositions.Length; i++)
        {
            GameObject obj = GameObject.Instantiate(treasurePrefab,GameLinks.Instance.respawnPositions[i].position  ,Quaternion.identity,GameLinks.Instance.TreasursParents);

            Debug.Log("sDSD");
            colletion.Add(obj.GetComponent<Treasure>());

        }
    }

    public override void PostInit()
    {
    }
}
