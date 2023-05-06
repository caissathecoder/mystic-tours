using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenAnimations : MonoBehaviour
{
    private bool _isAnimationComplete;
    public void OnEnable()
    {
        _isAnimationComplete = false; 

        transform.localScale = new Vector3(0, 0, 0);
        Debug.Log("open description...");
        transform.LeanScale(Vector3.one, 0.5f).setEaseOutExpo().setOnComplete(OnComplete);
    }

    public void FixedUpdate()
    {
        if (!_isAnimationComplete)
        {
            transform.LeanScale(Vector3.one, 0.5f).setEaseOutExpo();
            _isAnimationComplete = true;
            Debug.Log("open description animation complete on fixed update");
        }
    }

    public void OnComplete()
    {
        Debug.Log("open description complete");
    }

    // When the close button is pressed
    public void OnClose()
    {
        transform.LeanScale(Vector3.zero, 0.5f).setEaseInBack();
        Debug.Log("close animation");
    }

    void InactiveMe()
    {
        gameObject.SetActive(false);
    }

}
