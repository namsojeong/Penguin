
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class MessageTest1 : MonoBehaviour

{

    public Text chat1;

    public Text chat2;

    public Text chat3;

    public Text chat4;

    List<string> messages = new List<string>();

    private int RandomNum, RandomNum1, RandomNum2, RandomNum3, RandomNum4;


    private void OnEnable()
    {
        Chatting1();
    }
    void Awake()

    {

        messages.Add( "1");
        messages.Add("2");
        messages.Add("3");
        messages.Add("4���� ������ ��鿡 ��� �־ �Ծ����! �� ����� �Ϲݾ������ ����?");
        messages.Add("5ĵũ���� ç���� �غþ�? ĵ�� �߷� ��°ž�!! �ʵ� �غ� ��վ�");
        messages.Add("6������ ��δ� ����");
        messages.Add("��7��ġ�� ���� ���ؿ� ������ �ϳ� �� ���ܳ�!! �ʹ� ����!!");
        messages.Add("�װ� 8�˾�? ����ŷ�� �θ���� ����̷�..!");
        messages.Add("����9 ������ ��鿡 ��� �־ �Ծ����! �� ����� �Ϲݾ������ ����?");
        messages.Add("ĵũ���� ç���� �غþ�? ĵ�� �߷� ��°ž�!! �ʵ� �غ� ��վ�");

       
    }


    void Chatting1()
    {
      //  RandomNum = Random.Range(0, 11);

        chat1.text = string.Format(messages[RandomNum]);
     // messages.RemoveAt(RandomNum);
        Chatting2();
    }

    void Chatting2()
    {

        RandomNum1 = Random.Range(0, 11);

        chat2.text = string.Format(messages[RandomNum1]);
       // messages.RemoveAt(RandomNum1);
        Chatting3();
    }

    void Chatting3()
    {

        RandomNum2 = Random.Range(0, 11);

        chat3.text = string.Format(messages[RandomNum2]);
       // messages.RemoveAt(RandomNum2);
     //   Chatting4();
    }

    void Chatting4()
    {

        RandomNum3 = Random.Range(0, 11);

        chat4.text = string.Format(messages[RandomNum3]);
       // messages.RemoveAt(RandomNum3);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Chatting4();
            Debug.Log("�Ȱ�");
        }
    }
}


