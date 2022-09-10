using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryApp : MonoBehaviour
{
    [SerializeField, Header("메뉴 이미지")]
    Image menuImage;
    
    [SerializeField, Header("음식 이미지")]
    Sprite[] foodImage;
    [SerializeField, Header("코인")]
    Text coinText;
    [SerializeField, Header("비쌈")]
    GameObject expensive;
    
    [SerializeField, Header("메뉴 이름")]
    Text menuName;
    [SerializeField, Header("메뉴 가격")]
    Text menuPrice;
    
    [SerializeField, Header("배달 알림")]
    RectTransform popup;
    [SerializeField, Header("배달 알림")]
    Text popupText;
    [SerializeField, Header("알림 이동위치")]
    Vector2 nextpos;
    Vector2 defPos;

    EventParam eventParam = new EventParam();
    string choiceFood="";
    FoodE callFood;

    List<string> menuNames = new List<string>();

    private void Awake()
    {
        menuNames.Clear();
        menuNames.Add("새우");
        menuNames.Add("오징어");
        menuNames.Add("물고기");
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
            popupText.text = string.Format($"주문하신 {menuNames[(int)callFood - 1]}가 1분 뒤 도착 예정입니다.");
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
            menuName.text = string.Format("새우");
        }
        if(callFood == FoodE.SQUID)
        {
            menuName.text = string.Format("오징어");

        }
        if(callFood == FoodE.FISH)
        {
            menuName.text = string.Format("생선");
        }
    }
}
