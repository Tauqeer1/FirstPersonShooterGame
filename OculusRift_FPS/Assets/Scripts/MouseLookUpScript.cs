using UnityEngine;
using System.Collections;

public class MouseLookUpScript : MonoBehaviour {

    public float lookSensitivity = 5.0f;
    public float yRotation;
    public float xRotation;
    public float currentXRotation;
    public float currentYRotation;
    public float yRotationVelocity;
    public float xRotationVelocity;
    public float smoothTime = 0.1f;
    public float yMinimumAngle = -60f;
    public float yMaximumAngle = 70f;
    


	// Use this for initialization
	void Start () {
       

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        ////increase in y is the x rotation
        //xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        ////increase in x is the y rotation
        //yRotation += Input.GetAxis("Mouse X") * lookSensitivity;

        //xRotation = Mathf.Clamp(xRotation, yMinimumAngle, yMaximumAngle);
        

        ////Smooth move in x rotation
        //currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationVelocity, smoothTime);
        
        ////Smooth move in y rotation
        //currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationVelocity, smoothTime);

      

        ////Transform the rotation of the camera
        ////transform.rotation = Quaternion.Euler(new Vector3(xRotation, yRotation, 0));
        //transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * lookSensitivity, Input.GetAxis("Mouse X") * lookSensitivity, 0));
	}
}
