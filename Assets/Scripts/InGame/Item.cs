using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    public enum ItemType { Wood, Bronze, Silver, Gold };
    public ItemType type;

    void Start()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(() => { ItemSelect(); });

    }

    protected virtual void ItemSelect()
    {
        switch (TabCtrl.selectedType)
        {
            case TabCtrl.TabType.Mix:
                if (ItemManager.instance.GetCount(type) >= 1)
                    MixManager.instance.ItemSelect(type);
                break;
            case TabCtrl.TabType.Sell:
                if (SellManager.instance.ItemSelected == false)
                    SellManager.instance.SelectItem(type);
                break;
            default:
                break;
        }
    }

}
