using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingOfPE : MonoBehaviour
{
    [SerializeField]
    GameObject cine;
    [SerializeField]
    Button videoStartButton;

    void Awake()
    {
        videoStartButton.onClick.AddListener(()=>ClickVideo());
    }


    void Start()
    {
        cine.SetActive(false);
        videoStartButton.gameObject.SetActive(true);
    }
    public void ClickVideo()
    {
        cine.SetActive(true);
        videoStartButton.gameObject.SetActive(false);
    }
}
