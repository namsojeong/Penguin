using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    
        private float gravity = 9.8f;

        private float mVelocity = 0f;

        public StudyM sm;

        private void Start()
      {
        sm = GetComponent<StudyM>();
         }

    void Update()
        {
            Vector3 current = gameObject.transform.position;

            mVelocity += gravity * Time.deltaTime;

            current.y -= mVelocity * Time.deltaTime;
            gameObject.transform.position = current;
        }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Col")
        {
        transform.SetParent(sm.poolManager.transform, false);
        gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            transform.SetParent(sm.poolManager.transform, false);
            gameObject.SetActive(false);
        }
    }


}
