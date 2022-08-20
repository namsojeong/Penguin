using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIM : MonoBehaviour
{
    public GameObject startpanel;




    private void Start()
    {
        Time.timeScale = 0;


    }




    public void OnClickPlay()
    {
        startpanel.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("¿Ü¾ÊµÇ");

    }

    public void OnClickHome()
    {
        SceneManager.LoadScene("Main");
    }
}
