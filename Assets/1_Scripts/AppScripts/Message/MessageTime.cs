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
    RectTransform messagePopup;

    [SerializeField, Header("알림 이동위치")]
    Vector2 nextpos;
    Vector2 defPos;

    private void Start()
    {
        EventManager.StartListening("MessageUp", MessagePopUp);
    }
    private void OnDestroy()
    {
        
        EventManager.StopListening("MessageUp", MessagePopUp);
    }

    void MessagePopUp(EventParam eventParam)
    {
        defPos = messagePopup.anchoredPosition;
        messagePopup.anchoredPosition = nextpos;
        Invoke("PopupOff", 1.5f);
    }

    void PopupOff()
    {
        messagePopup.anchoredPosition = defPos;
    }

    //[SerializeField]
    //private Text transmissiontime;



    //public int countdownMinutes = 1;
    //public float countdownSeconds;
    //[SerializeField]
    //private Text remainingtime;

    private void OnEnable()
    {
       // countdownSeconds = 60;
        GetTime();
    }

    public void Update()
    {
        

     //   countdownSeconds -= Time.deltaTime;



     //   var span = new TimeSpan(0, 0, (int)countdownSeconds);

      //  if (countdownSeconds > 0)
      //      remainingtime.text = span.ToString(@"mm\:ss") + ("\n이후에 다시 와줘!");

    }

    
    //public void AddRemainingtime()
    //{
    //    countdownMinutes = 1;
    //}

    //public void Remainingtime_True()
    //{
    //    remainingtime.color = new Color(remainingtime.color.r, remainingtime.color.g, remainingtime.color.b, 1);

    //}

    //public void Remainingtime_False()
    //{


    //    remainingtime.color = new Color(remainingtime.color.r, remainingtime.color.g, remainingtime.color.b, 0);

     
    //}

    //private void Start()
    //{
        
    //    countdownSeconds = countdownMinutes * 60;
    //}

    // 시간 나타내기
    private void GetTime()
    {
        dateText.text = string.Format(DateTime.Now.ToString("M"));


    }
    
}
