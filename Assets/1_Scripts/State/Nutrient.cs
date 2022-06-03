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
    
    [SerializeField, Header("Sleep lamp On/Off")]
    private GameObject lampOffImage;

    [SerializeField, Header("미니게임 시 줄어들 영양소 양")]
    private int gameMinusNut;

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

    // 영양소 업데이트
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

    void StedMinus()
    {
        ChangeNut(NutrientE.HUNGRY, -0.1f);
        if(GameManager.instance.isLamp)
        {
            ChangeNut(NutrientE.SLEEP, -0.1f);
        }
        else
        {
            ChangeNut(NutrientE.SLEEP, 0.1f);
        }
    }

    public void GoGameMinusNut()
    {
        ChangeNut(NutrientE.HUNGRY, -10f);
        ChangeNut(NutrientE.FUN, +10f);
        ChangeNut(NutrientE.CLEAN, -7f);
        ChangeNut(NutrientE.SLEEP, -5f);
    }


    // 영양소 증가
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
        }
    }

    private void Feed(EventParam eventParam)
    {
        ChangeNut(eventParam.nutParam, eventParam.intParam);
    }

    private void LampOff()
    {
        GameManager.instance.isLamp = !GameManager.instance.isLamp;
        LampChangeImage();
    }

    public void LampChangeImage()
    {
        lampOffImage.SetActive(!GameManager.instance.isLamp);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("FEED", Feed);
    }
}
