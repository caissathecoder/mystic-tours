using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class LoadingScreenManager : MonoBehaviour
{
    [Header("Loading References")]
    [SerializeField] private GameObject loadingCanvas;
    [SerializeField] private Image loadingBar;
    [SerializeField] private Text loadingValue;

    private string museumID;

    public void Awake()
    {
        loadingCanvas.SetActive(false);
    }

    public void LoadLevel(string galleryName)
    {
        loadingCanvas.SetActive(true);
        StartCoroutine(LoadLevelAsync(galleryName));

        if (galleryName == "00-Katipunan-O-A")
        {
            museumID = "Museo ng Katipunan";
        }
        else if (galleryName == "00-Sining-O-A" || galleryName == "02-Sining-L-54")
        {
            museumID = "GSIS Museo ng Sining";
        }

        AnalyticsResult analyticsResult = Analytics.CustomEvent(
            "Museum",
            new Dictionary<string, object>
            {
                { "museum_id", museumID },
            });
        Debug.Log("analyticsResult_MuseumVisited: " + analyticsResult);
    }

    private IEnumerator LoadLevelAsync(string levelName)
    {
        yield return new WaitForSeconds(1f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);

            loadingBar.fillAmount = progress;
            loadingValue.text = (progress * 100f).ToString("F0") + "%";

            yield return null;
        }
    }
}
