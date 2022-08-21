using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{


    public GameObject[] randomItem;

    public GameObject[] Item;
    public int[] itemPrice;


    public Text talkText;


    public GameObject itemPosition;


    void Start()
    {
    }
    void Update()
    {
        
    }


    void RandomItem()
    {
        int selection = Random.Range(0, randomItem.Length);
        GameObject selectedPrefab = randomItem[selection];
        Instantiate(selectedPrefab, itemPosition.transform.position, Quaternion.identity);

    }

    public void OnClickRandomItem()
    {
        RandomItem();
    }

    public void Buy(int index)
    {
        int price = itemPrice[index];
        if(price > GameManager.instance.coin)
        {
            return;
        }


    }

    public void TalkText()
    {
        talkText.text = "";
    }
}


