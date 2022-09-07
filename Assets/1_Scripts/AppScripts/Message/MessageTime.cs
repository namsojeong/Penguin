using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MessageTime : MonoBehaviour
{
    [SerializeField]
    GameObject rewardPanel;

    [SerializeField]
    private Text dateText;

    public int countdownMinutes = 1;

    private int time=5;

    [SerializeField]
    private Text remainingtime;


    private void OnEnable()
    {
        //countdown �ʰ� 1�̶�� ����Ǿ� �ִٸ�?
        GetLoadTime();
        GetTime();
    }
    private void Start()
    {
        EventManager.StartListening("MessageTimer", StartTimer);
    }
    private void OnDestroy()
    {
        EventManager.StopListening("MessageTimer", StartTimer);
    }

    void StartTimer(EventParam eventParam)
    {
        InvokeRepeating("GoTime", 1f, 1f);
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
        IsOverTime();
        GameManager.instance.SetMessageTime(time);
    }

    void IsOverTime()
    {
        if (time < 0)
        {
            Debug.Log("����޾ƶ�");
            //���⿡�� ���� �г� ����� �����ִ� �ڵ� ����
            rewardPanel.SetActive(true);
            time = 5;
            GameManager.instance.IsNotMessage(false);
            CancelInvoke();
        }
        else
        {
            GameManager.instance.IsNotMessage(true);
            remainingtime.text = String.Format($"{time}" + "\n���Ŀ� �ٽ� ����!");
        }
    }
}
