using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayArbeit : MonoBehaviour
{
    [SerializeField]
    Image arbBar;

    float maxPlaying = 100;
    float curPlaying = 0;
    float barSpeed = 20;

    EventParam ep = new EventParam();

    private void Start()
    {
        EventManager.StartListening("PlayArb", PlayingArb);
    }
    private void OnDestroy()
    {
        EventManager.StopListening("PlayArb", PlayingArb);
    }

    private void Update()
    {
        SliderUpdate();
    }

    // 슬라이더 바 UI 업데이트
    void SliderUpdate()
    {
        arbBar.fillAmount = Mathf.Lerp(arbBar.fillAmount, curPlaying / maxPlaying, Time.deltaTime*barSpeed);
    }

    void PlayingArb(EventParam eventParam)
    {
        // 작업 시작
        ep.abilityParam = eventParam.abilityParam;
        WorkStart();
    }
    void WorkStart()
    {
        ResetBar();
        StartCoroutine(Work());
    }

    IEnumerator Work()
    {
        while (curPlaying <= maxPlaying)
        {
            yield return new WaitForSeconds(1f);
            curPlaying += 10;
        }
        EventManager.TriggerEvent("FinishArb", ep);
    }

    void ResetBar()
    {
        curPlaying = 0;
        arbBar.fillAmount = 0;
    }

    //void SettingTime()
    //{
    //    string lastTime = PlayerPrefs.GetString("SaveLastTime");
    //    DateTime lastDateTime = DateTime.Parse(lastTime);
    //    TimeSpan conpareTime = DateTime.Now - lastDateTime;
    //    int sec = ((int)conpareTime.TotalSeconds)* 10;
    //    int initPlaying = GameManager.instance.arbTime + sec;
    //    eventParam.intParam = 0;
    //    while (initPlaying >= maxPlaying)
    //    {
    //        eventParam.intParam++;
    //        initPlaying -= maxPlaying;
    //    }
    //    EventManager.TriggerEvent("PlusArb", eventParam);
    //    curPlaying = initPlaying;

    //    Debug.Log(curPlaying);
    //}
    //public void QuitBack()
    //{
    //    GameManager.instance.SetArbTime(curPlaying);
    //}
}
