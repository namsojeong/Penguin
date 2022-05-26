using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchOffGame : MonoBehaviour
{
    private static SwitchOffGame instance;
    public static SwitchOffGame Instance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<SwitchOffGame>();

            if (instance == null)
            {
                GameObject container = new GameObject("SwitchOffGame");
                instance = container.AddComponent<SwitchOffGame>();
            }
        }
        return instance;
    }

    [SerializeField, Header("ON 이미지")]
    public Sprite onImage;
    [SerializeField, Header("OFF 이미지")]
    public Sprite offImage;
    
    [SerializeField, Header("시작 화면")]
    GameObject mainGameScene;
    [SerializeField, Header("오버 화면")]
    GameObject endScene;

    [SerializeField, Header("UI")]
    Text scoreText;
    [SerializeField]
    Text bestScoreText;
    [SerializeField]
    Text endScoreText;
    
    [SerializeField, Header("제한시간 슬라이더")]
    Image timeSlider;
    [SerializeField, Header("MAX 제한시간")]
    float maxTime;
    float iTime;

     int score;
     int bestScore;

    private void Awake()
    {
        bestScore = PlayerPrefs.GetInt("SWITCHBESTSCORE", 0);
    }

    void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        timeSlider.fillAmount = iTime / maxTime;
    }

    public void ScoreUp(int v)
    {
        score += v;
        if (bestScore < score)
        {
            bestScore = score;
        }
        UpdateScore();
    }
    
    public void TimeDown(int v)
    {
        iTime -= v;
        if (iTime <= 0) EndGame();
    }

    private void MinusTime()
    {
        iTime -= 10f;
        if (iTime <= 0) EndGame();
    }

    public void UpdateScore()
    {
        scoreText.text = string.Format($"점수 : {score}");
    }

    public void StartGame()
    {
        ResetGame();
        mainGameScene.SetActive(true);
        endScene.SetActive(false);

        InvokeRepeating("MinusTime", 1f, 1f);
    }
    public void EndGame()
    {
        CancelInvoke("MinusTime");
        PlayerPrefs.SetInt("SWITCHBESTSCORE", bestScore);
        endScene.SetActive(true);
        mainGameScene.SetActive(false);

        bestScoreText.text = string.Format($"최고 점수 : {bestScore}");
        endScoreText.text = string.Format($"점수\n\n{score}");
        
    }

    void ResetGame()
    {
        Debug.Log(iTime);
        score = 0;
        iTime = maxTime;
        UpdateScore();

    }
}
