
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

    public GameObject reNextButton1;
    public GameObject reNextButton2;

    public GameObject set;

    public GameObject set2;

    public GameObject finishButton2;

    //public GameObject TimeImg;

    private void Start()
    {
        StartMessage();
        finishButton2.SetActive(false);
    }

    void Restart()
    {
        StartMessage();

    }

    public void StartMessage()
    {
        _chat1.SetActive(false);
        _chat2.SetActive(false);
        _chat3.SetActive(false);
        _chat4.SetActive(false);
        _chat5.SetActive(false);
        _chat6.SetActive(false);

        reNextButton1.SetActive(false);
        reNextButton2.SetActive(false);

        Chatting1();

        set2.GetComponent<MessageTime>().enabled = false;

       // TimeImg.SetActive(false);
    }

    void Awake()
    {
        //--첫번째, 잡담--
        messages_1.Add("오느으른.. 펭찌의 기부니 좋앙!!><");
        messages_1.Add("(꼬르륵) 갑자기 ㅈ좀 배고푸지 아나? 힛");
        messages_1.Add("나 갑짜기 빙판에서ㅓ 뒤뚱 거리고 시퍼졌어!");
        messages_1.Add("잘 잤어? 설마아 펭찌 꿈 꾼고 아니야?!");
        messages_1.Add("난 단순히 다리 짧은 조류가 아니이라구!");
        messages_1.Add("이거 비밀인데에 난 쓴맛과 단맛을 느끼지 못한다?!");
        messages_1.Add("나눈.. 어두운 곳에소도.. 시력이 좋다구우");
        messages_1.Add("이따아 펭찌랑 가치 크릴새우 사냥가지 않을랭?");
        messages_1.Add("난 500m 이하의 기픈 바다에서도 헤엄쳐 첨벙~");
        messages_1.Add("‘레오퍼드바다표범’은 너무 무소워.. 흐아앙");//10
        messages_1.Add("남극에 있을 때애 범고래가 나는 너무 무서워써..");
        messages_1.Add("아이 냠냠냠~ 나 오늘 맛있는 거 먹어써!");
        messages_1.Add("너가 날 보고 웃어조서 눈이 부신거까??");
        messages_1.Add("감기 조심해야행! 너가ㅏ 아프면 펭찌도 아푸니까..");
        messages_1.Add("안농ㅇ! 오늘따라 몬가 더 이뽀보이네 히히");
        messages_1.Add("생선 가게에소 살 수 이따면 얼마나 조을까?");
        messages_1.Add("너 쩡말 별로야! 흥!! 내 마음소게 별ㄹ로,, 크크");
        messages_1.Add("눈을 감는 시간이 아까오.. 널 보지 모타니까아~~");
        messages_1.Add("손에 그 무ㅜ거운 짐 좀 내려놔아 ‘멋짐' 크크 ");
        messages_1.Add("안ㄴ녕~ 오늘 날씨는 오때앵? 맑았으면 조켔눈대");//20
        messages_1.Add("나 오늘 너 꿈 꾸어따? 크크 부끄럽넹");
        messages_1.Add("어서와! 마침 너에게 할 말이 이썼는데 크크");
        messages_1.Add("먼가 하루 하루 성장하고 이따는 느낌이 드러");
        messages_1.Add("펭찌는 멸종 위기종인건 알고 이찌..? 흑흑 슬푸다");
        messages_1.Add("펭찌 첫사랑이 누구냐구..? 바로 지구야!!");
        messages_1.Add("응? 내 키가 짜가보인다구? 내 키는 무려 60cm라구!");
        messages_1.Add("너도 환경 운동 함께하자! 그럼 지구가 더 깨끗해지꺼야!");
        messages_1.Add("내가 따랑하는 지구는 둥글지롱~ 둥글둥글~ ");
        messages_1.Add("4월 25일은 무슨 날이게~ 바로오 세계 펭귄의 날이야! ");
        messages_1.Add("무리를 지어 생활하는 것울 이즌지는 오래야");//30
        messages_1.Add("빙하에서 살고 있눈 옴마..아빠ㅏ..눈 잘 계실까?");
        messages_1.Add("남극에소 살 때 바닷 속 포식짜가 두려워서 사냥을 모태써");
        messages_1.Add("펭찌는 커서 용감한 펭귄이 되구시포!");
        messages_1.Add("펭찌가 널 조아하는 이유는 412가지야! 몬지는 비밀");
        messages_1.Add("펭찌 이야기를 드러ㅓ어주러 왔구나! 노무너무ㅜ 고마어~");
        messages_1.Add("어디가따가 와써! 보고시펐다구..! 흥흥");
        messages_1.Add("너 생각하고 이써는대 마침 왔네에?");
        messages_1.Add("어떠와! 항상 기다리구 이썼지롱");
        messages_1.Add("맛있는 걸 먹는건 언제나 행보케");
        messages_1.Add("안농안넝안농~ 어떠와아아아아 크크");//40
        messages_1.Add("오늘의 미세먼지는 갠차나?");
        

        //--두번쨰, 잡담에 대한 대답--
        messages_2.Add("그래?");
        messages_2.Add("그렇구나");
        messages_2.Add("...?");
        messages_2.Add("응응!");
        messages_2.Add("응~");
        messages_2.Add("아하? 그렇군");
        messages_2.Add("어어");
        messages_2.Add("반가워!");
        messages_2.Add("응?");
        messages_2.Add("응!");
        messages_2.Add("하하");

        //--세번째, 환경 상식 설명--
       
        messages_3.Add("커피 한 잔울 버리면 마리야? 깨끗하개 만들기 위해");
        messages_3.Add("모오~든 사람들이 음식쑤레기를 절반만 줄여두");
        messages_3.Add("일회용품은 정말 쓰지 마라야게써!");
        messages_3.Add("음식물 쑤레기를 절약하는 것두 중요해");
        messages_3.Add("실내 온도를 적쩡하게 유지해보눈 건 어떠까?");
        messages_3.Add("티비를 보는 건 조치만 너무 많이 보는건..");
        messages_3.Add("사용하지 않눈 전등은 모두 모두 꺼버리자!");
        messages_3.Add("냉장고 문을 열구 닫을 때마다 지구가 아야한대애");
        messages_3.Add("엘레베이터 닫힘 버튼 누르는 걸 줄이는 거또");
        messages_3.Add("대중교통을 사용하는 것두 마리야..!");
        messages_3.Add("만약 남극의 얼음이 모오두 녹아 버린다면?");
        messages_3.Add("펭찌는 부레옥잠을 실제로 한 번 보고시퍼!");
        messages_3.Add("요즘 비닐봉투를 많이 사용하지 아나?");
        messages_3.Add("요즘 별을 보기 힘들지아나..?");
        messages_3.Add("남극 조약도 이따? 남극의 환경을 보호하기 위해");
        messages_3.Add("설마 한 번 쓴 물건을 그냥 버리는건 아니겠지?");
        messages_3.Add("겨울에는 옷을 두껍게 입고 다니는건 잊지 않아찌?");
        messages_3.Add("혹시 나갈 때 급하다구 구냥 나가지마!");
        messages_3.Add("다들 에어컨을 왜 이러케 마니 쓰는고지?");
        messages_3.Add("컴퓨터를 끄지 않는건 아니겠지?");
        messages_3.Add("목욕할 때 욕조를 사용하눈 것 보다눈");
        messages_3.Add("뽀득뽀득! 비누칠 할 때는 마리야아");
        messages_3.Add("목욕한 물이 많ㅎ은데 구냥 버릴 때! 아깝지 아나?");
        messages_3.Add("그냥 아무 거나 막 사는 것 보다눈");
        messages_3.Add("어? 혹시 환경마크라는 거 알아? 응? 응??");
        messages_3.Add("펭찌는 맨날 주머니에 손수건을 가지고 다니지 훗.");
        messages_3.Add("만년필을 사용해보는 건 어떨까아아?");
        messages_3.Add("자동차 경적 소음, 배기 소음을 줄이는거누");
        messages_3.Add("음식물 쓰레기눈 쓰레기 속에 있는 작은 미생물을 이용해소");
        messages_3.Add("펄럭펄럭~ 새로운 종이 1톤을 만들기 위해서눈");
        messages_3.Add("흙 속에 사는 지렁이, 달팽이와 같은 작은 동물드리");
        messages_3.Add("공기 오염의 가장 큰 이유눈 자동차의 배기가스와");
        messages_3.Add("우리가 마싯게 먹구 버리는 과자 봉지눈 땅속에서 분해를 시켜야해!");
        messages_3.Add("미세먼지가 심한 날, 콜록콜록 외출을 해야 할 경우에눈");
        messages_3.Add("건전지는 일반쓰레기로 버리면 토양을 오염시키구");
        messages_3.Add("치카치카하는 칫솔은 주기적으로 교체해줘야해");
        messages_3.Add("플라스틱 빨대는 재활용이 가능할까아아?");

        //--네번째, 환경 상식에 대한 대답--
        messages_4.Add("응!");
        messages_4.Add("엉");
        messages_4.Add("음음");
        messages_4.Add("응~!");
        messages_4.Add("응응!");
        messages_4.Add("응~");

        //--다섯번째, 환경 상식 세부 설명 (환경상식 설명 랜덤값과 똑같이 할 것!)--
        messages_5.Add("무려 깨끗한 물 19통이 필요하대!");
        messages_5.Add("음식물 처리비용 1,700억원이나아 절약이 된다구!");
        messages_5.Add("환경이 쉽게 무ㅜ너지는 지름길이라구!");
        messages_5.Add("알마즌 양만 사용하구 조리하면 쉽게 절약할 뚜 이써");
        messages_5.Add("대기 오염 물질이 너어무 마니 발생하고 이써");
        messages_5.Add("전기가 노무 마니 사용돼! 안 볼때눈 꼭 끄자!");
        messages_5.Add("그럼 지구가 방긋방긋 웃을 수 이뚤거야!");
        messages_5.Add("쪼오금씩만 줄여보는게 어떨까아아?");
        messages_5.Add("전기를 조금이라두 아낄 수 있는 방법이래");
        messages_5.Add("대기 오염 배출을 줄일 수 있는 방법이라는 건 알구 이찌?");
        messages_5.Add("도시나 낮은 평야는 모두 물 속에 잠겨 버리게 될꼬야");
        messages_5.Add("부레옥잠은 살아있는 수질 정화장치라니! 너무 신기하지!");
        messages_5.Add("그보다 에코백을 사용하면 지구를 지킬 수 이써!");
        messages_5.Add("대기오염 물질이랑 인공 불빛이 먼지층에 반사되어서 안 보이눈고야");
        messages_5.Add("평화 목적에만 이용한다는 조약이야! 너무 행보케");
        messages_5.Add("물건을 아껴쓰는 습관을 길러보자구우우!");
        messages_5.Add("그리고 난방을 줄이고 실내 온도를 낮추우어보눈고야");
        messages_5.Add("외출 시에는 반드시 소등했눈지 확인은 필수라구");
        messages_5.Add("부채나 선풍기가 있는데 마리양! 나 좀 슬포..");
        messages_5.Add("컴퓨터는 사용하지 않을 때눈 전원을 끄는 습관을 가지자");
        messages_5.Add("샤워기를 사용하눈게 더 좋대! 꼭 기억하깅!");
        messages_5.Add("수도꼭지를 꼭 꼭 잠가주자! 수도꼭지가 울자낭..");
        messages_5.Add("세탁이나 청소용으루 재사용하는 방법은 알구있나아?");
        messages_5.Add("환경 친화적인 상품을 구매하는게 지구에게 더 좋겠지?");
        messages_5.Add("이왕 사는거 환경 마크가 붙어있는 상품을 이용하자");
        messages_5.Add("휴지에 대한 나의 작은 매너라까?");
        messages_5.Add("왠지 만년필을 사용하는 사람은 멋진듯 크크.. 반하는 건 아니구");
        messages_5.Add("소음 공해를 막을 수 있눈 저은 방법이지 후후");
        messages_5.Add("친환경 가스나 퇴비를 만드는 데 재활용할 수 이써");
        messages_5.Add("나무 24그루, 물 86톤이 피료하다니 믿을 수 업따구!");
        messages_5.Add("흙을 깨끗하게 만들어소 우리 생활에 도움을 주고 이떠요.");
        messages_5.Add("우리에게 필요한 물건을 만두는 공장의 매연 때무니에여");
        messages_5.Add("근데 걸리는 시간은 무려 450년이나 걸린다구 해여");
        messages_5.Add("꼭 꼭 마스크를 착용해여! 이거 진짜 약속이야!");
        messages_5.Add("토양 속 물을 오염시켜여 그러니까 폐건전지 수거함에 버리자");
        messages_5.Add("근데 이걸 어디에다 버리냐구? 일반쓰레기야!");
        messages_5.Add("노노 아니징 바로! 일반쓰레기에 넣어야지 헤헤헤");
        //--여섯번째, 작별인사--

        messages_6.Add("그럼 잘가!");
        messages_6.Add("빠잉");
        messages_6.Add("좋은 하루 보냉!");
        messages_6.Add("나중에 다시 와줘!");
        messages_6.Add("또 내 얘기 들으러 와줄거지?");
        messages_6.Add("내 얘기 들어줘서 고마워");
        messages_6.Add("그럼 환경을 지키러 가볼까?");
        messages_6.Add("펭찌는 내 얘기를 들어줘서 너무 고마워");
        messages_6.Add("우리의 작은 실천이 지구를 지켜!");
    }

    void Chatting1() //잡담
    {
        RandomNum = Random.Range(0, 40);
       // reNextButton1true();

        Invoke("reNextButton1true", 1);

        chat1.text = string.Format(messages_1[RandomNum]);

        _chat1.SetActive(true);

        nextButton1.onClick.AddListener(Chatting2);

        // Chatting2();

       
    }

    void reNextButton1true()
    {
        reNextButton1.SetActive(true);
    }

    public void reNextButton_first()
    {
        //if (_chat1.activeSelf == true)
           

        //if (_chat2.activeSelf == true)
        //{
        //    reNextButton1.SetActive(false);
        //    GameObject.Find("MessageScript").GetComponent<MessageTime>().Remainingtime_True();
        //}


        //if (_chat3.activeSelf == true)
        //    GameObject.Find("MessageScript").GetComponent<MessageTime>().Update();
    }

    void Chatting2() //잡담대답
    {
       
        RandomNum1 = Random.Range(0, 2);

        chat2.text = string.Format(messages_2[RandomNum1]);
      
        _chat2.SetActive(true);

        set2.GetComponent<MessageTime>().enabled = true;

        Invoke("Chatting3", 1);

        //TimeImg.SetActive(true);
    }

    void Chatting3() //환경상식
    {
        //TimeImg.SetActive(false);

        set2.GetComponent<MessageTime>().enabled = false;

        RandomNum2 = Random.Range(0, 5);

        chat3.text = string.Format(messages_3[RandomNum2]);

        _chat3.SetActive(true);

        //GameObject.Find("MessageScript").GetComponent<MessageTime>().AddRemainingtime();

        Invoke("nextButton2_", 1);
    }

    void nextButton2_()
    {
        reNextButton2.SetActive(true);
        nextButton2.onClick.AddListener(Chatting4);
    }

    void Chatting4() //환경상식 대답
    {
        //TimeImg.SetActive(true);

        RandomNum3 = Random.Range(0, 2);

        chat4.text = string.Format(messages_4[RandomNum3]);

        _chat4.SetActive(true);

        Invoke("Chatting5", 1);

        set2.GetComponent<MessageTime>().enabled = true;
      //  Debug.Log("시간 시작!");
    }

    void Chatting5() //환경상식 대답
    {
        //TimeImg.SetActive(false);

        set2.GetComponent<MessageTime>().enabled = false;

        RandomNum4 = Random.Range(0, 2);

        chat5.text = string.Format(messages_5[RandomNum2]);

        _chat5.SetActive(true);
     
        Invoke("Chatting6", 1);
    }

    void Chatting6() //환경상식 대답
    {

        RandomNum5 = Random.Range(0, 2);

        chat6.text = string.Format(messages_6[RandomNum5]);

        _chat6.SetActive(true);

        Invoke("MesaggeFinish", 1);
    }

    void MesaggeFinish()
    {
        //finishButton2.SetActive(true);
        finishButton.onClick.AddListener(MesaggeFinish);

        _chat1.SetActive(false);
        _chat2.SetActive(false);
        _chat3.SetActive(false);
        _chat4.SetActive(false);
        _chat5.SetActive(false);
        _chat6.SetActive(false);

        Restart();
    }


    private void Update()
    {

    }
}


