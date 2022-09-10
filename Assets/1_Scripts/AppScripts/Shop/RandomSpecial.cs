using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpecial : MonoBehaviour
{
    [SerializeField, Header("����Ⱦ����� ����")]
    int specialItemCnt;

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

        price = GameManager.Instance.CurrentUser.ranPrice;
    }

    private void Start()
    {
        CantBuy();
    }
    private void OnEnable()
    {
        CantBuy();
    }

    // ���� �������� �� �� �ִ��� ��
    private void CantBuy()
    {
        if (GameManager.Instance.CurrentUser.isSpecialAll)
        {
            buyButton.interactable = false;
            buyButton.image.color = Color.red;
            priceText.text = string.Format("All Collect");
            return;
        }
        if (!GameManager.Instance.CurrentUser.isTryRan)
        {
            GameManager.Instance.CurrentUser.isTryRan = true;
            buyButton.interactable = true;
            buyButton.image.color = Color.white;
            priceText.text = string.Format("����");
            return;
        }
        if (GameManager.Instance.CurrentUser.coin < price)
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

    // ���� UI ������Ʈ
    private void UpdatePrice()
    {
        priceText.text = string.Format($"{price} Coin");
    }

    // �̱� ���� ����
    private void UpPrice()
    {
        price = GameManager.Instance.CurrentUser.ranPrice;
        price += 5000;
        GameManager.Instance.CurrentUser.ranPrice = price;
        UpdatePrice();
    }

    // �̱� ����
    public void BuyRandom()
    {
        if (GameManager.Instance.CurrentUser.coin < price)
        {
            return;
        }
        GameManager.Instance.PlusCoin(-price);
        UpPrice();
        int maxRan = GameManager.Instance.CurrentUser.specialItems.Count;
        int itemIndex = Random.Range(0, maxRan);
        GetItem(itemIndex);
    }

    // ���� ������ ȹ��
    void GetItem(int i)
    {
        if (GameManager.Instance.CurrentUser.specialItems[i].isGet)
        {
            nameText.text = string.Format("�� !");
            itemImage.sprite = itemSprites[GameManager.Instance.CurrentUser.specialItems.Count];
        }
        else
        {
            int cnt = GameManager.Instance.CurrentUser.specialCnt;
            GameManager.Instance.CurrentUser.specialCnt++;
            cnt++;
            nameText.text = string.Format($"{GameManager.Instance.CurrentUser.specialItems[i].name}");
            itemImage.sprite = itemSprites[i];
            GameManager.Instance.CurrentUser.specialItems[i].isGet = true;
            if (cnt == specialItemCnt)
            {
                GameManager.Instance.CurrentUser.isSpecialAll = true;
                buyButton.interactable = false;
                buyButton.image.color = Color.red;
                priceText.text = string.Format("All Collect");
                AllCollectEffect();
            }

        }
        specialPanel.SetActive(true);
        CantBuy();
    }

    // �� ����� ��
    void AllCollectEffect()
    {
        GameManager.Instance.PlusCoin(10000);
        allParticle.Play();
    }

 
}
