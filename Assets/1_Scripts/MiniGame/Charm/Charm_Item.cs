
using UnityEngine;

public enum ItemType { powerUp = 0,}

public class Charm_Item : MonoBehaviour
{

    [SerializeField]
    private ItemType itemType;
    private Charm_Movement2D movement2D;

    void Awake()
    {
        movement2D = GetComponent<Charm_Movement2D>();

        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(1.0f, 1.0f);

        movement2D.MoveTo(new Vector3(x, y, 0));

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
                player.GetComponent<Charm_PlayerMove>().AttackLevel++;
                Debug.Log("파워업해");
                break;
        }
    }
}
