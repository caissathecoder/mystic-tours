using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Volume Slider")]
    public Slider backgroundSlider;
    public Slider narrationSlider;

    [Header("Mute/Unmute")]
    public GameObject muteBackgroundButton;
    public GameObject unmuteBackgroundButton;
    public GameObject muteNarrationButton;
    public GameObject unmuteNarrationButton;

    [Header("Background Audio")]
    public GameObject backgroundMusic;

    //Default Volume
    private float backgroundAudioVolume = 0.75f;
    private float narrationAudioVolume = 0.75f;

    //Audio Source
    private AudioSource mainMenuBackgroundAudio;
    private AudioSource siningBackgroundAudio;
    private AudioSource katipunanBackgroundAudio;
    public AudioSource[] narrationAudio;

    void Awake()
    {
        //Background Audio

        backgroundMusic = GameObject.FindWithTag("background audio");

        mainMenuBackgroundAudio = backgroundMusic.transform.GetChild(0).GetComponent<AudioSource>();
        mainMenuBackgroundAudio.volume = backgroundAudioVolume;

        siningBackgroundAudio = backgroundMusic.transform.GetChild(1).GetComponent<AudioSource>();
        siningBackgroundAudio.volume = backgroundAudioVolume;

        katipunanBackgroundAudio = backgroundMusic.transform.GetChild(2).GetComponent<AudioSource>();
        katipunanBackgroundAudio.volume = backgroundAudioVolume;

        backgroundAudioVolume = PlayerPrefs.GetFloat("backgroundvolume", 0.75f);
        backgroundSlider.value = backgroundAudioVolume;

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "01-Main Menu" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "01-Museum Selection")
        {
            if (mainMenuBackgroundAudio.isPlaying)
            {
                siningBackgroundAudio.Stop();
                katipunanBackgroundAudio.Stop();
            }
            else
            {
                katipunanBackgroundAudio.Stop();
                siningBackgroundAudio.Stop();
                mainMenuBackgroundAudio.Play();
            }
        }

        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "02-Museo ng Sining Page")
        {
            if (siningBackgroundAudio.isPlaying)
            {
                mainMenuBackgroundAudio.Stop();
                katipunanBackgroundAudio.Stop();
            }
            else
            {
                katipunanBackgroundAudio.Stop();
                siningBackgroundAudio.Play();
                mainMenuBackgroundAudio.Stop();
            }
        }

        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "02-Museo ng Katipunan Page")
        {
            if (katipunanBackgroundAudio.isPlaying)
            {
                mainMenuBackgroundAudio.Stop();
                siningBackgroundAudio.Stop();
            }
            else
            {
                katipunanBackgroundAudio.Play();
                siningBackgroundAudio.Stop();
                mainMenuBackgroundAudio.Stop();
            }
        }

        //Narration Audio
        narrationAudioVolume = PlayerPrefs.GetFloat("narrationvolume", 0.75f);
        for (int i = 0; i < narrationAudio.Length; i++)
        {
            narrationAudio[i].volume = narrationAudioVolume;
            narrationSlider.value = narrationAudioVolume;
        }
 
    }

    void Update()
    {
        //Background Audio
        mainMenuBackgroundAudio.volume = backgroundAudioVolume;
        siningBackgroundAudio.volume = backgroundAudioVolume;
        katipunanBackgroundAudio.volume = backgroundAudioVolume;
        PlayerPrefs.SetFloat("backgroundvolume", backgroundAudioVolume);

        if (backgroundAudioVolume == 0)
        {
            unmuteBackgroundButton.SetActive(true);
            muteBackgroundButton.SetActive(false);
        }
        else
        {
            unmuteBackgroundButton.SetActive(false);
            muteBackgroundButton.SetActive(true);
        }

        //Narration Audio
        for (int i = 0; i < narrationAudio.Length; i++)
        {
            narrationAudio[i].volume = narrationAudioVolume;
        }
        PlayerPrefs.SetFloat("narrationvolume", narrationAudioVolume);

        if (narrationAudioVolume == 0)
        {
            unmuteNarrationButton.SetActive(true);
            muteNarrationButton.SetActive(false);
        }
        else
        {
            unmuteNarrationButton.SetActive(false);
            muteNarrationButton.SetActive(true);
        }

    }

    public void UpdateBackgroundVolume(float backgroundvolume)
    {
        backgroundAudioVolume = backgroundvolume;
    }

    public void UpdateNarrationVolume(float narrationvolume)
    {
        narrationAudioVolume = narrationvolume;
    }

    public void MuteBackgroundAudio()
    {
        PlayerPrefs.DeleteKey("backgroundvolume");
        mainMenuBackgroundAudio.volume = 0;
        siningBackgroundAudio.volume = 0;
        katipunanBackgroundAudio.volume = 0;
        backgroundSlider.value = 0;

        unmuteBackgroundButton.SetActive(true);
        muteBackgroundButton.SetActive(false);
    }

    public void MuteAllNarrationAudio()
    {
        PlayerPrefs.DeleteKey("narrationvolume");
        for (int i = 0; i < narrationAudio.Length; i++)
        {
            narrationAudio[i].volume = 0;
        }
        narrationSlider.value = 0;

        unmuteNarrationButton.SetActive(true);
        muteNarrationButton.SetActive(false);
    }

    public void UnmuteBackgroundAudio()
    {
        mainMenuBackgroundAudio.volume = 0.75f;
        siningBackgroundAudio.volume = 0.75f;
        katipunanBackgroundAudio.volume = 0.75f;
        backgroundSlider.value = 0.75f;

        unmuteBackgroundButton.SetActive(false);
        muteBackgroundButton.SetActive(true);
    }

    public void UnmuteAllNarrationAudio()
    {
        for (int i = 0; i < narrationAudio.Length; i++)
        {
            narrationAudio[i].volume = 0.75f;
        }
        narrationSlider.value = 0.75f;

        unmuteNarrationButton.SetActive(false);
        muteNarrationButton.SetActive(true);
    }

    public void PlayNarrationAudio(int NarrationAudioNumber)
    {
        narrationAudio[NarrationAudioNumber].Play();
    }

    public void PauseNarrationAudio(int NarrationAudioNumber)
    {
        narrationAudio[NarrationAudioNumber].Pause();
    }

    public void StopNarration()
    {
        for (int i = 0; i < narrationAudio.Length; i++)
        {
            narrationAudio[i].Stop();
        }
    }

}
