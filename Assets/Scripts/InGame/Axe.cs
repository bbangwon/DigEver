using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Axe : MonoBehaviour {

    public enum AxeType { Gold, Silver, Cooper };
    public AxeType type;
    public float damageMultiply; //기본 데미지 * ?
    public int count;        //개수
    public float duration;   // 지속시간
    public Image skillGauge;

    private Player player;
    private Text countText;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();

        countText = transform.FindChild("count").gameObject.GetComponent<Text>();
        GetComponent<Button>().onClick.AddListener(() => { use(); });

        skillGauge.gameObject.SetActive(false);
    }

    void Update()
    {
        countText.text = count.ToString();
    }

    public void use()   //아이템 사용시
    {
        if(count > 0 && player.isUsingItem == false)
        {
            player.isUsingItem = true;
            count--;
            StartCoroutine(UseInItem());
        }
    }

    IEnumerator UseInItem()
    {
        float currTime = 0;
        skillGauge.gameObject.SetActive(true);

        while(currTime < duration)
        {
            player._damageMultiply = (int)damageMultiply;
            currTime += Time.deltaTime;
            skillGauge.fillAmount = (duration - currTime) / duration;
            yield return new WaitForEndOfFrame();


        }

        player._damageMultiply = 1;
        player.isUsingItem = false;
        skillGauge.gameObject.SetActive(false);
        yield return null;
    }
}
