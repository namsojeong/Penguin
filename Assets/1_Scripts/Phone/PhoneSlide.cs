using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneSlide : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    [SerializeField]
    float speed;

    private Vector2 defaultPos;
    private Vector3 movePos;
    private Vector2 nowPos;
    private Vector2 offset;
    private Vector2 prePos;

    void Update()
    {
        if (Input.touchCount==1)
        {
            Touch touch = Input.GetTouch(0);
            defaultPos = panel.transform.position;
            if (touch.phase == TouchPhase.Began)
            {
                offset = touch.position - defaultPos;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Time.deltaTime * speed;
                movePos.x -= offset.x;
                panel.transform.Translate(movePos);
                prePos = touch.position - touch.deltaPosition;
            }
        }
    }

    
}
