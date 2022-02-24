using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LODManager : Manager
{
    const int nbRegion = 10;
    Player GetPlayer { get { return PlayerManager.Instance.player; } }
    GameObject buildingParent { get { return GameLinks.Instance.staticBuildingParent; } }
    int mapHeight { get { return GameLinks.Instance.heightOfMap; } } 


    List<Region> RegionList;
    int regionHeight;
    public override void Init()
    {
        regionHeight = mapHeight / nbRegion;
        List<MeshRenderer> everyBuildingMesh = buildingParent.GetComponentsInChildren<MeshRenderer>().ToList();
        //fullListOfMesh = buildingParent.GetComponentsInChildren<MeshRenderer>().ToList();
        List<MeshRenderer> listToGiveToRegion = new List<MeshRenderer>();

        for (int i = 1; i < nbRegion + 1; i++)
        {
            int BottomOfRegion = (i * nbRegion) - regionHeight;
            int topOfRegion = i * nbRegion;
            listToGiveToRegion.Clear();

            foreach (var mesh in everyBuildingMesh)
            {
                if (mesh.transform.position.y > BottomOfRegion && mesh.transform.position.y < topOfRegion)
                {
                    listToGiveToRegion.Add(mesh);
                }
            }
            RegionList.Add(new Region(listToGiveToRegion, topOfRegion, BottomOfRegion));
        }
        //RegionList.
    }

    public override void PostInit()
    {
        


    }

    public override void Refresh()
    {
        
    }

    public override void FixedRefresh()
    {
        
    }

    public override void Clean()
    {
        
    }

    private class Region
    {
        List<MeshRenderer> meshes;
        int topHeight;
        int bottomHeight;

        public Region(List<MeshRenderer> meshes, int topHeight, int bottomHeight)
        {
            this.meshes = meshes;
            this.topHeight = topHeight;
            this.bottomHeight = bottomHeight;
        }

        public void ToggleMeshes(bool value)
        {
            foreach (var mesh in meshes)
            {
                mesh.enabled = value;
            }
        }

        public void ToggleOffRegion()
        {
            foreach (var mesh in meshes)
            {
                mesh.gameObject.SetActive(false);
            }
        }

    }
}
