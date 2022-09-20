using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField]
    AudioClip finishSound;
    [SerializeField]
    Text tmiText;


    [SerializeField, Header("알바 후 패널")]
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

    Dictionary<int, string> tmiDict = new Dictionary<int, string>();
    
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

        ResetDict();
    }

    void ResetDict()
    {
        tmiDict.Clear();
        tmiDict.Add(1, "TMI : 펭찌의 성별은 개발자도 알지 못한다...");
        tmiDict.Add(2, "TMI : 펭찌는 아샷추를 좋아한다. 물론 아이스티에 샷 추가");
        tmiDict.Add(3, "TMI : 펭찌 아이템 중 안경은 도수가 없는 패션안경이다.");
        tmiDict.Add(4, "TMI : 펭찌는 사실 노래 중 힙합을 좋아한다. 가끔 혼자 랩을 부르곤 한다");
        tmiDict.Add(5, "TMI : 펭찌는 북극에 놀러 간 적이 있어 북극곰과 짱친을 먹었다.");
        tmiDict.Add(6, "TMI : 펭찌는 요리하다가 이글루가 폭발한 적이 있다.");
        tmiDict.Add(7, "TMI : 펭찌는 한때 3대 500을 친 리즈시절이 있다.");
        tmiDict.Add(8, "TMI : 펭찌는 남극에서 비담이었다 비주얼담당");
        tmiDict.Add(9, "TMI : 펭찌의 이름은 펭귄찌질이에서 유래되었다라는 전설이 있다.");
        tmiDict.Add(10, "TMI : 펭찌는 눈사람 친구도 있다. 그 친구도 새로운 터전을 찾아 떠났다는 소문이 있다.");
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

    IEnumerator UpdateTMI()
    {
        int randomTMI = 0;
        while(true)
        {
            randomTMI = UnityEngine.Random.Range(1, tmiDict.Count);
            tmiDict.TryGetValue(randomTMI, out string str);
            tmiText.text = String.Format(str);
            yield return new WaitForSeconds(6f);
        }
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

        // 보상
        AbilityE curAr = eventParam.abilityParam;
        GameManager.Instance.PlusCoin(100);
        GameManager.Instance.UpAbility(curAr, 10);
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
            tmiText.gameObject.SetActive(true);
            StartCoroutine(UpdateTMI());
        }
        else
        {
            playPanel.SetActive(false);
            calendarPanel.SetActive(true);
            tmiText.gameObject.SetActive(false);
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
        getCoinT.text = string.Format($"획득 코인: {nowCnt * 100} ");
        string str = "획득 스탯\n";
        if (arbCnt[0]>=1)
        {
            str += "운동 +" + arbCnt[0] * 10+"\n";
        }
        if(arbCnt[1]>=1)
        {
            str += "지식 +" + arbCnt[1] * 10+"\n";
        }
        if(arbCnt[2]>=1)
        {
            str += "매력 +" + arbCnt[2] * 10;
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
