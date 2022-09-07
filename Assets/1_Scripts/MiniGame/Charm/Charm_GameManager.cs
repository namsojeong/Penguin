using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charm_GameManager : MonoBehaviour
{
    [SerializeField]
    public Text scoreText = null;

    public static int saveScore ;

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
    //[SerializeField]
    //private GameObject overPanel;
   
    public Vector2 minPosition { get; private set; }
    public Vector2 maxPosition { get; private set; }
    public Charm_PoolManager poolManager { get; private set; }

    private int score = 0;
    private int highScore = 0;

    EventParam eventParam = new EventParam();

    void Awake()
    {
        poolManager = FindObjectOfType<Charm_PoolManager>();
    }

    private void OnEnable()
    {
        minPosition = new Vector2(-2f, -4f);
        maxPosition = new Vector2(2f, 4f);

        StartCoroutine(SpawnCroissant());
        StartCoroutine(SpawnHotdog());

        highScore = PlayerPrefs.GetInt("HIGHSCORE_CHARM", 0);

        UpdateUI();
    }

    public void Dead()
    {
        life--;
        if (life <= 0)
        {
            StopAllCoroutines();
            eventParam.intParam = score;
            PlayerPrefs.SetInt("HIGHSCORE_CHARM", highScore);
            PlayerPrefs.SetInt("SCORE_CHARM", score);
            SceneManager.LoadScene("CHARMGame_2_over");
            // overPanel.SetActive(true);
            gameObject.SetActive(false);
        }

        UpdateUI();
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        if (score > highScore)
        {
            highScore = score;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        lifeText.text = string.Format("LIFE : {0}", life);
        scoreText.text = string.Format("{0}", score);

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

            yield return new WaitForSeconds(0.2f + randomDelay);
        }
    }

    private IEnumerator SpawnHotdog()
    {
        float randomX = 0f;
        float randomDelay = 0f;

        yield return new WaitForSeconds(5f);

        while (true)
        {
            randomX = Random.Range(-2f, 2f);
            randomDelay = Random.Range(1f, 2f);

            Instantiate(enemyHotdog, new Vector2(randomX,5f), Quaternion.identity);
            yield return new WaitForSeconds(0.2f + randomDelay);
        }
    }

    void ResetGame()
    {
        
    }

}
