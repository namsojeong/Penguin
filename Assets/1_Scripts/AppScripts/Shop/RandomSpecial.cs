using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpecial : MonoBehaviour
{
    [SerializeField]
    Text priceText;
    [SerializeField]
    GameObject[] specialGet;


    [SerializeField, Header("Special panel")]
    GameObject specialPanel;
    [SerializeField]
    Text nameText;
    [SerializeField]
    Image itemImage;

    [SerializeField]
    Button buyButton;

    [SerializeField]
    Sprite[] itemSprites;
    int price;
    private void Awake()
    {
        buyButton.onClick.AddListener(() => BuyRandom());
    }

    private void Start()
    {
        CantBuy();
    }
    private void OnEnable()
    {
        CantBuy();
    }

    private void CantBuy()
    {
        if (GameManager.instance.CurrentUser.coin < price)
        {
            buyButton.image.color = Color.red;
            buyButton.interactable = false;
        }
        else
        {
            buyButton.image.color = Color.white;
            buyButton.interactable = true;
        }
    }
    private void UpdatePrice()
    {
        priceText.text = string.Format($"{price} Coin");
        
    }
    private void UpPrice()
    {
        price = GameManager.instance.CurrentUser.ranPrice;
        price += 10000;
        GameManager.instance.CurrentUser.ranPrice = price;
        UpdatePrice();
    }

    public void BuyRandom()
    {
        if (GameManager.instance.CurrentUser.coin < price)
        {
            return;
        }
        GameManager.instance.PlusCoin(-price);
        UpPrice();
        int maxRan = GameManager.instance.CurrentUser.specialItems.Count;
        int itemIndex = Random.Range(0, maxRan);
        GetItem(itemIndex);
    }

    void GetItem(int i)
    {
        if (GameManager.instance.CurrentUser.specialItems[i].isGet)
        {
            nameText.text = string.Format("²Î !");
            itemImage.sprite = itemSprites[GameManager.instance.CurrentUser.specialItems.Count];
        }
        else
        {
            nameText.text = string.Format($"{GameManager.instance.CurrentUser.specialItems[i].name}");
            itemImage.sprite = itemSprites[i];
            GameManager.instance.CurrentUser.specialItems[i].isGet = true;
        }
        specialPanel.SetActive(true);

        CantBuy();

    }
}
