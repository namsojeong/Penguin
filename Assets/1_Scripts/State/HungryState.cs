using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryState : MonoBehaviour
{
    [SerializeField, Header("���� �ؽ�Ʈ")]
    Text[] countText;
    [SerializeField, Header("����")]
    GameObject[] food;
    [SerializeField, Header("����")]
    Text expText;

    int shrimpCount;
    int squidCount;
    int fishCount;

    int nowKindFood;

    bool[] isHave = { false, false, false };

    EventParam eventParam = new EventParam();

    private void Start()
    {
        EventManager.StartListening("BUYFOOD", PlusFood);
        EventManager.StartListening("USEFOOD", MinusFood);
        EventManager.StartListening("FOODCOUNT", UpdateCount);
    }

    void GetCnt()
    {
        shrimpCount = GameManager.Instance.CurrentUser.shrimpCnt;
        squidCount = GameManager.Instance.CurrentUser.squidCnt;
        fishCount = GameManager.Instance.CurrentUser.fishCnt;
        UpdateCount(eventParam);
    }

    public void OnClickHungry()
    {
        GetCnt();
        if (shrimpCount == 0 && squidCount == 0 && fishCount == 0)
        {
            expText.text = string.Format("������ �����ϴ�\n����� �������� �����Ͻʽÿ�");
        }
        else
        {
            if (GameManager.Instance.CurrentUser.hungry >= 100)
            {
                expText.text = string.Format("�谡 ������ �ʾƿ�!");
            }
            else
            {
                expText.text = string.Format("������ �巡���Ͽ� ���̼���!");
            }
        }
    }
    public void UpdateCount(EventParam eventParam)
    {
        countText[0].text = string.Format($"{shrimpCount}");
        countText[1].text = string.Format($"{squidCount}");
        countText[2].text = string.Format($"{fishCount}");
    }

    private void MinusFood(EventParam eventParam)
    {
        GetCnt();
        OnClickHungry();
        if (eventParam.stringParam == "SHRIMP")
        {
            if (shrimpCount < 1) return;
            GameManager.Instance.PlusItemCount(FoodE.SHRIMP, -1);
            if (shrimpCount < 1)
            {
                nowKindFood--;
                isHave[(int)FoodE.SHRIMP - 1] = false;
            }
        }
        else if (eventParam.stringParam == "SQUID")
        {
            if (squidCount < 1) return;
            GameManager.Instance.PlusItemCount(FoodE.SQUID, -1);
            if (squidCount < 1)
            {
                nowKindFood--;
                isHave[(int)FoodE.SQUID - 1] = false;
            }

        }
        else if (eventParam.stringParam == "FISH")
        {
            if (fishCount < 1) return;
            GameManager.Instance.PlusItemCount(FoodE.FISH, -1);
            if (fishCount < 1)
            {
                nowKindFood--;
                isHave[(int)FoodE.FISH - 1] = false;
            }
        }
        GetCnt();
        OnClickHungry();
    }
    private void PlusFood(EventParam eventParam)
    {
        GetCnt();
        OnClickHungry();
        if (eventParam.stringParam == "SHRIMP")
        {
            if (shrimpCount < 1)
            {
                nowKindFood++;
                isHave[(int)FoodE.SHRIMP - 1] = true;
            }
            GameManager.Instance.PlusItemCount(FoodE.SHRIMP, 1);

        }
        else if (eventParam.stringParam == "SQUID")
        {
            if (squidCount < 1)
            {
                nowKindFood++;
                isHave[(int)FoodE.SQUID - 1] = true;
            }
            GameManager.Instance.PlusItemCount(FoodE.SQUID, 1);
        }
        else if (eventParam.stringParam == "FISH")
        {
            if (fishCount < 1)
            {
                nowKindFood++;
                isHave[(int)FoodE.FISH - 1] = true;
            }
            GameManager.Instance.PlusItemCount(FoodE.FISH, 1);
        }
        GetCnt();
        OnClickHungry();
        //StartCoroutine(Delivering());
    }

    IEnumerator Delivering()
    {
        yield return new WaitForSeconds(1f);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("FOODCOUNT", UpdateCount);
        EventManager.StopListening("BUYFOOD", PlusFood);
        EventManager.StopListening("USEFOOD", MinusFood);
    }
}
