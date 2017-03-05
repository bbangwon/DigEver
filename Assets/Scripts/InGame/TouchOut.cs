using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TouchOut : MonoBehaviour
{
    private bool notTouchAgain = false;
    private float waitTime = 2f; 
    private float currTime = 0.0f;
    void Update()
    {
        if(currTime < waitTime)
        {
            currTime += Time.deltaTime;
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (notTouchAgain == false)
                StartCoroutine(SceneChange());

            notTouchAgain = true;

        }
    }

    IEnumerator SceneChange()
    {
        StartCoroutine(FadeSceneInOut.Instance.FadeOut(1f));
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(2f));
        SceneManager.LoadSceneAsync("SelectStage");
    }
}
