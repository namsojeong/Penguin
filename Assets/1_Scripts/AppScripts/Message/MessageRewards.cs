using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageRewards : MonoBehaviour
{

    public Button RewardButton;


    private void Update()
    {
        RewardButton.onClick.AddListener(reward);
    }

    void reward()
    {
        Debug.Log("보상해주세요!");
    }

}
