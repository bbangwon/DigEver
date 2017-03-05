using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// 
/// </summary>
public class StageInfoPannel : MonoBehaviour
{
    public Text text_gold;
    public Text text_silver;
    public Text text_cooper;
    public Button target;
    public int stage;

    void Awake()
    {
        StageData data = PlayerData.instance.stageData[stage-1];

        if (stage > PlayerData.instance.currLevel)
        {
            text_gold.text = "????";
            text_silver.text = "????";
            text_cooper.text = "????";
            target.enabled = false;
        }
        else if(stage < PlayerData.instance.currLevel)
        {
            text_gold.text = data.goldMaxCount.ToString();
            text_silver.text = data.silverMaxCount.ToString();
            text_cooper.text = data.cooperMaxCount.ToString();
            target.enabled = false;
        }
        else
        {
            if ((float)PlayerData.instance.stageData[stage - 1].goldMaxCount / (float)PlayerData.instance.info.goldCount < 2.0f)
                text_gold.text = PlayerData.instance.info.goldCount.ToString();
            else
                text_gold.text = "????";

            if ((float)PlayerData.instance.stageData[stage - 1].silverMaxCount / (float)PlayerData.instance.info.sillverCount < 2.0f)
                text_silver.text = PlayerData.instance.info.sillverCount.ToString();
            else
                text_silver.text = "????";

            if ((float)PlayerData.instance.stageData[stage - 1].cooperMaxCount / (float)PlayerData.instance.info.copperCount < 2.0f)
                text_cooper.text = PlayerData.instance.info.copperCount.ToString();
            else
                text_cooper.text = "????";
        }
    }
}

