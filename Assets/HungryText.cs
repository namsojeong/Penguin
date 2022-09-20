using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryText : MonoBehaviour
{
    [SerializeField]
    RectTransform hungryPopup;

    [SerializeField, Header("�˸� �̵���ġ")]
    Vector2 nextpos;
    Vector2 defPos;

    private void Start()
    {
        EventManager.StartListening("SoHungry", HungryPopUp);
    }
    private void OnDestroy()
    {
        EventManager.StopListening("SoHungry", HungryPopUp);
    }

    void HungryPopUp(EventParam eventParam)
    {
        defPos = hungryPopup.anchoredPosition;
        hungryPopup.anchoredPosition = nextpos;
        Invoke("PopupOff", 1.5f);
    }

    void PopupOff()
    {
        hungryPopup.anchoredPosition = defPos;
    }
}
