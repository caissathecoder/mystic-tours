using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionVrCanvas : MonoBehaviour
{
    // 3D Canvas Transform Settings
    [SerializeField]
    Vector3 descriptionPosition = new Vector3(0,0,0);
    [SerializeField]
    Vector3 descriptionRotation = new Vector3(0,0,0);
    [SerializeField]
    Vector3 descriptionScale = new Vector3(0,0,0);

    private Canvas _descriptionCanvas = default;
    private Transform _descriptionTransform = default;
    private Image _image;
    private GameObject _vrController;
    private VRMode _vrMode;
    private bool _isVrCanvasEnabled;


    
    public void Awake()
    {
        // this references
        _descriptionCanvas = GetComponent<Canvas>();
        _descriptionTransform = GetComponent<Transform>();
        _image = GetComponent<Image>();

        // vrController reference
        _vrController = GameObject.FindGameObjectWithTag("vr controller");
        _vrMode = _vrController.GetComponent<VRMode>();
    }

    public void Start()
    {
        if (_descriptionCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            _isVrCanvasEnabled = false;
            Debug.Log("render mode changed to " + _descriptionCanvas.renderMode);
        }
        else if (_descriptionCanvas.renderMode == RenderMode.WorldSpace)
        {
            _isVrCanvasEnabled = true;
            Debug.Log("render mode changed to " + _descriptionCanvas.renderMode);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RenderModeWorld();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            RenderModeOverlay();
        }

        if (_vrMode.isVrModeEnabled && !_isVrCanvasEnabled)
        {
            RenderModeWorld();
        }
        else if (!_vrMode.isVrModeEnabled && _isVrCanvasEnabled)
        {
            RenderModeOverlay();
        }
    }

    public void RenderModeOverlay()
    {
        _descriptionCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        _descriptionTransform.localScale = new Vector3(1,1,1);
        _image.enabled = true;
        _isVrCanvasEnabled = false;
    }

    public void RenderModeWorld()
    {
        _descriptionCanvas.renderMode = RenderMode.WorldSpace;
        _descriptionTransform.localPosition = descriptionPosition;
        _descriptionTransform.localEulerAngles = descriptionRotation;
        _descriptionTransform.localScale = descriptionScale;
        _image.enabled = false;
        _isVrCanvasEnabled = true;
    }
}
