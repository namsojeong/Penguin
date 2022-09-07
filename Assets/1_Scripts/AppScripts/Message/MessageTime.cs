using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using JetBrains.Annotations;

public class MessageTime : MonoBehaviour
{
    [SerializeField]
    int defaultTime = 30;
    [SerializeField]
    GameObject rewardPanel;

    [SerializeField]
    private Text dateText;

    public int countdownMinutes = 1;

    private int time = 5;

    [SerializeField]
    private Text remainingtime;

    [SerializeField]
    Button lastButton;


    private void OnEnable()
    {
        GetTime();
        if (GameManager.instance.IsMessage())
        {
            GetLoadTime();
        }
        InvokeRepeating("GoTime", 0f, 1f);
    }
    
    void StartTimer()
    {
        ResetTimer();
        GameManager.instance.IsNotMessage(true);
    }

    void ResetTimer()
    {
        time = defaultTime;
    }

    // 시간 나타내기
    private void GetTime()
    {
        dateText.text = string.Format(DateTime.Now.ToString("M"));
    }

    private void GetLoadTime()
    {
        // 남은 시간 가져오기
        string lastTime = PlayerPrefs.GetString("SaveLastTime");
        DateTime lastDateTime = DateTime.Parse(lastTime);
        TimeSpan conpareTime = DateTime.Now - lastDateTime;
        GameManager.instance.CurrentUser.messageTime -= (int)conpareTime.TotalSeconds;
        time = GameManager.instance.CurrentUser.messageTime;
        IsOverTime();
    }

    void GoTime()
    {
        time--;
        remainingtime.text = String.Format($"{time}초" + "\n이후에 다시 와줘!");
        IsOverTime();
        GameManager.instance.SetMessageTime(time);
    }

    void IsOverTime()
    {
        if (time < 0)
        {
            //여기에다 보상 패널 띄워서 보상주는 코드 쓰기
            GameManager.instance.IsNotMessage(false);
            rewardPanel.SetActive(true);
            ResetTimer();
            CancelInvoke();
        }
        else
        {
            GameManager.instance.IsNotMessage(true);
        }
    }
}
