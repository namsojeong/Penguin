using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryApp : MonoBehaviour
{
    [SerializeField, Header("�޴� �̹���")]
    Image menuImage;
    
    [SerializeField, Header("���� �̹���")]
    Sprite[] foodImage;
    [SerializeField, Header("����")]
    Text coinText;
    [SerializeField, Header("���")]
    GameObject expensive;
    
    [SerializeField, Header("�޴� �̸�")]
    Text menuName;
    [SerializeField, Header("�޴� ����")]
    Text menuPrice;
    
    [SerializeField, Header("��� �˸�")]
    RectTransform popup;
    [SerializeField, Header("��� �˸�")]
    Text popupText;
    [SerializeField, Header("�˸� �̵���ġ")]
    Vector2 nextpos;
    Vector2 defPos;

    EventParam eventParam = new EventParam();
    string choiceFood="";
    FoodE callFood;

    List<string> menuNames = new List<string>();

    private void Awake()
    {
        menuNames.Clear();
        menuNames.Add("����");
        menuNames.Add("��¡��");
        menuNames.Add("�����");
    }

    private void OnEnable()
    {
        coinText.text = string.Format($"COIN : {GameManager.Instance.CurrentUser.coin}");
    }
    public void ClickOnBuy(string food)
    {
        choiceFood = food;
        if(food == "SHRIMP")
        {
            callFood = FoodE.SHRIMP;
        }
        else if(food == "SQUID")
        {
            callFood = FoodE.SQUID;
        }
        else if(food == "FISH")
        {
            callFood = FoodE.FISH;
        }

        UpdateMenuUI();
    }

    public void YesBuy()
    {
        if(GameManager.Instance.CurrentUser.coin < (int)callFood * 100)
        {
            expensive.SetActive(true);
            Invoke("ExpensiveOff", 2f);
        }
        else
        {
            eventParam.stringParam = choiceFood;
            GameManager.Instance.PlusCoin(-((int)callFood * 100));
            EventManager.TriggerEvent("BUYFOOD", eventParam);
            defPos = popup.anchoredPosition;
            popupText.text = string.Format($"�ֹ��Ͻ� {menuNames[(int)callFood - 1]}�� 1�� �� ���� �����Դϴ�.");
            popup.anchoredPosition = nextpos;
            Invoke("PopupOff", 1.5f);
        }
    }

    void PopupOff()
    {
        popup.anchoredPosition = defPos;
    }
    void ExpensiveOff()
    {
        expensive.SetActive(false);
    }

    void UpdateMenuUI()
    {
        menuImage.sprite = foodImage[(int)callFood-1];
        menuPrice.text = string.Format($"{(int)callFood * 100}");
        if(callFood == FoodE.SHRIMP)
        {
            menuName.text = string.Format("����");
        }
        if(callFood == FoodE.SQUID)
        {
            menuName.text = string.Format("��¡��");

        }
        if(callFood == FoodE.FISH)
        {
            menuName.text = string.Format("����");
        }
    }
}
