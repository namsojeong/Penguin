using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    [Header("Player")]
    public int spd;

    public GameObject overPanel;

    private Vector2 targetPosition = Vector2.zero;
    void Start()
    {
        overPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, -1.6f, 1.6f);
            targetPosition.y = Mathf.Clamp(targetPosition.y, -3.25f,-3.25f );
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, spd * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Recyclablewaste"))
        {
            StudyM.instance.AddScore();

        }
        if(collision.gameObject.CompareTag("GeneralWaste"))
        {
            overPanel.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
