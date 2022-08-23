using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemShuffle;
using UnityEngine.UI;


public class PoseButton : MonoBehaviour
{
    //public GameObject[] characterPose;

    //public GameObject position;

    public Image nomalImage;
    public Sprite[] changeSprite;



    void Start()
    {
    }

    void Update()
    {

    }

    //public void OnclickPoseButton()
    //{
    //    GameObject pose = characterPose[0]; 
    //    if(pose != null)
    //    {
    //    Destroy(pose);
    //    }
    //    Array.shuffl(characterPose);
    //    Instantiate(pose , position.transform.position , Quaternion.identity);
    //}

    public void OnClickPoseButton()
    {
        Array.shuffl(changeSprite);

        Sprite chSprite = changeSprite[0];
        nomalImage.sprite = chSprite;
    }

    
}
