using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MixManager : MonoBehaviour
{
    public GameObject ItemSlot1;
    public GameObject ItemSlot2;

    bool ItemSlot1Selected = false;
    bool ItemSlot2Selected = false;
    Item.ItemType ItemSlot1Type;
    Item.ItemType ItemSlot2Type;

    public static MixManager instance;

    void Awake()
    {
        MixManager.instance = this;
    }

    void Start()
    {
    }

    public void rollback()  //탭 이동시 롤백.
    {
        ItemErase(1);
        ItemErase(2);
    }

    public void ItemSelect(Item.ItemType type)
    {
        GameObject ItemChild = null;
        if (ItemSlot1Selected == false)
        {
            ItemChild = ItemSlot1.transform.GetChild(0).gameObject;
            ItemSlot1Selected = true;
            ItemSlot1Type = type;

            Button b = ItemChild.GetComponent<Button>();
            if (b == null)
                b = ItemChild.AddComponent<Button>();
            b.onClick.RemoveAllListeners();
            b.onClick.AddListener(() => { ItemErase(1, true); });

        }
        else if (ItemSlot2Selected == false)
        {
            ItemChild = ItemSlot2.transform.GetChild(0).gameObject;
            ItemSlot2Selected = true;
            ItemSlot2Type = type;

            Button b = ItemChild.GetComponent<Button>();
            if (b == null)
                b = ItemChild.AddComponent<Button>();
            b.onClick.RemoveAllListeners();
            b.onClick.AddListener(() => { ItemErase(2, true); });
        }

        if (ItemChild != null)
        {
            Image img = ItemChild.AddComponent<Image>();
            img.sprite = ItemManager.instance.GetItemSprite(type);
            ItemManager.instance.SubItemCount(type);
        }
    }


    public void ItemErase(int slotNumber, bool cancle = false)
    {
        GameObject ItemChild = null;
        Item.ItemType itemtype = ItemSlot1Type;
        if (slotNumber == 1)
        {
            ItemChild = ItemSlot1.transform.GetChild(0).gameObject;
            ItemSlot1Selected = false;
            itemtype = ItemSlot1Type;

        }
        else if (slotNumber == 2)
        {
            ItemChild = ItemSlot2.transform.GetChild(0).gameObject;
            ItemSlot2Selected = false;
            itemtype = ItemSlot2Type;
        }

        if (ItemChild.GetComponent<Image>() != null)
            Destroy(ItemChild.GetComponent<Image>());

        if (cancle)
            ItemManager.instance.AddItemCount(itemtype);

    }

    public void OnMixButtonClick()
    {
        GameObject itemSlot1Object = ItemSlot1.transform.GetChild(0).gameObject;
        GameObject itemSlot2Object = ItemSlot2.transform.GetChild(0).gameObject;
        if (ItemSlot1Selected == true && ItemSlot2Selected == true)
        {
            //나무가 1개는 있어야 한다.

            if ((ItemSlot1Type == Item.ItemType.Wood && ItemSlot2Type == Item.ItemType.Wood) ||
                (ItemSlot1Type != Item.ItemType.Wood && ItemSlot2Type != Item.ItemType.Wood))
            {
                return;
            }

            Item.ItemType remainItemType = ItemSlot2Type;
            if (ItemSlot1Type == Item.ItemType.Wood)
            {
                remainItemType = ItemSlot2Type;
            }
            else if (ItemSlot2Type == Item.ItemType.Wood)
            {
                remainItemType = ItemSlot1Type;
            }

            if (remainItemType == Item.ItemType.Gold)
            {
                InGameManager.instance.GoldAxe.count++;
            }
            else if (remainItemType == Item.ItemType.Silver)
            {
                InGameManager.instance.SilverAxe.count++;
            }
            else if (remainItemType == Item.ItemType.Bronze)
            {
                InGameManager.instance.CooperAxe.count++;
            }

            ItemErase(1);
            ItemErase(2);

            ItemManager.instance.commit();
        }
    }

}
