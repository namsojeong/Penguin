using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ArbeitApp : MonoBehaviour
{
    [SerializeField, Header("�˹� ���� ��ư")]
    private Button[] arButton;

    [SerializeField, Header("�÷��� Panel")]
    private GameObject playPanel;
    [SerializeField, Header("���� ���� Panel")]
    private GameObject calendarPanel;

    [SerializeField, Header("�˹� ���� ��ư")]
    private Image[] calImage;

    [SerializeField, Header("�˹� ���� ��ư")]
    private Sprite[] calSprite;
    [SerializeField, Header("Default ���� Sprite ")]
    private Sprite defSprite;

    [SerializeField, Header("�˹� ���� ��ư")]
    private Button selectButton;
    [SerializeField, Header("�ʱ�ȭ ��ư")]
    private Button resetButton;

    [SerializeField]
    AudioClip finishSound;


    [SerializeField, Header("�˹� �� �г�")]
    private GameObject overpanel;
    [SerializeField]
    private Text getCoinT;
    [SerializeField]
    private Text getstatsT;

    Queue<AbilityE> arbietQ = new Queue<AbilityE>();

    int dayCnt = 5;
    int nowCnt = 0;

    bool isFull = false;
    bool isPlaying = false;

    List<Sprite> setSprite = new List<Sprite>();
    int[] arbCnt = { 0, 0, 0 }; 

    EventParam eventParam = new EventParam();


    private void Awake()
    {
        arButton[0].onClick.AddListener(() => PushAr(AbilityE.PE));
        arButton[1].onClick.AddListener(() => PushAr(AbilityE.STUDY));
        arButton[2].onClick.AddListener(() => PushAr(AbilityE.CHARM));

        selectButton.onClick.AddListener(() => PlayArb());
        resetButton.onClick.AddListener(() => ResetArb());
        overpanel.SetActive(false);
    }

    private void Start()
    {
        EventManager.StartListening("FinishArb", Finish);
        //EventManager.StartListening("PlusArb", GetArb);

    }
    private void OnDestroy()
    {
        EventManager.StopListening("FinishArb", Finish);
        // EventManager.StopListening("PlusArb", GetArb);
    }

    private void OnEnable()
    {
        ResetArb();
    }

    void OpenArb()
    {
        IsPlay();
        IsFull();
    }

    void Finish(EventParam eventParam)
    {
        nowCnt++;
        calImage[nowCnt - 1].sprite = defSprite;

        // ����
        AbilityE curAr = eventParam.abilityParam;
        GameManager.instance.PlusCoin(100);
        GameManager.instance.UpAbility(curAr, 10);
        SoundManager.instance.SFXPlay(finishSound);

        if (nowCnt >= 5)
        {
            FinishEffect();
            ResetArb();
        }
        else
        {
            FinishOneEffect();
            StartArb();
        }



    }
    void IsPlay()
    {
        if (isPlaying)
        {
            playPanel.SetActive(true);
            calendarPanel.SetActive(false);
        }
        else
        {
            playPanel.SetActive(false);
            calendarPanel.SetActive(true);
        }
    }

    private void PushAr(AbilityE ar)
    {
        arbietQ.Enqueue(ar);
        calImage[arbietQ.Count - 1].sprite = calSprite[(int)ar - 1];
        arbCnt[(int)ar-1]++;
        IsFull();
    }

    private void FullArb()
    {
        arButton[0].interactable = false;
        arButton[1].interactable = false;
        arButton[2].interactable = false;
        selectButton.interactable = true;
    }

    private void NotFullArb()
    {
        arButton[0].interactable = true;
        arButton[1].interactable = true;
        arButton[2].interactable = true;
        selectButton.interactable = false;
    }

    private void IsFull()
    {
        if (dayCnt <= arbietQ.Count)
        {
            FullArb();
            isFull = true;
        }
        else
        {
            NotFullArb();
            isFull = false;
        }
    }

    private void ResetArb()
    {
        arbCnt[0] = 0;
        arbCnt[1] = 0;
        arbCnt[2] = 0;
        arbietQ.Clear();
        isPlaying = false;
        nowCnt = 0;
        for (int i = 0; i < 5; i++)
        {
            calImage[i].sprite = defSprite;
        }
        IsPlay();
        IsFull();
    }
    void PlayArb()
    {
        isPlaying = true;
        IsPlay();
        StartArb();
    }
    void StartArb()
    {
        eventParam.abilityParam = arbietQ.Dequeue();
        EventManager.TriggerEvent("PlayArb", eventParam);
    }

    void FinishEffect()
    {
        overpanel.SetActive(true);
        getCoinT.text = string.Format($"ȹ�� ����: {nowCnt * 100} ");
        string str = "ȹ�� ����\n";
        if (arbCnt[0]>=1)
        {
            str += "� +" + arbCnt[0] * 10+"\n";
        }
        if(arbCnt[1]>=1)
        {
            str += "���� +" + arbCnt[1] * 10+"\n";
        }
        if(arbCnt[2]>=1)
        {
            str += "�ŷ� +" + arbCnt[2] * 10;
        }
        getstatsT.text = string.Format(str);
        Invoke("OffEffct", 1f);
    }

    void OffEffct()
    {
        overpanel.SetActive(false);
    }

    void FinishOneEffect()
    {

    }

}
