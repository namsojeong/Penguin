using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class JumpGameManager : MonoBehaviour
{
    [SerializeField]
    GameObject start;
    [SerializeField]
    GameObject main;
    [SerializeField]
    GameObject over;

    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text highScoreText;
    
    [SerializeField]
    Text scoreText_i;
    [SerializeField]
    GameObject newScore;


    int score = 0;
    int highScore = 0;

    private void Start()
    {
        EventManager.StartListening("JumpGame_Over", GameOver);

        highScore = PlayerPrefs.GetInt("JumpGame_HIGHSCORE", 0);
        ChangeScene("START");
    }
    private void OnDestroy()
    {
        EventManager.StopListening("JumpGame_Over", GameOver);
    }

    public void Play()
    {
        ResetGame();
        ChangeScene("MAIN");
        PoolManager.instance.SpawnPlay();
        InvokeRepeating("ScoreUP", 1f, 1f);
    }

    void ResetGame()
    {
        score = 0;
        UpdateUIInGame();
        newScore.SetActive(false);
    }

    private void GameOver(EventParam evevntParam)
    {
        CancelInvoke("ScoreUP");
        PoolManager.instance.ResetObj();
        ChangeScene("OVER");
        UpdateOverUI();
    }

    void UpdateOverUI()
    {
        highScore = PlayerPrefs.GetInt("JumpGame_HIGHSCORE", 0);
        scoreText.text = string.Format($"점수\n{score}");
        highScoreText.text = string.Format($"최고점수 : {highScore}");
    }

    private void ScoreUP()
    {
        score += 10;
        UpdateUIInGame();
        if(score>highScore)
        {
            newScore.SetActive(true);
            highScore = score;
            PlayerPrefs.SetInt("JumpGame_HIGHSCORE", highScore);
        }
    }
    void UpdateUIInGame()
    {
        scoreText_i.text = string.Format($"{score}");
    }

    private void ChangeScene(string str)
    {
        if(str=="START")
        {
            start.SetActive(true);
            main.SetActive(false);
            over.SetActive(false);
        }
        else if(str=="MAIN")
        {
            start.SetActive(false);
            main.SetActive(true);
            over.SetActive(false);
        }
        else if(str=="OVER")
        {
            start.SetActive(false);
            main.SetActive(false);
            over.SetActive(true);
        }
    }

}
