using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{
    [SerializeField]
    Button[] haveButton;
    [SerializeField]
    Button[] haveSpecialButton;

    [SerializeField]
    GameObject[] itemImage;
    [SerializeField]
    GameObject[] itemButton;
    [SerializeField]
    GameObject[] realHave;

    [SerializeField]
    GameObject[] sItemImage;
    [SerializeField]
    GameObject[] sItemButton;
    [SerializeField]
    GameObject[] sRealHave;

    private void Awake()
    {
        //ÀÏ¹Ý
        haveButton[0].onClick.AddListener(() => ClikWear(0));
        haveButton[1].onClick.AddListener(() => ClikWear(1));
        haveButton[2].onClick.AddListener(() => ClikWear(2));

        //½ºÆä¼È
        haveSpecialButton[0].onClick.AddListener(() => ClikWearSpecial(0));
        haveSpecialButton[1].onClick.AddListener(() => ClikWearSpecial(1));
        haveSpecialButton[2].onClick.AddListener(() => ClikWearSpecial(2));

    }

    private void OnEnable()
    {
        CheckHaveItem();
        CheckHaveSpecialItem();
    }

    private void Start()
    {
        CheckHaveItem();
        CheckHaveSpecialItem();
    }

    void CheckHaveItem()
    {
        for (int i = 0; i < 3; i++)
        {
            itemButton[i].SetActive(GameManager.instance.CurrentUser.items[i].isGet);
            if (GameManager.instance.CurrentUser.items[i].isGet)
            {
                if (GameManager.instance.CurrentUser.items[i].isHave)
                {
                    haveButton[i].GetComponent<Image>().color = Color.red;
                    itemImage[i].SetActive(true);
                }
                else
                {
                    haveButton[i].GetComponent<Image>().color = Color.white;
                    itemImage[i].SetActive(false);
                }
            }
        }
    }
    void CheckHaveSpecialItem()
    {
        for (int i = 0; i < 3; i++)
        {
            sItemButton[i].SetActive(GameManager.instance.CurrentUser.specialItems[i].isGet);
            if (GameManager.instance.CurrentUser.specialItems[i].isGet)
            {
                if (GameManager.instance.CurrentUser.specialItems[i].isHave)
                {
                    haveSpecialButton[i].GetComponent<Image>().color = Color.red;
                    sItemImage[i].SetActive(true);
                }
                else
                {
                    haveSpecialButton[i].GetComponent<Image>().color = Color.white;
                    sItemImage[i].SetActive(false);
                }
            }
        }
    }

    public void ClikWear(int index)
    {
        if (GameManager.instance.CurrentUser.items[index].isHave)
        {
            GameManager.instance.CurrentUser.items[index].isHave = false;
            haveButton[index].GetComponent<Image>().color = Color.white;
            realHave[index].SetActive(false);
        }
        else
        {
            GameManager.instance.CurrentUser.items[index].isHave = true;
            haveButton[index].GetComponent<Image>().color = Color.red;
            realHave[index].SetActive(true);
        }
        itemImage[index].SetActive(GameManager.instance.CurrentUser.items[index].isHave);
    }
    public void ClikWearSpecial(int index)
    {
        GameManager.instance.CurrentUser.specialItems[index].isHave = !GameManager.instance.CurrentUser.specialItems[index].isHave;
        sItemImage[index].SetActive(GameManager.instance.CurrentUser.specialItems[index].isHave);
        if (GameManager.instance.CurrentUser.specialItems[index].isHave)
        {
            haveSpecialButton[index].GetComponent<Image>().color = Color.red;
            sRealHave[index].SetActive(true);
        }
        else
        {
            haveSpecialButton[index].GetComponent<Image>().color = Color.white;
            sRealHave[index].SetActive(false);
        }
    }
}
