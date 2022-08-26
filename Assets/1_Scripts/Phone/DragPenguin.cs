using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragPenguin : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField, Header("착지속도")]
    float speed = 2f;
    
    Vector3 defaultPos;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
   
    // 드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        anim.SetBool("isDrag", true);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        defaultPos = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    // 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        mousePosition.z = 0;
        transform.position = Vector3.Lerp(transform.position, mousePosition, 5f);
        if(transform.position.x >= 4f)
        {
            transform.position = new Vector3(4, transform.position.y, 0);
        }
        else if(transform.position.x <= -4f)
        {
            transform.position = new Vector3(-4, transform.position.y, 0);
        }
        else if(transform.position.y<-5.7f)
        {

            transform.position = new Vector3(transform.position.x, -5.7f, 0);
        }
    }

    // 드래그 멈춤
    public void OnEndDrag(PointerEventData eventData)
    {
        anim.SetBool("isDrag", false);
        defaultPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, 0f));
        defaultPos.y = -5.7f;
        defaultPos.z = 0f;
        if (defaultPos.x >= 4f)
        {
            defaultPos.x = 4;
        }
        else if (defaultPos.x <= -4f)
        {
            defaultPos.x = -4;
        }
        StartCoroutine(MoveTo(gameObject, defaultPos));
    }

    // 떨어지는 코드
    IEnumerator MoveTo(GameObject a, Vector3 toPos)
    {
        float count = 0;
        Vector3 wasPos = a.transform.position;
        while(true)
        {
            count += Time.deltaTime;
            a.transform.position = Vector3.Lerp(wasPos, toPos, count*speed);

            if(count>=1)
            {
                a.transform.position = toPos;
                break;
            }
            yield return null;
        }
    }
}
