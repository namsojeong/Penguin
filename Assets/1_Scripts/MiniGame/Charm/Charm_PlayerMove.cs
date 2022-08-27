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

    [SerializeField]
    private int attackLevel = 1;

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
            AttackByLevel();
           //InstantiateOrSpawn();
            yield return new WaitForSeconds(bulletDelay);
        }
    }

    void AttackByLevel()
    {
        GameObject bullet = null;

        switch(attackLevel)
        {
            case 1 :
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                break;
            case 2 :
                Instantiate(bulletPrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(bulletPrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 3:
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Charm_Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Charm_Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                break;


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

        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(Damaged());
        }

        if (collision.CompareTag("Bullet"))
        {
            
        }

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
              
                spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.2f);
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
            isDamaged = false;
        }
    }
}

