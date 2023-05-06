using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowButtonManager : MonoBehaviour
{
    [Header("Button Sprites")]
    public Sprite play;
    public Sprite replay;

    [Header("Narration Settings")]
    public bool hasFilipinoNarration;
    public int filipinoNarration;
    public bool hasEnglishNarration;
    public int englishNarration;

    GameObject descriptionWindow;
    GameObject narrationButtons;
    GameObject audioManager;
    GameObject playButton;

    public void Update()
    {
        descriptionWindow = GameObject.FindGameObjectWithTag("description window");
        narrationButtons = GameObject.FindGameObjectWithTag("narration buttons");
        audioManager = GameObject.FindGameObjectWithTag("audio manager");
        playButton = GameObject.FindGameObjectWithTag("play button");
    }

    public void PlayFilipinoNarration()
    {
        if (hasFilipinoNarration == true)
        {
            audioManager.GetComponent<AudioManager>().PlayNarrationAudio(filipinoNarration);
            EnableReplayButton();
            Debug.Log("play/replay narration");
        }
        else
        {
            DisableNarrationButtons();
        }
    }

    public void PlayEnglishNarration()
    {
        if (hasEnglishNarration == true)
        {
            audioManager.GetComponent<AudioManager>().PlayNarrationAudio(englishNarration);
            EnableReplayButton();
            Debug.Log("play/replay narration");
        }
        else
        {
            DisableNarrationButtons();
        }
    }

    public void PauseFilipinoNarration()
    {
        if (hasFilipinoNarration == true)
        {
            audioManager.GetComponent<AudioManager>().PauseNarrationAudio(filipinoNarration);
            DisableReplayButton();
            Debug.Log("pause narration");
        }
        else
        {
            DisableNarrationButtons();
        }
    }

    public void PauseEnglishNarration()
    {
        if (hasEnglishNarration == true)
        {
            audioManager.GetComponent<AudioManager>().PauseNarrationAudio(englishNarration);
            DisableReplayButton();
            Debug.Log("pause narration");
        }
        else
        {
            DisableNarrationButtons();
        }
    }

    public void Close()
    {
        StartCoroutine(StartCloseWindow());
    }

    public IEnumerator StartCloseWindow()
    {
        for (int i = 0; i < descriptionWindow.transform.childCount; i++)
        {
            if (descriptionWindow.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                descriptionWindow.transform.GetChild(i).GetComponentInChildren<LeanTweenAnimations>().OnClose();
                yield return new WaitForSeconds(0.5f);
                descriptionWindow.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        Reset();
    }

    public void Reset()
    {
        audioManager.GetComponent<AudioManager>().StopNarration();
        DisableReplayButton();
        Debug.Log("stop narration");
    }

    //Hide play, show replay and pause
    public void EnableReplayButton()
    {
        playButton.GetComponent<Image>().sprite = replay;
        narrationButtons.transform.GetChild(1).gameObject.SetActive(true);
    }

    //Show play, hide replay and pause
    public void DisableReplayButton()
    {
        playButton.GetComponent<Image>().sprite = play;
        narrationButtons.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void DisableNarrationButtons()
    {
        for (int i = 0; i < narrationButtons.transform.childCount; i++)
        {
            narrationButtons.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}