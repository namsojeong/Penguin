using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [Header("ON �̹���")]
    public Sprite onImage;
    [Header("OFF �̹���")]
    public Sprite offImage;
    
    [SerializeField, Header("���� ȭ��")]
    GameObject startGameScene;
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

    [Header("Switch")]
    [SerializeField]
    GameObject allSwitch;
    List<SwitchButtonScripts> switchButtons = new List<SwitchButtonScripts>();
    List<int> offswitchs = new List<int>();
    

    [SerializeField, Header("���ѽð� �����̴�")]
    Image timeSlider;
    [SerializeField, Header("Slide Speed")]
    float slideSpeed;
    [SerializeField, Header("MAX ���ѽð�")]
    float maxTime;
    [SerializeField, Header("Def Gage")]
    float curTime;

    [SerializeField, Header("����ġ ����")]
    int switchConut;
    int onCnt = 0;
    int minusTimeVal = 5;

   float level=1;
     int score;
     int bestScore;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Init();
        bestScore = PlayerPrefs.GetInt("SWITCHBESTSCORE", 0);
    }

    void Update()
    {
        UpdateTime();
    }

    // �ʱ�ȭ
    private void Init()
    {
        UpdateScene("START");
        for (int i = 0; i < switchConut; i++)
        {
            switchButtons.Add(allSwitch.transform.GetChild(i).GetComponent<SwitchButtonScripts>());
            offswitchs.Add(i);
        }
    }

    // �� �ٲٱ�
    void UpdateScene(string str)
    {
        startGameScene.SetActive(false);
        mainGameScene.SetActive(false);
        endScene.SetActive(false);
        if (str=="START")
        {
            startGameScene.SetActive(true);
        }
        else if(str=="MAIN")
        {
            mainGameScene.SetActive(true);
            
        }
        else if(str=="OVER")
        {
            endScene.SetActive(true);
        }
    }

    //UI Update
    public void UpdateScore()
    {
        scoreText.text = string.Format($"���� : {score}");
    }
    private void UpdateTime()
    {
        timeSlider.fillAmount = Mathf.Lerp(timeSlider.fillAmount, curTime / maxTime, slideSpeed*Time.deltaTime);
        if (timeSlider.fillAmount <= 0) EndGame();
        else if (timeSlider.fillAmount > 1) curTime = 1; 
    }

    // Score, Slider value Change
    public void ScoreUp(int v)
    {
        score += v;
        if(score%200==0)
        {
            level += 1;
        }
        if (bestScore < score)
        {
            bestScore = score;
        }
        UpdateScore();
    }
    public void TimeDown(int v)
    {
        curTime -= v;
    }

    // �ð� �����̴� ��� ���̱�
    private void MinusTime()
    {
        curTime -= minusTimeVal * level;
    }

    void RandomSwitch()
    {
        //int ranCount = Random.Range(1, (offswitchs.Count)/2);
        //Debug.Log(ranCount);
        //for(int i=0;i<ranCount;i++)
        {
            //if (onCnt > switchConut/2) break;
            onCnt++;
            int ranNum = Random.Range(0, offswitchs.Count);
            switchButtons[offswitchs[ranNum]].SwitchOn();
            offswitchs.RemoveAt(ranNum);
        }

    }

    public void StartGame()
    {
        ResetGame();
        UpdateScene("MAIN");

        InvokeRepeating("MinusTime", 1f, 1f);
        RandomSwitch();
    }

    void LevelUp()
    {
        level += 1f;
        minusTimeVal += 1;
    }

    // ���� ���� �Լ�
    public void EndGame()
    {
        CancelInvoke("MinusTime");
        PlayerPrefs.SetInt("SWITCHBESTSCORE", bestScore);
        UpdateScene("OVER");

        bestScoreText.text = string.Format($"�ְ� ���� : {bestScore}");
        endScoreText.text = string.Format($"����\n\n{score}");
    }

    // ���� ����
    void ResetGame()
    {
        score = 0;
        curTime = maxTime;
        UpdateScore();
    }

    public void OffButton(int num)
    {
        onCnt--;
        offswitchs.Add(num);
        RandomSwitch();
    }

}
