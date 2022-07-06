using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    

    public void OpenUI(GameObject ui)
    {
        ui.SetActive(true);
    }
    public void CloseUI(GameObject ui)
    {
        ui.SetActive(false);
    }

    public void TimeReset(int time)
    {
        Time.timeScale = time;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
