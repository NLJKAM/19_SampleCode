using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static PotionControl;

public class Shop : MonoBehaviour
{
    [System.Serializable]
    public class ShopItemList
    {
        public GameObject shopItemImage;
        public int itemCost;
        public ItemType type;
    }
    public List<ShopItemList> shopList;

    public GameObject purchasePanel;
    public GameObject waringPanel;
    public Text goldText;
    int itemIndexNum;
    
    void Update()
    {
        goldText.text = $"Gold : {PlayerManager.instance.playerGold}";
    }
    public void ExitPanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void PurchaseNotice(int indexNum)
    {
        itemIndexNum = indexNum;
        purchasePanel.SetActive(true);
    }
    public void Purchase()
    {
        //될경우
        if (shopList[itemIndexNum].itemCost <= PlayerManager.instance.playerGold)
        {
            PlayerManager.instance.playerGold -= shopList[itemIndexNum].itemCost;
            Inventory.instance.ClassifyAndCreateItem(shopList[itemIndexNum].type, shopList[itemIndexNum].shopItemImage);
        }
        else if (shopList[itemIndexNum].itemCost > PlayerManager.instance.playerGold)//안될경우
        {
            waringPanel.SetActive(true);
        }
        purchasePanel.SetActive(false);
    }
}
