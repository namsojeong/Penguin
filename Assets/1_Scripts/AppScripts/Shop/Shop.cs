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
        coinText.text = string.Format($"COIN : {GameManager.instance.CurrentUser.coin}");
    }
    void CheckHaveItem()
    {
        for (int i = 0; i < 3; i++)
        {
            itemHave[i].SetActive(GameManager.instance.CurrentUser.items[i].isGet);
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
        itemName.text = string.Format($"{GameManager.instance.CurrentUser.items[(int)choiceItem].name}");
        itemPrice.text = string.Format($"{GameManager.instance.CurrentUser.items[(int)choiceItem].price}");
        itemImage.sprite = itemSprites[(int)choiceItem];
        realBuyPanel.SetActive(true);
    }

    public void YesBuy()
    {
        realBuyPanel.SetActive(false);
        if (GameManager.instance.CurrentUser.coin < GameManager.instance.CurrentUser.items[(int)choiceItem].price)
        {
            expensive.SetActive(true);
            Invoke("ExpensiveOff", 2f);
        }
        else
        {
            GameManager.instance.CurrentUser.items[(int)choiceItem].isGet = true;
            GameManager.instance.PlusCoin(-(GameManager.instance.CurrentUser.items[(int)choiceItem].price));
            itemHave[(int)choiceItem].SetActive(true);
        }
    }
    void ExpensiveOff()
    {
        expensive.SetActive(false);
    }

    //private int randomCoin = 0;
    //int price;
    //int cnt = 0;

    //private void Start()
    //{
    //    for(int i=0;i<10;i++)
    //    {
    //        randomCoin += 10;
    //        coinPrice[i] = (int)(randomCoin * 0.5);
    //    }
    //}
    //public void CoinSequence()
    //{
    //    if(cnt+1 <5)
    //    {
    //        price += coinPrice[cnt++];
    //    }
    //    else
    //    {
    //        cnt = 0;
    //        price += coinPrice[cnt++];
    //    }

    //    ranCoinText.text = string.Format($"{price}");
    //}


    //public void RandomBox()
    //{
    //    int ran = Random.Range(0, 101);

    //    if(ran<50)
    //    {
    //        // 악세사리 아이템
    //    }
    //    else
    //    {
    //        // 배경화면 아이템
    //    }
    //}
}
