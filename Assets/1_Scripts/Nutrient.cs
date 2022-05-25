using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nutrient : MonoBehaviour
{
    [SerializeField, Header("영양소")]
    private Image[] nutrientBars;

    [SerializeField, Header("미니게임 시 줄어들 영양소 양")]
    private int gameMinusNut;

    private float hungry = 100;
    private float fun = 100;
    private float clean = 100;
    private float sleep = 100;

    float maxN = 100;

    private void Awake()
    {
        GetNut();
    }
    void Start()
    {
        InvokeRepeating("StedMinus", 1f, 1f);
    }

    void Update()
    {
        UpdateNutrient();
    }

    private void OnApplicationQuit()
    {
        Debug.Log("QUIT");
        SetNut();
    }
    private void OnApplicationPause(bool pause)
    {
        SetNut();
    }

    void SetNut()
    {
        PlayerPrefs.SetFloat("HUNGRY", hungry);
        PlayerPrefs.SetFloat("FUN", fun);
        PlayerPrefs.SetFloat("CLEAN", clean);
        PlayerPrefs.SetFloat("SLEEP", sleep);
    }
    private void GetNut()
    {
        hungry = PlayerPrefs.GetFloat("HUNGRY", 100);
        fun = PlayerPrefs.GetFloat("FUN", 100);
        clean = PlayerPrefs.GetFloat("CLEAN", 100);
        sleep = PlayerPrefs.GetFloat("SLEEP", 100);
    }

    // 영양소 업데이트
    void UpdateNutrient()
    {
        nutrientBars[(int)NutrientE.HUNGRY].fillAmount = hungry / maxN;
        nutrientBars[(int)NutrientE.FUN].fillAmount = fun / maxN;
        nutrientBars[(int)NutrientE.CLEAN].fillAmount = clean / maxN;
        nutrientBars[(int)NutrientE.SLEEP].fillAmount = sleep / maxN;
    }

    void StedMinus()
    {
        ChangeNut(NutrientE.HUNGRY, -0.1f);
        ChangeNut(NutrientE.SLEEP, -0.1f);
    }

    public void GoGameMinusNut()
    {
        ChangeNut(NutrientE.HUNGRY, -10f);
        ChangeNut(NutrientE.FUN, +10f);
        ChangeNut(NutrientE.CLEAN, -7f);
        ChangeNut(NutrientE.SLEEP, -5f);
        SetNut();
    }

    // 영양소 증가
    private void ChangeNut(NutrientE n, float v)
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
