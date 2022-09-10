using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    string itemName;

    EventParam eventParam = new EventParam();

    RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    [SerializeField] AudioClip eatSound;
    Vector2 defaultPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    
    void CheckFeed()
    {
        int plusHungry = 0;
        if (GameManager.Instance.CurrentUser.hungry >= 100)
        {
            GameManager.Instance.CurrentUser.hungry = 100;
            return;
        }
        if (itemName == "SHRIMP")
        {
            if (GameManager.Instance.CurrentUser.shrimpCnt <= 0) return;
            plusHungry = 10;
        }
        else if (itemName == "SQUID")
        {
            if (GameManager.Instance.CurrentUser.squidCnt <= 0) return;
            plusHungry = 15;
        }
        else if (itemName == "FISH")
        {
            if (GameManager.Instance.CurrentUser.fishCnt <= 0) return;
            plusHungry = 20;
        }
        eventParam.stringParam = itemName;
        EventManager.TriggerEvent("USEFOOD", eventParam);
        GameManager.Instance.UpNutrient(NutrientE.HUNGRY, plusHungry);
        SoundManager.instance.SFXPlay(eatSound);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = defaultPos;
        if ((eventData.position.x >= 460 && eventData.position.x <= 870) && (eventData.position.y >= 1200 && eventData.position.y <= 1530))
        {
            CheckFeed();
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = rectTransform.anchoredPosition;
    }
}