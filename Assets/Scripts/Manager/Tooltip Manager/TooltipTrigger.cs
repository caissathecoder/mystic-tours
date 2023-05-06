using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private static LTDescr delay;
    public string header;
    public float objectScale;

    public bool controlPanelAnimation = true;
    public bool descriptionAnimation = false;

    void Start()
    {
        if (descriptionAnimation)
        {
            LeanTween.scale(gameObject, Vector3.one * 1.15f, 0.2f).setLoopType(LeanTweenType.pingPong);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        delay = LeanTween.delayedCall(0.1f, () =>
        {
            TooltipManager.Show(header);
        });

        if (controlPanelAnimation)
        {
            transform.localScale = Vector3.one;
            LeanTween.scale(gameObject, Vector3.one * 1.25f, 0.2f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.cancel(delay.uniqueId);
        TooltipManager.Hide();

        LeanTween.scale(gameObject, Vector3.one, 0.2f);
    }
}
