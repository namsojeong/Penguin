using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArbeitApp : MonoBehaviour
{
    [SerializeField, Header("알바 선택 버튼")]
    private Button[] arButton;

    [SerializeField, Header("플레이 Panel")]
    private GameObject playPanel;
    [SerializeField, Header("일정 선택 Panel")]
    private GameObject calendarPanel;
    
    [SerializeField, Header("알바 선택 버튼")]
    private Image[] calImage;
    
    [SerializeField, Header("알바 선택 버튼")]
    private Sprite[] calSprite;
    [SerializeField, Header("Default 일정 Sprite ")]
    private Sprite defSprite;

    [SerializeField, Header("알바 실행 버튼")]
    private Button selectButton;
    [SerializeField, Header("초기화 버튼")]
    private Button resetButton;

    Queue<AbilityE> arbietQ = new Queue<AbilityE>();

    int arMaxCnt = 3;
    int dayCnt = 5;
    int nowCnt = 0;

    bool isFull = false;
    bool isPlaying = false;

    EventParam eventParam = new EventParam();


    private void Awake()
    {
        arButton[0].onClick.AddListener(() => PushAr(AbilityE.PE));
        arButton[1].onClick.AddListener(() => PushAr(AbilityE.STUDY));
        arButton[2].onClick.AddListener(() => PushAr(AbilityE.CHARM));

        selectButton.onClick.AddListener(() => StartArb());
        resetButton.onClick.AddListener(() => ResetArb());
    }

    private void Start()
    {
        EventManager.StartListening("FinishArb", Finish);

        arbietQ.Clear();
        IsPlay();
        IsFull();
    }
    private void OnDestroy()
    {
        EventManager.StopListening("FinishArb", Finish);
    }

    void Finish(EventParam eventParam)
    {
        Debug.Log("Finish");
        nowCnt++;
        calImage[nowCnt - 1].sprite = defSprite;
        if(nowCnt >=5)
        {
            isPlaying = false;
            nowCnt = 0;
            ResetArb();
            IsPlay();
        }
        else
        {
            StartArb();
        }
        
    }

    void IsPlay()
    {
        if(isPlaying)
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
        calImage[arbietQ.Count - 1].sprite = calSprite[(int)ar-1];
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
        arbietQ.Clear();
        for(int i=0;i<5;i++)
        {
            calImage[i].sprite = defSprite;
        }
        IsFull();
    }

    void StartArb()
    {
        isPlaying = true;
        IsPlay();
        eventParam.abilityParam = arbietQ.Dequeue();
        EventManager.TriggerEvent("PlayArb", eventParam);
    }

}
