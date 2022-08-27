using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm_EnemyMove : MonoBehaviour
{
    [SerializeField]
    private int score = 10;
   // [SerializeField]
    private int hp = 3;
    [SerializeField]
    protected float speed = 0.3f;

    private bool isDamaged = false;
    protected bool isDead = false;

    protected Charm_GameManager gameManager = null;
    private Animator animator = null;
    private Collider2D col = null;
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private GameObject[] itemprefab;

    
    protected virtual void Start()
    {
        gameManager = FindObjectOfType<Charm_GameManager>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        if (isDead) return;
        transform.Translate(Vector2.down  * speed * Time.deltaTime);


       
        if (transform.position.y < gameManager.minPosition.y - 5f)
        {

          
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.CompareTag("Bullet"))
        {
            Charm_BulletMove bullet = collision.GetComponent<Charm_BulletMove>();
            if (bullet != null)
            {
               bullet.Despawn();
            }
            if (isDamaged) return;
            isDamaged = true;
            StartCoroutine(Damaged());

            //Debug.Log(hp);

            if (hp <= 0)
            {
                isDead = true;
                col.enabled = false;
                gameManager.AddScore(score);
                StartCoroutine(Dead());
            }

        }
    }

    private IEnumerator Damaged()
    {
        //spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0f));
        hp--;
        yield return new WaitForSeconds(0.1f);
        //spriteRenderer.material.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
        isDamaged = false;
    }

    private IEnumerator Dead()
    {
        spriteRenderer.material.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
      //  animator.Play("Explosion");
        yield return new WaitForSeconds(0.5f);
       Destroy(gameObject);


        //적 죽고 아이템 스폰
        SpawnItem();
    }

    void SpawnItem()
    {
        int spawnItem = Random.Range(0, 100);
        if(spawnItem < 10)
        {
            Instantiate(itemprefab[0], transform.position, Quaternion.identity);
        }
    }
}
