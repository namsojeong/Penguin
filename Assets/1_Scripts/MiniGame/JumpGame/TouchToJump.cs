using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToJump : MonoBehaviour
{
    [SerializeField]
    float jumpPower;
    [SerializeField]
    GameObject[] lifeImage;
    [SerializeField]
    AudioClip damageSound;


    Rigidbody2D rigid;

    int life = 3;
    bool isDamage = false;
    SpriteRenderer spriteRenderer;

    EventParam eventParam = new EventParam();

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        ResetPlayer();
    }

    public void TouchJump()
    {
        rigid.velocity = Vector2.up * jumpPower;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDamage||collision.collider.tag=="WALL") return;
        life--;
        SoundManager.instance.SFXPlay(damageSound);
        lifeImage[life].SetActive(false);
        if (life <= 0)
        {
            Dead();
        }
        else
        {
            StartCoroutine(DamageEffect());
        }
    }

    void Dead()
    {
        EventManager.TriggerEvent("JumpGame_Over", eventParam);
        PoolManager.instance.GameOver();
        ResetPlayer();
    }

    IEnumerator DamageEffect()
    {   
        isDamage = true;
        for(int i = 0; i < 5; i++)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0);
         yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.2f);
        }
        spriteRenderer.color = new Color(1, 1, 1, 1);
        isDamage = false;
    }

    void ResetPlayer()
    {
        LifeReset();
        transform.position = Vector3.zero;
    }

    void LifeReset()
    {
        life = 3;
        lifeImage[0].SetActive(true);
        lifeImage[1].SetActive(true);
        lifeImage[2].SetActive(true);
    }
}
