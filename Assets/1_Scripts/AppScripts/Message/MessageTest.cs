
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
        //--ù��°, ���--
        messages_1.Add("��������.. ������ ��δ� ����!!><");
        messages_1.Add("(������) ���ڱ� ���� ���Ǫ�� �Ƴ�? ��");
        messages_1.Add("�� ��¥�� ���ǿ����� �ڶ� �Ÿ��� ��������!");
        messages_1.Add("�� ���? ������ ���� �� �۰� �ƴϾ�?!");
        messages_1.Add("�� �ܼ��� �ٸ� ª�� ������ �ƴ��̶�!");
        messages_1.Add("�̰� ����ε��� �� ������ �ܸ��� ������ ���Ѵ�?!");
        messages_1.Add("����.. ��ο� �����ҵ�.. �÷��� ���ٱ���");
        messages_1.Add("�̵��� ����� ��ġ ũ������ ��ɰ��� ������?");
        messages_1.Add("�� 500m ������ ���� �ٴٿ����� ����� ÷��~");
        messages_1.Add("�������۵�ٴ�ǥ������ �ʹ� ���ҿ�.. ��ƾ�");//10
        messages_1.Add("���ؿ� ���� ���� �������� ���� �ʹ� ��������..");
        messages_1.Add("���� �ȳȳ�~ �� ���� ���ִ� �� �Ծ��!");
        messages_1.Add("�ʰ� �� ���� �������� ���� �νŰű�??");
        messages_1.Add("���� �����ؾ���! �ʰ��� ������ ��� ��Ǫ�ϱ�..");
        messages_1.Add("�ȳ�! ���õ��� �� �� �̻Ǻ��̳� ����");
        messages_1.Add("���� ���Կ��� �� �� �̵��� �󸶳� ������?");
        messages_1.Add("�� �ĸ� ���ξ�! ��!! �� �����Ұ� ������,, ũũ");
        messages_1.Add("���� ���� �ð��� �Ʊ��.. �� ���� ��Ÿ�ϱ��~~");
        messages_1.Add("�տ� �� ���̰ſ� �� �� �������� ������' ũũ ");
        messages_1.Add("�Ȥ���~ ���� ������ ������? �������� ���N����");//20
        messages_1.Add("�� ���� �� �� �پ��? ũũ �β�����");
        messages_1.Add("���! ��ħ �ʿ��� �� ���� �̽�µ� ũũ");
        messages_1.Add("�հ� �Ϸ� �Ϸ� �����ϰ� �̵��� ������ �巯");
        messages_1.Add("����� ���� �������ΰ� �˰� ����..? ���� ��Ǫ��");
        messages_1.Add("���� ù����� �����ı�..? �ٷ� ������!!");
        messages_1.Add("��? ���� Ű�� ¥�����δٱ�? ���� 60cm��!");
        messages_1.Add("ȯ�� � �Բ�����! ������ �� ������������!");
        messages_1.Add("���� �����ϴ� ������ �ձ�����~ �ձ۵ձ�~ ");
        messages_1.Add("4�� 25���� �ٷο� ���� ����� ���̾�!");
        messages_1.Add("������ ���� ��Ȱ�ϴ� �Ϳ� �������� ������");//30
        messages_1.Add("���Ͽ��� ��� �ִ� �ȸ�..�ƺ���..�� �� ��Ǳ�?");
        messages_1.Add("���ؿ��� �ٴ� �� ����¥ ���� ����� ���½�");
        messages_1.Add("����� Ŀ�� �밨�� ����� �Ǳ�����!");
        messages_1.Add("��� �� �����ϴ� ������ 412������! ������ ���");
        messages_1.Add("���� �̾߱⸦ �巯���ַ� �Ա���! �빫 ������");
        messages_1.Add("��𰡵��� �ͽ�! ��������ٱ�..! ����");
        messages_1.Add("�� �����ϰ� �̽�´� ��ħ �Գ׿�?");
        messages_1.Add("���! �׻� ��ٸ��� �̽�����");
        messages_1.Add("���ִ� �� �Դ°� ������ �ຸ��");
        messages_1.Add("�ȳ�ȳվȳ�~ ��;ƾƾƾ� ũũ");//40

        //--�ι���, ��㿡 ���� ���--
        messages_2.Add("�׷�?");
        messages_2.Add("�׷�����");
        messages_2.Add("...?");
        messages_2.Add("����!");
        messages_2.Add("��~");
        messages_2.Add("����? �׷���");
        messages_2.Add("���");
        messages_2.Add("�ݰ���!");
        messages_2.Add("��?");
        messages_2.Add("��!");
        messages_2.Add("����");

        //--����°, ȯ�� ��� ����--
       
        messages_3.Add("Ŀ�� �� �ܿ� ������ ������? �����ϰ� ����� ����");
        messages_3.Add("���~�� ������� ���ľ����⸦ ���ݸ� �ٿ���");
        messages_3.Add("��ȸ��ǰ�� ���� ���� ����߰Խ�!");
        messages_3.Add("���Ĺ� �����⸦ �����ϴ� �͵� �߿���");
        messages_3.Add("�ǳ� �µ��� �����ϰ� �����غ��� �� ���?");
        messages_3.Add("Ƽ�� ���� �� ��ġ�� �ʹ� ���� ���°�..");
        messages_3.Add("������� �ʴ� ������ ��� ��� ��������!");
        messages_3.Add("����� ���� �� ������ ������ �ƾ��Ѵ��");
        messages_3.Add("���������� ���� ��ư ������ �� ���̴� �Ŷ�");
        messages_3.Add("���߱����� ����ϴ� �͵� ������..!");
        messages_3.Add("���� ������ ������ ����� ��� �����ٸ�?");
        messages_3.Add("����� �η������� ������ �� �� ��������!");
        messages_3.Add("���� ��Һ����� ���� ������� �Ƴ�?");
        messages_3.Add("���� ���� ���� �������Ƴ�..?");
        messages_3.Add("���� ���൵ �̵�? ������ ȯ���� ��ȣ�ϱ� ����");
        messages_3.Add("���� �� �� �� ������ �׳� �����°� �ƴϰ���?");
        messages_3.Add("�ܿ￡�� ���� �β��� �԰� �ٴϴ°� ���� �ʾ���?");
        messages_3.Add("Ȥ�� ���� �� ���ϴٱ� ���� ��������!");
        messages_3.Add("�ٵ� �������� �� �̷��� ���� ���°���?");
        messages_3.Add("��ǻ�͸� ���� �ʴ°� �ƴϰ���?");
        messages_3.Add("����� �� ������ ����ϴ� �� ���ٴ�");
        messages_3.Add("�ǵ�ǵ�! ��ĥ �� ���� �����߾�");
        messages_3.Add("����� ���� �������� ���� ���� ��! �Ʊ��� �Ƴ�?");
        messages_3.Add("�׳� �ƹ� �ų� �� ��� �� ���ٴ�");
        messages_3.Add("��? Ȥ�� ȯ�渶ũ��� �� �˾�? ��? ��??");
        messages_3.Add("����� �ǳ� �ָӴϿ� �ռ����� ������ �ٴ��� ��.");
        messages_3.Add("�������� ����غ��� �� ���ƾ�?");
        messages_3.Add("�ڵ��� ���� ����, ��� ������ ���̴°Ŵ�");
        messages_3.Add("���Ĺ� ������ �ӿ� �ִ� �̻����� �̿��ؼ�");
        messages_3.Add("�޷��޷�~ ���ο� ���� 1���� ����� ���ؼ���"); //30
        messages_3.Add("�� �ӿ� ��� �����̰��� ���� �����帮");
        messages_3.Add("���� ������ ���� ū ������ �ڵ����� ��Ⱑ����");
        messages_3.Add("������ ���� ������ ���ӿ��� ���ظ� ���Ѿ���!");
        messages_3.Add("�̼������� ���� ��, ������ �ؾ� �� ��쿡��");
        messages_3.Add("�������� �Ϲݾ������ ������ ����� ������Ű��");
        messages_3.Add("ġīġī�ϴ� ĩ���� �ֱ������� ��ü�������");
        messages_3.Add("�ö�ƽ ����� ��Ȱ���� �����ұ�ƾ�?"); //37
        messages_3.Add("Ȩȭ�鿡�� �� ������� �� ���� ���ڴ��");
        messages_3.Add("Ȩȭ�鿡�� �� ��ġ�ϸ� �������ٰ�");
        messages_3.Add("25���� �Ǹ� �� ��� ��� ������?");
        messages_3.Add("�� ������� ���� ������..!!");
        messages_3.Add("��ȭ�� �ϸ� �� ��Ҹ��� ���� �� �־�");
        messages_3.Add("ī�޶�� �츮�� �߾��� �����غ���~!");
        messages_3.Add("������ ���� �Ծ��!!");
        messages_3.Add("���������� � �߾��� ������ ������?");


        //--�׹�°, ȯ�� ��Ŀ� ���� ���--
        messages_4.Add("��!");
        messages_4.Add("��");
        messages_4.Add("����");
        messages_4.Add("��~!");
        messages_4.Add("����!");
        messages_4.Add("��~");

        //--�ټ���°, ȯ�� ��� ���� ���� (ȯ���� ���� �������� �Ȱ��� �� ��!)--
        messages_5.Add("���� ������ �� 19���� �ʿ��ϴ�!");
        messages_5.Add("���Ĺ� ó����� 1,700����̳��� ������ �ȴٱ�!");
        messages_5.Add("ȯ���� ���� ���̳����� �������̶�!");
        messages_5.Add("�˸��� �縸 ����ϱ� �����ϸ� ���� ������ �� �̽�");
        messages_5.Add("��� ���� ������ �ʾ ���� �߻��ϰ� �̽�");
        messages_5.Add("���Ⱑ �빫 ���� ����! �� ������ �� ����!");
        messages_5.Add("�׷� ������ ��߹�� ���� �� �̶԰ž�!");
        messages_5.Add("�ɿ��ݾ��� �ٿ����°� ���ƾ�?");
        messages_5.Add("���⸦ �����̶�� �Ƴ� �� �ִ� ����̷�");
        messages_5.Add("��� ���� ������ ���� �� �ִ� ����̾�");
        messages_5.Add("���ó� ���� ��ߴ� ��� �� �ӿ� ���� �ɲ���");
        messages_5.Add("�η������� ����ִ� ���� ��ȭ��ġ��!");
        messages_5.Add("�׺��� ���ڹ��� ����� ������ ���Ѻ���!");
        messages_5.Add("������ �����̶� �Һ��� �ݻ�Ǿ�� ����");
        messages_5.Add("��ȭ �������� �̿��Ѵٴ� �����̾�! �ʹ� �ຸ��");
        messages_5.Add("������ �Ʋ����� ������ �淯���ڱ����!");
        messages_5.Add("�׸��� ������ ���̰� �ǳ� �µ��� ���߾������");
        messages_5.Add("���� �ÿ��� �ݵ�� �ҵ��ߴ��� Ȯ���� �ʼ���");
        messages_5.Add("��ä�� ��ǳ�Ⱑ �ִµ� ������! �� �� ����..");
        messages_5.Add("��ǻ�� �� �� ���� ���� ���� ������ ������");
        messages_5.Add("�����⸦ ����ϴ��� �� ����! �� ����ϱ�!");
        messages_5.Add("���������� �� �� �ᰡ����! ���������� ���ڳ�..");
        messages_5.Add("��Ź�̳� û�ҿ����� �����ϴ� ����� �˱��ֳ���?");
        messages_5.Add("ȯ�� ģȭ���� ��ǰ�� �����ϴ°� �������� �� ������?");
        messages_5.Add("�̿� ��°� ȯ�� ��ũ�� �پ��ִ� ��ǰ�� �̿�����");
        messages_5.Add("������ ���� ���� ���� �ųʶ��?");
        messages_5.Add("���� �������� ����ϴ� ����� ������ ũũ.. ���ϴ� �� �ƴϱ�");
        messages_5.Add("���� ���ظ� ���� �� �ִ� ���� ������� ����");
        messages_5.Add("ģȯ�� ������ ��� ����� �� ��Ȱ���� �� �̽�");
        messages_5.Add("���� 24�׷�, �� 86���� �Ƿ��ϴٴ� ���� �� ������!");
        messages_5.Add("���� �����ϰ� ������ �츮 ��Ȱ�� ������ �ְ� �̶���.");
        messages_5.Add("�츮���� �ʿ��� ������ ���δ� ������ �ſ� �����Ͽ���");
        messages_5.Add("�ٵ� �ɸ��� �ð��� ���� 450���̳� �ɸ��ٱ� �ؿ�");
        messages_5.Add("�� �� ����ũ�� �����ؿ�! �̰� ��¥ ����̾�!");
        messages_5.Add("��� �� ���� �������ѿ� �׷��ϱ� ������� �����Կ� ������");
        messages_5.Add("�ٵ� �̰� ��𿡴� �����ı�? �Ϲݾ������!");
        messages_5.Add("��� �ƴ�¡ �ٷ�! �Ϲݾ����⿡ �־���� ������");

        messages_5.Add("Ȩȭ�鿡�� �� ������� �� ���� ���ڴ��");
        messages_5.Add("�ٵ� ���� �𸣰� ����� ��Ÿ ũũ...");
        messages_5.Add("���� �� �ڱ� ���� �����ϰ� ��..");
        messages_5.Add("������ ��θ� ���¸� ������������ ���ھ�.");
        messages_5.Add("���� ���� ��ȭ����~~");
        messages_5.Add("���� �̻� ��� �����ֱ� ���!");
        messages_5.Add("����� �������� ����ָ� �ȴ�?");
        messages_5.Add("�߾��� �̴ϰ��� ó�� �Ǿ���¥��?");

        //--������°, �ۺ��λ�--

        messages_6.Add("�׷� �߰�!");
        messages_6.Add("����");
        messages_6.Add("���� �Ϸ� ����!");
        messages_6.Add("���߿� �ٽ� ����!");
        messages_6.Add("�� ��� ������ ���ٰ���?");
        messages_6.Add("�� ��� ����༭ ������");
        messages_6.Add("�׷� ȯ���� ��Ű�� ������?");
        messages_6.Add("���� ��⸦ ����༭ ������");
        messages_6.Add("���� ��õ�� ������ ����!");

        messages_6.Add("����");
        messages_6.Add("������ �ٽ� ��");
        messages_6.Add("ũũ");
        messages_6.Add("�ȴ�");
        messages_6.Add("������ ��");
        messages_6.Add("�׷� �� �̸�~");
        messages_6.Add("ȯ�� ��ȣ�� ��õ����!");
        messages_6.Add("��� ����� �̸� ����");
        messages_6.Add("�׷� ������~");
        messages_6.Add("���� ������~");
        messages_6.Add("�׷� ������~");
        messages_6.Add("���� ������~");
    }

    void Chatting1() //���
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

    void Chatting2() //�����
    {
       
        RandomNum1 = Random.Range(0, 2);

        chat2.text = string.Format(messages_2[RandomNum1]);
      
        _chat2.SetActive(true);

        set2.GetComponent<MessageTime>().enabled = true;

        Invoke("Chatting3", 1);

        //TimeImg.SetActive(true);
    }

    void Chatting3() //ȯ����
    {
        RandomNum1 = Random.Range(0, 40);
        chat1.text = string.Format(messages_1[RandomNum1]);

        RandomNum2 = Random.Range(0, 10);
        chat2.text = string.Format(messages_2[RandomNum2]);

        RandomNum3 = Random.Range(0, 44);
        chat3.text = string.Format(messages_3[RandomNum3]);

        RandomNum4 = Random.Range(0, 5);
        chat4.text = string.Format(messages_4[RandomNum4]);

        chat5.text = string.Format(messages_5[RandomNum3]);

        RandomNum5 = Random.Range(0, 8);
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


