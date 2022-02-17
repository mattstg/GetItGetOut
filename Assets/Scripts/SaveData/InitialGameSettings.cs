using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType { Gun1, Gun2, Gun3 }
public static class InitialGameSettings
{
    public static GunType guntype = GunType.Gun1;
    public static void ChangeGunType(GunType type) 
    {
        guntype = type;
        Debug.Log("gun type changed "+ type.ToString());
    }

}





