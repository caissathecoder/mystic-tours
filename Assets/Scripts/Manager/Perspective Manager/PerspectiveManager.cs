using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveManager : MonoBehaviour
{
    private Camera _mainCamera;

    [SerializeField]
    private float _transformSpeed = 3f;
    [SerializeField]
    private float _desiredDuration = 0.5f;
    private float _elapsedTime;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private int perspectiveIndex;

    [SerializeField]
    private DescriptionManager _descriptionManager = default;
    [SerializeField]
    private GameObject settingsCanvas = default;
    private AnimationCurve _curve;

    public void Start()
    {
        // Saves the main camera from the scene.
        _mainCamera = Camera.main; 

        // Saves camera start position.
        _startPosition = _mainCamera.transform.localPosition;
    }

    public void FixedUpdate()
    {
        _elapsedTime += Time.unscaledDeltaTime;
        float percentDuration = _elapsedTime / _desiredDuration;

        _mainCamera.transform.localPosition = Vector3.Lerp(_mainCamera.transform.localPosition, _endPosition, Time.unscaledDeltaTime * _transformSpeed);
    }

    public void SetPerspective(int perspectiveNumber)
    {
        perspectiveIndex = perspectiveNumber;
        settingsCanvas.SetActive(false);
        Debug.Log("Changed Perspective");

        if (perspectiveNumber == 0)
        {
            _descriptionManager.ShowDescriptionButtons();
            _endPosition = new Vector3(0,0,0);
            Debug.Log("Perspective Changed to Normal");
        }

        if (perspectiveNumber == 1)
        {
            _descriptionManager.HideDescriptionButtons();
            _endPosition = new Vector3(0,0,-20);
            Debug.Log("Perspective Changed to Little Planet");
        }
    }
}
