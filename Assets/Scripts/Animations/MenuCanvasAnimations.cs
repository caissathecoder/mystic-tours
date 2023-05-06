using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasAnimations : MonoBehaviour
{
    private bool _isAnimationComplete;
    
    public Transform panel = default;

    // can use leantween sequence for opening
    public void OnEnable()
    {
        _isAnimationComplete = false;

        panel.localPosition = new Vector2(0, -Screen.height);
        Debug.Log("open menu animation...");
        panel.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().setOnComplete(OnComplete);   
    }

    public void FixedUpdate()
    {
        if (!_isAnimationComplete)
        {
            panel.LeanMoveLocalY(0, 0.5f).setEaseOutExpo();
            _isAnimationComplete = true;
            Debug.Log("open menu animation complete on fixedupdate" + panel.localPosition);
        }
    }

    public void OnComplete()
    {
        Debug.Log("open menu animation complete" + panel.localPosition);
    }


    public void OnClose()
    {
        StartCoroutine(CloseMove());
    }

    IEnumerator CloseMove()
    {
        yield return panel.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(InactiveMe);
    }

    public void InactiveMe()
    {
        gameObject.SetActive(false);
    }
}
