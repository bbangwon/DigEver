using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour {

    public Image plannet;
    public Sprite[] sprites;
    public float plannetRotateSpeed;
    public bool isRotateRight;
    public AudioSource click;
    public GameObject pangpare;
	void Awake() 
    {
        StartCoroutine(FadeSceneInOut.Instance.FadeIn(0.8f));
        int currLevel = PlayerData.instance.currLevel;

        if (currLevel != PlayerData.instance.prevLevel)
            pangpare.SetActive(true);

        PlayerData.instance.prevLevel = currLevel;

        plannet.sprite = sprites[currLevel-1];
        pangpare.GetComponent<Panpare>().plannet.sprite = sprites[currLevel - 1];
	}
	void Update () 
    {
        if (plannet.rectTransform.rotation.z >= 360)
            plannet.rectTransform.rotation = new Quaternion(0, 0, 0,0);

        plannet.rectTransform.Rotate(0,0, (isRotateRight ? -1 : 1) *  Time.deltaTime  *plannetRotateSpeed);
	}


    public void OnStageButtonDown(int stage)
    {
        click.Play();
        PlayerData.instance.currLevel = stage;
        StartCoroutine(FadeSceneInOut.Instance.FadeOut(0.8f));
        Invoke("ChangeScene",0.8f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("InGame");
    }


}
