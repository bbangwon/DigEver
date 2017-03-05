using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    public Image clearImg;
    int currLevel;

    public Axe GoldAxe;
    public Axe SilverAxe;
    public Axe CooperAxe;
    public AudioSource bgm;
    public Text playerMoney;

    bool isClear = false;
    bool once = true;
    void Awake()
    {
        InGameManager.instance = this;
        currLevel = PlayerData.instance.currLevel;
        bgm.Play();
    }

    void Start()
    {
        ItemManager.instance.GetCount(Item.ItemType.Wood);
    }

    void Update()
    {
        playerMoney.text = PlayerData.instance.info.playerGold.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //뒤로가기 
            SceneManager.LoadScene("SelectStage");
            SaveData();
            return;
        }

        CheckClear();

        if (isClear)
        {
            clearImg.gameObject.SetActive(true);
            ResetItem();
            return;
        }
    }
    // 데이터 저장 
    public void SaveData()
    {
        PlayerData.instance.info.woodCount += ItemManager.instance.GetCount(Item.ItemType.Wood);
        PlayerData.instance.info.copperCount += ItemManager.instance.GetCount(Item.ItemType.Bronze);
        PlayerData.instance.info.sillverCount += ItemManager.instance.GetCount(Item.ItemType.Silver);
        PlayerData.instance.info.goldCount += ItemManager.instance.GetCount(Item.ItemType.Gold);
    }

    void CheckClear()
    {
        int stack = 0;
        if (PlayerData.instance.info.copperCount + ItemManager.instance.GetCount(Item.ItemType.Bronze) > PlayerData.instance.stageData[currLevel - 1].cooperMaxCount)
        {
            ++stack;
        }
        if (PlayerData.instance.info.sillverCount + ItemManager.instance.GetCount(Item.ItemType.Silver) > PlayerData.instance.stageData[currLevel - 1].silverMaxCount)
        {
            ++stack;
        }
        if (PlayerData.instance.info.goldCount + ItemManager.instance.GetCount(Item.ItemType.Gold) > PlayerData.instance.stageData[currLevel - 1].goldMaxCount)
        {
            ++stack;
        }

        if (stack == 3)
            isClear = true;

    }

    void ResetItem()
    {
        if (once)
        {
            PlayerData.instance.info.woodCount = 0;
            PlayerData.instance.info.copperCount = 0;
            PlayerData.instance.info.sillverCount = 0;
            PlayerData.instance.info.goldCount = 0;
            PlayerData.instance.currLevel++;
            once = false;
        }
    }
}
