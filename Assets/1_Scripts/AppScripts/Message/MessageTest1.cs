
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
        messages.Add("4오늘 저녁은 라면에 계란 넣어서 먹어야지! 아 계란은 일반쓰레기야 알지?");
        messages.Add("5캔크러쉬 챌린지 해봤어? 캔을 발로 밟는거야!! 너도 해봐 재밌어");
        messages.Add("6오느른 기부니 좋앙");
        messages.Add("스7위치를 끄면 남극에 얼음이 하나 더 생겨나!! 너무 좋아!!");
        messages.Add("그거 8알아? 마네킹의 부모님이 비닐이래..!");
        messages.Add("오늘9 저녁은 라면에 계란 넣어서 먹어야지! 아 계란은 일반쓰레기야 알지?");
        messages.Add("캔크러쉬 챌린지 해봤어? 캔을 발로 밟는거야!! 너도 해봐 재밌어");

       
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
            Debug.Log("된거");
        }
    }
}


