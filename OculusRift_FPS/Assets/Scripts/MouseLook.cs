using UnityEngine;
using System.Collections;

public class MouseLookUp : MonoBehaviour {

    
    public float lookSensitivity = 5.0f;
    [HideInInspector]
    public float yRotation;
    [HideInInspector]
    public float xRotation;
    [HideInInspector]
    public float currentYRotation;
    [HideInInspector]
    public float currentXRotation;
    [HideInInspector]
    public float yRotationVelocity;
    [HideInInspector]
    public float xRotationVelocity;
    public float lookSmoothDamp = 0.1f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Rotation in yAxis is the increment or decrement in xAxis
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;

        //Rotation in xAxis is the increment or decrement in yAxis
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;


        //Limit the xRotation 
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //Mathf.SmoothDamp smoothing in the x Rotation
        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationVelocity, lookSmoothDamp);

        //Mathf.SmoothDamp smoothing in the y Rotation
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationVelocity, lookSmoothDamp);

        //Quaternion.Euler returns the rotation in this order (z,x,y) axes
        transform.rotation = Quaternion.Euler(new Vector3(currentXRotation, currentYRotation, 0));
	}
}
