using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nutrient : MonoBehaviour
{
    [SerializeField, Header("영양소")]
    private Image[] nutrientBars;
    
    [SerializeField, Header("영양소2")]
    private Image[] _nutrientBars;
    
    EventParam eventParam = new EventParam();

    float maxN = 100;

    void Start()
    {
        EventManager.StartListening("FEED", Feed);
        InvokeRepeating("StedMinus", 1f, 1f);
    }

    void Update()
    {
        UpdateNutrient();
    }

    // 영양소 UI 업데이트
    void UpdateNutrient()
    {
        nutrientBars[(int)NutrientE.HUNGRY].fillAmount = GameManager.instance.hungry / maxN;
        nutrientBars[(int)NutrientE.FUN].fillAmount = GameManager.instance.fun / maxN;
        nutrientBars[(int)NutrientE.CLEAN].fillAmount = GameManager.instance.clean / maxN;
        nutrientBars[(int)NutrientE.SLEEP].fillAmount = GameManager.instance.sleep / maxN;
        
        _nutrientBars[(int)NutrientE.HUNGRY].fillAmount = GameManager.instance.hungry / maxN;
        _nutrientBars[(int)NutrientE.FUN].fillAmount = GameManager.instance.fun / maxN;
        _nutrientBars[(int)NutrientE.CLEAN].fillAmount = GameManager.instance.clean / maxN;
        _nutrientBars[(int)NutrientE.SLEEP].fillAmount = GameManager.instance.sleep / maxN;
    }

    // 꾸준히 줄어드는 영양소
    void StedMinus()
    {
        ChangeNut(NutrientE.HUNGRY, -0.1f);
        ChangeNut(NutrientE.SLEEP, -0.1f);
    }

    // 미니게임 시 차감 필수요소
    public void GoGameMinusNut()
    {
        ChangeNut(NutrientE.HUNGRY, -10f);
        ChangeNut(NutrientE.FUN, +10f);
        ChangeNut(NutrientE.CLEAN, -7f);
        ChangeNut(NutrientE.SLEEP, -5f);
    }


    // 영양소 증가감소 함수
    private void ChangeNut(NutrientE n, float v)
    {
        if (n == NutrientE.HUNGRY)
        {
            GameManager.instance.hungry += v;
        }
        else if (n == NutrientE.FUN)
        {
            GameManager.instance.fun += v;
        }
        else if (n == NutrientE.CLEAN)
        {
            GameManager.instance.clean += v;
        }
        else if (n == NutrientE.SLEEP)
        {
            GameManager.instance.sleep += v;
            if(GameManager.instance.sleep < 0)
            {
                GameManager.instance.NextDay();
            }
        }
    }

    // 밥주기
    private void Feed(EventParam eventParam)
    {
        ChangeNut(eventParam.nutParam, eventParam.intParam);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("FEED", Feed);
    }
}
