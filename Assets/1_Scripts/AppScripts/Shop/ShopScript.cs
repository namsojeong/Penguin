using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public static ShopScript instance;

    public GameObject[] randomItem;

   
    public int[] itemPrice;

    public AudioSource audioSource;


    //public GameObject itemPosition;




    


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

    }


    public bool Item1 = false;
    public bool Item2 = false;
    public bool Item3 = false;
    public bool Item4 = false;

   public void OnClickBuyButton1()
    {
        Item1 = true;
    }
    public void OnClickBuyButton2()
    {
        Item2 = true;
    }
    public void OnClickBuyButton3()
    {
        Item3= true;
    }
    public void OnClickBuyButton4()
    {
        Item4 = true;
    }




}


