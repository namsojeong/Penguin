using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 defaultPos;
    private Vector2 enterPos;

    EventParam eventParam = new EventParam();

    [SerializeField]
    string itemName;

    void Start()
    {
        enterPos = transform.position;
        enterPos.y = transform.position.y + 800;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;


    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = defaultPos;

        if (Mathf.Abs(mousePos.x) <= 1.1f && Mathf.Abs(mousePos.y) <= 1.1f)
        {
            eventParam.stringParam = itemName;
            EventManager.TriggerEvent("USEFOOD", eventParam);
            eventParam.nutParam = NutrientE.HUNGRY;
            eventParam.intParam = 10;
            EventManager.TriggerEvent("FEED", eventParam);
            this.transform.position = defaultPos;
        }

    }

}