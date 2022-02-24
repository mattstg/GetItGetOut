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
            Treasure treasure = obj.GetComponent<Treasure>();
            colletion.Add(treasure);
            treasure.Init();

        }
    }

    public override void PostInit()
    {
        foreach (var treasure in colletion)
        {
            treasure.PostInit();
        }
    }
}
