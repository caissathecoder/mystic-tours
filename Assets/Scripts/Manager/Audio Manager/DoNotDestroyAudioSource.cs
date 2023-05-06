using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyAudioSource : MonoBehaviour
{
    void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("BackgroundAudio");

        
        if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
    }
}
