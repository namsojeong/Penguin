using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charm_Gameover : MonoBehaviour
{
    public Button Restart;
    public Button Main;

    void Start()
    {
        Restart.onClick.AddListener(Restart2);
        Main.onClick.AddListener(Main2);

    }

    void Update()
    {
        
    }

    void Main2()
    {
        SceneManager.LoadScene("Main");
    }

    void Restart2()
    {
        SceneManager.LoadScene("CHARMGame_2");
    }
}
