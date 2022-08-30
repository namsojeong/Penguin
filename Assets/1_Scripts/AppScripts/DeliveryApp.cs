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
    
    [SerializeField, Header("�޴� �̸�")]
    Text menuName;
    [SerializeField, Header("�޴� ����")]
    Text menuPrice;

    EventParam eventParam = new EventParam();
    string choiceFood="";

    public void ClickOnBuy(string food)
    {
        choiceFood = food;
        if(food == "SHRIMP")
        {
            UpdateMenuUI(FoodE.SHRIMP);
        }
        else if(food == "SQUID")
        {
            UpdateMenuUI(FoodE.SQUID);
        }
        else if(food == "FISH")
        {
            UpdateMenuUI(FoodE.FISH);
        }

    }

    public void YesBuy()
    {
        eventParam.stringParam = choiceFood;
        EventManager.TriggerEvent("BUYFOOD", eventParam);
    }

    void UpdateMenuUI(FoodE food)
    {
        menuImage.sprite = foodImage[(int)food-1];
        menuPrice.text = string.Format($"{(int)food * 100}");
        if(food == FoodE.SHRIMP)
        {
            menuName.text = string.Format("����");
        }
        if(food == FoodE.SQUID)
        {
            menuName.text = string.Format("��¡��");

        }
        if(food == FoodE.FISH)
        {
            menuName.text = string.Format("����");
        }
    }
}
