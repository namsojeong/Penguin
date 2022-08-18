using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM : MonoBehaviour
{
    public GameObject panel;
    public Text text;
    int score = 0;



    private void Start()
    {
        SetText();
        Time.timeScale = 0;
    }

    public void GetScore()
    {
        score += 100;
        SetText();
    }

    public void SetText()
    {
        text.text = "Score : " + score.ToString();
    }


    public void OnClickPlay()
    {
        panel.SetActive(false);
        Time.timeScale = 1;

    }
}
