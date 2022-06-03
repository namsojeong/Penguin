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

    private bool isOn = false;

    private void OnEnable()
    {
        SwitchReset();
        SwitchOffGame.Instance().UpdateScore();
        StartSwitch();
    }

    void StartSwitch()
    {
        startTime = Random.Range(1f, startMaxTime);
        Invoke("SwitchOn", startTime);
    }

    void SwitchOn()
    {
        isOn = true;
        switchImage.sprite = SwitchOffGame.Instance().onImage;
        cancelTime = Random.Range(1f, cancelMaxTime);
        Invoke("SwitchOff", cancelTime);
    }

    void SwitchOff()
    {
        CancelInvoke("SwitchOn");
        switchImage.sprite = SwitchOffGame.Instance().offImage;
        StartSwitch();
        isOn = false;
    }

    public void IsClick()
    {
        Debug.Log(isOn);
        if(isOn)
        {
            SwitchOffGame.Instance().ScoreUp(10);
        }
        else
        {
            SwitchOffGame.Instance().TimeDown(1);
        }
        SwitchOff();
    }

    void SwitchReset()
    {
        isOn = false;
        CancelInvoke("SwitchOff");
        CancelInvoke("SwitchOn");
        switchImage.sprite = SwitchOffGame.Instance().offImage;
    }
}
