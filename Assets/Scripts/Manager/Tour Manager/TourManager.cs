using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TourManager : MonoBehaviour
{
    // should the camera move
    public bool isCameraMove;

    GameObject menuCanvas;
    GameObject mapCanvas;
    GameObject descriptionWindow;
    GameObject buttonGroup;
    GameObject tooltipCanvas;

    void Awake()
    {
        MoveCamera();
    }
    void Start()
    {
        //Windows
        menuCanvas = GameObject.FindGameObjectWithTag("menu canvas");
        mapCanvas = GameObject.FindGameObjectWithTag("map canvas");
        descriptionWindow = GameObject.FindGameObjectWithTag("description window");

        //Game objects to enable or disable
        buttonGroup = GameObject.FindGameObjectWithTag("button group");
        tooltipCanvas = GameObject.FindGameObjectWithTag("tooltip canvas");
    }

    void Update()
    {
        ControlManager();
    }

    public void ControlManager()
    {
        // counts active children in hierarchy
        int descriptionCanvasChildCount = 0;
        foreach (Transform child in descriptionWindow.transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                descriptionCanvasChildCount++;
            }
        }

        // Checks if any menu canvas is open
        // is setting canvas or tips canvas open?
        if (descriptionCanvasChildCount > 0 || menuCanvas.transform.GetChild(1).gameObject.activeInHierarchy || menuCanvas.transform.GetChild(2).gameObject.activeInHierarchy)
        {
            DisableButtonGroup();
            tooltipCanvas.transform.GetChild(0).gameObject.SetActive(false);
        }
        // katipunan map canvas or sining map canvas open?
        else if (mapCanvas.transform.GetChild(0).gameObject.activeInHierarchy || mapCanvas.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            DisableButtonGroup();
        }
        else
        {
            if (!buttonGroup.activeInHierarchy)
            {
                EnableButttonGroup();
            }
        }
    }

    public void EnableButttonGroup()
    {
        buttonGroup.SetActive(true);
        MoveCamera();
    }

    public void DisableButtonGroup()
    {
        buttonGroup.SetActive(false);
        DontMoveCamera();
    }

    public void MoveCamera()
    {
        isCameraMove = true;
    }

    public void DontMoveCamera()
    {
        isCameraMove = false;
    }
}
