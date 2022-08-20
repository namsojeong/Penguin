using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    int maxEnding;

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

    public int arbTime = 0;
    public int coin = 0;

    public int day = 1;
    public int lastDay = 25;

    bool isFirst = true;

    public List<AbilityE> arbSprites;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;

        if(isFirst)
        {
            ResetVal();
            isFirst = false;
        }

    }

    public void UpAbility(AbilityE ability, int v)
    {
        switch(ability)
        {
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

    public void UpNutrient(NutrientE nut, float v)
    {
        switch (nut)
        {
            case NutrientE.HUNGRY:
                hungry += v;
                if (hungry <= 0)
                {
                    Debug.Log("배고파서 죽음");
                    Dead();
                }
                break;
            case NutrientE.CLEAN:
                clean += v;
                if (clean <= 0)
                {
                    Debug.Log("더러워서 죽음");
                    Dead();
                }
                break;
            case NutrientE.FUN:
                fun += v;
                if (fun <= 0)
                {
                    Debug.Log("노잼이라 죽음");
                    Dead();
                }
                break;
            case NutrientE.SLEEP:
                sleep += v;
                if (GameManager.instance.sleep < 0)
                {
                    GameManager.instance.NextDay();
                }
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

    private void Dead()
    {
        EndingSelect();
    }

    private void EndingSelect()
    {
        // 수치 계산
        AbilityE ab;
        Debug.Log($"PE : {pe}  STUDY : {study}  CHARM : {charm}");
        if (pe > study)
        {
            if (pe > charm) ab = AbilityE.PE;
            else ab = AbilityE.CHARM;
        }
        else
        {
            if (study > charm) ab = AbilityE.STUDY;
            else ab = AbilityE.CHARM;
        }

        if (ab == AbilityE.CHARM)
        {
            if(charm < maxEnding)  ab = AbilityE.NONE;
        }
        else if(ab == AbilityE.PE)
        {
            if(pe < maxEnding) ab = AbilityE.NONE;
        }
        else if(ab == AbilityE.STUDY)
        {
            if(study < maxEnding) ab = AbilityE.NONE;
        }
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

    public void SetArbTime(int t)
    {
        GameManager.instance.arbTime = t;
    }

    public void SetSpriteArb(List<AbilityE> arbs)
    {
        arbSprites = arbs;
    }

    public void SetLastTime()
    {
        PlayerPrefs.SetString("SaveLastTime", System.DateTime.Now.ToString());
    }
}
