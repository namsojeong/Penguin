using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    string itemName;
    [SerializeField]
    GameObject fish;

    EventParam eventParam = new EventParam();

    RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    [SerializeField] AudioClip eatSound;
    [SerializeField] Animator eatAnim;
    Vector2 defaultPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    
    void OnEnable()
    {
        EndEat();
    }
    void CheckFeed()
    {
        int plusHungry = 0;
        if (GameManager.instance.CurrentUser.hungry >= 100)
        {
            GameManager.instance.CurrentUser.hungry = 100;
            return;
        }
        if (itemName == "SHRIMP")
        {
            if (GameManager.instance.CurrentUser.shrimpCnt <= 0) return;
            plusHungry = 10;
        }
        else if (itemName == "SQUID")
        {
            if (GameManager.instance.CurrentUser.squidCnt <= 0) return;
            plusHungry = 15;
        }
        else if (itemName == "FISH")
        {
            if (GameManager.instance.CurrentUser.fishCnt <= 0) return;
            plusHungry = 20;
        }
        eventParam.stringParam = itemName;
        eatAnim.SetTrigger("Eat");
        fish.SetActive(false);
        Invoke("EndEat", 1.5f);
        EventManager.TriggerEvent("USEFOOD", eventParam);
        GameManager.instance.UpNutrient(NutrientE.HUNGRY, plusHungry);
        SoundManager.instance.SFXPlay(eatSound);
    }

    void EndEat()
    {
        fish.SetActive(true);
    }
    public void OnDrag(PointerEventData eventData)
    {
        // 이전 이동과 비교해서 얼마나 이동했는지를 보여줌
        // 캔버스의 스케일과 맞춰야 하기 때문에
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