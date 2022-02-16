public class HolsterManager : Manager
{
    #region Singleton
    private static HolsterManager instance;
    public static HolsterManager Instance => instance ??= new HolsterManager();
    protected HolsterManager() 
    { }
    #endregion
    
    public GameLinks links;
    private Holster holster;
    public override void Init()
    {
        holster = links.holster;
        holster.Init();
    }

    public override void PostInit()
    {
        holster.PostInit();
    }

    public override void Refresh()
    {
        holster.Refresh();
    }

    public override void FixedRefresh()
    {
        holster.FixedRefresh();
    }
}
