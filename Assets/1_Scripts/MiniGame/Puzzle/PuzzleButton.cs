using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleButton : MonoBehaviour
{
    [SerializeField]
    ColorSet num;
    [SerializeField]
    Color defaultColor;
    [SerializeField]
    Color falseColor;

    Text _text;
    Image _image;
    Color _color;
    Button _button;

    bool isNot = true;

    // 게임 판정 시 EventManager로 isNot이 False인지 체크 만약 True면 다시 반대로 신호줌

    private void Awake()
    {
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<Text>();
        _image = GetComponent<Image>();

        _button.onClick.AddListener(() => ClickMe());
        //MyColorSet();
    }
    private void OnEnable()
    {
        MyColorSet();
    }

    void ResetButton()
    {
        _image.color = defaultColor;
        _text.gameObject.SetActive(true);
    }

    // 버튼 색 정하기
    void MyColorSet()
    {
        _text.text = string.Format($"{(int)num}");
        switch (num)
        {
            case ColorSet.RED: {
                    _color = Color.red;
                    break;
                }
            case ColorSet.YELLOW: {
                    _color = Color.yellow;
                    break;
                }
            case ColorSet.CYAN: {
                    _color = Color.cyan;
                    break;
                }
        }
    }

    // 색깔퍼즐버튼 클릭
    public void ClickMe()
    {
        if (ArtGameManager.instance._color == _color)
        {
            _image.color = _color;
            _text.gameObject.SetActive(false);
        }
        else
        {
            _text.gameObject.SetActive(true);
            ArtGameManager.instance.HeartAttack();
            _image.color = falseColor;
            ArtGameManager.instance.isCorrect = false;
        }
    }
}
