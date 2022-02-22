
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
    private TMP_Text UIMoney;
    
    public override void Init()
    {
        UITime = GameLinks.Instance.UITime;
        UIMoney = GameLinks.Instance.UIMoney;
    }

    public override void PostInit()
    {
        
    }
    
    public override void Refresh()
    {
        if (UITime)
        {
            UITime.SetText(SecondToDigitalTime((int)LavaManager.Instance.TimeRemaining));
        }

        if (UIMoney)
        {
            UIMoney.SetText("$1000");
        }
    }

    public override void FixedRefresh()
    {
        
    }

    private string SecondToDigitalTime(int time)
    {
        int minutes = time / 60;
        int seconds = time % 60;
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
