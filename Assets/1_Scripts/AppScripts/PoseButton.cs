using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemShuffle;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PoseButton : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public Image nomalImage;
    public Sprite[] changeSprite;

    public void ChangePose()
    {
        Array.shuffl(changeSprite);

        Sprite chSprite = changeSprite[0];
        nomalImage.sprite = chSprite;
    }

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
        float rectX = rectTransform.anchoredPosition.x;
        float rectY = rectTransform.anchoredPosition.y;
        if (rectX <= -574f)
        {
            rectX = -574f;
        }
        else if (rectX > 574f)
        {
            rectX = 574f;
        }
        if (rectY <= 422f)
        {
            rectY = 422f;
        }
        else if (rectY > 1828f)
        {
            rectY = 1828f;
        }
        rectTransform.anchoredPosition = new Vector2(rectX, rectY);
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = rectTransform.anchoredPosition;
    }
}
