using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWindow : MonoBehaviour
{
    public GameObject[] windowCanvas;

    public void EnableCanvas(int CanvasNumber)
    {
        if (windowCanvas[CanvasNumber].activeInHierarchy == true)
        {
            windowCanvas[CanvasNumber].SetActive(false);
        }
        else
        {
            DisableCanvas();
            windowCanvas[CanvasNumber].SetActive(true);
        }
    }

    void DisableCanvas()
    {
        for (int i = 0; i < windowCanvas.Length; i++)
        {
            if (windowCanvas[i].activeSelf)
            {
                windowCanvas[i].SetActive(false);
            }
        }
    }

    public void HideWindowCanvas()
    {
        for (int i = 0; i < windowCanvas.Length; i++)
        {
            if (i == 0)
            {
                windowCanvas[i].SetActive(true);
            }
            else
            {
                windowCanvas[i].SetActive(false);
                gameObject.SetActive(false);
            } 
        }
    }
}