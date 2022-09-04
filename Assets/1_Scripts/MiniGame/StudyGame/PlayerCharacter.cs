using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    [Header("Player")]
    public int spd;


    private Vector2 targetPosition = Vector2.zero;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, -2.1f, 2.1f);
            targetPosition.y = Mathf.Clamp(targetPosition.y, -3.61f, -3.6f );
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, spd * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Recyclablewaste"))
        {
            StudyM.instance.AddScore();
            SoundManager.instance.Soundeffect();
            StudyM.instance.OverText();
        }
        if(collision.gameObject.CompareTag("GeneralWaste"))
        {
            UIM.instance.OverPenel();
            Time.timeScale = 0;
        }

    }
}
