using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Block : MonoBehaviour
{
    public Sprite[] blocks;


    // 각각의 블럭 HP
    public int dirtMaxHP;
    public int cooperMaxHP;
    public int silverMaxHP;
    public int goldMaxHP;

    public int randMax = 3;
    // 현재 블럭의 HP
    public int currHP;
    private int currMaxHP;

    private bool isCurrBlock;
    private Item.ItemType kind;

    private Text blockHP;
    private BlockGenerator gene;
    private Charater character;

    int rand;
    bool isFirst = true;

    void Awake()
    {
        gene = GameObject.FindObjectOfType<BlockGenerator>();
        blockHP = GameObject.Find("BlockHP").GetComponent<Text>();

    }


    public void InitBlock(float currBlockIndex, float imgHeight)
    {
        transform.localPosition = new Vector2(0, currBlockIndex * imgHeight);
        rand = Random.Range(0, blocks.Length);
        GetComponent<SpriteRenderer>().sprite = blocks[rand];

        kind = (Item.ItemType)rand;

        switch (kind)
        {
            case Item.ItemType.Wood:
                currMaxHP = dirtMaxHP + PlayerData.instance.stagePlusHP[PlayerData.instance.currLevel-1].woodMaxCount;
                break;
            case Item.ItemType.Bronze:
                currMaxHP = cooperMaxHP + PlayerData.instance.stagePlusHP[PlayerData.instance.currLevel - 1].cooperMaxCount;
                break;
            case Item.ItemType.Silver:
                currMaxHP = silverMaxHP + PlayerData.instance.stagePlusHP[PlayerData.instance.currLevel - 1].silverMaxCount;
                break;
            case Item.ItemType.Gold:
                currMaxHP = goldMaxHP + PlayerData.instance.stagePlusHP[PlayerData.instance.currLevel - 1].goldMaxCount;
                break;
        }
        currHP = currMaxHP;

        gameObject.SetActive(true);
        isFirst = false;
    }


    void Update()
    {
        if (isCurrBlock)
            blockHP.text = string.Format("{0} / {1}", currHP, currMaxHP);
    }


    // 사라질때 
    void OnDisable()
    {
        if (!isFirst)
        {
            isCurrBlock = false;

            if (gene.currBlockIndex == 1)
            {
                if (blockHP != null)
                    blockHP.gameObject.SetActive(false);
            }
            ItemManager.instance.AddItemCount(kind, Random.Range(1, 10));
            ItemManager.instance.commit();
            gene.AfterBlockProcess();


        }
    }


    void RotateLookAt()
    {
        // Quaternion rotation = Quaternion.LookRotation(
        // target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        //
        // transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
    public void SetCurrBlock(bool set)
    {
        isCurrBlock = true;
    }



}
