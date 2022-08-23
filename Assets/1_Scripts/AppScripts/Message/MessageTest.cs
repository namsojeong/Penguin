
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
        messages_1.Add("(������) ���ڱ� ���� ���Ǫ�� �Ƴ�? ��");
        messages_1.Add("�� ��¥�� ���ǿ����� �ڶ� �Ÿ��� ��������!");
        messages_1.Add("���� ���� �� �پ���? ������ ���� �� �۰� �ƴϾ�?!");
        messages_1.Add("���� �ܼ��� �߿� ���濡�� �紫 �ٸ� ª�� ������ �ƴ��̶�!");
        messages_1.Add("�̰� �� ��¥ ����ε��� ������ �ܸ��� ������ ���Ѵ�?!");
        messages_1.Add("����� ��ο� ������.. �÷��� ���� ��Ÿ�� �ҹ��� Ʋ�Ȱŵ�?");
        messages_1.Add("�̵��� ����� ��ġ �ٴٷ� ũ������� ����� ��ɰ��� ������?");
        messages_1.Add("���� 500m ������ ���� �ٴٷε� �����ĥ ���� ������ ÷��~");
        messages_1.Add("�������۵�ٴ�ǥ������ ���������� �ʹ� ���ҿ�.. ��ƾ�");//10
        messages_1.Add("���ؿ� ���� ���� ������ ���� �ʹ� ��������..");
        messages_1.Add("�� ���� �� �Ծ���~ �� ���ִ� �� �Ծ��! �ʵ� �׷�����? ũũ");
        messages_1.Add("�ذ� ���� ���� �ν� �ϰ�? �ƴϸ� �� ���� �������� �׷� �ű�?");
        messages_1.Add("����� �𵥳� �����ؾ���! �ʰ��� ������ ��� ��Ǫ�ϱ�..");
        messages_1.Add("�ȳ�! ���õ��� �� �� �̻Ǻ��̳� ����");
        messages_1.Add("���� ���Կ��� �� �� �̵��� �󸶳� ������?");
        messages_1.Add("�� �ĸ� ���ξ�! ��!! �� �����Ұ� ������,, ũũ");
        messages_1.Add("���� ���� �ð��̤� �ʹ� �Ʊ��.. �� ���� ��Ÿ�ϱ��~~");
        messages_1.Add("�տ� �� ���̰ſ� �� �� �������� ������' ũũ ");
        messages_1.Add("�Ȥ���~ ���� ������ ������? �������� ���N����");//20
        messages_1.Add("�� ���� �� �� �پ��? ũũ �β�����");
        messages_1.Add("���! ��ħ �ʿ��� �� ���� �̽�µ� ũũ");
        messages_1.Add("�հ� �Ϸ� �Ϸ� �����ϰ� �̵��� ������ �巯");
        messages_1.Add("����� ���� �������ΰ� �˰� ����..? ���� ��Ǫ��");
        messages_1.Add("���� ù����� �����ı�..? �ٷ� ������!! �� ������ ������");
        messages_1.Add("��? �� Ű�� ¥�����δٱ�? �� Ű�� ���� 60cm��!");
        messages_1.Add("�ʵ� ȯ�� � �Բ�����! �׷� ������ �� ������������!");
        messages_1.Add("���� �����ϴ� ������ �ձ�����~ �ձ۵ձ�~ ");
        messages_1.Add("4�� 25���� ���� ���̰�~ �ٷο� ���� ����� ���̾�! ");
        messages_1.Add("������ ���� ��Ȱ�ϴ� �Ϳ� �������� ������");//30
        messages_1.Add("���Ͽ��� ��� �ִ� �ȸ�..�ƺ���..�� �� ��Ǳ�?");
        messages_1.Add("���ؿ��� �� �� �ٴ� �� ����¥�� �η����� ����� ���½�");
        messages_1.Add("����� Ŀ�� �밨�� ����� �Ǳ�����!");
        messages_1.Add("��� �� �����ϴ� ������ 412������! ������ ���");
        messages_1.Add("���� �̾߱⸦ �巯�þ��ַ� �Ա���! �빫�ʹ��� ����~");
        messages_1.Add("��𰡵��� �ͽ�! �������ٱ�..! ����");
        messages_1.Add("�� �����ϰ� �̽�´� ��ħ �Գ׿�?");
        messages_1.Add("���! �׻� ��ٸ��� �̽�����");
        messages_1.Add("���ִ� �� �Դ°� ������ �ຸ��");
        messages_1.Add("�ȳ�ȳվȳ�~ ��;ƾƾƾ� ũũ");
        messages_1.Add("������ �̼������� ������?");
        

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
        messages_3.Add("����� ���� ���� ���� ������ ������ �ƾ��Ѵ��");
        messages_3.Add("���������� ���� ��ư ������ �� ���̴� �Ŷ�");
        messages_3.Add("���߱����� ����ϴ� �͵� ������..!");
        messages_3.Add("���� ������ ������ ����� ��� �����ٸ�?");
        messages_3.Add("����� �η������� ������ �� �� �������!");
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
        messages_3.Add("���Ĺ� �����⴫ ������ �ӿ� �ִ� ���� �̻����� �̿��ؼ�");
        messages_3.Add("�޷��޷�~ ���ο� ���� 1���� ����� ���ؼ���");
        messages_3.Add("�� �ӿ� ��� ������, �����̿� ���� ���� �����帮");
        messages_3.Add("���� ������ ���� ū ������ �ڵ����� ��Ⱑ����");
        messages_3.Add("�츮�� ���˰� �Ա� ������ ���� ������ ���ӿ��� ���ظ� ���Ѿ���!");
        messages_3.Add("�̼������� ���� ��, �ݷ��ݷ� ������ �ؾ� �� ��쿡��");
        messages_3.Add("�������� �Ϲݾ������ ������ ����� ������Ű��");
        messages_3.Add("ġīġī�ϴ� ĩ���� �ֱ������� ��ü�������");
        messages_3.Add("�ö�ƽ ����� ��Ȱ���� �����ұ�ƾ�?");

        //--�׹�°, ȯ�� ��Ŀ� ���� ���--
        messages_4.Add("�׷�?");
        messages_4.Add("�׷�����");
        messages_4.Add("����!");
        messages_4.Add("...?");
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
        messages_5.Add("��� ���� ������ ���� �� �ִ� ����̶�� �� �˱� ����?");
        messages_5.Add("���ó� ���� ��ߴ� ��� �� �ӿ� ��� ������ �ɲ���");
        messages_5.Add("�η������� ����ִ� ���� ��ȭ��ġ���! �ʹ� �ű�����!");
        messages_5.Add("�׺��� ���ڹ��� ����ϸ� ������ ��ų �� �̽�!");
        messages_5.Add("������ �����̶� �ΰ� �Һ��� �������� �ݻ�Ǿ �� ���̴����");
        messages_5.Add("��ȭ �������� �̿��Ѵٴ� �����̾�! �ʹ� �ຸ��");
        messages_5.Add("������ �Ʋ����� ������ �淯���ڱ����!");
        messages_5.Add("�׸��� ������ ���̰� �ǳ� �µ��� ���߿������");
        messages_5.Add("���� �ÿ��� �ݵ�� �ҵ��ߴ��� Ȯ���� �ʼ���");
        messages_5.Add("��ä�� ��ǳ�Ⱑ �ִµ� ������! �� �� ����..");
        messages_5.Add("��ǻ�ʹ� ������� ���� ���� ������ ���� ������ ������");
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
        //--������°, �ۺ��λ�--

        messages_6.Add("�׷� �߰�!");
        messages_6.Add("����");
        messages_6.Add("���� �Ϸ� ����!");
        messages_6.Add("���߿� �ٽ� ����!");
        messages_6.Add("�� �� ��� ������ ���ٰ���?");
        messages_6.Add("�� ��� ����༭ ����");
        messages_6.Add("�׷� ȯ���� ��Ű�� ������?");
        messages_6.Add("����� �� ��⸦ ����༭ �ʹ� ����");
        messages_6.Add("�츮�� ���� ��õ�� ������ ����!");
    }

    void StartChatting()
    {
        startButton.onClick.AddListener(Chatting1);
    }

    void Chatting1() //���
    {
       RandomNum = Random.Range(0, 40);

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

        RandomNum2 = Random.Range(0, 35);

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

        chat5.text = string.Format(messages_5[RandomNum2]);

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


