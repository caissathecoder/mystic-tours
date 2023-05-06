using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanelAnimations : MonoBehaviour
{
    public void OnEnable()
    {  
        transform.localScale = new Vector3(0, 0, 0);
        transform.LeanScale(Vector3.one, 0.2f).setEaseOutExpo();  
    }

    public void OnClose()
    {
        transform.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
    }
}