using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpecial : MonoBehaviour
{
    [SerializeField, Header("스페셜아이템 갯수")]
    int specialItemCnt = 2;

    [SerializeField]
    Text priceText;
    [SerializeField]
    GameObject[] specialGet;

    [SerializeField]
    ParticleSystem allParticle;


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

    int price = 0;

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

    // 가진 코인으로 살 수 있는지 비교
    private void CantBuy()
    {
        if (GameManager.instance.CurrentUser.isSpecialAll)
        {
            buyButton.interactable = false;
            buyButton.image.color = Color.red;
            priceText.text = string.Format("All Collect");
            return;
        }
        if (!GameManager.instance.CurrentUser.isTryRan)
        {
            GameManager.instance.CurrentUser.isTryRan = true;
            buyButton.interactable = true;
            buyButton.image.color = Color.white;
            priceText.text = string.Format("무료");
            return;
        }
        if (GameManager.instance.CurrentUser.coin < price)
        {
            UpdatePrice();
            buyButton.image.color = Color.red;
            buyButton.interactable = false;
        }
        else
        {
            UpdatePrice();
            buyButton.image.color = Color.white;
            buyButton.interactable = true;
        }
    }

    // 가격 UI 업데이트
    private void UpdatePrice()
    {
        priceText.text = string.Format($"{price} Coin");
    }

    // 뽑기 가격 증가
    private void UpPrice()
    {
        price = GameManager.instance.CurrentUser.ranPrice;
        price += 10000;
        GameManager.instance.CurrentUser.ranPrice = price;
        UpdatePrice();
    }

    // 뽑기 구매
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

    // 랜덤 아이템 획득
    void GetItem(int i)
    {
        if (GameManager.instance.CurrentUser.specialItems[i].isGet)
        {
            nameText.text = string.Format("꽝 !");
            itemImage.sprite = itemSprites[GameManager.instance.CurrentUser.specialItems.Count];
        }
        else
        {
            int cnt = GameManager.instance.CurrentUser.specialCnt;
            GameManager.instance.CurrentUser.specialCnt++;
            cnt++;
            nameText.text = string.Format($"{GameManager.instance.CurrentUser.specialItems[i].name}");
            itemImage.sprite = itemSprites[i];
            GameManager.instance.CurrentUser.specialItems[i].isGet = true;
            if (cnt == specialItemCnt)
            {
                GameManager.instance.CurrentUser.isSpecialAll = true;
                buyButton.interactable = false;
                buyButton.image.color = Color.red;
                priceText.text = string.Format("All Collect");
                AllCollectEffect();
            }

        }
        specialPanel.SetActive(true);
        CantBuy();
    }

    // 다 모았을 때
    void AllCollectEffect()
    {
        GameManager.instance.PlusCoin(10000);
        allParticle.Play();
    }

 
}
