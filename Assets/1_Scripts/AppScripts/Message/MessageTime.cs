using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MessageTime : MonoBehaviour
{
    [SerializeField]
    private Text dateText;

    [SerializeField]
    private Text transmissiontime;

    

    public int countdownMinutes = 1;
    public float countdownSeconds;
    [SerializeField]
    private Text remainingtime;

    public void Update()
    {
        //GetTime();


        //countdownSeconds -= Time.deltaTime;

        //var span = new TimeSpan(0, 0, (int)countdownSeconds);

        //if (countdownSeconds > 0)
        //    remainingtime.text = span.ToString(@"mm\:ss") + ("\n이후에 다시 와줘!");

        //if (countdownSeconds < 0)
        //    GameObject.Find("MessageScript").GetComponent<MessageTest>().reNextButton_first();
    }

    public void AddRemainingtime()
    {
        countdownMinutes = 1;
    }

    public void Remainingtime_True()
    {
        remainingtime.color = new Color(remainingtime.color.r, remainingtime.color.g, remainingtime.color.b, 1);

    }

    public void Remainingtime_False()
    {


        remainingtime.color = new Color(remainingtime.color.r, remainingtime.color.g, remainingtime.color.b, 0);

       // Debug.Log("투명");
    }

    private void Start()
    {
        time();

        countdownSeconds = countdownMinutes * 60;
    }

    // 시간 나타내기
    private void GetTime()
    {
        dateText.text = string.Format(DateTime.Now.ToString("M"));


    }
        void time()
    {
        transmissiontime.text = DateTime.Now.ToString("t");
    }



}
