using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradePanel : MonoBehaviour
{
    public int inven_UpgMaxCount;
    public int inven_UpgradeCost;
    public int inven_UpgCostAddition;
    public int mine_UpgCostAddition;

    public int itemStartMaxCount = 30;
    public int additionInven = 10;

    public Text invenCost;
    public Text mineCost;

    void Start()
    {
        // 나중에 setActive하면 이거 이사가야됨 bool 둬서 엌 ㄱ
        invenCost.text = inven_UpgradeCost.ToString();
        mineCost.text = PlayerData.instance.info.mineCurrCost.ToString();

        ItemManager.instance.SetItemMaxCount(Item.ItemType.Wood, itemStartMaxCount);
        ItemManager.instance.SetItemMaxCount(Item.ItemType.Bronze, itemStartMaxCount);
        ItemManager.instance.SetItemMaxCount(Item.ItemType.Silver, itemStartMaxCount);
        ItemManager.instance.SetItemMaxCount(Item.ItemType.Gold, itemStartMaxCount);

        ItemManager.instance.commit();
    }

    void Update()
    {
    }
    public void OnInvenUpgrade()
    {

        if (PlayerData.instance.info.playerGold >= inven_UpgradeCost && 0 < inven_UpgMaxCount)
        {
            PlayerData.instance.info.playerGold -= inven_UpgradeCost;


            inven_UpgradeCost += inven_UpgCostAddition;
            ItemManager.instance.AddMaxCount(Item.ItemType.Wood, additionInven);
            ItemManager.instance.AddMaxCount(Item.ItemType.Bronze, additionInven);
            ItemManager.instance.AddMaxCount(Item.ItemType.Silver, additionInven);
            ItemManager.instance.AddMaxCount(Item.ItemType.Gold, additionInven);
            ItemManager.instance.commit();

            invenCost.text = inven_UpgradeCost.ToString();

        }
    }

    public void OnMineUpgrade()
    {
        if(PlayerData.instance.info.playerGold >= PlayerData.instance.info.mineCurrCost)
        {
            PlayerData.instance.info.playerGold -= PlayerData.instance.info.mineCurrCost;

            PlayerData.instance.info.mineCurrCost += mine_UpgCostAddition;
            PlayerData.instance.info.mineCurrDmg++;
            GameObject.FindObjectOfType<Player>().damage =  PlayerData.instance.info.mineCurrDmg;
            mineCost.text = PlayerData.instance.info.mineCurrCost.ToString();
        }
    }


}
