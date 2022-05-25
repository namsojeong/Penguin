using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nutrient : MonoBehaviour
{
    [SerializeField, Header("영양소")]
    private Image[] nutrientBars;

    private float hungry = 100;
    private float fun = 100;
    private float clean = 100;
    private float sleep = 100;

    float maxN = 100;

    private void Awake()
    {
    }

    void Start()
    {
        InvokeRepeating("StedMinus", 1f, 1f);
    }

    void Update()
    {
        UpdateNutrient();
    }

    // 영양소 업데이트
    void UpdateNutrient()
    {
        nutrientBars[(int)NutrientE.HUNGRY].fillAmount = hungry/maxN;
        nutrientBars[(int)NutrientE.FUN].fillAmount = fun/maxN;
        nutrientBars[(int)NutrientE.CLEAN].fillAmount = clean/maxN;
        nutrientBars[(int)NutrientE.SLEEP].fillAmount = sleep/maxN;
    }

    void StedMinus()
    {
        Debug.Log(hungry);
        MinusNut(NutrientE.HUNGRY, 0.1f);
        MinusNut(NutrientE.SLEEP, 0.1f);
    }

    // 영양소 감소
    void MinusNut(NutrientE n, float v)
    {
        if(n==NutrientE.HUNGRY)
        {
            hungry -= v;
        }
        else if(n==NutrientE.FUN)
        {
            fun -= v;
        }
        else if(n==NutrientE.CLEAN)
        {
            clean -= v;
        }
        else if(n==NutrientE.SLEEP)
        {
            sleep -= v;
        }
    }

    // 영양소 증가
    void PlusNut(NutrientE n, int v)
    {
        if (n == NutrientE.HUNGRY)
        {
            hungry += v;
        }
        else if (n == NutrientE.FUN)
        {
            fun += v;
        }
        else if (n == NutrientE.CLEAN)
        {
            clean += v;
        }
        else if (n == NutrientE.SLEEP)
        {
            sleep += v;
        }
    }

}
