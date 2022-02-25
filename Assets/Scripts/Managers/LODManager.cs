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


    List<Region> regionList = new List<Region>();
    List<MeshRenderer> listToGiveToRegion = new List<MeshRenderer>();
    Region currentRegionOfPlayer;
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
                if (mesh.transform.position.y > BottomOfRegion && mesh.transform.position.y < topOfRegion)
                {
                    listToGiveToRegion.Add(mesh);
                    Debug.Log(everyBuildingMesh.IndexOf(mesh));
                }
            }
            regionList.Add(new Region(listToGiveToRegion, topOfRegion, BottomOfRegion));
        }
        Debug.Log("Buidling not selected: " + everyBuildingMesh.ElementAt(56).gameObject.name + " pos: " + everyBuildingMesh.ElementAt(56).transform.position.y);
        //currentRegionOfPlayer = GetRegionOfPlayer();
        //currentRegionOfPlayer.ToggleMeshes(true);

        Debug.Log(regionList.Count);
        int cpt = 1;
        int cptnNbOfBuildings = 0;
        foreach (var region in regionList)
        {
            Debug.Log(cpt + "region: " + "---------------------------------------------------Bottom: " + region.bottomHeight + "Top: " + region.topHeight);
            foreach (var mesh in region.GetMeshes())
            {
                Debug.Log("Building: " + mesh.gameObject.name + "pos:" + mesh.transform.position.y);
                cptnNbOfBuildings ++;
            }
            cpt++;
        }
        Debug.Log("nb of buildings regionned: " + cptnNbOfBuildings + " ---nb of buildings total in map: " + everyBuildingMesh.Count);
    }

    public override void PostInit()
    {
        


    }

    public override void Refresh()
    {
       //if (GetPlayer.transform.position.y < currentRegionOfPlayer.bottomHeight || GetPlayer.transform.position.y > currentRegionOfPlayer.topHeight)
       //{
       //    currentRegionOfPlayer = GetRegionOfPlayer();
       //    currentRegionOfPlayer.ToggleMeshes(true);
       //}
        
    }

    public override void FixedRefresh()
    {
        
    }

    public override void Clean()
    {
        
    }

    private Region GetRegionOfPlayer()
    {
        foreach (var region in regionList)
        {
            if (GetPlayer.transform.position.y > region.bottomHeight && GetPlayer.transform.position.y < region.topHeight)
            {
                return region;
            }
        }
        //Temporairely Null
        return null;
    }

    private List<Region> GetNeigbourRegion()
    {


        //Temporairely Null
        return null;
    }

    private class Region
    {
        public List<MeshRenderer> meshes = new List<MeshRenderer>();
        public int topHeight { get; private set; }
        public int bottomHeight { get; private set; }

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

        public List<MeshRenderer> GetMeshes()
        {
            return meshes;
        }

    }
}
