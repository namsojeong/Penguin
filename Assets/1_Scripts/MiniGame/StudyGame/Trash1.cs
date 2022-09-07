using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash1 : MonoBehaviour
{

    private float gravity = 9.8f;

    private float mVelocity = 0f;


    void Update()
    {
        Vector3 current = gameObject.transform.position;

        mVelocity += gravity * Time.deltaTime * StudyM.instance.difficult;

        current.y -= mVelocity * Time.deltaTime;
        gameObject.transform.position = current;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Col")
        {


            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


}
