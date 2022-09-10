using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("주문서")]
    [SerializeField, Header("물품 BUY Panel")]
    GameObject realBuyPanel;
    [SerializeField, Header("물품 이미지")]
    Image itemImage;
    [SerializeField, Header("물품 이름")]
    Text itemName;
    [SerializeField, Header("물품 가격")]
    Text itemPrice;

    [SerializeField, Header("비쌈")]
    GameObject expensive;
    [SerializeField, Header("비쌈")]
    GameObject appCanvas;
    [SerializeField, Header("비쌈")]
    GameObject cha;

    [SerializeField]
    Text coinText;
    [SerializeField]
    Button[] itemBuyButton;
    
    [SerializeField]
    Sprite[] itemSprites;
    [SerializeField]
    GameObject[] itemHave;

    EventParam eventParam = new EventParam();
    ItemTypeE choiceItem;

    private void Awake()
    {
        itemBuyButton[0].onClick.AddListener(() => BuyRibbon());
        itemBuyButton[1].onClick.AddListener(() => BuyClothes());
        itemBuyButton[2].onClick.AddListener(() => BuyPants());
    }
    private void OnEnable()
    {
        CheckCoin();
        CheckHaveItem();
    }
    public void CheckCoin()
    {
        coinText.text = string.Format($"COIN : {GameManager.Instance.CurrentUser.coin}");
    }
    void CheckHaveItem()
    {
        for (int i = 0; i < 3; i++)
        {
            itemHave[i].SetActive(GameManager.Instance.CurrentUser.items[i].isGet);
        }
    }
    private void BuyRibbon()
    {
        choiceItem = ItemTypeE.RIBBON;
        UpdateMenuUI();
    }

    private void BuyClothes()
    {
        choiceItem = ItemTypeE.CLOTHES;
        UpdateMenuUI();
    }
    
    private void BuyPants()
    {
        choiceItem = ItemTypeE.PANTS;
        UpdateMenuUI();
    }

    void UpdateMenuUI()
    {
        itemName.text = string.Format($"{GameManager.Instance.CurrentUser.items[(int)choiceItem].name}");
        itemPrice.text = string.Format($"{GameManager.Instance.CurrentUser.items[(int)choiceItem].price}");
        itemImage.sprite = itemSprites[(int)choiceItem];
        realBuyPanel.SetActive(true);
    }

    public void YesBuy()
    {
        realBuyPanel.SetActive(false);
        if (GameManager.Instance.CurrentUser.coin < GameManager.Instance.CurrentUser.items[(int)choiceItem].price)
        {
            appCanvas.SetActive(true);
            cha.SetActive(true);
            expensive.SetActive(true);
            Invoke("ExpensiveOff", 2f);
        }
        else
        {
            GameManager.Instance.CurrentUser.items[(int)choiceItem].isGet = true;
            GameManager.Instance.PlusCoin(-(GameManager.Instance.CurrentUser.items[(int)choiceItem].price));
            itemHave[(int)choiceItem].SetActive(true);
        }
    }
    void ExpensiveOff()
    {
        expensive.SetActive(false);
    }

}
