using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    private GameObject timeText;

    private void Start()
    {
        timeText = GameObject.FindGameObjectWithTag("TIME");
    }
    private void Update()
    {
        GetTime();
    }

    // 시간 나타내기
    private void GetTime()
    {
        timeText.GetComponent<Text>().text = String.Format(DateTime.Now.ToString("t"));
    }

    public void OpenUI(GameObject ui)
    {
        ui.SetActive(true);
    }
    public void CloseUI(GameObject ui)
    {
        ui.SetActive(false);
    }

    public void TimeReset(int time)
    {
        Time.timeScale = time;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
