using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageData
{
    public int woodMaxCount;
    public int cooperMaxCount;
    public int silverMaxCount;
    public int goldMaxCount;
}

public class PlayerInfo
{
    public int woodCount;
    public int copperCount;
    public int sillverCount;
    public int goldCount;
    public int mineCurrDmg;
    public int mineCurrCost;
    public int playerGold;
}
public class PlayerData : MonoBehaviour
{
    #region Singleton
    static PlayerData _instance;
    public static PlayerData instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject newGameObj = new GameObject("Player Data");
                _instance = newGameObj.AddComponent<PlayerData>();
            }
            return _instance;
        }
    }
    #endregion  

    public List<StageData>stageData = new List<StageData>();
    public List<StageData> stagePlusHP = new List<StageData>();

    public PlayerInfo info = new PlayerInfo();

    public int currLevel = 1; // 현재 하고있는 레벨 ( 임시로 1로 해놈 ) 
    public int prevLevel = 1;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        currLevel = 1;

        stageData.AddRange(new StageData[]{
            new StageData(){cooperMaxCount = 20, silverMaxCount=20, goldMaxCount = 10},
            new StageData(){cooperMaxCount = 500, silverMaxCount= 200, goldMaxCount = 400},
            new StageData(){cooperMaxCount = 2000, silverMaxCount=1000, goldMaxCount = 900}
        });

        stagePlusHP.AddRange(new StageData[]{
            new StageData(){cooperMaxCount = 0, silverMaxCount=0, goldMaxCount = 0},
            new StageData(){cooperMaxCount = 20, silverMaxCount=20, goldMaxCount = 20},
            new StageData(){cooperMaxCount = 40, silverMaxCount=40, goldMaxCount = 40}
        });


        info.mineCurrCost      = 1000;  // 1000씩 증가
        info.mineCurrDmg       = 1;  // 1씩증가
        info.playerGold        = 0;

        info.copperCount       = 1;
        info.sillverCount      = 1;
        info.goldCount         = 1;
    }


    
}
