using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm_PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float bulletDelay = 0.2f;
    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private float speed = 4f;

    private Vector2 targetPosition = Vector2.zero;
    private Charm_GameManager gameManager = null;
    private SpriteRenderer spriteRenderer = null;

    void Start()
    {
        gameManager = FindObjectOfType<Charm_GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Fire());
    }

    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.minPosition.x, gameManager.maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, gameManager.minPosition.y, gameManager.maxPosition.y);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }
    private IEnumerator Fire()
    {
        while (true)
        {
           InstantiateOrSpawn();
            yield return new WaitForSeconds(bulletDelay);
        }
    }

    private void InstantiateOrSpawn()
    {
        GameObject bullet = null;
        if (gameManager.poolManager.transform.childCount > 0)
        {
            bullet = gameManager.poolManager.transform.GetChild(0).gameObject;
            bullet.SetActive(true);
        }
        else
        {
           bullet = Instantiate(bulletPrefab, bulletPosition);
        }

        bullet.transform.SetParent(null);
        bullet.transform.position = bulletPosition.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 여기다가 사망 처리
        if (isDamaged) return;
        StartCoroutine(Damaged());
    }

    private bool isDamaged = false;

    private IEnumerator Damaged()
    {
     
        if (!isDamaged)
        {
            isDamaged = true;
            gameManager.Dead();
            for (int i = 0; i < 3; i++)
            {
               // spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.2f);
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
            isDamaged = false;
        }
    }
}

