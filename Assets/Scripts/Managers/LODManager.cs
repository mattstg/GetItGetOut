using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LODManager : Manager
{
    #region singleton
    private static LODManager instance;
    public static LODManager Instance => instance ??= new LODManager();
    private LODManager() { }
    #endregion

    const int nbRegion = 10;
    const int neighboursToLoad = 3;
    Player GetPlayer { get { return PlayerManager.Instance.player; } }
    GameObject buildingParent { get { return GameLinks.Instance.staticBuildingParent; } }
    int mapHeight { get { return GameLinks.Instance.heightOfMap; } }
    int lavaHeight { get { return (int)LavaManager.Instance.lava.transform.position.y; } }


    List<Region> regionList = new List<Region>();
    List<MeshRenderer> listToGiveToRegion = new List<MeshRenderer>();
    int currentRegionIndexOfPlayer;
    int regionHeight;

    public override void Init()
    {
        regionHeight = mapHeight / nbRegion;
        List<MeshRenderer> everyBuildingMesh = buildingParent.GetComponentsInChildren<MeshRenderer>().ToList();
        //Debug.Log(buildingParent.transform.position.y);

        for (int i = 1; i < nbRegion + 1; i++)
        {
            listToGiveToRegion = new List<MeshRenderer>();
            int BottomOfRegion = (int)buildingParent.transform.position.y + (i * regionHeight) - regionHeight;
            int topOfRegion = (int)buildingParent.transform.position.y + (i * regionHeight);

            foreach (var mesh in everyBuildingMesh)
            {
                if (mesh.transform.position.y >= BottomOfRegion && mesh.transform.position.y < topOfRegion)
                {
                    listToGiveToRegion.Add(mesh);
                    //Debug.Log(everyBuildingMesh.IndexOf(mesh));
                }
            }
            regionList.Add(new Region(listToGiveToRegion, topOfRegion, BottomOfRegion));
        }
        currentRegionIndexOfPlayer = GetRegionOfPlayer();
        ToggleSelectRegion();

        //Debug.Log("Buidling not selected: " + everyBuildingMesh.ElementAt(56).gameObject.name + " pos: " + everyBuildingMesh.ElementAt(56).transform.position.y);

        //Debug.Log(regionList.Count);
        //int cpt = 1;
        //int cptnNbOfBuildings = 0;
        //foreach (var region in regionList)
        //{
        //    Debug.Log(cpt + "region: " + "---------------------------------------------------Bottom: " + region.bottomHeight + "Top: " + region.topHeight);
        //    foreach (var mesh in region.GetMeshes())
        //    {
        //        Debug.Log("Building: " + mesh.gameObject.name + "pos:" + mesh.transform.position.y);
        //        cptnNbOfBuildings ++;
        //    }
        //    cpt++;
        //}
        //Debug.Log("nb of buildings regionned: " + cptnNbOfBuildings + " ---nb of buildings total in map: " + everyBuildingMesh.Count);
    }

    public override void PostInit()
    {
        


    }

    public override void Refresh()
    {
       if (GetPlayer.transform.position.y < regionList.ElementAt(currentRegionIndexOfPlayer).bottomHeight || GetPlayer.transform.position.y > regionList.ElementAt(currentRegionIndexOfPlayer).topHeight)
       {
            currentRegionIndexOfPlayer = GetRegionOfPlayer();
            ToggleSelectRegion();
            ToggleOffRegionUnderLava();
       }
    }

    public override void FixedRefresh()
    {
        
    }

    public override void Clean()
    {
        
    }

    private int GetRegionOfPlayer()
    {
        foreach (var region in regionList)
        {
            if (GetPlayer.transform.position.y >= region.bottomHeight && GetPlayer.transform.position.y < region.topHeight)
            {
                return regionList.IndexOf(region);
            }
        }
        Debug.LogError("Player outside of all Regions. Returned 0 as default.");
        return 0;
    }

    private void ToggleSelectRegion()
    {
        int minRegionToLoad = currentRegionIndexOfPlayer - neighboursToLoad;
        int maxRegionToLoad = currentRegionIndexOfPlayer + neighboursToLoad;

        if (minRegionToLoad < 0)
        {
            minRegionToLoad = 0;
        }
        if (maxRegionToLoad > nbRegion - 1)
        {
            maxRegionToLoad = nbRegion - 1;
        }

        for (int i = 0; i < regionList.Count; i++)
        {
            if (i >= minRegionToLoad && i <= maxRegionToLoad)
            {
                regionList.ElementAt(i).ToggleMeshes(true);
            }
            else
            {
                regionList.ElementAt(i).ToggleMeshes(false);
            }
        }
    }

    private void ToggleOffRegionUnderLava()
    {
        foreach (var region in regionList)
        {
            if (region.topHeight + regionHeight == lavaHeight)
            {
                region.ToggleOffRegion();
            }
        }
    }

    private class Region
    {
        public List<MeshRenderer> meshes = new List<MeshRenderer>();
        public int topHeight { get; private set; }
        public int bottomHeight { get; private set; }
        public bool isActive { get; private set; }

        public Region(List<MeshRenderer> meshes, int topHeight, int bottomHeight)
        {
            this.meshes = meshes;
            this.topHeight = topHeight;
            this.bottomHeight = bottomHeight;
            isActive = true;
        }

        public void ToggleMeshes(bool value)
        {
            if (value == isActive)
            {
                return;
            }

            isActive = value;
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
        public List<MeshRenderer> GetMeshes()
        {
            return meshes;
        }
    }
}
