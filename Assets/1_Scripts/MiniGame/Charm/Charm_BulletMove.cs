using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm_BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Charm_GameManager gameManager = null;
    void Start()
    {
        gameManager = FindObjectOfType<Charm_GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        CheckLimit();
    }

    private void CheckLimit()
    {
        if (transform.position.y > gameManager.maxPosition.y + 2f)
        {
            Despawn();
        }
        if (transform.position.y < gameManager.minPosition.y - 2f)
        {
            Despawn();
        }
        if (transform.position.x > gameManager.maxPosition.x + 2f)
        {
            Despawn();
        }
        if (transform.position.x < gameManager.minPosition.x - 2f)
        {
            Despawn();
        }
    }

    public void Despawn()
    {
        transform.SetParent(gameManager.poolManager.transform, false);
        gameObject.SetActive(false);
       
    }
}
