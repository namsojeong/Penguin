using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIM : MonoBehaviour
{
    public static UIM instance;

    public GameObject startpanel;

    public GameObject overPanel;

    public GameObject scoret;

    public GameObject peng;

    public GameObject col;


    

    private void Start()
    {
        overPanel.SetActive(false);
        instance = this;
        Time.timeScale = 0;
        scoret.SetActive(false);

        peng.SetActive(false);
        startpanel.SetActive(true);

        col.SetActive(false);
        
    }




    public void OnClickPlay()
    {
        startpanel.SetActive(false);
        scoret.SetActive(true);
        peng.SetActive(true);
        Time.timeScale = 1;
        col.SetActive(true);

    }

    public void OnClickHome()
    {
        SceneManager.LoadScene("Main");
    }


    public void OverPenel()
    {
        overPanel.SetActive(true);
    }

    public void OnClickReStart()
    {
        overPanel.SetActive(false);
        SceneManager.LoadScene("STUDYGame");
    }
}
