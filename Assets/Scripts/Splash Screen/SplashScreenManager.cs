using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    [Header("Splash Reference")]
    public GameObject splashMessage_1;
    public GameObject splashMessage_2;

    [Header("Next Scene to Load")]
    public string sceneName;

    public void Awake()
    {
        StartCoroutine(WaitScene());
    }

    IEnumerator WaitScene()
    {
        splashMessage_1.SetActive(true);

        yield return new WaitForSeconds(3.5f);

        FadeManager.Instance.FadeOut(1, Color.black);

        yield return new WaitForSeconds(1.5f);

        FadeManager.Instance.FadeIn(1, Color.black);

        splashMessage_2.SetActive(true);

        yield return new WaitForSeconds(3.5f);

        FadeManager.Instance.FadeOut(1, Color.black, ToScene);
    }


    private void ToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
