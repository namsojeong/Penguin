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

    // �ð� ��Ÿ����
    private void GetTime()
    {
        dateText.text = string.Format(DateTime.Now.ToString("M"));
    }

    private void GetLoadTime()
    {
        // ���� �ð� ��������
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
        remainingtime.text = String.Format($"{time}��" + "\n���Ŀ� �ٽ� ����!");
        IsOverTime();
        GameManager.instance.SetMessageTime(time);
    }

    void IsOverTime()
    {
        if (time < 0)
        {
            //���⿡�� ���� �г� ����� �����ִ� �ڵ� ����
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
