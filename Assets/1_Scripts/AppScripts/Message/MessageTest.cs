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

    private int RandomNum, RandomNum1, RandomNum2, RandomNum3, RandomNum4, RandomNum5;
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
        messages_1.Add("오느으른.. 펭찌의 기부니 조앙!!><");
        messages_1.Add("갑자기 ㅈ좀 배고푸지 아나? 힛");
        messages_1.Add("나 갑짜기 빙판에서ㅓ 뒤뚱 거리고 시퍼졌어!");
        messages_1.Add("잘 잤어? 설마아 펭찌 꿈 꾼고 아니야?!");
        messages_1.Add("난 단순히 다리 짤ㅂ은 조류가 아니이라구!");
        messages_1.Add("이거 비밀인데에 난 쓴맛과 단맛을 느끼지 못한다?!");
        messages_1.Add("나눈.. 어두운 곳에소도.. 시력이 조타구우");
        messages_1.Add("이따아 펭찌랑 가치 크릴새우 사냥가지 않을랭?");
        messages_1.Add("난 500m 이하의 기픈 바다에서도 헤엄쳐 첨벙~");
        messages_1.Add("레오퍼드바다표범은 너무 무소워.. 흐아앙");//10
        messages_1.Add("남극에 있을 때애 범고래가 너무 무서워써..");
        messages_1.Add("아이 냠냠냠~ 나 오늘 맛있는 거 먹어써!");
        messages_1.Add("너가 날 보고 웃어조서 눈이 부신거까??");
        messages_1.Add("감기 조심해야행! 너가ㅏ 아프면 펭찌도 아푸니까..");
        messages_1.Add("안농ㅇ! 오늘따라 먼가 더 이뽀보이네 히히");
        messages_1.Add("생선 가게에소 살 수 이따면 얼마나 조을까?");
        messages_1.Add("너 쩡말 별로야! 흥!! 내 마음소게 별ㄹ로,, 크크");
        messages_1.Add("눈을 감는 시간이 아까오.. 널 보지 모타니까아");
        messages_1.Add("손에 그 무ㅜ거운 짐 좀 내려놔아 ‘멋짐' 크크 ");
        messages_1.Add("안ㄴ녕~ 오늘 날씨는 오때앵? 맑았으면 조켔눈대");//20
        messages_1.Add("나 오늘 너 꿈 꾸어따? 크크 부끄럽넹");
        messages_1.Add("어서와! 마침 너에게 할 말이 이썼는데 크크");
        messages_1.Add("먼가 하루 하루 성장하고 이따는 느낌이 드러");
        messages_1.Add("펭찌는 멸종 위기종인건 알고 이찌..? 흑흑 슬푸다");
        messages_1.Add("펭찌 첫사랑이 누구냐구..? 바로 지구야!!");
        messages_1.Add("응? 펭찌 키가 짜가보인다구? 무려 60cm라구!");
        messages_1.Add("환경 운동 함께하자! 지구가 더 깨끗해지꺼야!");
        messages_1.Add("내가 따랑하는 지구는 둥글지롱~ 둥글둥글~ ");
        messages_1.Add("4월 25일은 바로오 세계 펭귄의 날이야!");
        messages_1.Add("무리를 지어 생활하는 것울 이즌지는 오래야");//30
        messages_1.Add("빙하에서 살고 있눈 옴마아빠ㅏ..눈 잘 계실까?");
        messages_1.Add("남극에소 바닷 속 포식짜 때메 사냥을 모태써");
        messages_1.Add("펭찌는 커서 용감한 펭귄이 되구시포!");
        messages_1.Add("펭찌가 널 조아하는 이유는 412가지야! 몬지는 비밀");
        messages_1.Add("펭찌 이야기를 드러어주러 왔구나! 노무 고마오");
        messages_1.Add("어디가따가 와써! 보고시펐다구..! 흥흥");
        messages_1.Add("너 생각하고 이써는대 마침 왔네에?");
        messages_1.Add("어떠와! 항상 기다리구 이썼지롱");
        messages_1.Add("맛있는 걸 먹는건 언제나 행보케");
        messages_1.Add("안농안넝안농~ 어떠와아아아아 크크");//40
        messages_1.Add("오늘 펭찌 오땡? 오늘도 언제나처럼 귀엽찌!!!!");
        messages_1.Add("난 언젠가 우주로 가서 지구를 보고 말테얍!");
        messages_1.Add("나랑 문자하는게 재미있어서 또 왔구나!");
        messages_1.Add("메인화면에서 날 건드리면 너무 간지러워");
        messages_1.Add("메인화면에서 날 위로 올리면 붕 떠 있는 기분이야");
        messages_1.Add("전화 한 번씩 해줘~! 나 심심하단 말이양");
        messages_1.Add("펭찌는 하루종일 기다리고 있어엉");
        messages_1.Add("25일이 되면 어떤 일이 일어날지 정말 궁금해!");
        messages_1.Add("펭찌의 뜻이 뭔지 알아? 바로... 비밀~");
        messages_1.Add("지구가 깨끗하면 펭찌는 정말 행보케~ ");//50

        //49


        //--두번쨰, 잡담에 대한 대답--
        messages_2.Add("아~");
        messages_2.Add("응!!");
        messages_2.Add("으응?");
        messages_2.Add("응응!");
        messages_2.Add("응~");
        messages_2.Add("엉");
        messages_2.Add("웅");
        messages_2.Add("허허");
        messages_2.Add("응?");
        messages_2.Add("응!");
        messages_2.Add("하하");

        //10

        //--세번째, 환경 상식 설명--

        messages_3.Add("커피 한 잔 버리면 깨끗하개 만들기 위해!");
        messages_3.Add("모오~든 음식쑤레기를 절반만 줄여두");
        messages_3.Add("일회용품은 정말 쓰지 마라야게써!");
        messages_3.Add("음식물 쑤레기를 절약하는 것두 중요해");
        messages_3.Add("실내 온도를 적쩡하게 유지해보눈 건 어떠까?");
        messages_3.Add("티비를 보는 건 조치만 너무 많이 보는건..");
        messages_3.Add("사용하지 않눈 전등은 모두 모두 꺼버리자!");
        messages_3.Add("냉장고 문을 열 때마다 지구가 아야한대애");
        messages_3.Add("엘레베이터 닫힘 버튼 누르는 걸 줄이는 거또");
        messages_3.Add("대중교통을 사용하는 것두 마리야..!"); //10
        messages_3.Add("만약 남극의 얼음이 모오두 녹아 버린다면?");
        messages_3.Add("펭찌는 부레옥잠을 실제로 한 번 보고시퍼!");
        messages_3.Add("요즘 비닐봉투를 많이 사용하지 아나?");
        messages_3.Add("요즘 별을 보기 힘들지아나..?");
        messages_3.Add("남극 조약도 이따? 남극의 환경을 보호하기 위해");
        messages_3.Add("설마 한 번 쓴 물건을 그냥 버리는건 아니겠지?");
        messages_3.Add("겨울에 옷을 두껍게 입고 다니는건 잊지 않아찌?");
        messages_3.Add("혹시 나갈 때 급하다구 구냥 나가지마!");
        messages_3.Add("다들 에어컨을 왜 이러케 마니 쓰는고지?");
        messages_3.Add("컴퓨터를 끄지 않는건 아니겠지?"); //20
        messages_3.Add("목욕할 때 욕조를 사용하눈 것 보다눈");
        messages_3.Add("뽀득뽀득! 비누칠 할 때는 마리야아");
        messages_3.Add("목욕한 물을 구냥 버릴 때! 좀 아깝지 아나?");
        messages_3.Add("그냥 아무 거나 막 사는 것 보다눈");
        messages_3.Add("어? 혹시 환경마크라는 거 알아? 응? 응??");
        messages_3.Add("펭찌는 맨날 주머니에 손수건을 가지고 다니지 훗."); //이거 기준으로 하자
        messages_3.Add("만년필을 사용해보는 건 어떨까아아?");
        messages_3.Add("자동차 경적 소음, 배기 소음을 줄이는거누");
        messages_3.Add("음식물 쓰레기 속에 있는 미생물을 이용해소");
        messages_3.Add("펄럭펄럭~ 새로운 종이 1톤을 만들기 위해서눈"); //30
        messages_3.Add("흙 속에 사는 지렁이같은 작은 동물드리");
        messages_3.Add("공기 오염의 가장 큰 이유눈 자동차의 배기가스와");
        messages_3.Add("버리는 과자 봉지눈 땅속에서 분해를 시켜야해!");
        messages_3.Add("미세먼지가 심한 날, 외출을 해야 할 경우에눈");
        messages_3.Add("건전지는 일반쓰레기로 버리면 토양을 오염시키구");
        messages_3.Add("치카치카하는 칫솔은 주기적으로 교체해줘야해");
        messages_3.Add("플라스틱 빨대는 재활용이 가능할까아아?"); //37
        messages_3.Add("홈화면에소 날 끌어당기묘눈 내 몸이 제멋대로");
        messages_3.Add("홈화면에소 날 터치하면 간지럽따구");
        messages_3.Add("25일이 되면 난 어떻게 살고 있우까?");
        messages_3.Add("펭찌를 배고프ㅡ게 하지 말아조...");
        messages_3.Add("전화룰 하묘누 펭찌 목소리를 들을 수 이쏘");
        messages_3.Add("카메라루 우리의 추억울 간직해보짜~!");
        messages_3.Add("오늘은 뭐를 먹어볼까!! 추천 좀 해조!");
        messages_3.Add("갤러리에서 어떤 추억을 꺼내서 봐볼까?");

        //45


        //--네번째, 환경 상식에 대한 대답--
        messages_4.Add("응!");
        messages_4.Add("어엉");
        messages_4.Add("음음");
        messages_4.Add("응~!");
        messages_4.Add("응응!");
        messages_4.Add("오호");
        messages_4.Add("그래그래");
        messages_4.Add("그래");
        messages_4.Add("응");
        messages_4.Add("오오");

        //10

        //--다섯번째, 환경 상식 세부 설명 (환경상식 설명 랜덤값과 똑같이 할 것!)--
        messages_5.Add("무려 깨끗한 물 19통이 필요하대!");
        messages_5.Add("음식물 처리비용 1,700억원이나아 절약된다구!");
        messages_5.Add("환경이 쉽게 무ㅜ너지는 지름길이라구!");
        messages_5.Add("알마즌 양만 조리하면 쉽게 절약할 뚜 이써");
        messages_5.Add("대기 오염 물질이 너어무 마니 발생하고 이써");
        messages_5.Add("전기가 노무 마니 사용돼! 안 볼때눈 꼭 끄자!");
        messages_5.Add("그럼 지구가 방긋방긋 웃을 수 이뚤거야!");
        messages_5.Add("쪼오금씩만 줄여보는게 어떨까아아?");
        messages_5.Add("전기를 조금이라두 아낄 수 있는 방법이래");
        messages_5.Add("대기 오염 배출을 줄일 수 있는 방법이양");
        messages_5.Add("도시나 낮은 평야는 모두 물 속에 잠기게 될꼬야");
        messages_5.Add("부레옥잠은 살아있는 수질 정화장치래!");
        messages_5.Add("그보다 에코백을 사용해 지구를 지켜보쟈!");
        messages_5.Add("대기오염 물질이랑 불빛이 반사되어소 구래");
        messages_5.Add("평화 목적에만 이용한다는 조약이야! 너무 행보케");
        messages_5.Add("물건을 아껴쓰는 습관을 길러보자구우우!");
        messages_5.Add("그리고 난방을 줄이구 실내 온도를 낮추는구야");
        messages_5.Add("외출 시에는 반드시 소등했눈지 확인은 필수라구");
        messages_5.Add("부채나 선풍기가 있는데 마리양! 나 좀 슬포..");
        messages_5.Add("컴퓨터 안 쓸 때눈 전원 끄는 습관을 가지자");
        messages_5.Add("샤워기를 사용하눈게 더 좋대! 꼭 기억하깅!");
        messages_5.Add("수도꼭지를 꼭 꼭 잠가주자! 수도꼭지가 울자낭..");
        messages_5.Add("세탁, 청소용으루 재사용하는 방법은 알구있나아?");
        messages_5.Add("환경 친화적인 상품은 지구에게 더 좋겠지?");
        messages_5.Add("이왕 사는고 환경 마크 상품을 이용하자");
        messages_5.Add("휴지에 대한 나의 작은 매너라까?");
        messages_5.Add("왠지 만년필을 사용하는 사람은 멋진듯 크크.. ");
        messages_5.Add("소음 공해를 막을 수 있눈 저은 방법이지 후후");
        messages_5.Add("친환경 가스나 퇴비로 재활용할 수 이써");
        messages_5.Add("나무 24그루, 물 86톤이 필요하다닝 말도안댕!");
        messages_5.Add("흙을 깨끗하게 만들어소 생활에 도움을 준대애");
        messages_5.Add("필요한 물건을 만드눈 공장의 매연 때무니에여");
        messages_5.Add("근데 걸리는 시간은 450년이나 걸린다구 해여");
        messages_5.Add("꼭 꼭 마스크를 착용해여! 이거 진짜 약속이야!");
        messages_5.Add("토양 속 물도 오염되니까 폐건전지 수거함에 버령");
        messages_5.Add("근데 이걸 어디에다 버리냐구? 일반쓰레기야!");
        messages_5.Add("노노 아니징 바로! 일반쓰레기에 넣어야지 헤헤헤");
        messages_5.Add("붕붕 뜨는 기분이야! 기분 탓이겠지?");
        messages_5.Add("근데 왠지 모르게 기분은 조타 크크...");
        messages_5.Add("매일 밤 자기 전에 생각하게 돼..");
        messages_5.Add("언제나 배부른 상태를 유지해줬으면 좋겠어.");
        messages_5.Add("나와 같이 통화하장~~ 나 정말 심심해");
        messages_5.Add("가장 이뿐 포즈를 취해주기 약속!");
        messages_5.Add("그거 배달의 만족에서 사와주면 안댕?");
        messages_5.Add("어라 근데 추억이 미니게임 처럼 되어있짜나?");

        //--여섯번째, 작별인사--

        messages_6.Add("구럼 잘가!");
        messages_6.Add("빠잉");
        messages_6.Add("좋은 하루 보냉!");
        messages_6.Add("나중에 다시 와줘!");
        messages_6.Add("또 얘기 들으러 와줄거지?");
        messages_6.Add("내 얘기 들어줘서 고마워");
        messages_6.Add("그럼 환경을 지키러 가볼까?");
        messages_6.Add("펭찌 얘기를 들어줘서 고마오");
        messages_6.Add("작은 실천이 지구를 지켜!");
        messages_6.Add("빠빠ㅣ");
        messages_6.Add("다음에 다시 왕");
        messages_6.Add("크크");
        messages_6.Add("안뇽");
        messages_6.Add("조심히 강");
        messages_6.Add("그럼 난 이만~");
        messages_6.Add("환경 보호를 실천하자!");
        messages_6.Add("흐아 펭찌는 이만 갈겡");
        messages_6.Add("그럼 빠빠잉~");
        messages_6.Add("구럼 빠빠잉~");
        messages_6.Add("그럼 빠빠잉~");
        messages_6.Add("구럼 빠빠잉~");

        //20
    }

    void Chatting1() //잡담
    {
        RandomNum = Random.Range(0, 49);
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

        RandomNum1 = Random.Range(0, 10);

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

        RandomNum2 = Random.Range(0, 45);

        chat3.text = string.Format(messages_3[RandomNum2]);

        _chat3.SetActive(true);

       // Debug.Log(RandomNum2);

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

        RandomNum3 = Random.Range(0, 10);

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


        chat5.text = string.Format(messages_5[RandomNum2]);

        _chat5.SetActive(true);

        Invoke("Chatting6", 1);
    }

    void Chatting6() //환경상식 대답
    {

        RandomNum5 = Random.Range(0, 20);

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


}