using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    
        private float gravity = 9.8f;

        private float mVelocity = 0f;

        private PoolManager poolManager;
        private void Awake()
        {
        poolManager = GetComponent<PoolManager>();
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
            //transform.SetParent(poolManager.transform, false);
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            //transform.SetParent(poolManager.transform, false);
            //gameObject.SetActive(false);
        }
    }


}
