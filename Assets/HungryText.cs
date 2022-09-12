using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryText : MonoBehaviour
{
    float fEndPos = -684f;
    Vector3 startPos;

    private void Start()
    {
        EventManager.StartListening("SoHungry", MoveOn);
        startPos = transform.position;
    }
    private void OnDestroy()
    {
        EventManager.StopListening("SoHungry", MoveOn);
    }

    void MoveOn(EventParam eventParam)
    {
        StartCoroutine(LeftMove());
    }

    IEnumerator LeftMove()
    {
        while (true)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 100f);
            if (transform.position.x <= fEndPos)
            {
                transform.position = startPos;
                break;
            }
            yield return null;
        }
    }
}
