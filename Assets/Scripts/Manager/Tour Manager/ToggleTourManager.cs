using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleTourManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject tourManager = GameObject.FindGameObjectWithTag("tour manager");
        tourManager.GetComponent<TourManager>().enabled = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject tourManager = GameObject.FindGameObjectWithTag("tour manager");
        tourManager.GetComponent<TourManager>().enabled = true;
    }
}
