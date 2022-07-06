using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryState : MonoBehaviour
{
    [SerializeField, Header("갯수 텍스트")]
    Text[] countText;
    [SerializeField, Header("다음 음식 버튼")]
    Button[] nextFoodButton;
    [SerializeField, Header("음식")]
    GameObject[] food;
    [SerializeField, Header("음식")]
    Text expText;

    int shrimpCount;
    int squidCount;
    int fishCount;

    int nowFood = 0;
    int nowKindFood;

    bool[] isHave = { false, false, false };

    EventParam eventParam = new EventParam();

    private void Awake()
    {
        nextFoodButton[0].onClick.AddListener(() => NextFood("LEFT"));
        nextFoodButton[1].onClick.AddListener(() => NextFood("RIGHT"));
    }
    private void Start()
    {
        EventManager.StartListening("BUYFOOD", PlusFood);
        EventManager.StartListening("USEFOOD", MinusFood);
        EventManager.StartListening("FOODCOUNT", UpdateCount);
    }
    private void Update()
    {
        UpdateCount(eventParam);
    }

    void GetCnt()
    {
        squidCount = GameManager.instance.squidCount;
        shrimpCount = GameManager.instance.shrimpCount;
        fishCount = GameManager.instance.fishCount;
    }

    public void OnClickHungry()
    {
        if (shrimpCount == 0 && squidCount == 0 && fishCount == 0)
        {
            expText.text = string.Format("음식이 없습니다\n배달의 만족에서 구매하십시오");
        }
        else
        {
            if (GameManager.instance.hungry >= 100)
            {
                expText.text = string.Format("배가 고프지 않아요!");
            }
            else
            {
                expText.text = string.Format("음식을 드래그하여 먹이세요!");
            }
        }
        UpdateCount(eventParam);
    }
    public void UpdateCount(EventParam eventParam)
    {
        //if (nowFood - 1 < 0) nextFoodButton[0].gameObject.SetActive(false);
        //else nextFoodButton[0].gameObject.SetActive(true);
        //if (nowFood + 1 >= nowKindFood) nextFoodButton[1].gameObject.SetActive(false);
        //else nextFoodButton[1].gameObject.SetActive(true);
        GetCnt();
        countText[0].text = string.Format($"{shrimpCount}");
        countText[1].text = string.Format($"{squidCount}");
        countText[2].text = string.Format($"{fishCount}");
    }

    private void NextFood(string dir)
    {
        UpdateCount(eventParam);
        food[nowFood].SetActive(false);
        if (dir == "LEFT")
        {
            nowFood--;
            if (nowFood < 0) nowFood = 0;
        }
        else
        {
            nowFood++;
            if (nowFood > 2) nowFood = 2;
        }
        food[nowFood].SetActive(true);
    }
    private void MinusFood(EventParam eventParam)
    {
        GetCnt();
        if (eventParam.stringParam == "SHRIMP")
        {
            if (shrimpCount < 1) return;
            GameManager.instance.shrimpCount--;
            if (shrimpCount < 1)
            {
                nowKindFood--;
                isHave[(int)FoodE.SHRIMP - 1] = false;
            }
        }
        else if (eventParam.stringParam == "SQUID")
        {
            if (squidCount < 1) return;
            GameManager.instance.squidCount--;
            if (squidCount < 1)
            {
                nowKindFood--;
                isHave[(int)FoodE.SQUID - 1] = false;
            }

        }
        else if (eventParam.stringParam == "FISH")
        {
            if (fishCount < 1) return;
            GameManager.instance.fishCount--;
            if (fishCount < 1)
            {
                nowKindFood--;
                isHave[(int)FoodE.FISH - 1] = false;
            }
        }
    }
    private void PlusFood(EventParam eventParam)
    {
        GetCnt();
        if (eventParam.stringParam == "SHRIMP")
        {
            if (shrimpCount < 1)
            {
                nowKindFood++;
                isHave[(int)FoodE.SHRIMP - 1] = true;
            }
           GameManager.instance.shrimpCount++;
        }
        else if (eventParam.stringParam == "SQUID")
        {
            if (squidCount < 1)
            {
                nowKindFood++;
                isHave[(int)FoodE.SQUID - 1] = true;
            }
            GameManager.instance.squidCount++;
        }
        else if (eventParam.stringParam == "FISH")
        {
            if (fishCount < 1)
            {
                nowKindFood++;
                isHave[(int)FoodE.FISH - 1] = true;
            }
            GameManager.instance.fishCount++;
        }
    }
    private void OnDestroy()
    {
        EventManager.StopListening("FOODCOUNT", UpdateCount);
        EventManager.StopListening("BUYFOOD", PlusFood);
        EventManager.StopListening("USEFOOD", MinusFood);
    }
}
