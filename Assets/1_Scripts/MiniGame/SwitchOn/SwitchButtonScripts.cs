using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtonScripts : MonoBehaviour
{
    [SerializeField]
    int num;
    [Header("���� ���� �� �ð�")]
    [SerializeField]
    int correctTime;
    [SerializeField]
    int failTime;

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
    }

    // ��ư Ŭ�� �� �Ǵ�
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

    // ����
    void Correct()
    {
        SwitchOffGame.Instance().ScoreUp(20);
        SwitchOffGame.Instance().TimeDown(correctTime);
    }
    // ����
    void Fail()
    {
        SwitchOffGame.Instance().TimeDown(failTime);
    }

    // Ŭ�� ����Ʈ
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

    // ������ ��
    void No()
    {
        if (!isOn) return;
        Fail();
        SwitchOff();
    }

}
