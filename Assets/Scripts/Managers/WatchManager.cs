
using System;
using TMPro;

public class WatchManager : Manager
{
    #region Singleton
    private static WatchManager instance;
    public static WatchManager Instance => instance ??= new WatchManager();
    private WatchManager() {}
    #endregion

    private TMP_Text UITime;
    
    public override void Init()
    {
        UITime = GameLinks.Instance.UITime;
    }

    public override void PostInit()
    {
        
    }
    
    public override void Refresh()
    {
        UITime.SetText(MillisecondToDigitalTime(1000000));
    }

    public override void FixedRefresh()
    {
        
    }

    private string MillisecondToDigitalTime(int time)
    {
        int minutes = time / 60000;
        int seconds = (time % 60000) / 1000;
        string min = "";
        string sec = "";

        if (minutes < 10)
        {
            min = "0";
        }

        min += minutes.ToString();

        if (seconds < 10)
        {
            sec = "0";
        }

        sec += seconds.ToString();

        return $"{min}:{sec}";
    }
}
