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


    

   

    private void Start()
    {
        overPanel.SetActive(false);
        instance = this;
        Time.timeScale = 0;
        scoret.SetActive(false);
        
    }




    public void OnClickPlay()
    {
        startpanel.SetActive(false);
        scoret.SetActive(true);
        Time.timeScale = 1;

    }

    public void OnClickHome()
    {
        SceneManager.LoadScene(2);
    }


    public void OverPenel()
    {
        overPanel.SetActive(true);
    }

    public void OnClickReStart()
    {
        overPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
