using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtonScripts : MonoBehaviour
{
    [SerializeField, Header("�̹���")]
    Image switchImage;

    [SerializeField, Header("����ġ ó�� ������ �ð�")]
    float startMaxTime = 1f;
    [SerializeField, Header("����ġ ó�� ������ �ð�")]
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
