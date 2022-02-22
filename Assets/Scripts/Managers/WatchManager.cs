using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WatchManager : Manager
{
    #region Singleton
    private static WatchManager instance;
    public static WatchManager Instance => instance ??= new WatchManager();
    private WatchManager() {}
    #endregion

    private int cachedTime = 0;
    private int cachedMoney = 0;
    
    private TMP_Text UITime;
    private TMP_Text UIMoney;
    private Button button;
    
    public override void Init()
    {
        UITime = GameLinks.Instance.UITime;
        UIMoney = GameLinks.Instance.UIMoney;
        button = GameLinks.Instance.button;
        button?.onClick.AddListener(LoadMainScene);
    }

    public override void PostInit()
    {
        
    }
    
    public override void Refresh()
    {
        int time = (int) LavaManager.Instance.TimeRemaining;
        int money = Shop.Instance.inventory.money;
        
        if (UITime && cachedTime != time)
        {
            cachedTime = time;
            UITime.SetText(SecondToDigitalTime(time));
        }

        if (UIMoney && cachedMoney != money)
        {
            cachedMoney = money;
            UIMoney.SetText(IntToDigitalMoney(money));
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

    private string IntToDigitalMoney(int money)
    {
        return $"${money}";
    }


    private void SaveMoney()
    {
        Shop.Instance.inventory.money += 1000;
        Shop.Instance.WriteJSON();
    }

    private void LoadMainScene()
    {
        SaveMoney();
        SceneManager.LoadScene("UIstartScene");
    }
}
