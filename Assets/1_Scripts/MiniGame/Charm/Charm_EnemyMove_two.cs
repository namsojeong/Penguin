using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm_EnemyMove_two : Charm_EnemyMove
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletDelay = 0.5f;

    private float timer = 0f;
    private Vector3 diff = Vector3.zero;
    private float rotationZ = 0f;

    private GameObject newBullet = null;
    private Charm_PlayerMove player = null;

    protected override void Start()
    {
        base.Start();
        player = FindObjectOfType<Charm_PlayerMove>();
    }

    protected override void Update()
    {
        if (isDead) return;
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= bulletDelay)
        {
            timer = 0f;
            // �Ѿ� ����
            newBullet = Instantiate(bulletPrefab, transform);
            // �θ� ����
            newBullet.transform.SetParent(null);

            // ���� ���� (�÷��̾ ���� ���)
            diff = transform.position - player.transform.position;
            diff.Normalize();
            rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 90f);
        }

        if (transform.position.x < gameManager.minPosition.x - 2f)
        {
            Destroy(gameObject);
        }
    }
}
