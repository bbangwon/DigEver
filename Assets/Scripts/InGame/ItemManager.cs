using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{

    private MinMaxManager count_gold = new MinMaxManager();
    private MinMaxManager count_silver = new MinMaxManager();
    private MinMaxManager count_bronze = new MinMaxManager();
    private MinMaxManager count_wood = new MinMaxManager();

    public Text txtGoldCount;
    public Text txtSilverCount;
    public Text txtBronzeCount;
    public Text txtWoodCount;

    public int costGold = 50;
    public int costSilver = 30;
    public int costBronze = 10;
    public int costWood = 5;

    //탭 이동등을 할때 사용할 백업본.
    //commit이 호출되면 변경된 내용을 다시 백업. commit은 판매나 조합을 완료했을때 호출.
    private MinMaxManager count_gold_backup = new MinMaxManager();
    private MinMaxManager count_silver_backup = new MinMaxManager();
    private MinMaxManager count_bronze_backup = new MinMaxManager();
    private MinMaxManager count_wood_backup = new MinMaxManager();


    public static ItemManager instance;

    public void commit()
    {
        count_gold_backup.SetMaxCount(count_gold.GetMaxCount());
        count_gold_backup.SetCount(count_gold.GetCount());

        count_silver_backup.SetMaxCount(count_silver.GetMaxCount());
        count_silver_backup.SetCount(count_silver.GetCount());

        count_bronze_backup.SetMaxCount(count_bronze.GetMaxCount());
        count_bronze_backup.SetCount(count_bronze.GetCount());

        count_wood_backup.SetMaxCount(count_wood.GetMaxCount());
        count_wood_backup.SetCount(count_wood.GetCount());

    }
    public void rollback()
    {
        count_gold.SetMaxCount(count_gold_backup.GetMaxCount());
        count_gold.SetCount(count_gold_backup.GetCount());

        count_silver.SetMaxCount(count_silver_backup.GetMaxCount());
        count_silver.SetCount(count_silver_backup.GetCount());

        count_bronze.SetMaxCount(count_bronze_backup.GetMaxCount());
        count_bronze.SetCount(count_bronze_backup.GetCount());

        count_wood.SetMaxCount(count_wood_backup.GetMaxCount());
        count_wood.SetCount(count_wood_backup.GetCount());

    }

    void Awake()
    {
        ItemManager.instance = this;
    }


    public Sprite GetItemSprite(Item.ItemType type)
    {
        Sprite itemSprite = null;
        switch (type)
        {
            case Item.ItemType.Gold:
                itemSprite = Resources.Load<Sprite>("InGame/img_ gold");
                break;
            case Item.ItemType.Silver:
                itemSprite = Resources.Load<Sprite>("InGame/img_ sliver");
                break;
            case Item.ItemType.Bronze:
                itemSprite = Resources.Load<Sprite>("InGame/img_ bronze");
                break;
            case Item.ItemType.Wood:
                itemSprite = Resources.Load<Sprite>("InGame/img_ wood");
                break;
        }
        return itemSprite;
    }


    void Update()
    {
        txtGoldCount.text = count_gold.toString();
        txtSilverCount.text = count_silver.toString();
        txtBronzeCount.text = count_bronze.toString();
        txtWoodCount.text = count_wood.toString();
    }

    public int GetCost(Item.ItemType type, int count = 1)
    {
        int retValue = 0;
        switch (type)
        {
            case Item.ItemType.Gold:
                retValue = costGold;
                break;
            case Item.ItemType.Silver:
                retValue = costSilver;
                break;
            case Item.ItemType.Bronze:
                retValue = costBronze;
                break;
            case Item.ItemType.Wood:
                retValue = costWood;
                break;
        }

        return retValue;

    }

    public void AddItemCount(Item.ItemType type, int count = 1)
    {
        switch (type)
        {
            case Item.ItemType.Gold:
                count_gold.addCount(count);
                break;
            case Item.ItemType.Silver:
                count_silver.addCount(count);
                break;
            case Item.ItemType.Bronze:
                count_bronze.addCount(count);
                break;
            case Item.ItemType.Wood:
                count_wood.addCount(count);
                break;

        }
    }
    public void AddMaxCount(Item.ItemType type, int count = 1)
    {
        switch (type)
        {
            case Item.ItemType.Gold:
                count_gold.addMaxCount(count);
                break;
            case Item.ItemType.Silver:
                count_silver.addMaxCount(count);
                break;
            case Item.ItemType.Bronze:
                count_bronze.addMaxCount(count);
                break;
            case Item.ItemType.Wood:
                count_wood.addMaxCount(count);
                break;
        }
    }
    public void SubItemCount(Item.ItemType type, int count = 1)
    {
        switch (type)
        {
            case Item.ItemType.Gold:
                count_gold.subCount(count);
                break;
            case Item.ItemType.Silver:
                count_silver.subCount(count);
                break;
            case Item.ItemType.Bronze:
                count_bronze.subCount(count);
                break;
            case Item.ItemType.Wood:
                count_wood.subCount(count);
                break;

        }
    }
    public void SetItemMaxCount(Item.ItemType type, int set = 1)
    {
        switch (type)
        {
            case Item.ItemType.Gold:
                count_gold.SetMaxCount(set);
                break;
            case Item.ItemType.Silver:
                count_silver.SetMaxCount(set);
                break;
            case Item.ItemType.Bronze:
                count_bronze.SetMaxCount(set);
                break;
            case Item.ItemType.Wood:
                count_wood.SetMaxCount(set);
                break;

        }
    }
    public void SubMaxCount(Item.ItemType type, int count = 1)
    {
        switch (type)
        {
            case Item.ItemType.Gold:
                count_gold.subMaxCount(count);
                break;
            case Item.ItemType.Silver:
                count_silver.subMaxCount(count);
                break;
            case Item.ItemType.Bronze:
                count_bronze.subMaxCount(count);
                break;
            case Item.ItemType.Wood:
                count_wood.subMaxCount(count);
                break;
        }
    }
    public int GetCount(Item.ItemType type)
    {
        int retValue = 0;
        switch (type)
        {
            case Item.ItemType.Gold:
                retValue = count_gold.GetCount();
                break;
            case Item.ItemType.Silver:
                retValue = count_silver.GetCount();
                break;
            case Item.ItemType.Bronze:
                retValue = count_bronze.GetCount();
                break;
            case Item.ItemType.Wood:
                retValue = count_wood.GetCount();
                break;
        }
        return retValue;
    }
    public int GetMaxCount(Item.ItemType type, int count = 1)
    {
        int retValue = 0;
        switch (type)
        {
            case Item.ItemType.Gold:
                retValue = count_gold.GetMaxCount();
                break;
            case Item.ItemType.Silver:
                retValue = count_silver.GetMaxCount();
                break;
            case Item.ItemType.Bronze:
                retValue = count_bronze.GetMaxCount();
                break;
            case Item.ItemType.Wood:
                retValue = count_wood.GetMaxCount();
                break;
        }
        return retValue;
    }
}
