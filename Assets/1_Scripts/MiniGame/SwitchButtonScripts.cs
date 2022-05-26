using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtonScripts : MonoBehaviour
{
    [SerializeField, Header("이미지")]
    Image switchImage;

    [SerializeField, Header("스위치 처음 켜지는 시간")]
    float startMaxTime = 1f;
    [SerializeField, Header("스위치 처음 켜지는 시간")]
    float cancelMaxTime = 1f;

    float cancelTime;
    float startTime;

    private bool isOn;

    private void OnEnable()
    {
        SwitchOffGame.Instance().UpdateScore();
        StartSwitch();
    }

    void StartSwitch()
    {
        startTime = Random.Range(0f, startMaxTime);
        Invoke("SwitchOn", startTime);
    }

    void SwitchOn()
    {
        isOn = true;
        switchImage.sprite = SwitchOffGame.Instance().onImage;
        cancelTime = Random.Range(0f, cancelMaxTime);
        Invoke("SwitchOff", cancelTime);
    }

    void SwitchOff()
    {
        CancelInvoke("SwitchOff");
        switchImage.sprite = SwitchOffGame.Instance().offImage;
        StartSwitch();
        isOn = false;
    }

    public void IsClick()
    {
        if(isOn)
        {
            SwitchOffGame.Instance().ScoreUp(10);
        }
        else
        {
            SwitchOffGame.Instance().TimeDown(10);
        }
        SwitchOff();
    }
}
