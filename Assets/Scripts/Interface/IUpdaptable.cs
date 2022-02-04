using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdaptable 
{
    public abstract void Init();
    public abstract void PostInit();
    public abstract void Refresh();
    public abstract void FixedRefresh();
}
