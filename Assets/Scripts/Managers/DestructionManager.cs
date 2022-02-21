using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DestructionManager : Manager
{
    #region singleton
    private DestructionManager instance;
    public DestructionManager Instance => instance ??= instance = new DestructionManager();
    protected DestructionManager() { }
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
            building.Explosion();
            building.lavaCollision();
        }
    }

    public override void FixedRefresh()
    {
       
    }
}
