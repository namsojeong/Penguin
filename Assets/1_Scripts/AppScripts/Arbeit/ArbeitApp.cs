using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ArbeitE
{
    PE,
    STUDY,
    CHARM
}

public class ArbeitApp : MonoBehaviour
{
    [SerializeField, Header("알바 선택 버튼")]
    private Button[] arButton;
    
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

    Queue<ArbeitE> arbietQ = new Queue<ArbeitE>();

    int arMaxCnt = 3;
    int dayCnt = 5;

    bool isFull = false;

    private void Awake()
    {
        arButton[0].onClick.AddListener(() => PushAr(ArbeitE.PE));
        arButton[1].onClick.AddListener(() => PushAr(ArbeitE.STUDY));
        arButton[2].onClick.AddListener(() => PushAr(ArbeitE.CHARM));

        selectButton.onClick.AddListener(() => PlayArb());
        resetButton.onClick.AddListener(() => ResetArb());
    }

    private void Start()
    {
        arbietQ.Clear();
    }

    private void PushAr(ArbeitE ar)
    {
        arbietQ.Enqueue(ar);
        calImage[arbietQ.Count - 1].sprite = calSprite[(int)ar];
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
            Debug.Log($"날짜 {dayCnt}");
        Debug.Log($"일정카운트 {arbietQ.Count}");
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

    private void PlayArb()
    {
    }
}
