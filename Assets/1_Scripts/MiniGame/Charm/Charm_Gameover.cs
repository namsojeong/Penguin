using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charm_Gameover : MonoBehaviour
{
    [SerializeField]
    GameObject manager;
    [SerializeField]
    GameObject mainBg;

    [Header("¹öÆ° UI")]
    [SerializeField]
    Button restart;
    [SerializeField]
    Button main;

    [Header("SCORE UI")]
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text highScoreText;

    [SerializeField]
    GameObject bg;

    void Start()
    {
        restart.onClick.AddListener(()=>RestartButton());
        main.onClick.AddListener(()=>GoMain());
    }

    private void OnEnable()
    {
        UpdateScoreUI();
    }

    void RestartButton()
    {
        mainBg.SetActive(true);
        manager.SetActive(true);
    }

    void GoMain()
    {
        SceneM.instance.ChangeScene("Main");
    }

    void UpdateScoreUI()
    {
        bg.SetActive(true);
        scoreText.text = string.Format($"Score : {PlayerPrefs.GetInt("SCORE_CHARM", 0)}");
        highScoreText.text = string.Format($"HighScore : {PlayerPrefs.GetInt("HIGHSCORE_CHARM", 0)}");
    }
}
