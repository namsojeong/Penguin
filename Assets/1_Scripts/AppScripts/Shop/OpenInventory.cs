using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject Item;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;

    public GameObject closetPanel;
    void Start()
    {
        
    }
    private void Awake()
    {
        closetPanel.SetActive(false);
        Item.SetActive(false);
        Item1.SetActive(false);
        Item2.SetActive(false);
        Item3.SetActive(false);
        
    }
    void Update()
    {
        CheckItem();
    }

    public void OnClickCharacter()
    {
        closetPanel.SetActive(true);
    }

    private void CheckItem()
    {
        if(ShopScript.instance.Item1 == true)
        {
            Item.SetActive(true);
        }


        if (ShopScript.instance.Item2 == true)
        {

            Item1.SetActive(true);
        }

        if (ShopScript.instance.Item3 == true)
        {

            Item2.SetActive(true);
        }

        if (ShopScript.instance.Item4 == true)
        {

            Item3.SetActive(true);
        }
    }
}
