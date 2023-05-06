using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDescription : MonoBehaviour
{
    [SerializeField]
    private DescriptionManager _descriptionManager = default;

    public void EnableButton()
    {
        _descriptionManager.ShowDescriptionButtons();
    }

    public void DisableButton()
    {
        _descriptionManager.HideDescriptionButtons();
    }
}
