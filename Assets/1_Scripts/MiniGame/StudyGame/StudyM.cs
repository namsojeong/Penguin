using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StudyM : MonoBehaviour
{
    public static StudyM instance;

    [SerializeField]
    private Text textScore = null;
    [SerializeField]
    private Text textHighScore = null;



    public int score = 0;
    public int highScore = 0;


    public PoolManager poolManager { get; private set; }
    void Start()
    {
        instance = this;

        poolManager = FindObjectOfType<PoolManager>();
    }

    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 100;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGHSCORE: ", highScore);
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (score < 0)
        {
            score = 0;
        }
        textScore.text = string.Format("SCORE: {0}", score);
        textHighScore.text = string.Format("HIGHSCORE: {0}", highScore);


    }


   
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene("STUDYGame");
    }

}
