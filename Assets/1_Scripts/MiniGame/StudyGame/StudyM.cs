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
   
    
    public float difficult = 1;
    public GameObject difficulttext;


    public int score = 0;
    public int highScore = 0;

    public Text overScoreT;


    public PoolManager poolManager { get; private set; }
    void Start()
    {
        instance = this;

        poolManager = FindObjectOfType<PoolManager>();
        StartCoroutine(Difficult());

        difficulttext.SetActive(false);

    }

    void Update()
    {
        
    }
    IEnumerator Difficult()
    {
        yield return new WaitForSeconds(20f);
        difficult = 1.5f;
        for (int i = 0; i < 4; i++)
        {
            difficulttext.SetActive(true);
            yield return new WaitForSeconds(.3f);
            difficulttext.SetActive(false);
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(20f);
        difficult = 2f;
        for (int i = 0; i < 4; i++)
        {
            difficulttext.SetActive(true);
            yield return new WaitForSeconds(.3f);
            difficulttext.SetActive(false);
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(20f);
        difficult = 2.5f;
        for (int i = 0; i < 4; i++)
        {
            difficulttext.SetActive(true);
            yield return new WaitForSeconds(.3f);
            difficulttext.SetActive(false);
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(20f);
        difficult = 3f;
        for (int i = 0; i < 4; i++)
        {
            difficulttext.SetActive(true);
            yield return new WaitForSeconds(.3f);
            difficulttext.SetActive(false);
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(20f);
        difficult = 3.5f;
        for (int i = 0; i < 4; i++)
        {
            difficulttext.SetActive(true);
            yield return new WaitForSeconds(.3f);
            difficulttext.SetActive(false);
            yield return new WaitForSeconds(.3f);
        }
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
        PlayerPrefs.SetInt("HIGHSCORE: ", highScore);

    }

    public void OverText()
    {
        overScoreT.text = string.Format("Score " +
            "{0}", score);   
    }
   
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene("STUDYGame");
    }

}
