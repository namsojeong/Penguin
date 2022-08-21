
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class MessageTest : MonoBehaviour

{
    public Text chat1;
    public Text chat2;
    public Text chat3;
    public Text chat4;
    public Text chat5;
    public Text chat6;

    public GameObject _chat1;
    public GameObject _chat2;
    public GameObject _chat3;
    public GameObject _chat4;
    public GameObject _chat5;
    public GameObject _chat6;

    List<string> messages_1 = new List<string>();
    List<string> messages_2 = new List<string>();
    List<string> messages_3 = new List<string>();
    List<string> messages_4 = new List<string>();
    List<string> messages_5 = new List<string>();
    List<string> messages_6 = new List<string>();

    private int RandomNum, RandomNum1, RandomNum2, RandomNum3, RandomNum4, RandomNum5 ;
    public Button startButton;
    public Button nextButton1;
    public Button nextButton2;
    public Button finishButton;

    private void OnEnable()
    {
       

        _chat1.SetActive(false);
        _chat2.SetActive(false);
        _chat3.SetActive(false);
        _chat4.SetActive(false);
        _chat5.SetActive(false);
        _chat6.SetActive(false);

        //스타트채팅 시간에 맞춰서 나오도록 하기
        StartChatting();
    }

    void Awake()
    {
        //--첫번째, 잡담--
        messages_1.Add("오느으른.. 펭찌의 기부니 좋앙!!><");
        messages_1.Add("(꼬르륵) 갑자기 좀 배고프지 아나? 힛");
        messages_1.Add("나 갑자기 빙판에서 뒤뚱 거리고 싶어졌어! ");
        messages_1.Add("오늘 무슨 꿈 꿔었도? 혹시 펭찌 꿈??");
        messages_1.Add("난 단순히 추운 지방에 사는 다리 짧은 조류가 아니라구!");
        messages_1.Add("이거 나 지짜 비밀인데에 쓴맛과 단맛을 느끼지 못한다?!");
        messages_1.Add("난 어두운 곳에서 시력이 좋지 않다는 소문이 있는데 바보야 틀렸어!");
        messages_1.Add("나랑 같이 바다로 크릴새우와 물고기 사냥가지 않을랭?");
        messages_1.Add("나는 500m 이하의 깊은 바다로도 헤엄칠 수도 있지롱");
        messages_1.Add("천적인 ‘레오퍼드바다표범’과 ‘범고래’ 언급은 하지마라조!");
        messages_1.Add("범고래는 언제나 무서워요..");
        messages_1.Add("나 오늘 뭐 먹었게~");
        messages_1.Add("해가 떠서 눈이 부신 건가? 아니면 네가 날 보고 웃어줘서 그런 걸까?");
        messages_1.Add("감기는 언제나 조심해야해!");
        messages_1.Add("안뇽! 오늘따라 뭔가 더 예뻐보이네");
        messages_1.Add("생선가게에서 살 수 있다면 얼마나 좋을까");
        messages_1.Add("너 정말 별로야! 내 마음속의 별로,,");
        messages_1.Add("눈을 감는 시간이 너무 아까워.. 널 못 보니까~~");
        messages_1.Add("손에 그 무거운 짐 좀 내려놔 ‘멋짐' 크크 ");
        messages_1.Add("안녕~ 오늘 날씨는 어떤가? 맑았으면 좋겠다.");
        messages_1.Add("나 오늘 너 꿈 꿨다? 크크 부끄럽네");
        messages_1.Add("큼큼 내 말 좀 들어주라!");
        messages_1.Add("뭔가 하루하루 성장하고 있다는 느낌이 들어");
        messages_1.Add("나 멸종 위기종인건 알고 있지..? 흑흑");
        messages_1.Add("내 첫사랑은 지구야");
        messages_1.Add("지구를 위해서라면 뭐든지 할 수 있을 것만 같아");
        messages_1.Add("나는 지구가 깨끗해질거라고 믿어");
        messages_1.Add("지구는 둥글지롱~ 둥글둥글~");
        messages_1.Add("4월 25일은 세계 펭귄의 날이야! ");
        messages_1.Add("무리를 지어 생활하는 것을 잊은지는 오래야");
        messages_1.Add("빙하에서 살고 있는 엄마..아빠..는 잘 계실까?");
        messages_1.Add("남극에 살 때 바닷속 포식자가 두려워서 사냥을 하지 못했어");
        messages_1.Add("용감한 펭귄이 되고싶어!");
        messages_1.Add("내가 널 좋아하는 이유는 412가지야! 뭔지는 비밀");

        //--두번쨰, 잡담에 대한 대답--
        messages_2.Add("그래?");
        messages_2.Add("그렇구나");
        messages_2.Add("아하!");
        messages_2.Add("...?");
        messages_2.Add("응응!");
        messages_2.Add("응~");
        
        //--세번째, 환경 상식 설명--
        messages_3.Add("스위치를 끄면 남극에 얼음이 하나 더 생겨나!! 너무 좋아!!");
        messages_3.Add("그거 알아? 마네킹의 부모님이 비닐이래..!");
        messages_3.Add("오늘 저녁은 라면에 계란 넣어서 먹어야지! 아 계란은 일반쓰레기야 알지?");
        messages_3.Add("캔크러쉬 챌린지 해봤어? 캔을 발로 밟는거야!! 너도 해봐 재밌어");

        //--네번째, 환경 상식에 대한 대답--
        messages_4.Add("그래?");
        messages_4.Add("그렇구나");
        messages_4.Add("아하!");
        messages_4.Add("...?");
        messages_4.Add("응응!");
        messages_4.Add("응~");

        //--다섯번째, 환경 상식 세부 추가 설명 (환경상식 설명 랜덤값과 똑같이 할 것!)--
        messages_5.Add("스위치를 끄면 남극에 얼음이 하나 더 생겨나!! 너무 좋아!!");
        messages_5.Add("그거 알아? 마네킹의 부모님이 비닐이래..!");
        messages_5.Add("오늘 저녁은 라면에 계란 넣어서 먹어야지! 아 계란은 일반쓰레기야 알지?");
        messages_5.Add("캔크러쉬 챌린지 해봤어? 캔을 발로 밟는거야!! 너도 해봐 재밌어");

        //--여섯번째, 작별인사--
        
        messages_6.Add("그럼 잘가!");
        messages_6.Add("빠잉");
        messages_6.Add("그럼 잘가!");
        messages_6.Add("빠잉");
    }

    void StartChatting()
    {
        startButton.onClick.AddListener(Chatting1);
    }

    void Chatting1() //잡담
    {
       RandomNum = Random.Range(0, 2);

        chat1.text = string.Format(messages_1[RandomNum]);

        _chat1.SetActive(true);

        nextButton1.onClick.AddListener(Chatting2);
        
        // Chatting2();
    }

    void Chatting2() //잡담대답
    {

        RandomNum1 = Random.Range(0, 2);

        chat2.text = string.Format(messages_2[RandomNum1]);
        //messages.RemoveAt(RandomNum1);
        // NextButton.onClick.AddListener(Chatting3);

        _chat2.SetActive(true);

        Invoke("Chatting3", 1);
    }

    void Chatting3() //환경상식
    {

        RandomNum2 = Random.Range(0, 2);

        chat3.text = string.Format(messages_3[RandomNum2]);

        _chat3.SetActive(true);

        nextButton2.onClick.AddListener(Chatting4);

        //Chatting4();
    }

    void Chatting4() //환경상식 대답
    {

        RandomNum3 = Random.Range(0, 2);

        chat4.text = string.Format(messages_4[RandomNum3]);

        _chat4.SetActive(true);

        Invoke("Chatting5", 1);

    }

    void Chatting5() //환경상식 대답
    {

        RandomNum4 = Random.Range(0, 2);

        chat5.text = string.Format(messages_5[RandomNum4]);

        _chat5.SetActive(true);
        //NextButton.onClick.AddListener(Chatting6);
        Invoke("Chatting6", 1);
    }

    void Chatting6() //환경상식 대답
    {

        RandomNum5 = Random.Range(0, 2);

        chat6.text = string.Format(messages_6[RandomNum5]);

        _chat6.SetActive(true);

        finishButton.onClick.AddListener(MesaggeFinish);
    }

    void MesaggeFinish()
    {
        _chat1.SetActive(false);
        _chat2.SetActive(false);
        _chat3.SetActive(false);
        _chat4.SetActive(false);
        _chat5.SetActive(false);
        _chat6.SetActive(false);


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Chatting6();
            Debug.Log("된거");
        }
    }
}


