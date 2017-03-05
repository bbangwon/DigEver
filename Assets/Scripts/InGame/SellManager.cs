using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SellManager : MonoBehaviour
{

    public GameObject selItemObj;
    Item.ItemType selItemType;

    public Text txtSelItemCount;
    public int selItemCount = 0;

    public Text txtSelItemGold;
    public int selItemGold = 0;

    public Button plus;
    public Button minus;

    public bool ItemSelected;
    public static SellManager instance;

    void Awake()
    {
        SellManager.instance = this;
    }

    public void rollback()  //탭 이동시 롤백.
    {
        ItemDeselect();
    }


    void Start()
    {
        StartCoroutine("buttonPressCheck");
    }

    IEnumerator buttonPressCheck()
    {
        while (true)
        {
            if (plus.GetComponent<sellManDown>().isPressFlag == true)
            {
                OnPlusButtonClick();
            }
            else if (minus.GetComponent<sellManDown>().isPressFlag == true)
            {
                OnMinusButtonClick();
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void OnPlusButtonClick()
    {
        if (ItemSelected)
        {
            if (ItemManager.instance.GetCount(selItemType) > 0)
            {
                ItemManager.instance.SubItemCount(selItemType);
                selItemCount++;
                selItemGold = selItemCount * ItemManager.instance.GetCost(selItemType);
            }
        }

    }

    public void OnMinusButtonClick()
    {

        if (ItemSelected)
        {
            if (selItemCount > 0)
            {
                ItemManager.instance.AddItemCount(selItemType);
                selItemCount--;
                selItemGold = selItemCount * ItemManager.instance.GetCost(selItemType);
            }
        }
    }

    void ItemDeselect()
    {
        if (selItemObj.GetComponent<Image>() != null)
            Destroy(selItemObj.GetComponent<Image>());

        ItemSelected = false;

        selItemCount = 0;
        selItemGold = 0;
    }


    public void OnSellButtonClick()
    {

        // ItemManager.instance.commit();  //자원판매함.

        //이부분에 골드 합쳐주면 됩니다.
        //=> selItemGold 판매금액

        PlayerData.instance.info.playerGold += selItemGold;

        //판매후 총 금액은 selItemGold
        //판매후
        ItemManager.instance.commit();
        ItemDeselect();


    }
    public void OnCancleButtonClick()
    {
        ItemManager.instance.AddItemCount(selItemType, selItemCount);
        ItemDeselect();

    }


    void Update()
    {
        txtSelItemCount.text = selItemCount.ToString();
        txtSelItemGold.text = selItemGold.ToString() + "G";

    }

    public void SelectItem(Item.ItemType type)
    {
        Sprite spr = ItemManager.instance.GetItemSprite(type);

        if (selItemObj.GetComponent<Image>() == null)
            selItemObj.AddComponent<Image>();

        selItemObj.GetComponent<Image>().sprite = spr;

        selItemType = type;
        ItemSelected = true;

    }

}
