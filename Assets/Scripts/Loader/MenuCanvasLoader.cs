using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvasLoader : MonoBehaviour
{
    public GameObject[] controlPanelCanvas;

    public void EnableCanvas(int buttonNumber)
    {
        controlPanelCanvas[buttonNumber].SetActive(true);
    }

    public void DisableCanvas()
    {
        for (int i = 0; i < controlPanelCanvas.Length; i++)
        {
            if (controlPanelCanvas[i].activeSelf)
            {
                controlPanelCanvas[i].SetActive(false);
            }
        }
    }

}
