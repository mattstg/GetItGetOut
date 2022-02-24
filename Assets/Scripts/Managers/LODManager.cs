using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LODManager : Manager<LODManager, CubeTile>
{
    public Vector3 mainBox;
    public GameObject box;

    public Vector3 divBoxVariables;

    float x;
    float y;
    float z;

    public override void Init()
    {

        
    }

    public override void PostInit()
    {
        //*to rework
        x = mainBox.x / divBoxVariables.x;
        y = mainBox.y / divBoxVariables.y;
        z = mainBox.z / divBoxVariables.z;

        Vector3 centerPos = new Vector3(-(mainBox.x / divBoxVariables.x) / 2, -(mainBox.y / divBoxVariables.y) / 2, -(mainBox.z / divBoxVariables.z) / 2);
        for (int u = 0; u < divBoxVariables.x; u++)
        {
            centerPos.x += x;
            for (int o = 0; o < divBoxVariables.y; o++)
            {
                centerPos.y += y;
                for (int p = 0; p < divBoxVariables.z; p++)
                {
                    centerPos.z += z;
                    box.transform.localScale = new Vector3(x, y, z);
                    GameObject.Instantiate(box, new Vector3(centerPos.x, centerPos.y, centerPos.z), Quaternion.identity);

                }

                centerPos.z = -(mainBox.z / divBoxVariables.z) / 2;
            }

            centerPos.y = -(mainBox.y / divBoxVariables.y) / 2;
        }
    }


}
