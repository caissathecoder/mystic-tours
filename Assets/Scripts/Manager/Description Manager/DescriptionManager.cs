using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{
    //Default
    private int _showDescription = 1;
    public GameObject descriptionButtonGroup;
    public GameObject enableButton;
    public GameObject disableButton;

    void Start()
    {

        _showDescription = PlayerPrefs.GetInt("Show", 1);

        if (_showDescription == 1)
        {
            SetObjects(true);
        }
        else
        {
            SetObjects(false);
        }
    }

    // ShowDescriptionButton() and HideDescriptionButton methods are called when an event is triggered
    // playerpref must stay for change scene setup/settings

    public void ShowDescriptionButtons()
    {
        _showDescription = 1;
        SetObjects(true);
        PlayerPrefs.SetInt("Show", _showDescription);
        Debug.Log("description button on");
    }


    public void HideDescriptionButtons()
    {
        _showDescription = 0;
        SetObjects(false);

        PlayerPrefs.SetInt("Show", _showDescription);
        Debug.Log("description button off");
    }

    // this handles what gameObjects must set active/inactive
    public void SetObjects(bool descriptionActive)
    {
        descriptionButtonGroup.SetActive(descriptionActive);
        enableButton.SetActive(descriptionActive);
        disableButton.SetActive(!descriptionActive);
    }
}