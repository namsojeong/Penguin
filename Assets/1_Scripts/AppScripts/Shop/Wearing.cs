using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wearing : MonoBehaviour
{
    [SerializeField]
    GameObject[] items;
    [SerializeField]
    GameObject[] specialItems;
     
    private void Start()
    {
        CheckHaveItem();
        CheckHaveSpecialItem();
    }
    void CheckHaveItem()
    {
        for (int i = 0; i < 3; i++)
        {
            items[i].SetActive(GameManager.Instance.CurrentUser.items[i].isHave);
        }
    }
    void CheckHaveSpecialItem()
    {
        for (int i = 0; i < 3; i++)
        {
            specialItems[i].SetActive(GameManager.Instance.CurrentUser.specialItems[i].isHave);
        }
    }
}
