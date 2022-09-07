using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtonScripts : MonoBehaviour
{
    [SerializeField]
    int num;
    [Header("성공 실패 시 시간")]
    [SerializeField]
    int correctTime;
    [SerializeField]
    int failTime;

    [SerializeField]
    float offTime = 5;

    [SerializeField, Header("이펙트")]
    ParticleSystem failEffect;
    [SerializeField, Header("이펙트")]
    ParticleSystem correctEffect;

    private Image switchImage;
    private bool isOn = false;

    private void Awake()
    {
        switchImage = GetComponent<Image>();
        //SwitchReset();
    }

    void SwitchReset()
    {
        CancelInvoke("No");
        isOn = false;
        switchImage.sprite = SwitchOffGame.Instance().offImage;
    }

    // 스위치 켜기
    public void SwitchOn()
    {
        isOn = true;
        switchImage.sprite = SwitchOffGame.Instance().onImage;
        Invoke("No", offTime);
    }

    // 스위치 끄기
    void SwitchOff()
    {
        CancelInvoke("No");
        isOn = false;
        switchImage.sprite = SwitchOffGame.Instance().offImage;
    }

    // 버튼 클릭 시 판단
    public void ClickMe()
    {
        if (isOn)
        {
            Correct();
            SwitchOffGame.Instance().OffCorrectButton(num);
        }
        else
        {
            Fail();
            SwitchOffGame.Instance().OffButton(num);
        }
        TouchEffect();
        SwitchOff();
    }

    // 성공
    void Correct()
    {
        SwitchOffGame.Instance().ScoreUp(20);
        SwitchOffGame.Instance().TimeDown(correctTime);
    }
    // 실패
    void Fail()
    {
        SwitchOffGame.Instance().TimeDown(failTime);
    }

    // 클릭 이펙트
    void TouchEffect()
    {
        if (isOn)
        {
            correctEffect.transform.position = transform.position;
            correctEffect.Play();
        }
        else
        {
            failEffect.transform.position = transform.position;
            failEffect.Play();
        }
    }

    // 놓쳤을 때
    void No()
    {
        if (!isOn) return;
        Fail();
        SwitchOff();
    }

}
