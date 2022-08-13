using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nutrient : MonoBehaviour
{
    [SerializeField, Header("�����")]
    private Image[] nutrientBars;
    
    [SerializeField, Header("�����2")]
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

    // ����� UI ������Ʈ
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

    // ������ �پ��� �����
    void StedMinus()
    {
        ChangeNut(NutrientE.HUNGRY, -0.1f);
        ChangeNut(NutrientE.SLEEP, -0.1f);
    }

    // �̴ϰ��� �� ���� �ʼ����
    public void GoGameMinusNut()
    {
        ChangeNut(NutrientE.HUNGRY, -10f);
        ChangeNut(NutrientE.FUN, +10f);
        ChangeNut(NutrientE.CLEAN, -7f);
        ChangeNut(NutrientE.SLEEP, -5f);
    }


    // ����� �������� �Լ�
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

    // ���ֱ�
    private void Feed(EventParam eventParam)
    {
        ChangeNut(eventParam.nutParam, eventParam.intParam);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("FEED", Feed);
    }
}
