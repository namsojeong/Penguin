using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleButton : MonoBehaviour
{
    [SerializeField]
    int num;
    [SerializeField]
    Color defaultColor;

    Text _text;
    Image _image;
    Color _color;
    Button _button; 

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
    }

    void MyColorSet()
    {
        _text.text = string.Format($"{num}");
        switch(num)
        {
            case 1: {
                _color = Color.red;
                break;
                }
            case 2: {
                _color = Color.yellow;
                break;
                }
            case 3: {
                _color = Color.cyan;
                break;
                }
        }
    }

    public void ClickMe()
    {
        Debug.Log("¤±¤¤¤·");
        _image.color = _color;
        _text.gameObject.SetActive(false);
    }
}
