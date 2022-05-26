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

    [SerializeField, Header("ON �̹���")]
    public Sprite onImage;
    [SerializeField, Header("OFF �̹���")]
    public Sprite offImage;
    
    [SerializeField, Header("���� ȭ��")]
    GameObject mainGameScene;
    [SerializeField, Header("���� ȭ��")]
    GameObject endScene;

    [SerializeField, Header("UI")]
    Text scoreText;
    [SerializeField]
    Text bestScoreText;
    [SerializeField]
    Text endScoreText;
    
    [SerializeField, Header("���ѽð� �����̴�")]
    Image timeSlider;
    [SerializeField, Header("MAX ���ѽð�")]
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
        scoreText.text = string.Format($"���� : {score}");
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

        bestScoreText.text = string.Format($"�ְ� ���� : {bestScore}");
        endScoreText.text = string.Format($"����\n\n{score}");
        
    }

    void ResetGame()
    {
        Debug.Log(iTime);
        score = 0;
        iTime = maxTime;
        UpdateScore();

    }
}
