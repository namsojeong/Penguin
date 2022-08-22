using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{
    [SerializeField]
    Button[] haveButton;

    [SerializeField]
    GameObject[] itemImage;
    [SerializeField]
    GameObject[] itemButton;
    [SerializeField]
    GameObject[] realHave;

    private void Awake()
    {
        haveButton[0].onClick.AddListener(() => ClikWear(0));
        haveButton[1].onClick.AddListener(() => ClikWear(1));
        haveButton[2].onClick.AddListener(() => ClikWear(2));

    }

    private void OnEnable()
    {
        CheckHaveItem();
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
                    ClikWear(i);
                }
                else
                {
                    haveButton[i].GetComponent<Image>().color = Color.white;
                }
            }


        }
    }

    public void ClikWear(int index)
    {
        GameManager.instance.CurrentUser.items[index].isHave = !GameManager.instance.CurrentUser.items[index].isHave;
        itemImage[index].SetActive(GameManager.instance.CurrentUser.items[index].isHave);
        if (GameManager.instance.CurrentUser.items[index].isHave)
        {
            haveButton[index].GetComponent<Image>().color = Color.red;
            realHave[index].SetActive(true);
        }
        else
        {
            haveButton[index].GetComponent<Image>().color = Color.white;
            realHave[index].SetActive(false);
        }
    }
}
