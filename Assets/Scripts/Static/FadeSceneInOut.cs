using UnityEngine;
using System.Collections;

/// <summary>
///  이건 어디서나 쓸 수 있게 Singleton 으로 두고 씬전환할떄 써먹자
///  FadeIn : 검정화면 -> 게임화면
///  FadeOut : 게임화면 -> 검정화면
///  사용방법 : 아래 소스를 붙여넣기하면 된다.
///  StartCoroutine(FadeSceneInOut.Instance.FadeIn(1.0f));
/// </summary>
public class FadeSceneInOut : MonoBehaviour
{

    SpriteRenderer sprRenderer;
    Sprite black;
    private float fadeAlpha;

    #region Singleton
    static FadeSceneInOut _Instance;
    public static FadeSceneInOut Instance
    {
        get
        {
            if (_Instance == null)
            {
                GameObject newGameObj = new GameObject("FadeInOut");
                _Instance = newGameObj.AddComponent<FadeSceneInOut>();
                newGameObj.AddComponent<RectTransform>();
                newGameObj.AddComponent<SpriteRenderer>();
                newGameObj.GetComponent<RectTransform>().localScale = new Vector3(100, 100, 100);
                newGameObj.GetComponent<SpriteRenderer>().enabled = true;
                newGameObj.GetComponent<SpriteRenderer>().sortingLayerName = "Black";
            }
            return _Instance;
        }
    }

    #endregion

    void Awake()
    {
        black = Resources.Load<Sprite>("black");
    }

    public IEnumerator FadeOut(float time)
    {
        fadeAlpha = 0;
        sprRenderer = this.GetComponent<SpriteRenderer>();
        sprRenderer.sortingLayerName = "GameUI";
        sprRenderer.sortingOrder = 1;
        sprRenderer.sprite = black;

        while (fadeAlpha != 1)
        {
            // 이함수가 실행되면 fadeAlpha가 1로 time초동안 변경한다.
            fadeAlpha = Mathf.MoveTowards(fadeAlpha, 1, Time.unscaledDeltaTime * (1 / time));
            sprRenderer.color = new Color(0, 0, 0, fadeAlpha);
            yield return null;
        }

        Destroy(this);
    }

    public IEnumerator FadeIn(float time)
    {
        fadeAlpha = 1;
        sprRenderer = this.GetComponent<SpriteRenderer>();
        sprRenderer.sortingLayerName = "GameUI";
        sprRenderer.sortingOrder = 1;
        sprRenderer.sprite = black;

        while (fadeAlpha != 0)
        {
            // 이함수가 실행되면 fadeAlpha가 0로 time초동안 변경한다.
            fadeAlpha = Mathf.MoveTowards(fadeAlpha, 0, Time.unscaledDeltaTime * (1 / time));
            sprRenderer.color = new Color(0, 0, 0, fadeAlpha);
            yield return null;
        }
        Destroy(this);
    }
}
