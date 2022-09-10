using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSoap : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler
{

    [SerializeField]
    ParticleSystem bubbleParticle;
    [SerializeField] AudioClip bubbleSound;

    RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    Vector2 defaultPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ���� �̵��� ���ؼ� �󸶳� �̵��ߴ����� ������
        // ĵ������ �����ϰ� ����� �ϱ� ������
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = defaultPos;
        if ((eventData.position.x >= 582 && eventData.position.x <= 910) && (eventData.position.y >= 1100 && eventData.position.y <= 1510))
        {
            GameManager.Instance.UpNutrient(NutrientE.CLEAN, 10);
            SoundManager.instance.SFXPlay(bubbleSound);
            bubbleParticle.Play();
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = rectTransform.anchoredPosition;
    }
}
