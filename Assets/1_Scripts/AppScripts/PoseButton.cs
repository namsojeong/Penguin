using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemShuffle;
using UnityEngine.UI;


public class PoseButton : MonoBehaviour
{
    public Image nomalImage;
    public Sprite[] changeSprite;

    public void ChangePose()
    {
        Array.shuffl(changeSprite);

        Sprite chSprite = changeSprite[0];
        nomalImage.sprite = chSprite;
    }
}
