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
        nutrientBars[(int)NutrientE.HUNGRY].fillAmount = GameManager.instance.CurrentUser.hungry / maxN;
        nutrientBars[(int)NutrientE.FUN].fillAmount = GameManager.instance.CurrentUser.fun / maxN;
        nutrientBars[(int)NutrientE.CLEAN].fillAmount = GameManager.instance.CurrentUser.clean / maxN;
        nutrientBars[(int)NutrientE.SLEEP].fillAmount = GameManager.instance.CurrentUser.sleep / maxN;
        
        _nutrientBars[(int)NutrientE.HUNGRY].fillAmount = GameManager.instance.CurrentUser.hungry / maxN;
        _nutrientBars[(int)NutrientE.FUN].fillAmount = GameManager.instance.CurrentUser.fun / maxN;
        _nutrientBars[(int)NutrientE.CLEAN].fillAmount = GameManager.instance.CurrentUser.clean / maxN;
        _nutrientBars[(int)NutrientE.SLEEP].fillAmount = GameManager.instance.CurrentUser.sleep / maxN;
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
            GameManager.instance.UpNutrient(n, v);
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
