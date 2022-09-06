using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MessageTime : MonoBehaviour
{
    [SerializeField]
    private Text dateText;

    public int countdownMinutes = 1;

    private int time=60;
    [SerializeField]
    private Text remainingtime;

    private void OnEnable()
    {
        //countdown 초가 1이라고 저장되어 있다면?
        GetTime();
    }

    public void Update()
    {
        Debug.Log(GameManager.instance.CurrentUser.messageTime);
    }

    private void Start()
    {
        GetLoadTime();
        InvokeRepeating("GoTime", 1f, 1f);
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
        IsOverTime();
        GameManager.instance.SetMessageTime(time);
    }

    void IsOverTime()
    {
        if (time < 0)
        {
            //여기에다 보상 패널 띄워서 보상주는 코드 쓰기

            time = 60;
            GameManager.instance.IsNotMessage(false);
            CancelInvoke();
        }
        else
        {
            GameManager.instance.IsNotMessage(true);
            remainingtime.text = String.Format($"{time}" + "\n이후에 다시 와줘!");
        }
    }
}
