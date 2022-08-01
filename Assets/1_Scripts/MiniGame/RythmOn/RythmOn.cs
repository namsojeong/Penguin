using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmOn : MonoBehaviour
{
    [SerializeField]
    Button leftButton;
    [SerializeField]
    Button rightButton;

    [SerializeField]
    Image leftImage;
    [SerializeField]
    Image rightImage;

    string dir = "";

    private void Awake()
    {
        leftButton.onClick.AddListener(() => Touch("LEFT"));
        rightButton.onClick.AddListener(() => Touch("RIGHT"));
    }

    void Touch(string str)
    {
        if (dir == str)
        {
            if (str == "LEFT")
            {
                leftImage.gameObject.SetActive(true);
                Debug.Log("¿ÞÂÊ");
            }
            else if (str == "RIGHT")
            {

                rightImage.gameObject.SetActive(true);
                Debug.Log("¿À¸¥ÂÊ");

            }
        }
    }

    void RythmStart()
    {
        int ranDir = Random.Range(0, 101);

        if (ranDir < 50)
        {
            dir = "LEFT";
            leftImage.gameObject.SetActive(false);
        }
        else
        {
            dir = "RIGHT";
            rightImage.gameObject.SetActive(false);
        }

        Invoke("RythmStop", 2f);
    }

    void RythmStop()
    {

    }
}
