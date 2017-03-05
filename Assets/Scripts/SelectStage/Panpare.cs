using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Panpare : MonoBehaviour
{
    public Image pang1;
    public Image pang2;
    public Image plannet;
    private float currTime = 0.0f;

    void Start()
    {

        StartCoroutine(Pang());
    }

    // Update is called once per frame
    void Update()
    {
        if (currTime < 2.0f)
        {
            currTime += Time.deltaTime;
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Pang()
    {
        while(true)
        {
            pang1.enabled = !pang1.enabled;
            yield return new WaitForSeconds(0.1f);
            pang2.enabled = !pang2.enabled;
                
        }
    }
}
