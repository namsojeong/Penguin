using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charm_Save : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore = null;

    [SerializeField]
    private Text textScore = null;

    private int Over_score;

    private void Start()
    {
       textHighScore.text = string.Format("HIGHSCORE\n{0}", PlayerPrefs.GetInt("HIGHSCORE", 10));

        Over_score = Charm_GameManager.saveScore;


        textScore.text = string.Format("SCORE\n{0}",Over_score);

    }

    public void Save()
    {
     
    }

    void Update()
    {
       
    }
}
