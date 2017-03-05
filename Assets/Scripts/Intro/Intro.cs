using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour 
{
    bool notTowTouch = false;
    public Transform moon;
    public float moonRotateSpeed;
    public bool isRotateRight;
    void Update()
    {
        if (moon.rotation.z >= 360)
            moon.rotation = new Quaternion(0, 0, 0, 0);

        moon.Rotate(0, 0, (isRotateRight ? -1 : 1) * Time.deltaTime * moonRotateSpeed);
        if (Input.GetMouseButtonDown(0))
        {
            if (!notTowTouch)
            {
                StartCoroutine(FadeSceneInOut.Instance.FadeOut(0.8f));
                Invoke("ChangeScene", 0.8f);
            }
            notTowTouch = true;
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("SelectStage");
    }
}

