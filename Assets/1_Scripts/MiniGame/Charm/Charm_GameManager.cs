using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charm_GameManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text highScoreText = null;
    [SerializeField]
    private Text lifeText = null;
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private GameObject enemyCroissant;
    [SerializeField]
    private GameObject enemyHotdog;
    [SerializeField]
    private GameObject gameoverPannel;

    public Vector2 minPosition { get; private set; }
    public Vector2 maxPosition { get; private set; }
    public Charm_PoolManager poolManager { get; private set; }

    private int score = 0;
    private int highScore = 0;

    void Awake()
    {
        minPosition = new Vector2(-2f, -4f);
        maxPosition = new Vector2(2f, 4f);

        poolManager = FindObjectOfType<Charm_PoolManager>();

        StartCoroutine(SpawnCroissant());
       StartCoroutine(SpawnHotdog());
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 500);
        UpdateUI();
    }

    public void Dead()
    {
        life--;
        if (life <= 0)
        {
            Time.timeScale = 0;

            gameoverPannel.SetActive(true);

            Debug.Log("끝입니다");
        }
        UpdateUI();
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGHSCORE", score);
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        lifeText.text = string.Format("LIFE\n{0}", life);
        scoreText.text = string.Format("{0}", score);
       // highScoreText.text = string.Format("HIGHSCORE\n{0}", highScore);
    }

    private IEnumerator SpawnCroissant()
    {
        float randomX = 0f;
        float randomDelay = 0f;

        while (true)
        {
            randomX = Random.Range(-2f, 2f);
            randomDelay = Random.Range(0f, 1f);

            Instantiate(enemyCroissant, new Vector2(randomX, 6f), Quaternion.identity);

           

            yield return new WaitForSeconds(0.2f);
            
            yield return new WaitForSeconds(randomDelay);
        }
    }

    private IEnumerator SpawnHotdog()
    {
        float randomY = 0f;
        float randomDelay = 0f;

        yield return new WaitForSeconds(5f);

        while (true)
        {
            randomY = Random.Range(-4f, 4f);
            randomDelay = Random.Range(5f, 10f);
            
                Instantiate(enemyHotdog, new Vector2(5f, randomY), Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
           

            yield return new WaitForSeconds(randomDelay);
        }
    }
}
