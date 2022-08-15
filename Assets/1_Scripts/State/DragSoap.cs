using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditorInternal.ReorderableList;

public class DragSoap : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler
{

    [SerializeField]
    ParticleSystem bubbleParticle;

    RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    Vector2 defaultPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
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
        if ((eventData.position.x >= 582 && eventData.position.x <= 910) && (eventData.position.y >= 1100 && eventData.position.y <= 1510))
        {
            GameManager.instance.UpNutrient(NutrientE.CLEAN, 10);
            bubbleParticle.Play();
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = rectTransform.anchoredPosition;
    }
}
