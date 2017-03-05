using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockGenerator : MonoBehaviour
{
    public string blockID = "BLOCK";

    private int blockMaxCount = 5;

    private ObjectPool blockPool = null;
    private AudioSource dirtDestory;

    private Transform temp;
    private float imgHeight = 0.92f;
    public int currBlockIndex
    {
        get;
        private set;
    }

    public Block lastBlock
    {
        get;
        private set;
    }
    public Block currBlock
    {
        get;
        private set;
    }

    void Start()
    {
        blockPool = ObjectPoolManager.GetPoolbyID(blockID);
        dirtDestory = GetComponent<AudioSource>();
        // 이게 씬 다붙으면 ㄱ
        // stageMaximumBlock = InGameManager.instance.stageMaximumBlock[PlayerData.instance.currLevel - 1];

        for (int i = 0; i < blockMaxCount + 1; i++)
        {
            temp = blockPool.RequestObject();
            temp.parent = transform;
            if (i == 0)
            {
                temp.GetComponent<Block>().SetCurrBlock(true);
                currBlock = temp.GetComponent<Block>();
            }

            temp.GetComponent<Block>().InitBlock(currBlockIndex, -imgHeight);
            ++currBlockIndex;

        }

    }



    #region 블럭이 터지고 난후 프로세스

    public void AfterBlockProcess()
    {
        dirtDestory.Play();
        --currBlockIndex;


        UpBlocks();

        Invoke("SlowSpawn", 0.1f);
    }

    void SlowSpawn()
    {
        temp = FindUnActive();
        temp.GetComponent<Block>().InitBlock(currBlockIndex, -imgHeight);
        currBlockIndex++;
    }


    void UpBlocks()
    {
        Transform[] aliveBlocks;
        aliveBlocks = GetComponentsInChildren<Transform>(false);
        float maxPosY = 0;

        for (int i = 1; i < aliveBlocks.Length; i++)
        {
            if (aliveBlocks[i].position.y > maxPosY)
                maxPosY = aliveBlocks[i].position.y;
        }

        for (int i = 1; i < aliveBlocks.Length; i++)
        {
            if (maxPosY == aliveBlocks[i].position.y)
            {
                aliveBlocks[i].GetComponent<Block>().SetCurrBlock(true);
                currBlock = aliveBlocks[i].GetComponent<Block>();
            }
            aliveBlocks[i].position = new Vector2(0, aliveBlocks[i].position.y + imgHeight);
        }
    }

    Transform FindUnActive()
    {
        Transform[] tempTS = transform.GetComponentsInChildren<Transform>(true);

        for (int i = 0; i < tempTS.Length; i++)
        {
            if (!tempTS[i].gameObject.activeSelf)
            {
                return tempTS[i];
            }
        }
        Debug.LogError("자식중 활성화된 것이 없습니다");
        return null;
    }

    #endregion


    public void AttackedBlock(int damage)
    {

        if (currBlock.currHP - damage <= 0)
        {
            currBlock.gameObject.SetActive(false);
            return;
        }
        currBlock.currHP -= damage;
    }


}
