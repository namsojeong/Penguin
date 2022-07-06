using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    Text ranCoinText;

    private int randomCoin = 0;
    int[] coinPrice = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    int price;
    int cnt = 0;

    private void Start()
    {
        for(int i=0;i<10;i++)
        {
            randomCoin += 10;
            coinPrice[i] = (int)(randomCoin * 0.5);
        }
    }
    public void CoinSequence()
    {
        if(cnt+1 <5)
        {
            price += coinPrice[cnt++];
        }
        else
        {
            cnt = 0;
            price += coinPrice[cnt++];
        }

        ranCoinText.text = string.Format($"{price}");
    }


    public void RandomBox()
    {
        int ran = Random.Range(0, 101);

        if(ran<50)
        {
            // 악세사리 아이템
        }
        else
        {
            // 배경화면 아이템
        }
    }
}
