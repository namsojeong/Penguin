using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ColorSet
{
    RED = 1,
    YELLOW = 2,
    CYAN = 3,
}
public class ArtGameManager : MonoBehaviour
{
    public static ArtGameManager instance;

    [SerializeField]
    GameObject start;
    [SerializeField]
    GameObject main;
    [SerializeField]
    GameObject over;

    [SerializeField]
    int heart = 3;

    public bool isCorrect = true;
    public Color _color = Color.white;

    private void Awake()
    {
        instance = this;
    }

    // 시작
    private void Start()
    {
        start.SetActive(true);
        main.SetActive(false);
    }

    // 페인트 색 바꿈
    public void ColorChange(int n)
    {
        switch ((ColorSet)n)
        {
            case ColorSet.RED:
                {
                    _color = Color.red;
                    break;
                }
            case ColorSet.YELLOW:
                {
                    _color = Color.yellow;
                    break;
                }
            case ColorSet.CYAN:
                {
                    _color = Color.cyan;
                    break;
                }
        }
    }

    // 하트 -1
    public void HeartAttack()
    {
        heart--;
        if(heart <= 0)
        {
            main.SetActive(false);
            over.SetActive(true);
        }
    }

    // 광고 시청 후 이어서
    public void AdsTry()
    {
        heart = 3;
        main.SetActive(true);
        over.SetActive(false);
    }

}
