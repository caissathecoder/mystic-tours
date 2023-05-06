using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene to Load")]
    public string sceneName;
    public bool fadeToBlack = true;

    public void LoadGallery(string SceneGallery)
    {
        sceneName = SceneGallery;
        LoadScene();
    }

    public void LoadScene()
    {
        if (fadeToBlack)
        {
            FadeManager.Instance.FadeOut(0.25f, Color.black, ToScene);
        }
        else
        {
            FadeManager.Instance.FadeOut(0.25f, Color.white, ToScene);
        }
    }

    public void ToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

