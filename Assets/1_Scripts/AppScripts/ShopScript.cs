using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public static ShopScript instance;

    public GameObject[] randomItem;

    public GameObject[] Item;
    public int[] itemPrice;

    public AudioSource audioSource;


    //public GameObject itemPosition;




    public bool[] isBuyToItme;


    void Start()
    {

        instance = this;
    }
    void Update()
    {

    }


    void RandomItem()
    {
        int selection = Random.Range(0, randomItem.Length);
        GameObject selectedPrefab = randomItem[selection];
    //    Instantiate(selectedPrefab, itemPosition.transform.position, Quaternion.identity);

    }

    public void OnClickRandomItem()
    {
        int gachaprice = 200;
        GameManager.instance.coin -= gachaprice;

        if (gachaprice > GameManager.instance.coin)
        {
            audioSource.Play();
            return;
        }
        RandomItem();
    }

    public void OnclickBuy(int index)
    {
        int price = itemPrice[index];
        if (price > GameManager.instance.coin)
        {
            audioSource.Play();
            return;
        }

        GameManager.instance.coin -= price;

        bool isBuy = isBuyToItme[index];

        isBuy = true;


    }





}


