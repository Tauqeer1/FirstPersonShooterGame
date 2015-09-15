using UnityEngine;
using System.Collections;


public class MouseLook : MonoBehaviour {

    enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    };
    RotationAxes axes = MouseLook.RotationAxes.MouseXAndY;
    float sensitivity;
    float savedSensitivity = 2.0f;

    float minimumX = -360;
    float maximumX = 360;

    float minimumY;
    float maximumY;

    float normalMinimumY = -90;
    float normalMaximumY = 85;

    float proneMinimumY = -20;
    float proneMaximumY = 40;

    float rotationX = 0;
    float rotationY = 0;

    float offsetX = 0;
    float offsetY = 0;

    float kickTime = 0;

    Camera mineCamera;
    PlayerControllerScript controllerScript;
    Quaternion originalQuaternion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
