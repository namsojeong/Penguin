using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PhoneUI : MonoBehaviour
{
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text batteryText;
    [SerializeField]
    private Text dayText;

    private void Update()
    {
        GetTime();
    }

    // 시간 나타내기
    private void GetTime()
    {
        timeText.text = string.Format(DateTime.Now.ToString("t"));
        batteryText.text = string.Format($"{(int)(SystemInfo.batteryLevel*100)} %");
        dayText.text = string.Format($"Day {GameManager.Instance.CurrentUser.day}");
    }
}
