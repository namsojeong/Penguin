using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charm_Gameover : MonoBehaviour
{
   // [SerializeField]
    //GameObject manager;
    //[SerializeField]
    //GameObject mainBg;

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

    //[SerializeField]
    // GameObject bg;

    int scoreT = 0;
    int highscoreT = 0;

    void Start()
    {
        scoreT = PlayerPrefs.GetInt("SCORE_CHARM", 0);
        highscoreT = PlayerPrefs.GetInt("HIGHSCORE_CHARM", 0);

        Debug.Log(highscoreT);

        restart.onClick.AddListener(()=>RestartButton());
        main.onClick.AddListener(()=>GoMain());

        UpdateScoreUI();
    }

    private void OnEnable()
    {
       
    }

    private void Update()
    {
        UpdateScoreUI();
    }

    void RestartButton()
    {
        //mainBg.SetActive(true);
        //manager.SetActive(true);

        SceneManager.LoadScene("CHARMGame_2");
    }

    void GoMain()
    {
        //SceneM.instance.ChangeScene("Main");
        SceneManager.LoadScene("main");
    }

    void UpdateScoreUI()
    {
       
        scoreText.text = string.Format($"Score : {scoreT}");
        highScoreText.text = string.Format($"HighScore : {highscoreT}");
    }
}
