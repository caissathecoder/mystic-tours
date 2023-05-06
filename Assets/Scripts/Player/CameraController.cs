using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    public TourManager tourManager;

    //Mouse Panning
    float sensitivity = 1.25f;
    float minRotation = -90f;
    float maxRotation = 90f;
    float rotationY = 0f;
    float rotationX;

    //Mouse Zooming
    float zoomSpeed = 5f;
    float minZoom = 50f;
    float maxZoom = 120f;

    //Touch Zooming
    float touchZoomSpeed = 3f;


    [SerializeField]
    private float minimumDistance = 0.2f;
    [SerializeField]
    //private float maximumTime = 1f;

    //Touch Panning
    private Touch firstTouch0 = new Touch();
    private Touch secondTouch0 = new Touch();
    private Touch firstTouch1 = new Touch();
    private Touch secondTouch1 = new Touch();
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;


    //Touch Zooming
    float minPinchSpeed = 5f;
    float touchDelta = 0f;
    float previousDistance = 0f;
    float currentDistance = 0f;
    Vector2 primaryDelta = new Vector2(0, 0);
    Vector2 secondaryDelta = new Vector2(0, 0);
    float oppositeDirection = 0f;
    float speedTouch0 = 0f;
    float speedTouch1 = 0f;
    Vector3 originalRotation = new Vector3(0, 0, 0);

    void Start()
    {
#if UNITY_ANDROID
        // initialize Quaternion Euler Angles
        yAngle = PlayerPrefs.GetFloat("yTouchRotation", -90f);
        player.transform.localEulerAngles = new Vector3(xAngle, yAngle, 0);
        originalRotation = player.transform.localEulerAngles;
        xAngle = originalRotation.x;
        yAngle = originalRotation.y;
#else
        rotationX = PlayerPrefs.GetFloat("xRotation", -90f);
        player.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
#endif
    }

    void Update()
    {
        if (tourManager.isCameraMove)
        {
            #if UNITY_ANDROID
                TouchSettings();
            #else
                MouseSettings();
            #endif
        }
    }

    void MouseSettings()
    {
        //Rotate
        if (Input.GetMouseButton(0))
        {
            rotationX = player.transform.localEulerAngles.y - Input.GetAxis("Mouse X") * sensitivity;

            rotationY += -Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, minRotation, maxRotation);

            player.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            PlayerPrefs.SetFloat("xRotation", rotationX);   
        }

        //Zoom
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            mainCamera.fieldOfView += zoomSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            mainCamera.fieldOfView -= zoomSpeed;
        }
        else if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
                mainCamera.fieldOfView += zoomSpeed;
            }
            else if (Input.GetAxis("Mouse Y") > 0)
            {
                mainCamera.fieldOfView -= zoomSpeed;
            }
        }

        mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, minZoom, maxZoom);
    }

    void TouchSettings()
    {
        //Rotate
        if (Input.touchCount == 1)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstTouch0 = Input.GetTouch(0);
                xAngleTemp = xAngle;
                yAngleTemp = yAngle;
            }

            else if (Input.GetTouch(0).phase == TouchPhase.Moved &&
                Vector3.Distance(firstTouch0.position, Input.GetTouch(0).position) >= minimumDistance)
            {
                secondTouch0 = Input.GetTouch(0);
                xAngle = xAngleTemp + (secondTouch0.position.y - firstTouch0.position.y) * 90 / Screen.height;
                xAngle = Mathf.Clamp(xAngle, -90, 90);
                yAngle = yAngleTemp + (-secondTouch0.position.x + firstTouch0.position.x) * 180 / Screen.width;
                player.transform.rotation = Quaternion.Euler(xAngle, yAngle, 0.0f);
            }

            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                firstTouch0 = new Touch();
                secondTouch0 = new Touch();
                PlayerPrefs.SetFloat("yTouchRotation", yAngle);
            }


        }

        //Zoom
        else if (Input.touchCount == 2)
        {
            if (Input.GetTouch(1).phase == TouchPhase.Began)
            {
                firstTouch0 = Input.GetTouch(0);
                firstTouch1 = Input.GetTouch(1);
            }
            else if ((Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved) &&
                (Vector2.Distance(firstTouch0.position, Input.GetTouch(0).position) >= minimumDistance ||
                Vector2.Distance(firstTouch1.position, Input.GetTouch(1).position) >= minimumDistance))
            {
                secondTouch0 = Input.GetTouch(0);
                secondTouch1 = Input.GetTouch(1);
                speedTouch0 = Input.GetTouch(0).deltaPosition.magnitude / Input.GetTouch(0).deltaTime;
                speedTouch1 = Input.GetTouch(1).deltaPosition.magnitude / Input.GetTouch(1).deltaTime;

                currentDistance = Vector2.Distance(secondTouch0.position, secondTouch1.position);
                previousDistance = Vector2.Distance(firstTouch0.position, firstTouch1.position);
                primaryDelta = secondTouch0.position - firstTouch0.position;
                secondaryDelta = secondTouch1.position - firstTouch1.position;

                //To check if the direction is opposite
                oppositeDirection = Vector2.Dot(primaryDelta, secondaryDelta);

                touchDelta = currentDistance / previousDistance;


                if ((touchDelta < 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
                {
                    mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView + ((2 - touchDelta) * touchZoomSpeed), minZoom, maxZoom);
                }

                //zoom in
                if ((touchDelta > 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
                {
                    mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView - (touchDelta * touchZoomSpeed), minZoom, maxZoom);
                }
            }


            else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Ended)
            {
                firstTouch0 = new Touch();
                secondTouch0 = new Touch();
                firstTouch1 = new Touch();
                secondTouch1 = new Touch();
            }

        }

    }

    public void ResetCamera(float setRotationTo)
    {
        PlayerPrefs.SetFloat("yTouchRotation", setRotationTo);
        PlayerPrefs.SetFloat("xRotation", setRotationTo);
    }

}
