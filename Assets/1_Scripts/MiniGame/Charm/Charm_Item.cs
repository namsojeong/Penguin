
using UnityEngine;

public enum ItemType { powerUp = 0, getCoin = 1,}

public class Charm_Item : MonoBehaviour
{

    [SerializeField]
    private ItemType itemType;
    private Charm_Movement2D movement2D;

    private int speed=5;

    void Awake()
    {
        movement2D = GetComponent<Charm_Movement2D>();

        Destroy(gameObject, 2);
        //float x = Random.Range(-1.0f, 1.0f);
        //float y = Random.Range(1.0f, 1.0f);



        // movement2D.MoveTo(new Vector3(x, y, 0));

    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Use(collision.gameObject);
            Destroy(gameObject);

           
           
        }
    }

    public void Use(GameObject player)
    {
        switch(itemType)
        {
            case ItemType.powerUp:
                Charm_EnemyMove.countdownSeconds = 30;

                var clones = GameObject.FindGameObjectsWithTag("Item");
                foreach (var clone in clones)
                {
                    Destroy(clone);
                }
                break;

            case ItemType.getCoin:
                
                break;
        }
    }
}
