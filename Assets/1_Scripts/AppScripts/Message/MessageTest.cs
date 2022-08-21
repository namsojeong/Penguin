
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

        //��ŸƮä�� �ð��� ���缭 �������� �ϱ�
        StartChatting();
    }

    void Awake()
    {
        //--ù��°, ���--
        messages_1.Add("��������.. ������ ��δ� ����!!><");
        messages_1.Add("(������) ���ڱ� �� ������� �Ƴ�? ��");
        messages_1.Add("�� ���ڱ� ���ǿ��� �ڶ� �Ÿ��� �;�����! ");
        messages_1.Add("���� ���� �� �����? Ȥ�� ���� ��??");
        messages_1.Add("�� �ܼ��� �߿� ���濡 ��� �ٸ� ª�� ������ �ƴ϶�!");
        messages_1.Add("�̰� �� ��¥ ����ε��� ������ �ܸ��� ������ ���Ѵ�?!");
        messages_1.Add("�� ��ο� ������ �÷��� ���� �ʴٴ� �ҹ��� �ִµ� �ٺ��� Ʋ�Ⱦ�!");
        messages_1.Add("���� ���� �ٴٷ� ũ������� ����� ��ɰ��� ������?");
        messages_1.Add("���� 500m ������ ���� �ٴٷε� ���ĥ ���� ������");
        messages_1.Add("õ���� �������۵�ٴ�ǥ������ �������� ����� ����������!");
        messages_1.Add("������ ������ ��������..");
        messages_1.Add("�� ���� �� �Ծ���~");
        messages_1.Add("�ذ� ���� ���� �ν� �ǰ�? �ƴϸ� �װ� �� ���� �����༭ �׷� �ɱ�?");
        messages_1.Add("����� ������ �����ؾ���!");
        messages_1.Add("�ȴ�! ���õ��� ���� �� �������̳�");
        messages_1.Add("�������Կ��� �� �� �ִٸ� �󸶳� ������");
        messages_1.Add("�� ���� ���ξ�! �� �������� ����,,");
        messages_1.Add("���� ���� �ð��� �ʹ� �Ʊ��.. �� �� ���ϱ�~~");
        messages_1.Add("�տ� �� ���ſ� �� �� ������ ������' ũũ ");
        messages_1.Add("�ȳ�~ ���� ������ ���? �������� ���ڴ�.");
        messages_1.Add("�� ���� �� �� ���? ũũ �β�����");
        messages_1.Add("ŭŭ �� �� �� ����ֶ�!");
        messages_1.Add("���� �Ϸ��Ϸ� �����ϰ� �ִٴ� ������ ���");
        messages_1.Add("�� ���� �������ΰ� �˰� ����..? ����");
        messages_1.Add("�� ù����� ������");
        messages_1.Add("������ ���ؼ���� ������ �� �� ���� �͸� ����");
        messages_1.Add("���� ������ ���������Ŷ�� �Ͼ�");
        messages_1.Add("������ �ձ�����~ �ձ۵ձ�~");
        messages_1.Add("4�� 25���� ���� ����� ���̾�! ");
        messages_1.Add("������ ���� ��Ȱ�ϴ� ���� �������� ������");
        messages_1.Add("���Ͽ��� ��� �ִ� ����..�ƺ�..�� �� ��Ǳ�?");
        messages_1.Add("���ؿ� �� �� �ٴ�� �����ڰ� �η����� ����� ���� ���߾�");
        messages_1.Add("�밨�� ����� �ǰ�;�!");
        messages_1.Add("���� �� �����ϴ� ������ 412������! ������ ���");

        //--�ι���, ��㿡 ���� ���--
        messages_2.Add("�׷�?");
        messages_2.Add("�׷�����");
        messages_2.Add("����!");
        messages_2.Add("...?");
        messages_2.Add("����!");
        messages_2.Add("��~");
        
        //--����°, ȯ�� ��� ����--
        messages_3.Add("����ġ�� ���� ���ؿ� ������ �ϳ� �� ���ܳ�!! �ʹ� ����!!");
        messages_3.Add("�װ� �˾�? ����ŷ�� �θ���� ����̷�..!");
        messages_3.Add("���� ������ ��鿡 ��� �־ �Ծ����! �� ����� �Ϲݾ������ ����?");
        messages_3.Add("ĵũ���� ç���� �غþ�? ĵ�� �߷� ��°ž�!! �ʵ� �غ� ��վ�");

        //--�׹�°, ȯ�� ��Ŀ� ���� ���--
        messages_4.Add("�׷�?");
        messages_4.Add("�׷�����");
        messages_4.Add("����!");
        messages_4.Add("...?");
        messages_4.Add("����!");
        messages_4.Add("��~");

        //--�ټ���°, ȯ�� ��� ���� �߰� ���� (ȯ���� ���� �������� �Ȱ��� �� ��!)--
        messages_5.Add("����ġ�� ���� ���ؿ� ������ �ϳ� �� ���ܳ�!! �ʹ� ����!!");
        messages_5.Add("�װ� �˾�? ����ŷ�� �θ���� ����̷�..!");
        messages_5.Add("���� ������ ��鿡 ��� �־ �Ծ����! �� ����� �Ϲݾ������ ����?");
        messages_5.Add("ĵũ���� ç���� �غþ�? ĵ�� �߷� ��°ž�!! �ʵ� �غ� ��վ�");

        //--������°, �ۺ��λ�--
        
        messages_6.Add("�׷� �߰�!");
        messages_6.Add("����");
        messages_6.Add("�׷� �߰�!");
        messages_6.Add("����");
    }

    void StartChatting()
    {
        startButton.onClick.AddListener(Chatting1);
    }

    void Chatting1() //���
    {
       RandomNum = Random.Range(0, 2);

        chat1.text = string.Format(messages_1[RandomNum]);

        _chat1.SetActive(true);

        nextButton1.onClick.AddListener(Chatting2);
        
        // Chatting2();
    }

    void Chatting2() //�����
    {

        RandomNum1 = Random.Range(0, 2);

        chat2.text = string.Format(messages_2[RandomNum1]);
        //messages.RemoveAt(RandomNum1);
        // NextButton.onClick.AddListener(Chatting3);

        _chat2.SetActive(true);

        Invoke("Chatting3", 1);
    }

    void Chatting3() //ȯ����
    {

        RandomNum2 = Random.Range(0, 2);

        chat3.text = string.Format(messages_3[RandomNum2]);

        _chat3.SetActive(true);

        nextButton2.onClick.AddListener(Chatting4);

        //Chatting4();
    }

    void Chatting4() //ȯ���� ���
    {

        RandomNum3 = Random.Range(0, 2);

        chat4.text = string.Format(messages_4[RandomNum3]);

        _chat4.SetActive(true);

        Invoke("Chatting5", 1);

    }

    void Chatting5() //ȯ���� ���
    {

        RandomNum4 = Random.Range(0, 2);

        chat5.text = string.Format(messages_5[RandomNum4]);

        _chat5.SetActive(true);
        //NextButton.onClick.AddListener(Chatting6);
        Invoke("Chatting6", 1);
    }

    void Chatting6() //ȯ���� ���
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
            Debug.Log("�Ȱ�");
        }
    }
}


