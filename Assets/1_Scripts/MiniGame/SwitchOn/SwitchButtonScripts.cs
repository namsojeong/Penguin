using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtonScripts : MonoBehaviour
{
    [SerializeField]
    int num;
    [SerializeField]
    float offTime = 5;

    [SerializeField, Header("����Ʈ")]
    ParticleSystem failEffect;
    [SerializeField, Header("����Ʈ")]
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

    // ����ġ �ѱ�
    public void SwitchOn()
    {
        isOn = true;
        switchImage.sprite = SwitchOffGame.Instance().onImage;
        Invoke("No", offTime);
    }

    // ����ġ ����
    void SwitchOff()
    {
        CancelInvoke("No");
        isOn = false;
        switchImage.sprite = SwitchOffGame.Instance().offImage;
        SwitchOffGame.Instance().OffButton(num);
    }

    // ��ư Ŭ�� �� �Ǵ�
    public void ClickMe()
    {
        if(isOn)
        {
            Correct();
        }
        else
        {
            Fail();
        }
        TouchEffect();
        SwitchOff();
    }

    // ����
    void Correct()
    {
        SwitchOffGame.Instance().ScoreUp(20);
        SwitchOffGame.Instance().TimeDown(-5);
    }
    // ����
    void Fail()
    {
            SwitchOffGame.Instance().TimeDown(30);
    }

    // Ŭ�� ����Ʈ
    void TouchEffect()
    {
        if(isOn)
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
    
    // ������ ��
    void No()
    {
        if (!isOn) return;
        Fail();
        SwitchOff();
    }

}
