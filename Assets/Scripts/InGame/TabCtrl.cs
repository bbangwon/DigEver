using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TabCtrl : MonoBehaviour {

    public enum TabType { Mix, Sell, Upgrade};
    public TabType type = TabType.Mix;
    public static TabType selectedType;

    private Sprite noSelTab;
    private Sprite SelTab;

    GameObject[] tabObjects;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { TabChange(); });

        SelTab = Resources.Load<Sprite>("InGame/btn_tab");
        noSelTab = Resources.Load<Sprite>("InGame/btn_tab2");

        tabObjects = GameObject.FindGameObjectsWithTag("TabObject");

    }

    void TabChange()
    {

        selectedType = type;

        foreach(GameObject go in tabObjects)
        {
            go.GetComponent<Image>().sprite = noSelTab;
        }

        GetComponent<Image>().sprite = SelTab;
        
    }


}
