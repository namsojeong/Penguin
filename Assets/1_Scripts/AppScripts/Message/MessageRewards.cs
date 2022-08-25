using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageRewards : MonoBehaviour
{

    //public Image rewardFillImage;
    //public float fillValue = 10f;
    //public float maxFillValue = 1000f;

    public Button RewardButton;

    void Start()
    {
        
    }

    private void Update()
    {
        RewardButton.onClick.AddListener(reward);
    }

    void reward()
    {
        Debug.Log("보상해주세요!");
    }

    //void Update()
    //{
    //    if(fillValue >= 0)
    //    {
    //        fillValue -= Time.deltaTime * 8;
    //    }

    //    rewardFillImage.fillAmount = fillValue / maxFillValue;
    //}
}
