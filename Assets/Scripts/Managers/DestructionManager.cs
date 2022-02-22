using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DestructionManager : Manager
{
    #region singleton
    private static  DestructionManager instance;
    public static DestructionManager Instance => instance ??= instance = new DestructionManager();
    private DestructionManager() { }
    #endregion

    private List<DestroyBuilding> destructibleBuildings = new List<DestroyBuilding>();
    

    public override void Init()
    {
        destructibleBuildings = GameObject.FindObjectsOfType<DestroyBuilding>().ToList();
        foreach (DestroyBuilding building in destructibleBuildings)
        {
            building.setParts();
        }
    }

    public override void PostInit()
    {
        
    }

    public override void Refresh()
    {
        foreach (DestroyBuilding building in destructibleBuildings)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                building.Explosion();
            }
        }
    }

    public override void FixedRefresh()
    {
       
    }
}
