using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DestructionManager : Manager <DestructionManager, DestroyBuilding>
{
    public override void Init()
    {
        colletion = new HashSet<DestroyBuilding>(GameObject.FindObjectsOfType<DestroyBuilding>().ToList());
        foreach (DestroyBuilding building in colletion)
        {
            building.Init();
        }
    }

    public override void PostInit()
    {
        foreach (DestroyBuilding building in colletion)
        {
            building.PostInit();
        }
    }
}
