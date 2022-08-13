using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // 능력
    public int art;
    public int pe;
    public int study;
    public int charm;

    // 영양소
    public float hungry = 100;
    public float fun = 100;
    public float clean = 100;
    public float sleep = 100;
    public int shrimpCount = 0;
    public int squidCount = 0;
    public int fishCount = 0;

    public int coin = 0;

    public int day = 1;
    public int lastDay = 25;

    bool isFirst = true;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;

        if(isFirst)
        {
            ResetVal();
            isFirst = false;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void UpAbility(AbilityE ability, int v)
    {
        switch(ability)
        {
            case AbilityE.ART:
                art += v;
                break;
            case AbilityE.PE:
                pe += v;
                break;
            case AbilityE.STUDY:
                study += v;
                break;
            case AbilityE.CHARM:
                charm += v;
                break;
        }

    }

    public void NextDay()
    {
        day++;
        sleep = 100;
        if(day>lastDay)
        {
            EndingSelect();
        }
    }

    private void EndingSelect()
    {
        // 수치 계산
        AbilityE ab = AbilityE.PE;
        GoEnding(ab);
    }
    private void GoEnding(AbilityE ability)
    {
        ResetVal();
        SceneM.instance.ChangeScene("End"+ability);
    }

    public void ResetVal()
    {
        hungry = 100;
        fun = 100;
        clean = 100;
        sleep = 100;

        art = 0;
        pe = 0;
        study = 0;
        charm = 0;

        shrimpCount = 0;
        squidCount = 0;
        fishCount = 0;

        coin = 0;
        day = 1;
    }

}
