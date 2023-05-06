using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GalleryLoader : MonoBehaviour
{
    [Header("Loading References")]
    public string sceneID;
    private string sceneGroup;

    GameObject galleryLoader;

    public void LoadScene(string galleryName)
    {
        sceneID = galleryName;
        LoadLevel();
    }

    public void LoadLevel()
    {
        galleryLoader = GameObject.FindGameObjectWithTag("gallery loader");
        galleryLoader.transform.GetChild(0).gameObject.SetActive(true);

        StartCoroutine(LoadLevelAsync());

        //Unity Analytics
        if (sceneID == "00-Katipunan-O-A"
            || sceneID == "02-Katipunan-PS-B")
        {
            sceneGroup = "Scenes_KatipunanMuseum_A";
        }
        else if (sceneID == "01-Katipunan-I-B"
            || sceneID == "01-Katipunan-I-D"
            || sceneID == "01-Katipunan-I-E"
            || sceneID == "01-Katipunan-I-F"
            || sceneID == "01-Katipunan-I-G"
            || sceneID == "01-Katipunan-I-I")
        {
            sceneGroup = "Scenes_KatipunanMuseum_B";
        }
        else if (sceneID == "01-Katipunan-I-L"
            || sceneID == "01-Katipunan-I-N"
            || sceneID == "01-Katipunan-I-Q"
            || sceneID == "01-Katipunan-I-R"
            || sceneID == "01-Katipunan-I-S"
            || sceneID == "01-Katipunan-I-T")
        {
            sceneGroup = "Scenes_KatipunanMuseum_C";
        }
        else if (sceneID == "01-Sining-U-01"
            || sceneID == "01-Sining-U-07"
            || sceneID == "01-Sining-U-16"
            || sceneID == "01-Sining-U-43"
            || sceneID == "01-Sining-U-52"
            || sceneID == "02-Sining-L-54"
            || sceneID == "02-Sining-L-78"
            || sceneID == "02-Sining-L-81"
            || sceneID == "02-Sining-L-84"
            || sceneID == "02-Sining-L-88")
        {
            sceneGroup = "Scenes_GSISMuseum";
        }

        if (sceneGroup == "Scenes_KatipunanMuseum_A"
            || sceneGroup == "Scenes_KatipunanMuseum_B"
            || sceneGroup == "Scenes_KatipunanMuseum_C"
            || sceneGroup == "Scenes_GSISMuseum")
        {
            AnalyticsResult analyticsResult = Analytics.CustomEvent(
            sceneGroup,
            new Dictionary<string, object>
            {
                { "scene_id", sceneID },
            });
            Debug.Log("analyticsResult_SceneVisited: " + analyticsResult);
        }

    }

    private IEnumerator LoadLevelAsync()
    {
        yield return new WaitForSeconds(1f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
    }
}
