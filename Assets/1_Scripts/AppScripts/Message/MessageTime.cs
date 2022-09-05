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
    public float countdownSeconds;
    [SerializeField]
    private Text remainingtime;

    private void OnEnable()
    {
        //countdown 초가 1이라고 저장되어 있다면?
      //  countdownSeconds = 60;
        GetTime();
    }

    public void Update()
    {
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);

        if (countdownSeconds > 0)
            remainingtime.text = span.ToString(@"mm\:ss") + ("\n이후에 다시 와줘!");
    }

    private void Start()
    {
        countdownSeconds = countdownMinutes * 60;
    }

    // 시간 나타내기
    private void GetTime()
    {
        dateText.text = string.Format(DateTime.Now.ToString("M"));
    }
    
}
